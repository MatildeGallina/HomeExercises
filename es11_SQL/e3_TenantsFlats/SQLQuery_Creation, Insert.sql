create database TenantsFlats


create table Tenants
(
	Id int identity not null primary key,
	Name nvarchar(max) not null,
	Surname nvarchar(max) not null,
	FlatId int
)

create table Flats
(
	Id int identity not null primary key,
	Address nvarchar(max) not null,
	SquareMeters int not null,
	City nvarchar(max) not null
)

-------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------
-----				                                                                                                -----
-----		Prima delle query bisogna riempire le tabelle con almeno 10 record per tabella, con queste regole:      -----
-----		duplicare un po' di cognomi e di città                                                                  -----
-----		variare i mq da 50 a 200                                                                                -----
-----		più persone possono stare nello stesso appartamento                                                     -----  
-----		mettere alcune persone con `FlatId` null                                                                -----
-----		gli `Address` devono essere univoci (aggiungere constraint `unique` sulla colonna)                      -----
-----			                                                                                                    -----
-------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------


--alter table Tenants
--add constraint FK_Tenants_Flats foreign key (FlatId)
--    references Flats (Id) 
--    on delete cascade
--    on update cascade

--alter table Flats
--alter column Address nvarchar(450) not null

--alter table Flats
--add constraint UC_Flats unique ([Address])

