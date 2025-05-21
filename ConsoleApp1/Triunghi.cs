using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMosteniriInterfete
{
   public class Triunghi: Polygon
   {
      //private Punct[] _puncte; //devine mostenit
      private static byte _nrPuncte = 3;

      public Triunghi
         (
            (double x, double y) p1,
            (double, double) p2,
            (double, double) p3,
            Culoare culoare

         ) : base(culoare, _nrPuncte, p1, p2, p3)    
      {
         _puncte = new Punct[3]
         {
            new Punct(p1.x, p1.y, culoare),
            new Punct(p2.Item1, p2.Item2, culoare),
            new Punct(p3.Item1, p3.Item2, culoare)
         };


      }

      //public void AfiseazaCampurile(Punct[] campurile)
      //{
      //   for (int i = 0; i < campurile.Length; i++)
      //   {
      //      campurile[i].Afiseaza();
      //   }
      //}

      public void Afiseaza()
      {
         foreach(Punct p in _puncte)
         {
            p.Afiseaza();
         }
      }

      public void MutareaPunctelor
         (
            (double x, double y)? p1 = null,
            (double x, double y)? p2 = null,
            (double x, double y)? p3 = null
         )
      {
         if (p1.HasValue) _puncte[0].Muta(p1.Value.x, p1.Value.y);
         if (p2.HasValue) _puncte[1].Muta(p2.Value.x, p2.Value.y);
         if (p3.HasValue) _puncte[2].Muta(p3.Value.x, p3.Value.y);
      }

      //private double CalculeazaLatura(Punct punct1, Punct punct2)
      //{
      //   return Math.Sqrt(Math.Pow(punct1.CoordX - punct2.CoordX, 2)
      //      + Math.Pow(punct1.CoordY - punct2.CoordY, 2));
      //}

      

      public double CalculeazaArie()
      {
         double semiPer = CalculeazaPerimetru() / 2;
         double prod = semiPer;

         for (byte p=0; p<3; p++)
         {
            prod *= semiPer - DistanceCalculator.CalculeazaDistanta(_puncte[p], _puncte[(p + 1) % 3]);
         }

         return Math.Sqrt(prod);
      }

      public static bool operator >= (Triunghi tr1, Triunghi tr2)
      {
         return tr1.CalculeazaArie() > tr2.CalculeazaArie();
      }

      public static bool operator <= (Triunghi tr1, Triunghi tr2)
      {
         return tr1.CalculeazaArie() < tr2.CalculeazaArie();
      }

   }
}
