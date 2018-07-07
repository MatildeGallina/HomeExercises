using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateExercise1
{
    /*
     * Lista di impiegati
     * Gli impiegati sono pagati in modo diverso
     * 1) salario fisso: hanno una quota mensile
     *      e gli viene accreditata l'ultimo del mese
     * 2) a commissioni: per ogni vendita
     *      ricevono una percentuale
     *      sono pagati ongi fine settimana (venerdi)
     * 
     * Ogni impiegato deve tener traccia delle sue vendite
     * una vendita ha: data, importo
     * 
     * L'applicazione ogni giorno itera gli impiegati
     * se è giorno di paga da lo stipendio
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Mario",
                    Contract = TipoContratto.Fixed,
                    Sales = {
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 25.50m },
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 150m}
                    }
                },
                new Employee { Name = "Luigi",
                    Contract = TipoContratto.Percentage,
                    Sales = {
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 25.50m },
                        new Sale { Date = new DateTime(2018, 6, 3), Amount = 49.99m},
                        new Sale { Date = new DateTime(2018, 6, 11), Amount = 200m},
                        new Sale { Date = new DateTime(2018, 6, 13), Amount = 10}
                    }
                },
                new Employee { Name = "Anna",
                    Contract = TipoContratto.Fixed,
                    Sales = {
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 25.50m },
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 300},
                        new Sale { Date = new DateTime(2018, 6, 1), Amount = 20.01m}
                    }
                }
            };
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public TipoContratto Contract { get; set; }
        public List<Sale> Sales { get; set; }
    }

    class Sale
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

    class SalaryCalculator
    {

        //public static IReadOnlyList<SalaryCalculator> Calculators { get; }

        //public SalaryCalculator ForFixed { get; }
        //public SalaryCalculator ForPercentage { get; }

        public decimal FixedSalary { get; set; }
        public decimal PercentageSalary { get; }
        public DateTime Today { get; set; }

        public decimal CalculateSalary(Employee e)
        {

            if(e.Contract == TipoContratto.Fixed)
            {
                e.Salary = FixedSalary;
            }
            else if (e.Contract == TipoContratto.Percentage && Today.DayOfWeek == DayOfWeek.Friday)
            {
                var salesOfWeek = e.Sales
                    .Select(x => x)
                    .Where(x => x.Date.DayOfYear > (Today.DayOfYear - 6))
                    .ToList();

                foreach (Sale sale in salesOfWeek)
                    e.Salary += (sale.Amount * PercentageSalary);
                return e.Salary;
            }

            return e.Salary;
        }
    }

    enum TipoContratto
    {
        Fixed,
        Percentage
    }
}
