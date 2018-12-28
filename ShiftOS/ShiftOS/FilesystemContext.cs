using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ShiftOS
{
    public class FilesystemContext
    {
        private string _workingDirectory;

        public FilesystemContext()
        {
            _workingDirectory = Path.Combine(Environment.CurrentDirectory, "ShiftFS");

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
                OutPath = "/" + Part;
            }
            return OutPath;
        }

        private string MapToEnvironmentPath(string InPath)
        {
            return Path.Combine(_workingDirectory, ResolveToAbsolutePath(InPath).Replace("/", Path.DirectorySeparatorChar.ToString()));
        }
    }
}
