use TrainStationDB;

-- insert into Trains
--     (Name, Seats, StepHeight, CompanyId)
-- values
--     ('Regionale Veloce 6209', 100, 0.8, 1),
--     ('Italo', 400, 1.2, 2)


select * from Companies;
select * from Trains;
select * from Departures;

-- delete from Departures where Id in (1004)

-- insert into Companies
--     (Name, Nationality)
-- values
--     ('Trenord', 'Italia')

-- select * from Companies
-- where [Name] like '%tren%'

-- select count(*) as CountOfCompanies from Companies

 --select TrainId, count(*) as Count
 --from Departures
 --group by TrainId

 --select DAY([Time]) as Day, [Rail]
 --from Departures
 --group by DAY([Time]), [Rail]

-- select Rail, count(*) as Count
-- from Departures
-- group by Rail 

select current_trains.Name, inner_result.Count
from 
    (select TrainId, count(*) as Count
    from Departures
    group by TrainId) inner_result,
    Trains as current_trains
    where current_trains.Id = inner_result.TrainId
