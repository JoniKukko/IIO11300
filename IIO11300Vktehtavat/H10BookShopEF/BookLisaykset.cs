using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H10BookShopEF
{
    public partial class Book
    {
        public string DisplayName
        {
            get
            {
                return this.author + " " + this.name;
            }
        }
    }
}
