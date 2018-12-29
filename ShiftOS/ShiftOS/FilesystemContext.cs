using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace ShiftOS
{

    public class FilesystemContext
    {
        private string _workingDirectory;

        public FilesystemContext()
        {
            _workingDirectory = Path.Combine(Application.StartupPath, "ShiftFS");
            Console.WriteLine(" --> Working directory: {0}", _workingDirectory);

            // Create the directory if it does not exist.
            if (!Directory.Exists(_workingDirectory))
            {
                Directory.CreateDirectory(_workingDirectory);
            }
        }

        private string ResolveToAbsolutePath(string InPath)
        {
            if (!InPath.StartsWith("/"))
                throw new FormatException();

            Stack<string> PathParts = new Stack<string>();

            foreach(string Part in InPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if(Part == "..")
                {
                    // Pop the last part off the absolute path only if there's a part to pop.
                    if(PathParts.Count == 0)
                    {
                        continue;
                    }
                    PathParts.Pop();
                }
                if(Part == ".")
                {
                    // Skip "current directory" marker.
                    continue;
                }
                // Push the path part onto the stack.
                PathParts.Push(Part);
            }

            // Resolution completed. Now let's get it into a string array.
            string OutPath = "";
            foreach(var Part in PathParts)
            {
                OutPath = "/" + Part + OutPath;
            }
            return OutPath;
        }

        private string MapToEnvironmentPath(string InPath)
        {
            string abs = ResolveToAbsolutePath(InPath);
            while (abs.StartsWith("/"))
                abs = abs.Remove(0, 1);

            string mapped = Path.Combine(_workingDirectory, abs.Replace("/", Path.DirectorySeparatorChar.ToString()));

            Console.WriteLine("Mapped {0} to {1}.", InPath, mapped);
            return mapped;
        }

        public Stream Open(string InPath, FileMode InFileMode)
        {
            return File.Open(MapToEnvironmentPath(InPath), InFileMode);
        }

       public Stream OpenRead(string InPath)
        {
            return File.OpenRead(this.MapToEnvironmentPath(InPath));
        }

        public Stream OpenWrite(string InPath)
        {
            return File.OpenWrite(this.MapToEnvironmentPath(InPath));
        }

        public StreamReader OpenText(string InPath)
        {
            return File.OpenText(this.MapToEnvironmentPath(InPath));
        }

        public string ReadAllText(string InPath)
        {
            using (var sr = OpenText(InPath))
            {
                return sr.ReadToEnd();
            }
        }

        public string[] ReadAllLines(string InPath)
        {
            return ReadAllText(InPath).Split(new[] { Environment.NewLine.ToString() }, StringSplitOptions.None);
        }

        public byte[] ReadAllBytes(string InPath)
        {
            using (var s = OpenRead(InPath))
            {
                byte[] bytes = new byte[s.Length];
                s.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        public void WriteAllBytes(string InPath, byte[] InBytes)
        {
            using (var s = this.Open(InPath, FileMode.OpenOrCreate))
            {
                s.SetLength(InBytes.Length);
                s.Write(InBytes, 0, InBytes.Length);
                s.Flush();
            }
        }

        public void WriteAllText(string InPath, string InText)
        {
            WriteAllBytes(InPath, Encoding.UTF8.GetBytes(InText));
        }

        public void WriteAllLines(string InPath, string[] InLines)
        {
            WriteAllText(InPath, string.Join(Environment.NewLine, InLines));
        }

        public void CreateDirectory(string InPath)
        {
            if (DirectoryExists(InPath))
                return;

            Directory.CreateDirectory(MapToEnvironmentPath(InPath));
            Console.WriteLine("Creating directory: {0}", InPath);
        }

        public bool DirectoryExists(string InPath)
        {
            return Directory.Exists(MapToEnvironmentPath(InPath));
        }

        public bool FileExists(string InPath)
        {
            return File.Exists(MapToEnvironmentPath(InPath));
        }

        public void MoveDirectory(string InPath, string OutPath)
        {
            Directory.Move(MapToEnvironmentPath(InPath), MapToEnvironmentPath(OutPath));
        }

        public void CopyFile(string InPath, string OutPath)
        {
            File.Copy(MapToEnvironmentPath(InPath), MapToEnvironmentPath(OutPath));
        }

        public void MoveFile(string InPath, string OutPath)
        {
            File.Move(MapToEnvironmentPath(InPath), MapToEnvironmentPath(OutPath));
        }

        public void DeleteFile(string InPath)
        {
            File.Delete(MapToEnvironmentPath(InPath));
            Console.Write("Deleting file {0}", InPath);
        }

        public void DeleteDirectory(string InPath, bool Recurse = false)
        {
            Directory.Delete(MapToEnvironmentPath(InPath), Recurse);
            Console.WriteLine("Deleting directory {0} (recursive: {1})", InPath, Recurse);
        }

        public string[] GetFiles(string InPath)
        {
            var files = Directory.GetFiles(MapToEnvironmentPath(InPath));

            var ret = new string[files.Length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = InPath + "/" + Path.GetFileName(files[i]);
            }

            return ret;
        }

        

    }
}
