/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
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
