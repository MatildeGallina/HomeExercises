using System;
using System.Collections.Generic;
using System.Text;

namespace _2_StatisticAnalizerWithObj
{
    class StatisticAnalizer
    {
        public IInputOutput _inputOutput;

        public StatisticAnalizer(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public void Run()
        {
            List<double> inputValues = new List<double>();

            uint count = _inputOutput.ReadNumberInt();
            // fa partire le richieste di dati
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{i + 1}: ");
                double value = _inputOutput.ReadNumberDouble();
                inputValues.Add(value);
            }

            // fa i calcoli statistici
            StatisticContainers sc = StatisticOperations(inputValues);

            PrintStaitstics(sc);
        }

        public StatisticContainers StatisticOperations(List<double> inputValues)
        {
            double averege = 0;
            foreach(double v in inputValues)
                averege += v;

            averege /= (inputValues.Count);

            double standardDeviation = 0;
            foreach (double v in inputValues)
                standardDeviation += (v - averege) * (v - averege);

            standardDeviation /= (inputValues.Count);
            standardDeviation = Math.Sqrt(standardDeviation);

            return new StatisticContainers(averege, standardDeviation);
        }

        public void PrintStaitstics (StatisticContainers sc)
        {
            _inputOutput.WriteString("average " + sc.Average);
            _inputOutput.WriteString("standard deviation " + sc.StandardDeviation);
        }
    }

    class StatisticContainers
    {
        public StatisticContainers(double average, double standardDeviation)
        {
            Average = average;
            StandardDeviation = standardDeviation;
        }

        public double Average { get; }
        public double StandardDeviation { get; }
    }
}
