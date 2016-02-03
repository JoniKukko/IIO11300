using System;
using System.Collections.Generic;
using System.IO;

namespace Tehtava3D
{
    [Serializable]
    class FileModel
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Filename
        {
            get
            {
                return this.Name + this.Ext;
            }
        }
        public long Size { get; set; }
        public List<FileModel> Versions { get; set; }
        public string VirtualMachine { get; set; }
        public string Path { get; set; }
        public string BackupFolder { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public string RealPath { get; set; }

    }
}
