CREATE DATABASE ProductoDb
GO

USE ProductoDb
create table RegistroProductos(

ProductoId int primary key identity ,
Descripcion varchar (max),
Exixtencia decimal,
Costo decimal ,
ValorInventario decimal

) 
GO
