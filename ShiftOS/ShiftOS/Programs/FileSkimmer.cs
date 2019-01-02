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

            base.OnDesktopUpdate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lvfiles.LargeImageList = ImageList1;
            lvfiles.SmallImageList = ImageList1;

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
                }
            }
        }
    }
}
