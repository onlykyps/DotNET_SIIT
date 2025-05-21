using ClaseMosteniriInterfete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Dreptunghi : Polygon
   {
      private static byte _nrPuncte = 4;

      public Dreptunghi
         (
            (double x, double y) p1,
            (double, double) p2,
            (double, double) p3,
            (double, double) p4,
            Culoare culoare

         ) : base(culoare, _nrPuncte, p1, p2, p3, p4)
      {
         Console.WriteLine("In CTOR Dreptunghi");

      }


      public override double CalculeazaArie()
      {
         return DistanceCalculator.CalculeazaDistanta(_puncte[0], _puncte[1]) *
             DistanceCalculator.CalculeazaDistanta(_puncte[1], _puncte[2]);
      }

   }
}
