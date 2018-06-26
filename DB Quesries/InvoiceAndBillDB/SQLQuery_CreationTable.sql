use BillInvoice;

create table [InvoiceModel]
(
    [Id] [int] IDENTITY(1, 1) NOT NULL primary key,
    [Name] [nvarchar](MAX) NOT NULL,
    [Price] [float] NOT NULL,
    [Quantity] [int] NOT NULL,
    [BillId] [int] NOT NULL,
    [BillEmission] [datetime] NOT NULL,
    [Employee] [nvarchar](MAX) NOT NULL
)

