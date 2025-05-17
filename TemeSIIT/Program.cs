using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TemeSIIT
{
   class Program
   {
      static void Main(string[] args)
      {
         //String[] deVerificatTotal;

         ////optiune hard-codata

         ////String[] deVerificatTotal = 
         ////   {
         ////      "redeem",
         ////      "recognize",
         ////      "jail",
         ////      "fly",
         ////      "dragon"
         ////   }
         ////;

         ////String[] deVerificatTotal =
         ////   {
         ////      "jelly",
         ////      "generate",
         ////      "threat",
         ////      "cow",
         ////      "wreck",
         ////      "retailer",
         ////      "straw",
         ////      "cover",
         ////      "response",
         ////      "last"
         ////   };

         ////optiune programata

         //int lungimeaTabloului;
         //int dubluriMin = 1;
         //int dubluriMax = 1;

         //Console.WriteLine("Introduceti lungimea tabloului");
         //lungimeaTabloului = int.Parse(Console.ReadLine());
         //deVerificatTotal = new string[lungimeaTabloului];



         //while (lungimeaTabloului > 0)
         //{
         //   Console.WriteLine("Introduceti string la pozitia {0} in tablou",
         //      deVerificatTotal.Length - lungimeaTabloului);

         //   string inputDeVerificat = Console.ReadLine();

         //   deVerificatTotal[deVerificatTotal.Length - lungimeaTabloului] = inputDeVerificat;

         //   lungimeaTabloului--;
         //}


         //string minVerificat = deVerificatTotal[0];
         //string maxVerificat = deVerificatTotal[0];

         //string[] totalDubluriMax = new string[0];
         //string[] totalDubluriMin = new string[0];

         //foreach (string item in deVerificatTotal)
         //{
         //   //verificare maxim
         //   if (item.Length > maxVerificat.Length)
         //   {
         //      maxVerificat = item;
         //      dubluriMax = 0;
         //      Array.Resize(ref totalDubluriMax, 0);
         //   }
         //   else if (item.Length == maxVerificat.Length && item != maxVerificat)
         //   {
         //      dubluriMax++;
         //      Array.Resize(ref totalDubluriMax, totalDubluriMax.Length + 2);
         //      totalDubluriMax[totalDubluriMax.Length - 1] = item.ToString();
         //      totalDubluriMax[totalDubluriMax.Length - 2] = maxVerificat.ToString();
         //   }
         //}

         //foreach (string item in deVerificatTotal)
         //{
         //   //verificare minim
         //   if (item.Length < minVerificat.Length)
         //{
         //   minVerificat = item;
         //   dubluriMin = 0;
         //   Array.Resize(ref totalDubluriMin, 0);
         //}
         //else if (item.Length == minVerificat.Length && item != minVerificat)
         //{
         //   dubluriMin++;
         //   Array.Resize(ref totalDubluriMin, totalDubluriMin.Length + 2);
         //   totalDubluriMin[totalDubluriMin.Length - 1] = item.ToString();
         //   totalDubluriMin[totalDubluriMin.Length - 2] = minVerificat.ToString();
         //}
         //}

         //string raspunsFinal = "";

         //if (totalDubluriMin.Length > 0)
         //{
         //   raspunsFinal += "Sunt " + totalDubluriMin.Length.ToString() + " valori minime: ";
         //   foreach (string item in totalDubluriMin)
         //   {
         //      if (item != null)
         //      {
         //         raspunsFinal += (item.ToString() + " ");
         //      }
         //   }

         //}
         //else 
         //{
         //   raspunsFinal += "Exista o valoare minima " + minVerificat.ToString();
         //}

         //raspunsFinal += " si ";

         //if (totalDubluriMax.Length > 0)
         //{
         //   raspunsFinal += "si " + totalDubluriMax.Length.ToString() + " valori maxime: ";
         //   foreach (string item in totalDubluriMax)
         //   {
         //      if (item != null)
         //      {
         //         raspunsFinal += (item.ToString() + " ");
         //      }
         //   }

         //}
         //else
         //{
         //   raspunsFinal += "si o valoare maxima: " + maxVerificat.ToString();
         //}
         //   Console.WriteLine(raspunsFinal);
         ////Console.WriteLine("Stringul cel mai scurt este {0}, stringul cel mai lung este {1}",
         ////   minVerificat, maxVerificat);
         ///

         //ROT3

         Console.WriteLine("Introduceti mesajul de codat:");
         String mesajDeCodat = Console.ReadLine();
         char[] mesajDeCodatSegementat = mesajDeCodat.ToCharArray();

         StringBuilder codificare = new StringBuilder();

         char[] alfabetul = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

         foreach (char c in mesajDeCodatSegementat)
         {
            for (int i = 0; i < alfabetul.Length; i++) 
            {
               
               if(Char.ToUpper(c) == alfabetul[i])
               {
                  codificare.Append
                     (
                        i+3 <= alfabetul.Length -1 ? alfabetul[i + 3] : alfabetul[i + 3 - alfabetul.Length]
                     );
               }
            }
           
         }

         Console.WriteLine(codificare.ToString());


      }
   }
}
