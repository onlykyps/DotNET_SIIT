using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfism
{
   public class Instrument
   {
      public virtual void RedaNota()
      {
         Console.WriteLine("instrument");
      }
   }
}
