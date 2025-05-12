using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public static class MaxFinder
   {
      public static int GetMax(int a, int b)
      {
         return a > b ? a : b;
      }

      public static double GetMax(double a, double b) 
      {
         return a > b ? a : b; 
      }

      public static Punct GetMax(Punct p1, Punct p2)
      {
         return (Math.Pow(p1.CoordX, 2) + Math.Pow(p2.CoordY, 2) >=
            Math.Pow(p2.CoordX, 2) + Math.Pow(p2.CoordY, 2)) ? p1 : p2;
      }

      public static Triunghi GetMax(Triunghi tr1, Triunghi tr2)
      {
         return tr1 >= tr2 ? tr1 : tr2;
      }

   }
}
