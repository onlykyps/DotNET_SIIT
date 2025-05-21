using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMosteniriInterfete
{
   public static class MaxFinder
   {
      // pentru siguranta, trecem un set de metode in privat
      private static int GetMax(int a, int b)
      {
         return a > b ? a : b;
      }

      private static double GetMax(double a, double b) 
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

      // pentru a nu fi incurcate de copilatoare mai vechi
      // care nu stiu care e diferenta intre metode cu un set dat sau nestiut de parametri
      public static int GetMax(params int[] parametri)
      {
         int maxim = 0;

         for (int i = 0; i < parametri.Length; i++)
         {
            maxim = GetMax(maxim, parametri[i]);
         }

         return maxim;
      }

      public static double GetMax(params double[] parametri)
      {
         double maxim = 0;

         for (int i = 0; i < parametri.Length; i++)
         {
            maxim = GetMax(maxim, parametri[i]);
         }

         return maxim;
      }

   }
}
