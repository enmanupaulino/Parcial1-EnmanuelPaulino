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
select * from Inventarios;
go

create  table Ubicaciones (
  
  UbicacionId int primary key identity,
  Descripcion varchar (max)

)
drop table Inventario
drop database ProductoDb
