/*CREATE TABLE Ciudad
    (idCiudad int PRIMARY KEY NOT NULL,
    ciudad varchar(25) NOT NULL,
    departamento varchar(25) NULL,
    codigoPostal varchar(50) NULL);
	
	CREATE TABLE Persona
    (idPersona int PRIMARY KEY NOT NULL,
    nombre varchar(25) NULL,
    apellido varchar(25) NULL,
	tipoDocumento varchar(15), 
	nroDocumento varchar(15),
	 direccion varchar (100),
	 celular varchar (20),
	 email varchar (25),
	 estado varchar (25),
	 idCiudad int,
	 FOREIGN KEY(idCiudad) REFERENCES Ciudad(idCiudad))*/
	
	/*CREATE TABLE Clientes
  (idCliente integer PRIMARY KEY  NOT NULL,
    idPersona integer NOT NULL,
    fechaIngreso date,
    calificacion varchar (10),
    estado varchar(25),
	FOREIGN KEY(idPersona) REFERENCES Persona(idPersona))*/
	/*
	CREATE TABLE Cuentas
    (idCuenta int PRIMARY KEY NOT NULL,
    nroCuenta varchar(25) NULL,
    fechaAlta date NULL,
	tipoCuenta varchar(15), 
	 saldo real,
	 nroContacto varchar (20),
	 costoMantenimiento real,
	 promedioAcreditacion varchar(25),
	 moneda varchar (20),
	 estado varchar (25))
	FOREIGN KEY(idCliente) REFERENCES Clientes(idCliente))*/
	 
	/* CREATE TABLE Movimientos
    (idMovimiento int PRIMARY KEY NOT NULL,
    fechaMovimiento date NULL,
    tipoMovimiento varchar(25) NULL,
	sueldoAnterior real, 
	sueldoAnual real,
	 montoMovimiento real,
	cuentaOrigen real,
	 cuentaDestino real,
	 canal real)
	FOREIGN KEY(idCuenta) REFERENCES Cuentas(idCuenta))*/
	
	Create table Usuarios
	(idUsuario int Primary key not null,
	 idPersona int,
	 nombre_usuario varchar (20),
	 contraseña varchar (100),
	 nivel varchar (25),
	 estado varchar (20)
	)
	 