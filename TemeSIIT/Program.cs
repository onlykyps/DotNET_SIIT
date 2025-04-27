using System;

namespace TemeSIIT
{
   class Program
   {
      static void Main(string[] args)
      {
         //rezlolvarea temei cu ecuatia quadratica
         //---------------------------------------

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

         //   Console.WriteLine("Pentru valorile introduse rezulta radacinile x1={0} si x2={1}", x1, x2);
         //}
         //else if (discriminant < 0)
         //{
         //   Console.WriteLine("Pentru valorile introduse radacinile nu exista sau sunt imaginare");
         //}
         //else
         //{
         //   x1 = (-b + MathF.Sqrt(discriminant)) / 2 * a;
         //   x2 = (-b - MathF.Sqrt(discriminant)) / 2 * a;

         //   Console.WriteLine("Pentru valorile introduse radacinile sunt egale si rezulta x1=x2={0}", x1);
         //}



         //rezlolvarea temei cu valoarea minima si maxima a unui tablou
         //------------------------------------------------------------

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

         // varianta in care caut minim si maxim separat

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


         // varianta in care sortez tot tabloul crescator apoi afisez primul si ultimul element

         int tempLength = tablou.Length;

         while (tempLength > 0) 
         { 
            for (int i = 0;i < tablou.Length-1;i++)
            {
               int temp = tablou[i];
               if (tablou[i] > tablou[i + 1])
               {
                  temp = tablou[i];
                  tablou[i] = tablou[i + 1];
                  tablou[i+1] = temp;

               }

            }
            tempLength--;
         }

         Console.WriteLine("Valoarea maxima a tabloului este {0}, iar valoarea minima este {1}",
            tablou[tablou.Length-1], tablou[0]);

         Console.WriteLine("Stop");
      }
   }
}
