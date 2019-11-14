using KY.Aplicacion.Aplicacion;
using KY.Aplicacion.Interface;
using KY.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KY.CasoNorthwind.Controllers
{
    public class ListOrdersController : Controller
    {

        // GET: ListOrders
        public ActionResult Index(IEnumerable<PendingOrder> pendingOrder)
        {
            if (ModelState.IsValid)
            {
                IOrderServices _orderServices = new OrderServices();
                pendingOrder = _orderServices.GetPendingOrders();
            }
            return View(pendingOrder);
        }
    }
}