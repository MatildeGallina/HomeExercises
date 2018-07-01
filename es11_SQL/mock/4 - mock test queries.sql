/* SCRIPT DI CREAZIONE DEL DATABASE */

create database ShipsTrips

go

use ShipsTrips

go

create table Companies
(
    Id int identity primary key not null,
    Name nvarchar(max) not null,
    Country nvarchar(max) not null
)

create table Ships
(
    Id int identity primary key not null,
    Name nvarchar(max) not null,
    Type int not null,  -- 1 means goods, 2 means tourist
    Quantity int not null, -- tons of goods, or nr. of tourists
    CompanyId int not null,
    CommanderId int not null
)

create table Commanders
(
    Id int identity primary key not null,
    Name nvarchar(max) not null,
    Surname nvarchar(max) not null,
    Birth date not null
)

create table Cities
(
    Id int identity primary key not null,
    Name nvarchar(max) not null,
)

create table SeaTrips
(
    Id int identity primary key not null,
    DateStart date not null,
    DateEnd date not null,
    CityStartId int not null,
    CityEndId int not null,
    ShipId int not null,
    Quantity int not null
)

go

alter table SeaTrips
add constraint FK_SeaTrips_Cities_Start foreign key (CityStartId)
    references Cities (Id) on delete cascade on update cascade

alter table SeaTrips
add constraint FK_SeaTrips_Cities_End foreign key (CityEndId)
    references Cities (Id) on delete no action on update no action -- NO ACTION and not -- ON CASCADE because of a annoying error of SQL Server

alter table SeaTrips
add constraint FK_SeaTrips_Ships foreign key (ShipId)
    references Ships (Id) on delete cascade on update cascade

alter table Ships
add constraint FK_Ships_Commanders foreign key (CommanderId)
    references Commanders (Id) on delete cascade on update cascade

alter table Ships
add constraint FK_Ships_Companies foreign key (CompanyId)
    references Companies (Id) on delete cascade on update cascade

go



--Creare query di SELECT per ottenere tabelle che mostrino:

--DateStart, DateEnd, CityStart, CityEnd, Ship, Company (cioè mostare i nomi, non gli id)



--Compagnia, Nr.Navi

select Companies.Name, count(*) as Count
from Ships, Companies
where Ships.CompanyId = Companies.Id
group by Companies.Name

--Compagnia, YoungestCommander

select c.Name, c.Birth
from
	(select MAX(Birth) as Younger
	from Commanders) t
	join Commanders as c on c.Birth = t.Younger

--Compagnia, BiggestShip

	-- maggiore Quantity delle navi
select c.Name, s.Name
from (select MAX(Quantity) as MaxQuantity, CompanyId
	from Ships
	group by CompanyId) t
join Ships as s on s.CompanyId = t.CompanyId AND s.Quantity = t.MaxQuantity
join Companies as c on c.Id = s.CompanyId


--La singola compagnia con il commander più giovane di tutti

	-- NON VAAAAAAAA
select c.Name, comm.Name
from Companies as c
join Ships as s on c.Id = s.CompanyId
right join Commanders as comm on comm.Id = s.CommanderId
where comm.Birth = MAX(comm.Birth)

--La singola compagnia con la nave-merci più grande

select c.Name, s.Name
from (select MAX(Quantity) as MaxQuantity, CompanyId
	from Ships
	where Type = 1
	group by CompanyId) t
join Ships as s on s.CompanyId = t.CompanyId AND s.Quantity = t.MaxQuantity
join Companies as c on c.Id = s.CompanyId

--Mese, Compagnia, nr. viaggi

--Nave, nr. di partenze per ogni giorno, filtrando solo quelle con Nr. Partenze > 1
--(ogni nave si suppone possa fare una singola partenza al giorno.
--Se qualche Count è > 1, ci sono dati invalidi nel db. Questa è una query che in azienda si farebbe
--per fare dei check incrociati sui dati.)

