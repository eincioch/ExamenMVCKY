using KY.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Persistencia.Interface
{
    public interface IRepositorio
    {
        Orders GetOrders(int OrderID);
        IEnumerable<PendingOrder> GetPendingOrders();
    }
}
