using System;

namespace _2_StatisticAnalizerWithObj
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Prendere il simil - test sul calcolo statistico.
            *  Invece di implementarlo in modo procedurale, creare:
            *  - una classe `StatisticAnalyzer`, con un metodo `Run()`che fa partire le richieste di dati
            *    e alla fine i calcoli statistici
            *  - una classe `ConsoleIO`, con dei metodi `ReadNumber()`e `WriteString()` che leggono da Console
            *    in modo "safe"(come già visto, con un while e un TryParse...), e scrivono in output.
            *  - una classe `FileIO` che abbia gli stessi due metodi, ma legga gli input da un file, e scriva
            *    gli output su un altro file(i percorsi dei due file vanno indicati nel costruttore)
            *  - una interfaccia `IInputOutput` con questi due metodi
            *  - `StatisticAnalyzer` accetta nel costruttore un'instanza dell'interfaccia `IInputOutput`, la
            *    salva in un campo privato, e la usa per chiedere il prossimo valore statistico, o scrivere in
            *    output un messaggio.
            *  - Il `Main()` deve solo istanziare le varie classi nell'ordine corretto, poi chiamare `Run()`
            *    sullo `StatisticalAnalyzer`.
            */

            StatisticAnalizer sa = new StatisticAnalizer(new ConsoleIO());
            sa.Run();

            Console.ReadLine();

        }
    }
}
