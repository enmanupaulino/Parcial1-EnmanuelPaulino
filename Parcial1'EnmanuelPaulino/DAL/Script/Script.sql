CREATE DATABASE ProductoDb
GO
Use master

create database ProductoDb
use ProductoDB
create table Productos(

ProductoId int primary key identity ,
Descripcion varchar (max),
Existencia decimal,
Costo decimal ,
ValorInventario decimal

) 


create table Inventario(
    InventarioId int primary key identity ,
	ProductoId INT ,
    TotalInventario decimal,
	foreign key (ProductoId) references Productos(ProductoId)
)
go


