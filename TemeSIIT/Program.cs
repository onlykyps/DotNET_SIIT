using System;

namespace TemeSIIT
{
   class Program
   {
      static void Main(string[] args)
      {
         //int a, b, c;
         //float discriminant, x1, x2;

         //Console.WriteLine("Introduceti coeficientul lui x1 ");
         //a = int.Parse(Console.ReadLine());
         //Console.WriteLine("Introduceti coeficientul lui x2 ");
         //b = int.Parse(Console.ReadLine());
         //Console.WriteLine("Introduceti constanta c ");
         //c = int.Parse(Console.ReadLine());


         ////x = [-b ± √(b2 - 4ac)]/ 2a

         //discriminant = b * b - 4 * a * c;

         //if (discriminant > 0)
         //{
         //   x1 = (-b + MathF.Sqrt(discriminant)) / 2 * a;
         //   x2 = (-b - MathF.Sqrt(discriminant)) / 2 * a;

         //   Console.WriteLine($"Pentru valorile introduse rezulta radacinile x1={0} si x2={1}", x1, x2);
         //}
         //else if (discriminant < 0)
         //{
         //   Console.WriteLine("Pentru valorile introduse radacinile nu exista sau sunt imaginare");
         //}
         //else
         //{
         //   x1 = (-b + MathF.Sqrt(discriminant)) / 2 * a;
         //   x2 = (-b - MathF.Sqrt(discriminant)) / 2 * a;

         //   Console.WriteLine($"Pentru valorile introduse radacinile sunt egale si rezulta x1=x2={0}", x1);
         //}


         int dimensiune;

         Console.WriteLine("Introduceti dimensiunea tabloului ");
         dimensiune = int.Parse(Console.ReadLine());

         int[] tablou = new int[dimensiune];
         int index = 0;

         while (dimensiune > 0) 
         {
            Console.WriteLine("Adaugati elemntul {0} al tabloului",index);
            tablou[index] = int.Parse(Console.ReadLine());
            index++;
            dimensiune--;
         }

         int valoareMaxima = 0;

         for (int i = 0; i < tablou.Length; i++)
         {
            if (tablou[i] > valoareMaxima)
            {
               valoareMaxima = tablou[i];
            }
         }

         int valoareMinima = tablou[0];
         for (int i = 0; i < tablou.Length; i++)
         {
            if (tablou[i] < valoareMinima)
            {
               valoareMinima = tablou[i];
            }
         }

         Console.WriteLine("Valoarea maxima a tabloului este {0}, iar valoarea minima este {1}",
            valoareMaxima, valoareMinima);
      }
   }
}
