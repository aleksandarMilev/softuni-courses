using System;
namespace _06._Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double skumriqPriceForKg = double.Parse(Console.ReadLine());
            double cacaPriceForkg = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());

            double palamudPrice = skumriqPriceForKg * 1.6;
            double palamudSum = palamudPrice * kgPalamud;
            double safridPrice = cacaPriceForkg * 1.8;
            double safridSum = safridPrice * kgSafrid;
            double midiSum = kgMidi * 7.5;
            double totalSum = palamudSum + safridSum + midiSum;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}