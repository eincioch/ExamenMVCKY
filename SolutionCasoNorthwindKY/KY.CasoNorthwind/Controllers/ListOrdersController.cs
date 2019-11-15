using KY.Aplicacion.Aplicacion;
using KY.Aplicacion.Interface;
using KY.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult VerDetalle(int OrderID)
        {
            if (OrderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IOrderServices _orderServices = new OrderServices();
            IEnumerable<Orders> orders = _orderServices.GetOrders(OrderID);

            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerDetalle([Bind(Include = "OrderID,Comments")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                IOrderServices _orderServices = new OrderServices();
                _orderServices.UpdOrder(orders);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}