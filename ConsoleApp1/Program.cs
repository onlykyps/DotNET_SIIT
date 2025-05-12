using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Program
   {
      struct TwoFields
      {
         public ushort _2f1; 
         public ushort _2f3;
      }

      struct FourFields
      {
         public byte _4f1;
         public byte _4f2;
         public byte _4f3;
         public byte _4f4;
      }

      static void Main(string[] args)
      {
         TwoFields twoF;
         twoF._2f1 = 0xF11F;
         twoF._2f3 = 0xABBA;

         //Console.WriteLine("{0:X}{1:X}", twoF._2f3, twoF._2f1);

         FourFields fourFields = new FourFields();
         //fourFields._4f1 = twoF._2f1/2;
         fourFields._4f1 = (byte)twoF._2f1;

         //fourFields._4f2 = twoF._2f1/2;
         fourFields._4f2 = (byte)(twoF._2f1/256);

         fourFields._4f3 = (byte)(twoF._2f3/256);
         fourFields._4f4 = (byte)(twoF._2f3/256);

         //Console.WriteLine("{0:X}{1:X}{2:X}{3:X}", fourFields._4f1, fourFields._4f2, fourFields._4f3, fourFields._4f4);

         TwoFields threeTwoF = twoF;

         //Console.WriteLine("{0:X}{1:X}", threeTwoF._2f1, threeTwoF._2f3);

         threeTwoF._2f1 = 0xB116;
         //Console.WriteLine("{0:X}{1:X}", twoF._2f1, twoF._2f3);
         //Console.WriteLine("{0:X}{1:X}", threeTwoF._2f1, threeTwoF._2f3);


         Culoare blue = new Culoare(0xFF, 0x00, 0x00, 0xFF);
         //Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);

         // redundant
         blue.Alpha = 0xFF;
         blue.Red = 0x00;
         blue.Green = 0x00;
         blue.Blue = 0xFF;

         Punct p1 = new Punct(10,5, blue);
        
         p1.CoordX = 10;
         p1.CoordY = 5;
         p1.Culoare = blue;

         //Console.WriteLine("Contor are valoarea {0}",Punct.Contor);

         //p1._culoare._alpha = 0xFF;
         //p1._culoare._red = 0x00;
         //p1._culoare._green = 0x00;
         //p1._culoare._blue = 0xFF;

         Culoare red = new Culoare(0xFF, 0xFF, 0x00, 0x00);
         //Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);

         // redundant
         Punct p2 = new Punct(7, 9, red)
         {
            CoordX = 7,
            CoordY = 9

         };

         //Console.WriteLine("Contor are valoarea {0}", Punct.Contor);

         Punct p3 = p1;

         //Console.WriteLine("Contor are valoarea {0}", Punct.Contor);
         //Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);

         //p1.Afiseaza();
         //p2.Afiseaza();

         //p1.ComplementeazaCuloarea();
         //p1.Inverseaza();
         //p1.Afiseaza();

         //p1.Muta(13,15);

         Triunghi triunghi = new Triunghi((0,0), (2, 0), (0,4), blue);
         //triunghi.Afiseaza();
         triunghi.MutareaPunctelor((1, 1), (2, 1), (5, 1));
         //triunghi.Afiseaza();

         triunghi.MutareaPunctelor((0, 0), (3, 0), (3, 4));
         //triunghi.Afiseaza();
         triunghi.MutareaPunctelor((0, 0), (3, 0));
         triunghi.MutareaPunctelor(p3:(3, 4));

         triunghi.MutareaPunctelor(p1: (6, 0));

         Console.WriteLine($"Perimetrul triunghiului este {triunghi.CalculeazaPerimetru()}");

         double a = 20;
         double b = 39;

         Console.WriteLine($"Max dintre {a} si {b} e {MaxFinder.GetMax(a, b)}") ;

         Punct pctMax = MaxFinder.GetMax(p1, p2);
         pctMax.Afiseaza();

         Triunghi nouTriungi = new Triunghi((5, 6), (7, 8), (8, 9), red);

         Triunghi maxTriunghi = MaxFinder.GetMax(triunghi, nouTriungi);
         Console.Write("Afiseaza cel mai mare triunghi");
         maxTriunghi.Afiseaza();

         Console.WriteLine($"Maximul dintre 2, 5, 2, 4, 9 si 0 e {MaxFinder.GetMax(2, 5, 2, 4, 9, 0)}");

         Console.WriteLine($"Maximul dintre 4.5, 4.8, 4.75, 4.6, 4.9 si 4 e " +
            $"{MaxFinder.GetMax(4.5, 4.8, 4.75, 4.6, 4.9, 4)}");

      }
   }
}
