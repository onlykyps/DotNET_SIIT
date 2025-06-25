using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnon
{
   public delegate void GreetDelegate(string name);

   delegate int MathOp(int x, int y);

   public class Program
   {
      static void SayHello(string n)
      {
         Console.WriteLine($"Hello {n}!");
      }

      static void SayGoodbye(string n)
      {
         Console.WriteLine($"Goodbye {n}!");
      }

      static void Main(string[] args)
      {
         GreetDelegate greetDelegate = SayHello;

         greetDelegate("Ovidiu");

         greetDelegate = SayGoodbye;

         greetDelegate("Claudiu");

         greetDelegate += SayHello;

         greetDelegate("Ovidiu");

         //MathOp add = (a, b) => { return a + b; }; // corect si asa
         MathOp add = (a, b) => a + b;

         int result = add(28, 30);

         Console.WriteLine($"Result is {result}");

      }
   }
}
