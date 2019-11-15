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
        /// <summary>
        /// Obtiene detalle orden
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public IEnumerable<Orders> GetOrders(int OrderID)
        {
            using (var db = new Model.NorthwindEntities()) {

                var objData = (from o in db.Orders
                                   join d in db.Order_Details on o.OrderID equals d.OrderID
                                   join c in db.Customers on o.CustomerID equals c.CustomerID
                                   join p in db.Products on d.ProductID equals p.ProductID
                               select new {
                                   o.OrderID,
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
                                        p.ProductName,
                                        p.SupplierID,
                                        p.CategoryID,
                                        p.QuantityPerUnit,
                                        p.UnitsInStock,
                                        p.UnitsOnOrder,
                                        p.ReorderLevel,
                                        p.Discontinued,
                                    c.CompanyName,
                                    c.ContactName,
                                    c.ContactTitle,
                                    c.Address,
                                    c.City,
                                    c.Region,
                                    c.PostalCode,
                                    c.Country,
                                    c.Phone,
                                    c.Fax
                               }
                ).Where(o => o.OrderID == OrderID);

                List<Orders> ordersList = new List<Orders>();

                foreach (var item in objData)
                {
                    Orders orders = new Orders();

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

                    orders.Order_Details = (new List<Order_Details>(){ 
                        new Order_Details {
                                ProductID = item.ProductID,
                                UnitPrice = item.UnitPrice,
                                Quantity = item.Quantity,
                                Discount = item.Discount,
                                Products = (new Products(){
                                                ProductName= item.ProductName,
                                                SupplierID = item.SupplierID,
                                                CategoryID= item.CategoryID,
                                                QuantityPerUnit= item.QuantityPerUnit,
                                                UnitsInStock= item.UnitsInStock,
                                                UnitsOnOrder= item.UnitsOnOrder,
                                                ReorderLevel= item.ReorderLevel,
                                                Discontinued= item.Discontinued
                            })
                    }});

                    orders.Customers = (new Customers() {
                        CompanyName = item.CompanyName,
                        ContactName = item.ContactName,
                        ContactTitle = item.ContactTitle,
                        Address = item.Address,
                        City = item.City,
                        Region = item.Region,
                        PostalCode = item.PostalCode,
                        Country = item.Country,
                        Phone = item.Phone,
                        Fax = item.Fax
                    });

                    ordersList.Add(orders);
                }

                return ordersList;
            }
        }

        /// <summary>
        /// Lista ordenes pendientes
        /// </summary>
        /// <returns></returns>
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
                              ).OrderByDescending(x=>x.OrderDate);


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

        /// <summary>
        /// Actualizar campos (COMMENTS, ConfirmationDate)
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public int UpdOrder(Orders orders)
        {
            using (var db = new Model.NorthwindEntities()) {

                var query = (from o in db.Orders
                             where o.OrderID == orders.OrderID
                             select o).FirstOrDefault();

                query.COMMENTS = orders.COMMENTS;
                query.ConfirmationDate = DateTime.Now;

                return db.SaveChanges();

            }
        }
    }
}
