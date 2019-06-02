CREATE DATABASE ProductoDb
GO
Use master

create database ProductoDb
use ProductoDb
create table Productos(

ProductoId int primary key identity ,
Descripcion varchar (max),
Existencia decimal,
Costo decimal ,
ValorInventario decimal

) 


create table Inventarios(
    InventarioId int primary key identity,
    TotalInventario decimal,
)
go

drop database ProductoDb
