using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftOS.Metadata;
using ShiftOS.Windowing;
using System.Windows.Forms;
using System.IO;

namespace ShiftOS.Programs
{
    [Program("fileskimmer", "File Skimmer", "Browse files on your computer.")]
    [Requires("fileskimmer")]
    [AppLauncherRequirement("alfileskimmer")]
    public partial class FileSkimmer : Window
    {
        private string _working = "/";

        public FileSkimmer()
        {
            InitializeComponent();
        }

        public FileSkimmerMode Mode { get; set; } = FileSkimmerMode.Skim;
        public Func<string, bool> FileOpenCallback { get; set; }
        
        public void SetFilters(string[] InFilters)
        {
            cmbformatchooser.Items.Clear();
            foreach(var filter in InFilters)
            {
                cmbformatchooser.Items.Add(filter);
            }
            cmbformatchooser.SelectedIndex = 0;
            lbextention.Text = InFilters[0];
        }


        private string GetIcon(string extension)
        {
            switch(extension)
            {
                case "png":
                case "jpg":
                case "jpeg":
                case "bmp":
                case "gif":
                    return "imagefile.png";
                case "txt":
                    return "textfile.png";
                case "json":
                case "dat":
                case "conf":
                case "cfg":
                    return "config.png";
                case "dri":
                case "sys":
                    return "driver.png";
                case "exe":
                case "com":
                    return "philips exe.png";
                case "dll":
                case "so":
                    return "philips dll.png";
                case "skn":
                    return "skinfile.png";
                default:
                    return "unknown.png";
            }
        }

        private void UpdateFolderList()
        {
            // Clear the last file list.
            lvfiles.Items.Clear();

            // Add an 'up one level' button if we're not the root path.
            if(_working != "/")
            {
                var up = new ListViewItem();
                up.Text = "Up one";
                up.Tag = "..";
                up.ImageKey = "folderup";
                lvfiles.Items.Add(up);
            }

            // Get the filesystem context.
            var fs = CurrentSystem.GetFilesystem();

            // Loop through all folders.
            foreach(var folder in fs.GetDirectories(_working))
            {
                var folderItem = new ListViewItem();
                folderItem.Tag = folder;

                int lastslash = folder.LastIndexOf("/");

                string name = folder.Substring(lastslash + 1);

                folderItem.Text = name;
                folderItem.ImageKey = "folder";
                lvfiles.Items.Add(folderItem);
            }

            // Now onto files.
            foreach(var file in fs.GetFiles(_working))
            {
                if (Mode != FileSkimmerMode.Skim)
                    if (!file.ToLower().EndsWith(lbextention.Text))
                        continue;

                var fileItem = new ListViewItem();

                fileItem.Tag = file;
                int lastslash = file.LastIndexOf("/");

                string name = file.Substring(lastslash + 1);

                fileItem.Text = name;

                if (name.Contains("."))
                {
                    string extension = name.Substring(name.LastIndexOf(".") + 1);
                    fileItem.ImageKey = GetIcon(extension);
                }
                else
                {
                    fileItem.ImageKey = "unknown.png";
                }

                lvfiles.Items.Add(fileItem);
            }
        }

        protected override void OnDesktopUpdate()
        {
            // Update the working directory.
            lbllocation.Text = _working;

            pnloptions.Visible = CurrentSystem.HasShiftoriumUpgrade("fsnewfolder") || CurrentSystem.HasShiftoriumUpgrade("fsdelete") && Mode == FileSkimmerMode.Skim;

            btnnewfolder.Visible = CurrentSystem.HasShiftoriumUpgrade("fsnewfolder");
            btndeletefile.Visible = CurrentSystem.HasShiftoriumUpgrade("fsdelete") && lvfiles.SelectedItems.Count > 0 && lvfiles.SelectedItems[0].Tag.ToString() != "..";

            pnlopenoptions.Visible = Mode == FileSkimmerMode.Open || Mode == FileSkimmerMode.Save;

            pnlbreak.Visible = pnlopenoptions.Visible || pnloptions.Visible;

            switch(Mode)
            {
                case FileSkimmerMode.Open:
                    txtfilename.Hide();
                    lblfilenameprompt.Hide();
                    lblcurrentlydisplayingprompt.Show();
                    btnopen.Text = "Open";
                    break;
                case FileSkimmerMode.Save:
                    txtfilename.Show();
                    lblfilenameprompt.Show();
                    lblcurrentlydisplayingprompt.Hide();
                    btnopen.Text = "Save";
                    break;
            }

            if(pnlopenoptions.Visible)
            {
                if(cmbformatchooser.Items.Count == 1)
                {
                    cmbformatchooser.Hide();
                }
                else
                {
                    cmbformatchooser.Show();
                }
                lbextention.Text = cmbformatchooser.SelectedItem.ToString();
            }

            if(btndeletefile.Visible)
            {
                var item = lvfiles.SelectedItems[0];
                if(item.ImageKey == "folder")
                {
                    btndeletefile.Text = "Delete Folder";
                    btndeletefile.Image = Properties.Resources.deletefolder;
                }
                else
                {
                    btndeletefile.Text = "Delete File";
                    btndeletefile.Image = Properties.Resources.deletefile;
                }
            }

            base.OnDesktopUpdate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lvfiles.LargeImageList = ImageList1;
            lvfiles.SmallImageList = ImageList1;


            if(CurrentSystem!=null)
                UpdateFolderList();
        }

