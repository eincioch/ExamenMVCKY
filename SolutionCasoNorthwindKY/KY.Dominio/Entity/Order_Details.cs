using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Dominio.Entity
{
    public class Order_Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }

        public Order_Details()
        {
            
        }

        public decimal CalcSubTotal() {
            return (Convert.ToDecimal(this.Quantity) * this.UnitPrice) - Convert.ToDecimal(this.Discount);
        }
    }
}
