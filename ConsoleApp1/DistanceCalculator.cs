using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMosteniriInterfete
{
   public static class DistanceCalculator
   {
      public static double CalculeazaDistanta(Punct punct1, Punct punct2)
      {
         return Math.Sqrt(Math.Pow(punct1.CoordX - punct2.CoordX, 2)
            + Math.Pow(punct1.CoordY - punct2.CoordY, 2));
      }
   }
}