        private void lvfiles_DoubleClick(object sender, EventArgs e)
        {
            if(lvfiles.SelectedItems.Count != 0)
            {
                var itemTag = lvfiles.SelectedItems[0].Tag.ToString();

                if(itemTag == "..")
                {
                    _working = _working.Substring(0, _working.LastIndexOf("/"));
                    if(string.IsNullOrWhiteSpace(_working))
                    {
                        _working = "/";
                    }
                    UpdateFolderList();
                }
                else
                {
                    var fs = CurrentSystem.GetFilesystem();
                    if(fs.DirectoryExists(itemTag))
                    {
                        _working = itemTag;
                        UpdateFolderList();
                    }
                    else if(fs.FileExists(itemTag))
                    {
                        txtfilename.Text = itemTag.Substring(itemTag.LastIndexOf("/") + 1);
                        HandleFileOpen();
                    }
                }
            }
        }

        private void btnnewfolder_Click(object sender, EventArgs e)
        {
            string work = this._working;

            CurrentSystem.AskForText("New Folder", "Please enter a name for your new folder.", (name) =>
            {
                if(string.IsNullOrWhiteSpace(name))
                {
                    CurrentSystem.ShowInfo("New Folder", "The folder name cannot be blank.");
                    return false;
                }

                if (name.Any(x => Path.GetInvalidFileNameChars().Contains(x)))
                {
                    CurrentSystem.ShowInfo("New Folder", "The folder name contains some invalid characters.");
                    return false;
                }

                string path = "";
                if (work.EndsWith("/"))
                    path = work + name;
                else
                    path = work + "/" + name;

                var fs = CurrentSystem.GetFilesystem();

                if(fs.DirectoryExists(path))
                {
                    CurrentSystem.ShowInfo("New Folder", "A folder with that name already exists.");
                    return false;
                }

                fs.CreateDirectory(path);
                UpdateFolderList();
                return true;
            });
        }

        private void btndeletefile_Click(object sender, EventArgs e)
        {
            string path = lvfiles.SelectedItems[0].Tag.ToString();

            if(path.StartsWith("/Shiftum42") || path.StartsWith("/SoftwareData"))
            {
                CurrentSystem.ShowInfo("Permission denied.", $"You do not have permission to delete {path}.");
                return;
            }

            var fs = CurrentSystem.GetFilesystem();

            if(fs.DirectoryExists(path))
            {
                CurrentSystem.AskYesNo("Delete folder?", $"Do you erally want to delete {path}?", (answer) =>
                {
                    if (answer)
                    {
                        fs.DeleteDirectory(path, true);
                        UpdateFolderList();
                    }
                });
            }
            else if(fs.FileExists(path))
            {
                CurrentSystem.AskYesNo("Delete file?", $"Do you erally want to delete {path}?", (answer) =>
                {
                    if (answer)
                    {
                        fs.DeleteFile(path);
                        UpdateFolderList();
                    }
                });
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            HandleFileOpen();
        }

        private void HandleFileOpen()
        {
            var fs = CurrentSystem.GetFilesystem();
            switch(Mode)
            {
                case FileSkimmerMode.Open:
                    if(lvfiles.SelectedItems.Count == 0)
                    {
                        CurrentSystem.ShowInfo("Open File", "No file has been selected.");
                        return;
                    }
                    string path = lvfiles.SelectedItems[0].Tag.ToString();
                    if(fs.FileExists(path))
                    {
                        if(FileOpenCallback?.Invoke(path) == true)
                        {
                            Close();
                            return;
                        }
                    }
                    else
                    {
                        CurrentSystem.ShowInfo("Open File", "File not found.");
                        return;
                    }
                    break;
                case FileSkimmerMode.Save:
                    string work = _working;
                    string name = txtfilename.Text;

                    if(string.IsNullOrWhiteSpace(name))
                    {
                        CurrentSystem.ShowInfo("Save File", "Please enter a file name.");
                        return;
                    }

                    if(!name.ToLower().EndsWith(lbextention.Text))
                    {
                        name += lbextention.Text;
                    }

                    if(name.Any(x=>Path.GetInvalidFileNameChars().Contains(x)))
                    {
                        CurrentSystem.ShowInfo("Save File", "The file name you entered contains some invalid characters.");
                        return;
                    }

                    string savePath = "";
                    if (work.EndsWith("/"))
                        savePath = work + name;
                    else
                        savePath = work + "/" + name;

                    if(savePath.StartsWith("/Shiftum42") || savePath.StartsWith("/SoftwareData"))
                    {
                        CurrentSystem.ShowInfo("Permission denied.", "You do not have permission to save here.");
                        return;
                    }

                    if(fs.FileExists(savePath))
                    {
                        CurrentSystem.AskYesNo("Save File - Overwrite?", "A file with that name already exists. Do you want to overwrite it?", (answer) =>
                        {
                            if(FileOpenCallback?.Invoke(savePath) == true)
                            {
                                Close();
                                return;
                            }
                        });
                        return;
                    }
                    else
                    {
                        if(FileOpenCallback?.Invoke(savePath)==true)
                        {
                            Close();
                            return;
                        }
                    }
                    break;
            }
        }

        private void cmbformatchooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbextention.Text = cmbformatchooser.SelectedItem.ToString();
            UpdateFolderList();
        }
    }

    public enum FileSkimmerMode
    {
        Skim,
        Open,
        Save
    }
}
