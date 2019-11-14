using KY.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Aplicacion.Interface
{
    public interface IOrderServices
    {
        IEnumerable<PendingOrder> GetPendingOrders();
    }
}
