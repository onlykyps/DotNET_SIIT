using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnon
{
   public delegate void GreetDelegate(string name);

   delegate int MathOp(int x, int y);

   public delegate void Notify(string mesaj);

   public class Publisher
   {
      public event Notify OnPublish;

      public void Publish(string continut)
      {
         Console.WriteLine("Published content");
         OnPublish?.Invoke(continut);
      }
   }

   public class EmailSubscriber
   {
      public void SendMail(string mesaj) 
      {
         Console.WriteLine($"Email sent with message: {mesaj}");
      } 
   }

   public class SMSSubscriber
   {
      public void SendSMS(string mesaj)
      {
         Console.WriteLine($"SMS sent with message: {mesaj}");
      }
   }

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

      public static string WordReverse(this string str)
      {
         string[] words = str.Split(' ');

         for (int i = 0; i < words.Length; i++)
         {
            words[i] = new string(words[i].Reverse().ToArray());

         }

         return String.Join(" ", words);
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

         Action<int> printSqr = (x) =>
         {
            int rezultat = x * x;
            Console.WriteLine($"Square of {x} is {rezultat}"); 
         };

         printSqr(2);

         Func<int, int> funcSqr = (x) =>
         {
           return x * x;
         };

         int y = 3;

         Console.WriteLine($"Square of {y} is {funcSqr(y)}");

         Publisher publisher = new Publisher();
         EmailSubscriber subscriber = new EmailSubscriber();   
         SMSSubscriber smsSub = new SMSSubscriber();

         publisher.OnPublish += subscriber.SendMail;
         publisher.OnPublish += smsSub.SendSMS;

         publisher.Publish("Salutare cursanti C Sharp");
         
      }
   }
}
