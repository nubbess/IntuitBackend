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

Posterior a eso, voy a armar los servicios, primero creo el IGenericService<T> y  GenericService<T> para implementarlos luego en
IClienteService y ClienteService (para que todo sea mas 'sostenible')

el Update lo dejé fuera del serivicio generico porque en un principio quería hacer patches pero lo deje como put

una vez que tengo listos los servicios genericos, armo el ClientesController (controlador de API);

iba a usar un objeto HttpResponse con Response, Status, y (bool) Success pero dado lo pequeño del ejemplo no lo compliqué

para que sea flexible el tipo de retorno use IActionResult

documento con la anotación el tipo de respuesta del sv;









