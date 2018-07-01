USE TrainStation;


-- table withi time, train name and company name

	-- WHERE
select d.[Time], t.[Name], c.[Name]
from Departures as d, Trains as t, Companies as c
where d.TrainId = t.Id AND t.CompanyId = c.Id;

	-- JOIN
select d.[Time], t.[Name], c.[Name]
from Departures as d
join Trains as t on t.Id = d.TrainId
join Companies as c on c.Id = t.CompanyId


-- Nome del treno, media delle partenze al giorno

	-- fa una media con la virgola
select t.Name, count(*)/TotalDays as AverageDeparturesPerDay
from
	(select cast(count(distinct cast([Time] as Date)) as float) as TotalDays
	from Departures) inner_table,
Trains as t
join Departures on t.Id = TrainId
group by t.Name, TotalDays

	-- fa la media arrotondando
select t.Name as Train, (count(*)/count(distinct cast(Time as date))) as DeparturesPerDay
from Trains as t
join Departures as d on t.Id = d.TrainId
group by t.Name


-- Nome della compagnia, media delle partenze dei suoi treni al giorno

	-- media arrotondata
select c.Name, (count(*)/count(distinct cast(Time as date))) as DeparturesPerDay
from Companies as c
join Trains as t on t.CompanyId = c.Id
join Departures as d on d.TrainId = t.Id
group by c.Name


-- per ogni giorno, conto di quante partenze ci sono

select cast(Time as date) as Day, count(*) as CountOfDepartures
from Departures
group by cast(Time as date)


-- per ogni ora, il conto di quante partenze ci sono (scelto un giorno X)

	-- NON RIESCO A RAGGRUPPARE PER ORA
select cast(Time as time(0)) as Hour, count(*) as DeparturesPerHour
from Departures
where cast(Time as date) = '2018-07-03'
group by cast(Time as time(0))


-- la compagnia con più partenze e quella con meno (operatori `max` e `min`
   -- su un aggregato fatto col `group by`...)



