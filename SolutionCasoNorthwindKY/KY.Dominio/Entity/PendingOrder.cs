using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Dominio.Entity
{
    public class PendingOrder
    {
        public int OrderID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Estado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConfirmationDate { get; set; }
    }
}
