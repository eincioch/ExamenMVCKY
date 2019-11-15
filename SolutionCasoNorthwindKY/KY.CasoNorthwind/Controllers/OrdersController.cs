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
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index() //IEnumerable<Orders> orders)
        {
            /*if (ModelState.IsValid)
            {
                IOrderServices _orderServices = new OrderServices();
                orders = _orderServices.GetOrders(10248);
            }
            return View(orders);*/
            return View();
        }

    }
}