using System;
using System.Reflection;

namespace ConsoleApp1
{
   class Program
   {
      static void Main(string[] args)
      {
         ushort input = ushort.Parse(Console.ReadLine());
         bool ePrim = false;

         for (ushort i = 2; i <= input / 2; i++) 
         {
            if(input % i == 0)
            {
               ePrim = false;
               break;
            }

            //if (input % i == 0)
            //{
            //   break;
            //   Console.WriteLine("numarul nu este prim");
            //}
            //else
            //{
            //   Console.WriteLine("numarul este prim");
            //}
         }

         if (!ePrim) Console.WriteLine("{0} nu e prim", input);
         else Console.WriteLine("{0} e prim", input);

      }
   }
}
