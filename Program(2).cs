using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> municipalitati = new Dictionary<string, double[]>();

            municipalitati.Add("Cluj", [2, 3]);
            municipalitati.Add("Iasi", [9, 8]);
            municipalitati.Add("Brasov", [7, 3]);
            municipalitati.Add("Huedin", [4, 8]);
            municipalitati.Add("Dej", [5, 2]);

            string afisareMunicipalitati = "Municipalitatile de comparat sunt ";

            foreach (var mun in municipalitati)
            {
                afisareMunicipalitati += mun.Key.ToString() + $" la x={mun.Value[0]} si y={mun.Value[1]}" + ", ";
            }

            Console.WriteLine(afisareMunicipalitati.Substring(0, afisareMunicipalitati.Length - 2) + ".");

            Console.WriteLine("Introduceti un nou oras: ");
            string nouOras = Console.ReadLine();
            Console.WriteLine($"Coordonata x a {nouOras}");
            int coordX = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Coordonata y a {nouOras}");
            int coordY = Int32.Parse(Console.ReadLine());

            double distantaCeaMaiMica = 0;
            double distantaCalculata = 0;

            double xAfisare = 0;
            double yAfisare = 0;
            string orasGasit = null;

            foreach (var mun in municipalitati)
            {
                distantaCalculata = Math.Sqrt(
                                                (mun.Value[0] - coordX) * (mun.Value[0] - coordX) + 
                                                (mun.Value[1] - coordY) * (mun.Value[1] - coordY)
                                              );
                if (distantaCeaMaiMica == 0 || distantaCalculata < distantaCeaMaiMica)
                {
                    distantaCeaMaiMica = distantaCalculata;
                    xAfisare = mun.Value[0];
                    yAfisare = mun.Value[1];
                    orasGasit = mun.Key;
                }
            }

            Console.WriteLine($"Orasul cel mai apropiat de orasul {nouOras}" +
                $" este orasul {orasGasit}");

        }
    }
}
