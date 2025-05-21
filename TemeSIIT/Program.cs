using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TemeSIIT
{
   class Program
   {
      static void Main(string[] args)
      {
         //ROT3

         Console.WriteLine("Introduceti mesajul de codat:");
         String mesajDeCodat = Console.ReadLine();
         char[] mesajDeCodatSegementat = mesajDeCodat.ToCharArray();

         StringBuilder codificare = new StringBuilder();

         char[] alfabetul = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

         foreach (char c in mesajDeCodatSegementat)
         {
            for (int i = 0; i < alfabetul.Length; i++) 
            {
               
               if(Char.ToUpper(c) == alfabetul[i])
               {
                  codificare.Append
                     (
                        i+3 <= alfabetul.Length -1 ? alfabetul[i + 3] : alfabetul[i + 3 - alfabetul.Length]
                     );
               }
            }
           
         }

         Console.WriteLine(codificare.ToString());


      }
   }
}
