using System;

namespace ConsoleApp1
{
   class Program
   {
      static void Main(string[] args)
      {
         //Console.WriteLine("Hello World!");

         int aa = 2;
         int bb = 3;

         float cc = aa * bb / (5f / 6f);

         //Console.WriteLine("answer is " + cc);

         int incr = 9;
         //  inainte de trimitere a variabilei la tiparire
         //Console.WriteLine("primu e " + ++incr);
         incr = 9;
         //  dupa trimiterea a variabilei la tiparire
         //  este o usoara diferenta de prioritare
         //Console.WriteLine("al doilea e " + incr++);

         // la fel cu --decr si decr--

         // daca e weekend si nu am obligatii dorm pana la pranz
         // daca sunt promotii sau oferte ma duc la cumparaturi
         // daca nu e weekend ma trezesc la 4

         ushort exp1 = 0x00AB;
         ushort exp2 = 0x00B1;
         //Console.WriteLine("exp1 & exp2 = {0:X}", exp1 & exp2);
         //Console.WriteLine("exp1 | exp2 = {0:X}", exp1 | exp2);
         //Console.WriteLine("~exp1 = {0:X}", ~exp1); // because of integral promotion

         //Console.WriteLine("exp1 ^ exp2 = {0:X}", exp1 ^ exp2);

         // << (deplasare la stanga)
         // >> (deplasare la dreapta)
         // muta informatia, ce se elibereaza este inlocuit cu 0
         // 0101 1000 P XXXX XXXX 
         //             <<2 
         //             XXXX XX00
         //             >>2 
         //             00XX XXXX
         // P de la prapastie

         ushort exp3 = 0x00AB;

         //Console.WriteLine("exp1 <<4 = {0:X}", exp3 << 4); // 0AB0
         //Console.WriteLine("exp1 <<8 = {0:X}", exp3 << 8); // AB00

         //Console.WriteLine("exp1 >>4 = {0:X}", exp3 >> 4); // 000A
         //Console.WriteLine("exp1 >>8 = {0:X}", exp3 >> 8); // 0000

         Console.WriteLine("Introduceti un numar");
         short an = short.Parse(Console.ReadLine());

         // varianta 1
         if(an % 4 != 0)
         {
            Console.WriteLine("{0} nu este an bisect", an);
         }
         else
         {
            if(an % 100 != 0)
               Console.WriteLine("{0} este an bisect", an);
            else
               if(an % 400 == 0)
                  Console.WriteLine("{0} este an bisect", an);
               else
                  Console.WriteLine("{0} nu este an bisect", an);
         }

         // varianta 2
         if (an % 4 != 0 || (an % 100 == 0 && an % 400 !=0))
         {
            Console.WriteLine("{0} nu este an bisect", an);
         }
         else
         {
            Console.WriteLine("{0} este an bisect", an);
         }


      }
   }
}
