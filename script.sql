select * from Customers 
select * from Orders 
go
select * from [Order Details] 
select * from Products
go
select O.OrderID , O.OrderDate , C.CompanyName, C.Phone  , C.City ,  
	case when O.ConfirmationDate IS NULL then 'NO CONFIRMADO' ELSE 'CONFIRMADO' END	Estado,
	O.ConfirmationDate
from Orders O with(nolock) inner join Customers C with(nolock) on O.CustomerID = C.CustomerID 
Order by O.OrderDate desc, o.CustomerID , O.OrderID 
go

/*Ejecutar estas lineas*/
alter table Orders add ConfirmationDate datetime NULL
alter table Orders add COMMENTS text NULL