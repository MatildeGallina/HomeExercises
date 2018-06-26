use TrainStationDB

select *
from Departures

select cast(d.Time as time) as Time, t.Name, d.Destination
from Departures as d, Trains as t
where d.TrainId = t.Id and DAY(d.Time) = DAY('2018-06-25')

insert into Departures
    (Time, Rail, Destination, TrainId)
values
    ('20180625 15:01:00', 5, 'Pordenone', 1)

alter table Departures
add constraint FK_Departures_Trains foreign key (TrainId)
    references Trains (Id) 
    on delete cascade
    on update cascade

alter table Trains
add constraint FK_Trains_Companies foreign key (CompanyId)
    references Companies (Id) 
    on delete cascade
    on update cascade