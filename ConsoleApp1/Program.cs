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
         p1._x = 10;
         p1._y = 5;

         Punct p2 = new Punct
         {
            _x = 7,
            _y = 9
         };
        
      }
   }
}
