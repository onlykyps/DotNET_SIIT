using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnon
{
   public delegate void GreetDelegate(string name);

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

      }
   }
}
