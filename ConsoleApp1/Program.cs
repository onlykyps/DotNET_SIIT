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
         Punct p1 = new Punct();
         Culoare blue = new Culoare();
         p1.CoordX = 10;
         p1.CoordY = 5;

         blue.Alpha = 0xFF;
         blue.Red = 0x00;
         blue.Green = 0x00;
         blue.Blue = 0xFF;
         
         p1.Culoare = blue;

         //p1._culoare._alpha = 0xFF;
         //p1._culoare._red = 0x00;
         //p1._culoare._green = 0x00;
         //p1._culoare._blue = 0xFF;

         Punct p2 = new Punct
         {
            CoordX = 7,
            CoordY = 9
           
         };
        
      }
   }
}
