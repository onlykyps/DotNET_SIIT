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
         p1._x = 10;
         p1._y = 5;

         blue._alpha = 0xFF;
         blue._red = 0x00;
         blue._green = 0x00;
         blue._blue = 0xFF;
         
         p1._culoare = blue;

         //p1._culoare._alpha = 0xFF;
         //p1._culoare._red = 0x00;
         //p1._culoare._green = 0x00;
         //p1._culoare._blue = 0xFF;

         Punct p2 = new Punct
         {
            _x = 7,
            _y = 9
           
         };
        
      }
   }
}
