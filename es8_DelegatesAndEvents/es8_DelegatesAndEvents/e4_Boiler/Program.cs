using System;

namespace e4_Boiler
{
    /* Un bollitore elettrico ha tre componenti:
    * - un pulsante di accensione, che se premuto spara un evento "Acceso";
    * - uno che misura la temperatura del liquido da scaldare, e lancia un evento
    *   quando la temperatura sale (lancia l'evento solo a scaglioni di 10 gradi).
    * - un altro per illuminare un led di rosso o di verde.
    * 
    * Questo terzo componente ascolta gli eventi dei primi due. Quando il bollitore
    * si accende, il led deve diventare rosso. Quando il liquido supera i 100 gradi,
    * la luce deve diventare verde.
    * 
    * Si possono simulare le luci con una semplice proprietà di tipo string, che sarà
    * "Spento", "Verde", "Rosso", oppure con una opportuna Enum.
    * 
    * Allo stesso modo, si può simulare la registrazione dell'aumento di temperatura
    * con un metodo pubblico sul secondo componente, a cui passare di volta in volta
    * l'aumento di temperatura registrato.
    * 
    * Il componente di temperatura ha un metodo che riceve la temperatura e la salva
    * in una proprietà. Appena uno scaglione di 10 gradi è superato, lancia l'evento,
    * che avrà come parametro la temperatura. Il terzo componente che ascolta questo
    * evento, decide se cambiare colore o meno.
    * 
    */

    class Program
    {
        static void Main(string[] args)
        { }
    }

    public class Kettle
    {
        public bool KettelOn = false;
        public int Temperature = 15;
        public Color LED = Color.Off;
    }

    public class PowerButton
    {
        event Action<Kettle> KettlePowerOn;

        public void PressedPowerButton(WarningLED warning, Kettle k)
        {
            KettlePowerOn += warning.TurnKettleOn;
            if(!k.KettelOn)
                KettlePowerOn.Invoke(k);
            else
            {
                k.KettelOn = false;
                k.LED = Color.Off;
                k.Temperature = 15;
            }
        }
    }

    public class LiquidButton
    {
        event Action<Kettle> IncreasernTemperature;

        public void IncresedLiquidTemperature(WarningLED warning, Kettle k)
        {
            if(k.KettelOn)
               k.Temperature += 10;
            IncreasernTemperature += warning.RisingTemperature;
            IncreasernTemperature.Invoke(k);
        }
    }

    public class WarningLED
    {
        public void TurnKettleOn(Kettle k)
        {
            k.KettelOn = true;
            k.LED = Color.Red;
        }

        public void RisingTemperature(Kettle k)
        {
            if (k.Temperature > 100)
                k.LED = Color.Green;
        }
    }

    public enum Color
    {
        Off,
        Red,
        Green
    }
}
