-- create database Chess;

-- create table Whites
-- (
--     Id int identity primary key not null,
--     Name varchar(max) not null,
--     TableId int null
-- )
-- create table Blacks
-- (
--     Id int identity primary key not null,
--     Name varchar(max) not null,
--     TableId int null
-- )

-- insert into Whites
--     (Name, TableId)
-- values
--     ('Mario', null),
--     ('Luigi', 1),
--     ('Anna', 2),
--     ('Elisa', 3),
--     ('Marco', null)

-- insert into Blacks
--     (Name, TableId)
-- values
--     ('Carlo', null),
--     ('Barbara', 2),
--     ('Filippo', null),
--     ('Gabriele', null),
--     ('Ugo', 1)

-- select w.Name, b.Name, w.TableId
-- from Whites as w, Blacks as b
-- where w.TableId = b.TableId


-- COME GESTIRE NULL
select * from Whites
where TableId is null


-- select White
-- from
--     (select w.Name as White, b.Name as Black, w.TableId
--     from Whites as w, Blacks as b
--     where w.TableId is null OR w.TableId = b.TableId) t
-- group by White


-- INNER JOIN: NO NULL
select w.Name as White, b.Name as Black, w.TableId as TableId
from Whites as w
join Blacks as b on w.TableId = b.TableId

-- LEFT JOIN
select w.Name as White, b.Name as Black, w.TableId as TableId
from Whites as w
left join Blacks as b on w.TableId = b.TableId

-- RIGHT JOINT
select w.Name as White, b.Name as Black, w.TableId as TableId
from Whites as w
right join Blacks as b on w.TableId = b.TableId

-- FULL OUTER JOIN
select w.Name as White, b.Name as Black, w.TableId as TableId
from Whites as w
full outer join Blacks as b on w.TableId = b.TableId
order by w.Id