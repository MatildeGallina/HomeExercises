create database Person

create table [Persons]
(
	Id int identity(1, 1) not null primary key,
	Name nvarchar(max) not null,
	Bestfriend nvarchar(max)
)

use Person

alter table [Persons]
alter column Bestfriend [int] null

alter table Persons
add constraint FK_Persons_Persons foreign key (Bestfriend)
    references Persons (Id)
    ON DELETE NO ACTION
	ON UPDATE no action

alter table Persons
drop constraint FK_Persons_Persons


insert [Persons]
(Name)
values
('Maria')

insert [Persons]
(Name, Bestfriend)
values
('Anna', 3)

insert [Persons]
(Name)
values
('Marco')

insert [Persons]
(Name, Bestfriend)
values
('Luigi', 7)

update Persons
set
	Bestfriend = 8
where Id = 7


select * from Persons

--Scrivere una query che visualizzi un elenco di persone con: Name, BestFriendName
--Andrà fatta una join della tabella su se stessa.

select Name
from Persons
where [Id] = [Bestfriend]