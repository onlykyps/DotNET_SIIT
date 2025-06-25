using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti adresa de email: ");
            string emailInput = Console.ReadLine();
            string emailOfuscat = null;

            if (Validare(emailInput))
            {
                char[] caractere = emailInput.ToCharArray();
               

                for (int i = 0; i < caractere.Length; i++)
                {
                    if (caractere[i] != '@')
                    {
                        emailOfuscat += "*";
                    }
                    else if (caractere[i] == '@')
                    {
                        emailOfuscat += emailInput.Substring(i);
                        Console.WriteLine($"Email-ul ofuscat este {emailOfuscat}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nu ati introdus un email valid");
            }
            
        }

        public static bool Validare(string emailDeValidat)
        {
            bool validARond = false;
            bool validDupaARond = false;
            int pozitie = 0;

            char[] caractere = emailDeValidat.ToCharArray();

            for (int i = 0; i < caractere.Length; i++)
            {
                if(caractere[i] == '@')
                {
                    validARond = true;
                    pozitie = i;
                }
            }

            for (int i = pozitie; i < caractere.Length; i++)
            {
                if (caractere[i] == '.')
                {
                    validDupaARond = true;
                }
            }

            return validARond && validDupaARond;
        }

    }
}
