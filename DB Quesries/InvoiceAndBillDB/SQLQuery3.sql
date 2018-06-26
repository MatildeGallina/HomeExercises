use BillInvoice;

select * from InvoiceModel

-- select InvoiceModel.Employee, sales.TotalSales
-- from
--     (select [Price], [Quantity]
--     from InvoiceModel) sales


select [Employee], sum([Price] * [Quantity]) as TotalSalesEmployee
from InvoiceModel
group by [Employee]

select [BillId], [BillEmission], sum([Price] * [Quantity]) as TotalSalesBill
from InvoiceModel
group by [BillId], [BillEmission]

select Employee, count(*) as BillCount
from 
    (select Employee, BillId
    from InvoiceModel
    group by Employee, BillId) t
group by Employee

select Employee, count(distinct BillId) as TotalSalesBill
from InvoiceModel
group by Employee

select distinct Employee, BillId
from InvoiceModel
