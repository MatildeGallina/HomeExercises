use TrainStationDB;

select d.Time, t.Name
from Departures as d
join Trains as t on d.TrainId = t.Id
where DAY(d.[Time]) = DAY('2018-06-25')


