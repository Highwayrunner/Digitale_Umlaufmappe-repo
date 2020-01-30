/*
create table Benutzer
(
	idBenutzer int not null,
	Benutzername varchar(45),
	Passwort varchar(max),
	Registrierdatum Datetime,
	Letzte_Anmeldung Datetime,
	Onlinestatus bit,
	ID_Rechte int,
	Vorname varchar(100),
	Nachname varchar(100),
	Geburtsdatum Date,
	Geschlecht int,
	Beruf varchar(100),
	Bild varchar(500)
	primary key (idBenutzer)
);
*/
drop table benutzer
select * from ordner
delete from dokument
delete from ordner
delete from Dokumentinformation

delete from Objektmatchcode
delete from Benutzerordner
delete from Bearbeitungschronik

select * from DokumentCheck
select * from dokument
/*
create Table Rechte
(
	idRechte int,
	Bezeichnung varchar(50)
);
*/

/*
create Table Ordner
(
	idOrdner int,
	Ordnername varchar(45),
	Erstelldatum datetime,
	ID_Benutzer int
	primary key (idOrdner)
);
*/



/*
create Table Dokument
(
	idDokument int,
	Dokumentname varchar(100),
	Dokumentpfad varchar(1000),
	Dokument_BLOB varbinary(max),
	Dateiendung varchar(10),
	
	Erstelldatum datetime,
	Aenderungsdatum datetime, 
	Hinzugefuegt_Am datetime,
	ID_Ordner int,
	Pruefsumme varchar(max),
	primary key (idDokument)
);


/*
create Table DokumentCheck
(
	idDokumentCheck int,
	Checksum varchar(max),
	primary key (idDokumentCheck)
)
*/


create Table Dokumentinformation
(
	idDokumentinformation int,
	Dokumentinformationsname varchar(50),
	Dokumentinformation varchar(1000),
	ID_Benutzer int,
	Erstelldatum datetime,
	ID_Dokument int
	primary key (idDokumentinformation)
);
select * from Dokumentinformation
delete from Dokumentinformation 
drop table Dokumentinformation



create table Objektmatchcode
(
	idObjektmatchcode int,
	ID_Dokument int,
	ID_Ordner int,
	Objekttyp int,
	ID_MatchcodeItem int
	primary key (idObjektmatchcode)
);
select * from Objektmatchcode
delete from Objektmatchcode
drop table objektmatchcode
select ID_Ordner, Bezeichnung From Objektmatchcode join Matchcode on idMatchcode = ID_Matchcode where Objekttyp = 1



create Table Matchcode
(
	idMatchcode int,
	Matchcodename varchar(50),
	primary Key (idMatchcode)
);

select * from Matchcode
drop table Matchcode
select idMatchcode, Matchcodeame, Bezeichnung From Matchcode order by idMatchcode

select ID_Matchcode, Matchcodename, Bezeichnung From Objektmatchcode join Matchcode on idMatchcode = ID_Matchcode 
delete e From Objektmatchcode e inner join Matchcode s on idMatchcode = ID_Matchcode and ID_Ordner = 1


create Table MatchcodeItem
(
	idMatchcodeItem int,
	Bezeichnung varchar(50),
	ID_Matchcode int
	primary key(idMatchcodeItem)
);

select * from MatchcodeItem
drop table Matchcode_Item



create table Benutzerordner
(
	idBenutzerordner int,
	ID_Benutzer int,
	ID_Ordner int,
	Position int,
	Status int
	primary key (idBenutzerordner)
);


create Table Bearbeitungschronik
(
	idBearbeitungschronik int,
	ID_Vorheriger_Benutzer int,
	ID_Ordner int,
	ID_Ordneraktionen int,
	Weitergereicht_Am DateTime
	primary key (idBearbeitungschronik)
);
select * from Bearbeitungschronik
drop table bearbeitungschronik



create table Ordneraktionen
(
	idOrdneraktionen int,
	ID_Ordner int,
	ID_Benutzer int,
	ID_Aktion int,
	ID_Naechste_Aktion int,
	Status int,
	Erledigt_Am datetime
	primary key (idOrdneraktionen)
);


create table Aktion
(
	idAktion int,
	Bezeichnung varchar(100)
	primary key (idAktion)
);





*/
