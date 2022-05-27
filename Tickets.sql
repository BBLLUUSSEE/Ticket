CREATE DATABASE Ticket;

USE Ticket;

CREATE TABLE Tickets(
	idTicket int primary key identity (1,1),
	DataDiCreazione datetime not null,
	Richiedente varchar(50) not null,
	DescrizioneBreve varchar(50) not null,
	DescrizioneLunga varchar(100) not null,
	Categoria varchar(30) not null,
	Stato varchar(30) not null,
	Assegnatario varchar(30) not null,
	DataDiChiusura datetime not null,
	CONSTRAINT CHK_STATO CHECK (Stato = 'Nuovo' or Stato = 'Assegnato' or Stato = 'OnGoing' or Stato = 'Chiuso'),
	CONSTRAINT CHK_CATEGORIA CHECK (Categoria = 'Other' or Categoria = 'System' or Categoria = 'Office' or Categoria = 'SAP' or Categoria = 'Hardware')
);

INSERT INTO Tickets VALUES('2000-09-11', 'Luca', 'questa descrizione è breve', 'questa descrizione è lunga questa descrizione è lunga', 'System', 'Chiuso', 'Marco', '2000-09-12');

SELECT * FROM Tickets;
SELECT * FROM Tickets WHERE idTicket = 3;