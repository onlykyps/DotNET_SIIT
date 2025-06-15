using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace TemeSIIT
{
   class Program
   {
      static List<string> numereDistincte = new List<string>{"zero", "one", "two", "three",
                                                "four", "five","six", "seven", "eight",
                                                "nine","ten", "eleven", "twelve", "thirteen",
                                                "fourteen", "fifteen", "sixteen", "seventeen",
                                                "eighteen", "nineteen"};

      static List<string> dupaZece = new List<string>{"twenty", "thirty", "fourty", "fifty",
                                                "sixty", "seventy", "eighty", "ninety"};


      static void Main(string[] args)
      {
         string raspunsFinal = null;
         Console.WriteLine("Introduceti numar intreg pentru convertire in string: ");
         int input = int.Parse(Console.ReadLine());

         List<int> numarFragmentat = AnalizaFragmentare(input);

         if (input >= 0 && input < 20)
         {
            raspunsFinal = numereDistincte[input].ToString() + raspunsFinal;
         }
         else
         {
            for (int i=0; i < numarFragmentat.Count;  i++)
            {
               switch (i / 3)
               {
                  case 0:
                     raspunsFinal = ScriuPrimulSetDeTrei(raspunsFinal, numarFragmentat[i], i);
                     break;
                  case 1:
                     if (i % 3 == 0)
                        raspunsFinal = " thousand " + raspunsFinal;
                     raspunsFinal = ScriuAlDoileaSetDeTrei(raspunsFinal, numarFragmentat[i], i);
                     break;
                  case 2:
                     if (i % 3 == 0)
                        raspunsFinal = " million " + raspunsFinal;
                     raspunsFinal = ScriuAlTreileaSetDeTrei(raspunsFinal, numarFragmentat[i], i);
                     break;

               }

            }
         }

         Console.WriteLine($"Numarul in string este {raspunsFinal}");
           
      }

      public static string ScriuPrimulSetDeTrei(string raspunsFinal, int numar, int pozitie) 
      {
         switch(pozitie % 3)
         {
            case 0: 
               raspunsFinal = numereDistincte[numar].ToString() + raspunsFinal;
               break ;
            case 1:
               raspunsFinal = dupaZece[numar - 2].ToString() + "-" + raspunsFinal;
               break;
            case 2:
               raspunsFinal = numereDistincte[numar].ToString() + " hundred "+ raspunsFinal;
               break;

         }

         return raspunsFinal;
      }

      public static string ScriuAlDoileaSetDeTrei(string raspunsFinal, int numar, int pozitie)
      {
         raspunsFinal = ScriuPrimulSetDeTrei("", numar, pozitie) + raspunsFinal;

         return raspunsFinal;
      }

      public static string ScriuAlTreileaSetDeTrei(string raspunsFinal, int numar, int pozitie)
      {
         raspunsFinal = ScriuPrimulSetDeTrei("", numar, pozitie) + raspunsFinal;

         return raspunsFinal;
      }

      public static List<int> AnalizaFragmentare(int numarPentruAnaliza)
      {
         List<int> numarAnalizat = new List<int>();
         while(numarPentruAnaliza != 0 )
         {
            numarAnalizat.Add(numarPentruAnaliza % 10);
            numarPentruAnaliza = numarPentruAnaliza / 10;
         }

         return numarAnalizat;
      }
   }
}
