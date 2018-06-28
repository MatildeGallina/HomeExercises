-- use TrainStationDB

-- create procedure GetActiveRails
--     @Day date
-- as
--     select cast([Time] as date) as Day, [Rail], Count(*) as DeparturesCount
--     from Departures
--     group by cast([Time] as date) , Rail
--     having cast([Time] as date)  = @Day

alter procedure GetActiveRails
    @Day date
as
    select [Rail], Count(*) as DeparturesCount
    from Departures
    group by cast([Time] as date) , Rail
    having cast([Time] as date)  = @Day


exec GetActiveRails @Day = '20180625'

alter table Departures
alter column [Destination] nvarchar(max) null


-- select current_company.Name, inner_result.Count
-- from 
--     (select Id, count(*) as Count
--     from Companies
--     group by Id) inner_result,
--     Companies as current_company
--     where current_company.Id = inner_result.Id

-- select c.Name, inner_count.Count
-- from
--     (select count(*) as Count
--     from Departures
--     group by TrainId) inner_count,
--     Companies as c, Trains as t, Departures as d
--     where c.Id = t.CompanyId

 select DAY([Time]) as Day, [Rail]
 from Departures
 group by DAY([Time]), [Rail]

 select TrainId, count(*) as Count
 from Departures
 group by TrainId

select c.Name, inner_result.Count
from
    (select CompanyId, count(*) as Count
    from Trains as t, Departures as d
    where cast(d.[Time] as date) = '2018-06-25' AND d.TrainId = t.Id
    group by CompanyId) inner_result,
    Companies as c
    where c.Id = inner_result.CompanyId
