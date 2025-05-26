using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
   public class Program
   {
      static void Main(string[] args)
      {
         Instrument vioara = new Vioara();
         Instrument pian = new Pian();
         Instrument flaut = new Flaut();

         vioara.RedaNota();
         pian.RedaNota();
         flaut.RedaNota();


      }
   }
}
