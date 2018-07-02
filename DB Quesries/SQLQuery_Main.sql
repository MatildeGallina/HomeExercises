use TrainStation

select CompanyName, SUM(case when DepartureId is not null then 1 else 0 end) as DepartureCount
from
(select c.Name as CompanyName, d.Id as DepartureId
from Companies as c 
left join  Trains as t on t.CompanyId = c.Id
left join Departures as d on d.TrainId = t.Id) companyDeparures
group by CompanyName


-- prima creo una tabella che contiene tutti i treni di ogni compagnia e il numero della loro partenza.
-- da questa tabella proietto in una seconda con il nome della compagnia e calcolo il totale dell partenze sommando se c'e una partenza effettiva (Id non null), se no sommo 0
--
-- 2 join annidate non bastano perchè:
-- inner join elimina le righe delle compagnie senza treni o con treni senza partenze: invece devono esserci e avere count 0;
-- left join fa venir fuori la riga della compagnia senza treni ma allora il count è 1 non più 0



select TrainId, count(*) as Count
from Departures
group by TrainId

-- partenze tatali per ogni treno



select DAY([Time]) as Day, [Rail]
from Departures
group by DAY([Time]), [Rail]

-- tabella per numero del giono, partenza al binario n.
-- altro modo per fare CAST DATETIME A DAY: cast(Time as date)

select DAY(d.[Time]) as Day, t.Name
from Departures as d, Trains as t
where Rail = 2 AND d.TrainId = t.Id
group by DAY(d.[Time]), t.Name


select current_trains.Name, inner_result.Count
from 
    (select TrainId, count(*) as Count
    from Departures
    group by TrainId) inner_result,
    Trains as current_trains
where current_trains.Id = inner_result.TrainId
group by current_trains.Name, inner_result.Count

-- tabella annidata: conta quante partenze ci sono per un determinato treno, raggruppando per TrainId
-- tabella esterna: collega la tabella a Train per ricavare il nome di ogni treno

select t.Name, count(*) as Count
from Departures as d, Trains as t
where d.TrainId = t.Id
group by t.Name

-- stesso risultato finale senza query annidata



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

-- Nome del treno, media delle partenze al giorno



	-- media arrotondata
select c.Name, (count(*)/count(distinct cast(Time as date))) as DeparturesPerDay
from Companies as c
join Trains as t on t.CompanyId = c.Id
join Departures as d on d.TrainId = t.Id
group by c.Name

-- Nome della compagnia, media delle partenze dei suoi treni al giorno


-- la compagnia con più partenze e quella con meno (operatori `max` e `min`
   -- su un aggregato fatto col `group by`...)

select c.Name, MAX(inner_table.Count) as MAX
	from
		(select TrainId, count(*) as Count
		from Departures
		group by TrainId) inner_table
	left join Trains as t on t.Id = inner_table.TrainId
	left join  Companies as c on c.Id = t.CompanyId
group by c.Name


-- 1: raggruppo le partenze per ogni compagnia
-- 2: le sommo
-- 3: trovo max e min
select *
from
	(select c.Id, sum(case when company_departures.DepartureId is not null then 1 else 0 end) as TotalDepartures
	from
		(select c.Id as CompanyId, d.Id as DepartureId
		from Companies as c
		left join Trains as t on t.CompanyId = c.Id
		left join Departures as d on d.TrainId = t.Id) company_departures
	left join Companies as c on c.Id = company_departures.CompanyId
	group by c.Id) company_totalDepartures
group by company_totalDepartures.Id, company_totalDepartures.TotalDepartures
having TotalDepartures = MAX(TotalDepartures)

-- trovo il massimo delle partenze ma non riesco a mettere nella tabella anche il nome della compagnia



--	 -- in the projection
--	 -- I can aggregate data and do calculation
--	 select
--	 	 (CAST(Id AS VARCHAR(16)) + ' ' + Name) as Employee,
--		 (Salary / 12) as MonthlySalary
--	 from Persons
--	 where Id = 3


--	 -- WHERE vs HAVING
--
--	 -- if I want to filter on the initial un-aggregate rows, I use WHERE
--	 -- if I want to filter the groups, I use HAVING.
--	 select Employee, count(*) as BillCount
--	 from
--		 (select Employee, BillId
--		 from Invoices
--		 where ProductName = 'Falciatrice' -- WHERE filters the rows of Invoices
--	 	 group by Employee, BillId
--	 	 having Employee = 'Luigi') t -- HAVING filters the groups Employee+BillId
--	 where BillId > 0 -- WHERE filters the rows of Invoices
--	 group by Employee
-- 	 having count(*) < 2 -- HAVING filters the groups Employee+Count