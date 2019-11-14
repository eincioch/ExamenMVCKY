using KY.Aplicacion.Interface;
using KY.Dominio.Entity;
using KY.Persistencia.Interface;
using KY.Persistencia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Aplicacion.Aplicacion
{
    public class OrderServices : IOrderServices
    {
        public IEnumerable<PendingOrder> GetPendingOrders()
        {
            IRepositorio _repositorio = new Repositorio();
            return _repositorio.GetPendingOrders();
        }
    }
}
