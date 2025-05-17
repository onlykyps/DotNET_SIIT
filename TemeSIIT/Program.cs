using System;
using System.IO;
using System.Linq;
using System.Threading;

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

         //int dimensiune;

         //Console.WriteLine("Introduceti dimensiunea tabloului ");
         //dimensiune = int.Parse(Console.ReadLine());

         //int[] tablou = new int[dimensiune];
         //int index = 0;

         //while (dimensiune > 0) 
         //{
         //   Console.WriteLine("Adaugati elemntul {0} al tabloului",index);
         //   tablou[index] = int.Parse(Console.ReadLine());
         //   index++;
         //   dimensiune--;
         //}

         //// varianta in care caut minim si maxim separat

         //int valoareMaxima = 0;

         //for (int i = 0; i < tablou.Length; i++)
         //{
         //   if (tablou[i] > valoareMaxima)
         //   {
         //      valoareMaxima = tablou[i];
         //   }
         //}

         //int valoareMinima = tablou[0];
         //for (int i = 0; i < tablou.Length; i++)
         //{
         //   if (tablou[i] < valoareMinima)
         //   {
         //      valoareMinima = tablou[i];
         //   }
         //}

         //Console.WriteLine("Valoarea maxima a tabloului este {0}, iar valoarea minima este {1}",
         //   valoareMaxima, valoareMinima);


         //// varianta in care sortez tot tabloul crescator apoi afisez primul si ultimul element

         //int tempLength = tablou.Length;

         //while (tempLength > 0) 
         //{ 
         //   for (int i = 0;i < tablou.Length-1;i++)
         //   {
         //      int temp = tablou[i];
         //      if (tablou[i] > tablou[i + 1])
         //      {
         //         temp = tablou[i];
         //         tablou[i] = tablou[i + 1];
         //         tablou[i+1] = temp;

         //      }

         //   }
         //   tempLength--;
         //}

         //Console.WriteLine("Valoarea maxima a tabloului este {0}, iar valoarea minima este {1}",
         //   tablou[tablou.Length-1], tablou[0]);

         //Console.WriteLine("Stop");

         String[] deVerificatTotal;

         //optiune hard-codata

         //String[] deVerificatTotal = 
         //   {
         //      "redeem",
         //      "recognize",
         //      "jail",
         //      "fly",
         //      "dragon"
         //   }
         //;

         //String[] deVerificatTotal =
         //   {
         //      "jelly",
         //      "generate",
         //      "threat",
         //      "cow",
         //      "wreck",
         //      "retailer",
         //      "straw",
         //      "cover",
         //      "response",
         //      "last"
         //   };

         //optiune programata

         int lungimeaTabloului;
         int dubluriMin = 1;
         int dubluriMax = 1;

         Console.WriteLine("Introduceti lungimea tabloului");
         lungimeaTabloului = int.Parse(Console.ReadLine());
         deVerificatTotal = new string[lungimeaTabloului];

         

         while (lungimeaTabloului > 0)
         {
            Console.WriteLine("Introduceti string la pozitia {0} in tablou",
               deVerificatTotal.Length - lungimeaTabloului);

            string inputDeVerificat = Console.ReadLine();

            deVerificatTotal[deVerificatTotal.Length - lungimeaTabloului] = inputDeVerificat;

            lungimeaTabloului--;
         }


         string minVerificat = deVerificatTotal[0];
         string maxVerificat = deVerificatTotal[0];

         string[] totalDubluriMax = new string[0];
         string[] totalDubluriMin = new string[0];

         foreach (string item in deVerificatTotal)
         {
            //verificare maxim
            if (item.Length > maxVerificat.Length)
            {
               maxVerificat = item;
               dubluriMax = 0;
               Array.Resize(ref totalDubluriMax, 0);
            }
            else if (item.Length == maxVerificat.Length && item != maxVerificat)
            {
               dubluriMax++;
               Array.Resize(ref totalDubluriMax, totalDubluriMax.Length + 2);
               totalDubluriMax[totalDubluriMax.Length - 1] = item.ToString();
               totalDubluriMax[totalDubluriMax.Length - 2] = maxVerificat.ToString();
            }
         }

         foreach (string item in deVerificatTotal)
         {
            //verificare minim
            if (item.Length < minVerificat.Length)
         {
            minVerificat = item;
            dubluriMin = 0;
            Array.Resize(ref totalDubluriMin, 0);
         }
         else if (item.Length == minVerificat.Length && item != minVerificat)
         {
            dubluriMin++;
            Array.Resize(ref totalDubluriMin, totalDubluriMin.Length + 2);
            totalDubluriMin[totalDubluriMin.Length - 1] = item.ToString();
            totalDubluriMin[totalDubluriMin.Length - 2] = minVerificat.ToString();
         }
         }

         string raspunsFinal = "";

         if (totalDubluriMin.Length > 0)
         {
            raspunsFinal += "Sunt " + totalDubluriMin.Length.ToString() + " valori minime: ";
            foreach (string item in totalDubluriMin)
            {
               if (item != null)
               {
                  raspunsFinal += (item.ToString() + " ");
               }
            }

         }
         else 
         {
            raspunsFinal += "Exista o valoare minima " + minVerificat.ToString();
         }

            raspunsFinal += " si ";

         if (totalDubluriMax.Length > 0)
         {
            raspunsFinal += "si " + totalDubluriMax.Length.ToString() + " valori maxime: ";
            foreach (string item in totalDubluriMax)
            {
               if (item != null)
               {
                  raspunsFinal += (item.ToString() + " ");
               }
            }

         }
         else
         {
            raspunsFinal += "si o valoare maxima: " + maxVerificat.ToString();
         }
            Console.WriteLine(raspunsFinal);
         //Console.WriteLine("Stringul cel mai scurt este {0}, stringul cel mai lung este {1}",
         //   minVerificat, maxVerificat);

      }
   }
}
