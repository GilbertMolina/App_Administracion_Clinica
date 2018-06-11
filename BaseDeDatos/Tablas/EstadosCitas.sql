CREATE TABLE EstadosCitas
(
	Id INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	CONSTRAINT PK_EstadosCitas_Id
		PRIMARY KEY (Id)
);
