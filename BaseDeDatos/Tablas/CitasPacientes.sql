CREATE TABLE CitasPacientes
(
	Id INT IDENTITY(1,1),
	IdPaciente INT NOT NULL,
	IdTipoCita INT NOT NULL,
	IdEstadoCita INT NOT NULL,
	FechaCita SMALLDATETIME NOT NULL
	CONSTRAINT PK_CitasPacientes_Id
		PRIMARY KEY (Id),
	CONSTRAINT FK_CitasPacientes_IdPaciente
		FOREIGN KEY (IdPaciente)
		REFERENCES Pacientes(Id),
	CONSTRAINT FK_CitasPacientes_IdTipoCita
		FOREIGN KEY (IdTipoCita)
		REFERENCES TiposCitas(Id),
	CONSTRAINT FK_CitasPacientes_IdEstadoCita
		FOREIGN KEY (IdEstadoCita)
		REFERENCES EstadosCitas(Id),
	CONSTRAINT UC_CitasPacientes
		UNIQUE(IdPaciente,FechaCita)
);
