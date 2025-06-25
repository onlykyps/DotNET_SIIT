using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] listaDeParcurs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            Console.WriteLine("Introduceti un numar pentru a fi verificat: ");
            int intInput = Int32.Parse(Console.ReadLine());
            bool gasit = false;

            for (int i = 0; i < listaDeParcurs.Length; i++)
            {
                if (listaDeParcurs[i] == intInput)
                {
                    Console.WriteLine($"Numarul {intInput} se afla in lista la pozitia {i}");
                    gasit = true;
                    break;
                }


            }

            if (!gasit) 
            {
                Console.WriteLine($"Numarul {intInput} nu se afla in lista de parcurs "); 
            }

        }
    }
}
