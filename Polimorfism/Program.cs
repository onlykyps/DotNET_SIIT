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
         IInstrument vioara = new Vioara();
         IInstrument pian = new Pian();
         IInstrument flaut = new Flaut();

         //vioara.RedaNota();
         //pian.RedaNota();
         //flaut.RedaNota();

         Vioara vioaraClasica = new VioaraClasica();
         Vioara vioaraElectrica = new VioaraElectrica();

         //vioaraClasica.RedaNota();
         //vioaraElectrica.RedaNota();

         IInstrument[] instruments = new IInstrument[]
         { vioara, pian, flaut, vioaraClasica, vioaraElectrica };

         foreach (IInstrument instr in instruments) 
         { 
            instr.RedaNota();
         }
      }
   }
}
