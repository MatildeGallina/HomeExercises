USE TrainStation;

CREATE TABLE [Companies]
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](MAX) NOT NULL,
	[Nationality] [nvarchar](MAX) NOT NULL
)

CREATE TABLE [Trains]
(
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] [nvarchar](MAX) NOT NULL,
    [Seats] [int] NOT NULL,
    [StepHeight] [float] NOT NULL,
    [CompanyId] [int] NOT NULL
)

CREATE TABLE [Departures]
(
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Time] [DateTime] NOT NULL,
    [Rail] [int] NOT NULL,
    [Destination] [nvarchar](MAX) NOT NULL,
    [TrainId] [int] NOT NULL
)

alter table Trains
add constraint FK_Trains_Companies foreign key (CompanyId)
    references Companies (Id) 
    on delete cascade
    on update cascade

alter table Departures
add constraint FK_Departures_Trains foreign key (TrainId)
	references Trains (Id)
	on delete cascade
	on update cascade