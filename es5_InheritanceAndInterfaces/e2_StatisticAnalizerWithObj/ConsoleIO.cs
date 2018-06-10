using System;
using System.Collections.Generic;
using System.Text;

namespace e2_StatisticAnalizerWithObj
{
    public class ConsoleIO : IInputOutput
    {
        public uint ReadNumberInt()
        {
            Console.Write("Quanti numeri vuoi inserire? ");
            uint n;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = uint.TryParse(input, out n);

                if (canConvert)
                    break;

                Console.Write("L'inserimento deve essere un numero positivo.\n\rInserirsci: ");
            }
            while (!canConvert);

            return n;
        }

        double IInputOutput.ReadNumberDouble()
        {
            double d;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = double.TryParse(input, out d);

                if (canConvert)
                    break;

                Console.Write("L'inserimento deve essere valido.\n\rDevi inserire un numero: ");
            }
            while (!canConvert);

            return d;
        }

        void IInputOutput.WriteString(string output)
        {
            Console.WriteLine(output);
        }
    }
}
