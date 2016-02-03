using System;
using System.Collections.Generic;

namespace Tehtava3D
{
    class FileModel
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Filename
        {
            get
            {
                return this.Name + "." + this.Ext;
            }
        }
        public int Size { get; set; }
        public List<FileModel> versions { get; set; }
        public string VirtualMachine { get; set; }
        public string BackupFolder { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public string FullPath
        {
            get
            {
                return this.Path + this.Name + this.Ext;
            }
        }

    }
}
