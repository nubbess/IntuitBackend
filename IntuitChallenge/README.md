### Step 1:
voy a usar SQL Server;

create database IntuitClientes;

create table Clientes(
-- para validar la unicidad del campo ID voy a hacer que se autogenere en la base de datos
ClienteID int primary key identity,
Nombre varchar(30) not null,
Apellido varchar(30) not null,
Fecha_nacimiento date not null,
CUIT varchar(11) not null,
Domicilio varchar (50) not null,
Telefono_Celular varchar (20) not null,
Email varchar(30) not null
);

-- como empecé desde la DB voy a hacer el scaffold con Entity Framework;

en la consola NuGet PM

Scaffold-DbContext "DefaultConnection" -OutputDir Models

Posterior a eso, voy a armar los servicios para poder usarlos en el controlador por medio de inyeccción de dependencias
para eso, creo la interfaz IClienteService y el ClienteService



