using System;

namespace Tehtava3D
{
    class FolderModel
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
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
