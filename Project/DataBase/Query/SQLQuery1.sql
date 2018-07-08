--create database MechanicalComponentsDB;

use MechanicalComponentsDB;

-- tabella engines
create table Engines
(
	Id int identity(1,1) primary key not null,
	Name nvarchar(max) not null,
    SerialNumber nvarchar(max) unique not null
)

-- tabella components
create table Components
(
	Id int identity(1,1) primary key not null,
	Name nvarchar(max) not null,
	Icon image default(0x0),
	EngineId int not null
)

alter table Components
add constraint FK_Components_Engines foreign key (EngineId)
    references Engines (Id) 
    on delete cascade
    on update cascade


-- tabella elements
create table Elements
(
	Id int identity(1,1) primary key not null,
	Name nvarchar(max) not null,
	Icon image default(0x0),
	EngineId int not null,
	ComponentId int not null
)

alter table Elements
add constraint FK_Elements_Engines foreign key (EngineId)
    references Engines (Id) 
    on delete cascade
    on update cascade

alter table Elements
add constraint FK_Elements_Components foreign key (ComponentId)
    references Components (Id) 
    on delete cascade
    on update cascade


-- tabella properties
create table Properties
(
	Id int identity(1,1) primary key not null,
	SerialNumber nvarchar(max) unique,
	Material nvarchar(max),
	Height int,
	Length int,
	Depth int,
	Diameter int,
	Power int,
	Ampere int,
	Voltage int,
	Capacity int,
	EngineId int not null
)

alter table Properties
add constraint FK_Properties_Elements foreign key (ElementId)
    references Elements (Id) 
    on delete cascade
    on update cascade


-- inserisci engine
insert into Engines
    (Name, SerialNumber)
values
	('', '')


-- inserisci componente
insert into Components
    (Name, Icon, EngineId)
values
	('', , )


-- inserisci elemento
insert into Elements
    (Name, Icon, EngineId, ComponentId)
values
	('', , , )

-- inserisci proprietà



-- select dei componenti di un engine (icona e nome)
select c.Icon, c.Name
from Components as c
join Engines as en on en.Id = c.EngineId
group by en.Id


-- select degli elementi di un componente (icona e nome)
select el.Icon, el.Name
from Elements as el
join Components as c on c.Id = el.ComponentId
group by c.Id


-- alter per aggiungere o modificare proprietà di un elemento
UPDATE Properties
SET NomeColonna = InserimentoCheSiVuoleFare, NomeColonna2=InserimentoCheSiVuoleFare2
WHERE condizione = condizione; -- usare la PK 

