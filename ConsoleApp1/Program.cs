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

         // redundant
         blue.Alpha = 0xFF;
         blue.Red = 0x00;
         blue.Green = 0x00;
         blue.Blue = 0xFF;

         Punct p1 = new Punct(10,5, blue);
        
         p1.CoordX = 10;
         p1.CoordY = 5;
         p1.Culoare = blue;

         //p1._culoare._alpha = 0xFF;
         //p1._culoare._red = 0x00;
         //p1._culoare._green = 0x00;
         //p1._culoare._blue = 0xFF;

         Culoare red = new Culoare(0xFF, 0xFF, 0x00, 0x00);

         // redundant
         Punct p2 = new Punct(7, 9, red)
         {
            CoordX = 7,
            CoordY = 9

         };

      }
   }
}
