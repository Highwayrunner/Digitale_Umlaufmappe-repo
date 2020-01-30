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
insert into Benutzer values (1, 'Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', '2015-02-10', '2015-02-10', 0, 1, 'Nico', 'Riemenschneider', '1991-05-09', 0, 'Programmierer', '')
insert into Benutzer values (2, 'Benutzer', 'Benutzer', '2015-23-02', '2015-23-02', 0, 0, 'Fabian', 'Riemenschneider', '1994-02-25', 0, 'Student', '')
insert into Benutzer values (3, 'Schweinehund', 'Lala', '2015-23-02', '2015-23-02', 0, 0, 'Alexander', 'Dorsch', '1992-02-25', 0, 'Student', '')
select * from Benutzer join rechte on idRechte = id_Rechte
select * From Benutzer
drop table benutzer
delete from  benutzer
UPDATE Benutzer SET Vorname ='Nico', Nachname = 'Riemenschneider', Beruf = 'Programmierer', Geschlecht = 0, Bild = '' , Geburtsdatum = '25.05.1991' WHERE idBenutzer = 1
*/

/*
create Table Rechte
(
	idRechte int,
	Bezeichnung varchar(50)
);

insert into Rechte values (0, 'Benutzer')
insert into Rechte values (1, 'Administrator')
select * from Rechte
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
insert into Ordner values (1, 'DokFolder 1', '2015-23-02 10:39', 1)
insert into Ordner values (2, 'DokFolder 2', '2015-23-02', 1)
insert into Ordner values (3, 'DokFolder 3', '2015-23-02', 1)
insert into Ordner values (4, 'Fabians Ordner', '2015-23-02', 2)
drop table ordner

select * from Ordner
SELECT  MAX(idOrdner) as MaxID FROM Ordner;
delete from ordner
*/
/*

/*
create Table Dokument
(
	idDokument int,
	Dokumentname varchar(100),
	Dokument_BLOB varbinary(max),
	Dateiendung varchar(10),
	
	Erstelldatum datetime,
	Aenderungsdatum datetime, 
	Hinzugefuegt_Am datetime,
	ID_Ordner int,
	Pruefsumme varchar(max),
	primary key (idDokument)
);
select * from dokument
SELECT idDokument, Dokumentname, Dokumentpfad, Dokument_BLOB, Dateiendung, ID_Ordner, ID_Benutzer, Dokument.Erstelldatum, Aenderungsdatum, Hinzugefuegt_Am FROM Dokument JOIN Ordner ON idOrdner = ID_Ordner ORDER BY ID_Ordner
insert into Dokument values (1, 'Einfache Fragen 1', 'G:\Einfache Fragen 1.odt', '2015-23-02', 1)
insert into Dokument values (2, 'Linux Admin Tutorial', 'E:\Schule\adm1-de-manual.pdf', '2015-23-02', 1)
insert into Dokument values (3, 'Datenschutz', 'E:\Schule\Datenschutz.pdf', '2015-23-02', 2)
insert into Dokument values (4, 'Bild', 'C:\Users\Nico\Documents\C# Bilder\256x256\user_male_128.png', '2015-23-02', 4)
select * from Dokument
SELECT MAX(idDokument) as MaxID FROM Dokument
delete from dokument
drop table dokument




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
select * from Benutzerordner
select Benutzername From Benutzer join Benutzerordner on idBenutzer = ID_Benutzer order by Position 

drop table Benutzerordner
select * from Benutzerordner
delete from benutzerordner
Insert into Benutzerordner values (0, 1, 1, 1, 0)


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

delete from ordneraktionen
select * FROM ordneraktionen
drop table Ordneraktionen
Select ID_Naechste_Aktion From Ordneraktionen Where  ID_Ordner = @nFolderID and Erledigt_Am = (Select (max)Erledigt_Am From Ordneraktionen Where ID_Ordner = @nFolderID)
Select max(Erledigt_Am) From Ordneraktionen Where ID_Ordner = 1


create table Aktion
(
	idAktion int,
	Bezeichnung varchar(100)
	primary key (idAktion)
);
insert into Aktion values (1, 'zur Kenntnis')
insert into Aktion values (2, 'Rechnungsprüfung')
insert into Aktion values (3, 'zur weiteren Bearbeitung')

Create Table DokumentCheck 
(
	idDokumentCheck int, 
	Checksum varchar(max), 
	primary key(idDokumentCheck)
);
*/
