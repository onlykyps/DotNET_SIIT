using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMosteniriInterfete
{
   public abstract class Polygon
   {
      protected Punct[] _puncte;

      public Polygon(Culoare cul, byte nrPct, params( double, double )[] coords)
      {
         Console.WriteLine("In CTOR Poligon");
         _puncte = new Punct[nrPct];

         for (byte i = 0; i< nrPct; i++)
         {
            _puncte[i] = new Punct(coords[i].Item1, coords[i].Item2, cul);
         }
      }

      public double CalculeazaPerimetru()
      {
         double perimetru = 0;
         for (int i = 0; i < _puncte.Length; i++)
         {
            perimetru += DistanceCalculator.CalculeazaDistanta(_puncte[i], _puncte[(i + 1) % _puncte.Length]);
         }

         return perimetru;
      }

      public abstract double CalculeazaArie();


   }
}
