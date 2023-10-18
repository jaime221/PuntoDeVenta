create database PuntoVenta;
go 
use PuntoVenta;
go
create table Clientes(
 Id int identity(1,1)not null,
 primary key(Id),
 Nombre varchar(50) not null,
 Apellido varchar(50) not null,
 DUI varchar(9) not null,
 Telefono varchar(9) not null,
 Correo varchar(100) not null,
 Estado tinyint not null,
);
go
create table CategoriaProductos(
Id int identity(1,1) not null,
primary key(Id),
Nombre varchar(50) not null,
Estado tinyint not null,
);
go
create table Roles(
Id int identity(1,1) not null,
Nombre varchar(50)not null,
Estado tinyint not null,
primary key(Id)
);
go
create table Cargos(
Id int identity(1,1) not null,
primary key(Id),
Nombre varchar(50) not null,
Estado tinyint not null,
);
go 
create table Salarios(
Id int identity(1,1) not null,
Cantidad int not null,
Estado tinyint not null,
primary key(Id)
);
go
create table Productos(
Id int identity(1,1) not null,
CategoriaProductoId int not null,
Precio int not null,
Descuento int not null,
Nombre varchar(50) not null,
Stock int not null,
Estado tinyint not null,
primary key(Id),
foreign key(CategoriaProductoId)
references CategoriaProductos(Id)
);
go
create table Empleados(
Id int identity(1,1) not null,
SalarioId int not null,
CargoId int not null,
Nombre varchar not null,
Apellido varchar not null,
FechaInicio varchar not null,
DUI varchar not null,
Correo varchar not null,
Direccion varchar not null,
Estado tinyint not null,
primary key(Id),
foreign key(CargoId)
references Cargos(Id),
foreign key(SalarioId)
references Salarios(Id),
);
go
create table Usuarios(
Id int identity(1,1) not null,
RolId int not null,
Correo varchar not null,
Clave varchar(max) not null,
Estado tinyint not null,
primary key(Id),
foreign key(RolId)
references Roles(id),
);
go 
create table Ventas(
Id int identity(1,1) not null,
ClienteId int not null,
Total decimal(9,2) not null,
Estado tinyint not null,
primary key(Id),
foreign key(ClienteId)
references Clientes(Id),

);
go
create table DetalleVentas(
Id int identity(1,1) not null,
VentaId int not null,
Cantidad int not null,
ProductoId int not null,
Estado tinyint not null,
foreign key(ProductoId)
references Productos(Id),
primary key (Id),
foreign key (VentaId)
references Ventas(Id)
);

