using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace TemeSIIT
{
   class Program
   {
      public string[] CuratarePalindrom(string[] palindromInputDeCuratat)
      {
         char[] nonAlphaNum = ",.'-!?:;".ToCharArray();
         

         string[] palindromListProcesare = new string[palindromInputDeCuratat.Length];
         for (int i = 0; i < palindromInputDeCuratat.Length; i++)
         {
            char[] temp = palindromInputDeCuratat[i].ToCharArray();
            StringBuilder tempFinal = new StringBuilder();

            foreach (char c in temp)
            {
               if (c != ' ' && !nonAlphaNum.Contains(c))
               {
                  tempFinal.Append(c);
               }
            }


            palindromListProcesare[i] = tempFinal.ToString();
         }

         return palindromListProcesare;

      }


      public string CuratarePalindromIndividual(string palindromInputDeCuratat)
      {
         char[] nonAlphaNum = ",.'-!?:;".ToCharArray();


         char[] palindromListProcesare = palindromInputDeCuratat.ToCharArray();

        
         StringBuilder palindromListPredare = new StringBuilder();

         foreach (char c in palindromListProcesare)
         {
            if (c != ' ' && !nonAlphaNum.Contains(c))
            {
               palindromListPredare.Append(c);
            }
         }

         return palindromListPredare.ToString();

      }

      public bool VerificarePalindromIndividual(string palindromInput)
      {
         char[] palindromInputChars = palindromInput.ToCharArray();
         bool isPalindrom = false;
         int index = 0;

         if (palindromInputChars.Length % 2 == 0)
         {
            for (int i = 0; i < palindromInputChars.Length; i++)
            {
               if (Char.ToLower(palindromInputChars[i]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - i - 1])
                  &&
                  palindromInputChars[i] != ',')
               {
                  isPalindrom = true;
               }
               else if (Char.ToLower(palindromInputChars[i]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - i - 2])
                  &&
                  palindromInputChars[i] != ',')
               {
                  isPalindrom = true;
               }
               else
               {
                  isPalindrom = false;
                  break;
               }
            }
         }
         else
         {
            while (index != palindromInputChars.Length / 2 + 1)
            {
               if (Char.ToLower(palindromInputChars[index]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - index - 1])
                  &&
                  palindromInputChars[index] != ',')
               {
                  isPalindrom = true;

               }
               else if (Char.ToLower(palindromInputChars[index]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - index - 2])
                  &&
                  palindromInputChars[index] != ',')
               {
                  isPalindrom = true;

               }
               else
               {
                  isPalindrom = false;

                  break;
               }
               index++;
            }

         }


         return isPalindrom;
      }

      public void VerificarePalindromLista(string[] palindromList, string palindromInput, int indexLaPalindromOriginal)
      {
         //char[] palindromInputChars = palindromInput.ToCharArray();
         //bool isPalindrom = false;
         //int index = 0;


         //if (palindromInputChars.Length % 2 == 0)
         //{
         //   for (int i = 0; i < palindromInputChars.Length; i++)
         //   {
         //      if (Char.ToLower(palindromInputChars[i]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - i - 1])
         //         &&
         //         palindromInputChars[i] != ',')
         //      {
         //         isPalindrom = true;
         //      }
         //      else if (Char.ToLower(palindromInputChars[i]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - i - 2])
         //         &&
         //         palindromInputChars[i] != ',')
         //      {
         //         isPalindrom = true;
         //      }
         //      else
         //      {
         //         isPalindrom = false;
         //         break;
         //      }
         //   }
         //}
         //else
         //{
         //   while (index != palindromInputChars.Length / 2 + 1)
         //   {
         //      if (Char.ToLower(palindromInputChars[index]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - index - 1])
         //         &&
         //         palindromInputChars[index] != ',')
         //      {
         //         isPalindrom = true;

         //      }
         //      else if (Char.ToLower(palindromInputChars[index]) == Char.ToLower(palindromInputChars[palindromInputChars.Length - index - 2])
         //         &&
         //         palindromInputChars[index] != ',')
         //      {
         //         isPalindrom = true;

         //      }
         //      else
         //      {
         //         isPalindrom = false;

         //         break;
         //      }
         //      index++;
         //   }

         //}

         //VerificarePalindromIndividual(palindromInput);

         string raspunsFinal = VerificarePalindromIndividual(palindromInput) == true ? "este palindrom" : "nu este palindrom";


         Console.WriteLine(@"{0} {1}", palindromList[indexLaPalindromOriginal], raspunsFinal);
         
      }

      static void Main(string[] args)
      {
         //Palindrom Assignment

         //solutie pentru Compiler Error CS0120
         Program program = new Program();

         //Cu input de la operator
         //Console.WriteLine("Introduceti polindromul: ");
         //string palindromInput = Console.ReadLine();
         //string palindromInputDeCuratat = program.CuratarePalindromIndividual(palindromInput);
         //string raspunsFinal = program.VerificarePalindromIndividual(palindromInputDeCuratat) == true ? "este palindrom" : "nu este palindrom";
         //Console.WriteLine(@"{0} {1}", palindromInput, raspunsFinal);


         //Cu input prestabilit
         string[] palindromList = {"kayak","deified","rotator","repaper","deed","peep",
            "wow","noon","civic","racecar","level","mom", "solos", "rotator", "radar", "tenet",
         "haiduc","razes","balaur","monitor","tastatura","mouse", "visual", "cafea", "camera", "telefon",
         "Amore, Roma", "A Toyota", "A Santa deified at NASA", "telefon",
         "Gert, I saw Ron avoid a radio-van, or was it Reg?", "Eva, can I see bees in a cave?", 
            "KC, answer DNA loop award. Emit time. Draw a pool. Andrew, snack.", "Naomi, did I moan?", "Naomy, did I moan?"};

         //pentru teste rapide
         //string[] palindromList = { "Amore, Roma", "A Toyota", "A Santa deified at NASA", "telefon"};


         //stergem spatiile goale
         string[] palindromCuratat = new string[palindromList.Length];

         
         palindromCuratat = program.CuratarePalindrom(palindromList);

         int indexLaPalindromOriginal = 0;

         foreach (string pal in palindromCuratat)
         {
            program.VerificarePalindromLista(palindromList, pal, indexLaPalindromOriginal);
            indexLaPalindromOriginal++;
         }
      }

      
   }
}
