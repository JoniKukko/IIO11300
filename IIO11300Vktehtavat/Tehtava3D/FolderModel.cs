using System;

namespace Tehtava3D
{
    class FolderModel
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string FullPath
        {
            get
            {
                return this.Path + this.Name;
            }
        }
    }
}
