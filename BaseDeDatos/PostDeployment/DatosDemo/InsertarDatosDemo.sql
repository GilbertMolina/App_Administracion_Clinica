INSERT INTO TiposCitas
(
	Nombre
)
VALUES
(
	'Medicina General'
),
(
	'Odontología'
),
(
	'Pediatría'
),
(
	'Neurología'
);
GO

INSERT INTO EstadosCitas
(
	Nombre
)
VALUES
(
	'Activa'
),
(
	'Cancelada'
);
GO

INSERT INTO Pacientes
(
	Id,
	Nombre,
	Apellido1,
	Apellido2
)
VALUES
(
	304540214,
	'Gilbert',
	'Molina',
	'Castrillo'
);
GO

INSERT INTO CitasPacientes
(
	IdPaciente,
	IdTipoCita,
	IdEstadoCita,
	FechaCita
)
VALUES
(
	304540214,
	2,
	1,
	'06-10-2018 10:00'
);
GO