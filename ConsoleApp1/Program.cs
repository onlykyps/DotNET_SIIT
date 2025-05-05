using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Program
   {
      static void Main(string[] args)
      { 
         Culoare blue = new Culoare(0xFF, 0x00, 0x00, 0xFF);
         Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);

         // redundant
         blue.Alpha = 0xFF;
         blue.Red = 0x00;
         blue.Green = 0x00;
         blue.Blue = 0xFF;

         Punct p1 = new Punct(10,5, blue);
        
         p1.CoordX = 10;
         p1.CoordY = 5;
         p1.Culoare = blue;

         Console.WriteLine("Contor are valoarea {0}",Punct.Contor);

         //p1._culoare._alpha = 0xFF;
         //p1._culoare._red = 0x00;
         //p1._culoare._green = 0x00;
         //p1._culoare._blue = 0xFF;

         Culoare red = new Culoare(0xFF, 0xFF, 0x00, 0x00);
         Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);

         // redundant
         Punct p2 = new Punct(7, 9, red)
         {
            CoordX = 7,
            CoordY = 9

         };

         Console.WriteLine("Contor are valoarea {0}", Punct.Contor);

         Punct p3 = p1;

         Console.WriteLine("Contor are valoarea {0}", Punct.Contor);
         Console.WriteLine("Contor culoare are valoarea {0}", Culoare.Contor);
      }
   }
}
