using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var models = new List<InvoiceModel>
            {
                new InvoiceModel(1, "Falciatrice", 74.99m, 2, 1, 2018, 6, 14, 9, 30, 12, "Mario"),
                new InvoiceModel(2, "Sega Elettrica", 150m, 3, 1, 2018, 6, 14, 9, 30, 12, "Mario"),
                new InvoiceModel(3, "Tritatutto", 39.99m, 1, 2, 2018, 6, 14, 20, 40, 00, "Mario"),
                new InvoiceModel(4, "Concime", 5.99m, 10, 3, 2018, 6, 16, 12, 12, 12, "Luigi"),
                new InvoiceModel(5, "Forbici", 7.89m, 10, 3, 2018, 6, 16, 12, 12, 12, "Luigi"),
                new InvoiceModel(6, "Tenaglie", 8.99m, 7, 3, 2018, 6, 16, 12, 12, 12, "Luigi"),
            };

            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "bill-export.xlsx");

            var billExp = new BillExporter(filePath);

            billExp.Export(models);
        }
    }

    class InvoiceModel
    {
        public InvoiceModel() { }

        public InvoiceModel(
            int id,
            string productName,
            decimal productPrice,
            int quantity,
            int billId,
            int year,
            int month,
            int day,
            int hour,
            int minute,
            int second,
            string employee)
        {
            Id = id;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
            BillId = billId;
            BillEmission = new DateTime(year, month, day, hour, minute, second);
            Employee = employee;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public DateTime BillEmission { get; set; }
        public string Employee { get; set; }
    }

    abstract class ExcelExport<T>
    {
        private string Path { get; set; }

        private IEnumerable<InvoiceModel> list;

        void Export(IEnumerable<InvoiceModel> list)
        {
            IEnumerable<T> result = Elaborate(list);

            var matrix = Transform(result);

            WriteOnExcel(matrix);
        }

        protected abstract IEnumerable<T> Elaborate(IEnumerable<InvoiceModel> list);

        protected abstract object Transform(IEnumerable<T> result);

        private void WriteOnExcel(object cells)
        {
            throw new NotImplementedException();
        }
    }

    class InvoiceModelExcelTable<T> : ExcelExport<T>
    {
        protected override IEnumerable<T> Elaborate(IEnumerable<InvoiceModel> list)
        {
            return (IEnumerable<T>)list;
        }

        protected override object Transform(IEnumerable<T> result)
        {
            var cells = new List<Cell>();

            AddHeaders(cells);
            AddValues(cells, result);

            return cells;
        }

        private void AddHeaders(List<Cell> cells)
        {
            var headers = new List<string>
            {
                "Bill Id", "Emission Date", "Employee", "Invoice Id",
                "Product Name", "Product Price", "Quantity"
            };

            for (int i = 0; i < headers.Count; i++)
            {
                cells.Add(new Cell { Row = 1, Column = i + 1, Value = headers[i] });
            }
        }

        private void AddValues(List<Cell> cells, IEnumerable<T> result)
        {
            int row = 2;

            foreach (var bill in result)
            {
                cells.Add(new Cell(row, 1, bill.Id));
                cells.Add(new Cell(row, 2, bill.Emission.ToString("yyyy/MM/dd")));
                cells.Add(new Cell(row, 3, bill.Employee));
                row++;

                foreach (var invoice in bill.Invoices)
                {
                    cells.Add(new Cell(row, 4, invoice.Id));
                    cells.Add(new Cell(row, 5, invoice.ProductName));
                    cells.Add(new Cell(row, 6, invoice.ProductPrice));
                    cells.Add(new Cell(row, 7, invoice.Quantity));
                    row++;
                }

                row++;
            }
        }
    }

    class SalesPerEmployeeExcelTable<T> : ExcelExport<T>
    {
        protected override IEnumerable<T> Elaborate(IEnumerable<InvoiceModel> list)
        {
            var salesPerEmployeeList = list
                            .GroupBy(x => x.Employee)
                            .Select(g => new
                                {
                                    Name = g.Key,
                                    TotalSales = g.Sum(im => im.ProductPrice * im.Quantity)
                                })
                            .ToList();

            return (IEnumerable<T>)salesPerEmployeeList;
        }

        protected override object Transform(IEnumerable<T> result)
        {
            //using (ExcelPackage paper = new ExcelPackage())
            //{
            //    ExcelWorksheet ws = paper.Workbook.Worksheets.Add("testsheet");

            //    ws.Cells["B1"].Value = "Employee";
            //    ws.Cells["C1"].Value = "Total sales";

            //    foreach(object o in result)
            //    {

            //    }
            //}

            throw new NotImplementedException();
        }
    }

    class BillInvoiceExcelTable<T> : ExcelExport<T>
    {
        protected override IEnumerable<T> Elaborate(IEnumerable<InvoiceModel> list)
        {
            var billInvoiceLlist = list
                        .GroupBy(x => x.BillId)
                        .Select(g => new
                        {
                            Id = g.Key,
                            Emission = g.First().BillEmission,
                            Employee = g.First().Employee,
                            Invoices = g.Select(im => new
                            {
                                Id = im.Id,
                                ProductName = im.ProductName,
                                ProductPrice = im.ProductPrice,
                                Quantity = im.Quantity
                            })
                                .ToList()
                        })
                        .ToList();

            return (IEnumerable<T>)billInvoiceLlist;
        }

        protected override object Transform(IEnumerable<T> result)
        {
            throw new NotImplementedException();
        }
    }

    public class Cell
    {
        public Cell() { }

        public Cell(int row, int column, object value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public object Value { get; set; }
    }
}




