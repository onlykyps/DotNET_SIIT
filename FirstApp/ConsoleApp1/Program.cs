using System;

namespace ConsoleApp1
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");

         int aa = 2;
         int bb = 3;

         float cc = aa * bb / (5f / 6f);
         
         Console.WriteLine("answer is " + cc);

         int incr = 9;
         //  inainte de trimitere a variabilei la tiparire
         Console.WriteLine("primu e " + ++incr);
         incr = 9;
         //  dupa trimiterea a variabilei la tiparire
         //  este o usoara diferenta de prioritare
         Console.WriteLine("al doilea e " + incr++);

         // la fel cu --decr si decr--

         // daca e weekend si nu am obligatii dorm pana la pranz
         // daca sunt promotii sau oferte ma duc la cumparaturi
         // daca nu e weekend ma trezesc la 4
      }
   }
}
