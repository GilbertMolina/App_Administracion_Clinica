﻿CREATE TABLE TiposCitas
(
	Id INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TiposCitas_Id
		PRIMARY KEY (Id)
);
