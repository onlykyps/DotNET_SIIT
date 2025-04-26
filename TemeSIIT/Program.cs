using System;

namespace TemeSIIT
{
   class Program
   {
      static void Main(string[] args)
      {
         int a, b, c;
         float discriminant, x1, x2;

         Console.WriteLine("Introduceti coeficientul lui x1 ");
         a = int.Parse(Console.ReadLine());
         Console.WriteLine("Introduceti coeficientul lui x2 ");
         b = int.Parse(Console.ReadLine());
         Console.WriteLine("Introduceti constanta c ");
         c = int.Parse(Console.ReadLine());


         //x = [-b ± √(b2 - 4ac)]/ 2a

         discriminant = b * b - 4 * a * c;

         if (discriminant > 0)
         {
            x1 = (-b + MathF.Sqrt(discriminant)) / 2 * a;
            x2 = (-b - MathF.Sqrt(discriminant)) / 2 * a;

            Console.WriteLine($"Pentru valorile introduse rezulta radacinile x1={0} si x2={1}", x1, x2);
         }
         else if (discriminant < 0)
         {
            Console.WriteLine("Pentru valorile introduse radacinile nu exista sau sunt imaginare");
         }
         else
         {
            x1 = (-b + MathF.Sqrt(discriminant)) / 2 * a;
            x2 = (-b - MathF.Sqrt(discriminant)) / 2 * a;

            Console.WriteLine($"Pentru valorile introduse radacinile sunt egale si rezulta x1=x2={0}", x1);
         }

        




      }
   }
}
