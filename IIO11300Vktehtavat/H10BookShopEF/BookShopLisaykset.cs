using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H10BookShopEF
{
    public partial class Customer
    {
        public string DisplayName
        {
            get
            {
                return this.firstname + " " + this.lastname;
            }
        }

        public int OrderCount
        {
            get
            {
                return this.Orders.Count();
            }
        }
    }
}
