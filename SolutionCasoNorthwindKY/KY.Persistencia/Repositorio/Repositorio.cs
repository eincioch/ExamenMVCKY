using KY.Dominio.Entity;
using KY.Persistencia.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KY.Persistencia.Repositorio
{
    public class Repositorio : IRepositorio
    {
        public Orders GetOrders(int OrderID)
        {
            using (var db = new Model.NorthwindEntities()) {

                var objData = (from o in db.Orders.Where(o => o.OrderID == OrderID)
                                   /*join d in db.Order_Details on o.OrderID equals d.OrderID
                                   join c in db.Customers on o.CustomerID equals c.CustomerID
                                   join p in db.Products on d.ProductID equals p.ProductID*/
                               select new {
                                   o,
                                   order_detalle = (from d in db.Order_Details
                                              where d.OrderID == o.OrderID
                                              select d),

                                    customer = (from c in db.Customers where c.CustomerID == o.CustomerID select c)
                                    //product = (from p in db.Products where p.ProductID == )

                                   /*o.OrderID,
                                   o.CustomerID,
                                   o.EmployeeID,
                                   o.OrderDate,
                                   o.RequiredDate,
                                   o.ShippedDate,
                                   o.ShipVia,
                                   o.Freight,
                                   o.ShipName,
                                   o.ShipAddress,
                                   o.ShipCity,
                                   o.ShipRegion,
                                   o.ShipPostalCode,
                                   o.ShipCountry,
                                   o.ConfirmationDate,
                                   o.COMMENTS,
                                   d.ProductID,
                                    d.UnitPrice,
                                    d.Quantity,
                                    d.Discount,
                                    c.CompanyName,
                                    c.ContactName,
                                   c.ContactTitle,
                                    c.Address,
                                    c.City,
                                    c.Region,
                                    c.PostalCode,
                                    c.Country,
                                    c.Phone,
                                    c.Fax,
                                    p.ProductName,
                                    p.SupplierID,
                                    p.CategoryID,
                                    p.QuantityPerUnit,
                                    p.UnitsInStock,
                                    p.UnitsOnOrder,
                                    p.ReorderLevel,
                                    p.Discontinued*/
                               }
                               );

                Orders orders = new Orders();
                Order_Details order_Details;

                foreach (var item in objData)
                {
                    orders.OrderID = item.OrderID;
                    orders.CustomerID = item.CustomerID;
                    orders.EmployeeID = item.EmployeeID;
                    orders.OrderDate = item.OrderDate;
                    orders.RequiredDate = item.RequiredDate;
                    orders.ShippedDate = item.ShippedDate;
                    orders.ShipVia = item.ShipVia;
                    orders.Freight = item.Freight;
                    orders.ShipName = item.ShipName;
                    orders.ShipAddress = item.ShipAddress;
                    orders.ShipCity = item.ShipCity;
                    orders.ShipRegion = item.ShipRegion;
                    orders.ShipPostalCode = item.ShipPostalCode;
                    orders.ShipCountry = item.ShipCountry;
                    orders.ConfirmationDate = item.ConfirmationDate;
                    orders.COMMENTS = item.COMMENTS;

                    orders.Order_Details = item.order_detalle.;

                    //orders.Customers = item.Cus
                }

                return orders;
            }
        }

        public IEnumerable<PendingOrder> GetPendingOrders()
        {
            using (var db = new Model.NorthwindEntities()) {

                var objData = (from o in db.Orders
                               join c in db.Customers on o.CustomerID equals c.CustomerID
                               select new
                               {
                                   o.OrderID,
                                   o.OrderDate,
                                   c.CompanyName,
                                   c.Phone,
                                   c.City,
                                   Estado = o.ConfirmationDate == null ? "NO CONFIRMADO" : "CONFIRMADO",
                                   o.ConfirmationDate
                               }
                              );


                List<PendingOrder> pendingOrders = new List<PendingOrder>();

                foreach (var item in objData)
                {
                    PendingOrder pendingOrder = new PendingOrder();
                    pendingOrder.OrderID = item.OrderID;
                    pendingOrder.OrderDate = Convert.ToDateTime(item.OrderDate);
                    pendingOrder.CompanyName = item.CompanyName;
                    pendingOrder.Phone = item.Phone;
                    pendingOrder.City = item.City;
                    pendingOrder.Estado = item.Estado;
                    pendingOrder.ConfirmationDate = Convert.ToDateTime(item.ConfirmationDate);

                    pendingOrders.Add(pendingOrder);
                }

                return pendingOrders;
            }
        }
    }
}
