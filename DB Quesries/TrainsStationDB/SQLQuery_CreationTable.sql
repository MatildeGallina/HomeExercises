use TrainStationDB;

create table [Companies]
(
    [Id] [int] identity(1,1) not null primary key,
    [Name] [nvarchar](MAX) not null,
    [Nationality] [nvarchar](MAX) not null
)

create table [Trains]
(
    [Id] [int] identity(1,1) not null primary key,
    [Name] [nvarchar](MAX) not null,
    [Seats] [int] not null,
    [StepHeight] [float] not null,
    [CompanyId] [int] not null
)

create table [Departures]
(
    [Id] [int] identity(1, 1) not null primary key,
    [Time] [DateTime] not null,
    [Rail] [int] not null,
    [Destination] [nvarchar](MAX) not null,
    [TrainId] [int] not null
)