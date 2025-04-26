using System;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
   class Program
   {

      enum Masini
      {
         Skoda=23,
         Lada,
         Fiat = 8,
         Audi = 10,
         BMW,
         Opel = 15,
         Jeep
      };

      static void Main(string[] args)
      {
         //Console.WriteLine("Introduceti un numar");
         //int opt = int.Parse(Console.ReadLine());

         //Masini optEnum = (Masini)opt;

         //switch (optEnum) 
         //{
         //   case Masini.Jeep:
         //      Console.WriteLine("Ati castigat un Jeep");
         //      break;
         //   case Masini.Lada:
         //      Console.WriteLine("Ati castigat un Lada");
         //      break;
         //   case Masini.Fiat:
         //      Console.WriteLine("Ati castigat un Fiat");
         //      break;
         //   case Masini.Audi:
         //      Console.WriteLine("Ati castigat un Audi");
         //      break;
         //   case Masini.BMW:
         //      Console.WriteLine("Ati castigat un BMW");
         //      break;
         //   case Masini.Opel:
         //      Console.WriteLine("Ati castigat un Opel");
         //      break;
         //   default:
         //      Console.WriteLine("Ciu ciu");
         //      break;

         //}

         //varianta dotNet Core
         //Masini optEnu = Enum.Parse<Masini>(Console.ReadLine());
         //Console.WriteLine("Ati castigat o masina " + optEnum.ToString());

         //varianta dotNet framwork
         //Masini optEn;
         //Enum.TryParse<Masini>(Console.ReadLine(), out optEn);
         

         //ushort input = ushort.Parse(Console.ReadLine());
         //bool ePrim = false;

         //for (ushort i = 2; i <= input / 2; i++) 
         //{
         //   if(input % i == 0)
         //   {
         //      ePrim = false;
         //      break;
         //   }

         //   //if (input % i == 0)
         //   //{
         //   //   break;
         //   //   Console.WriteLine("numarul nu este prim");
         //   //}
         //   //else
         //   //{
         //   //   Console.WriteLine("numarul este prim");
         //   //}
         //}

         //if (!ePrim) Console.WriteLine("{0} nu e prim" , input);
         //else Console.WriteLine("{0} e prim", input);

         //gresit, de revizuit
         //ushort input = ushort.Parse(Console.ReadLine());
         //int fib0 = 1;
         //int fib1 = 1;

         //while(input > fib1)
         //{
         //   int temp = fib1;
         //   fib1 = fib0 + fib1;
         //   fib0 = temp;

         //}

         //Console.WriteLine(fib1);

         //uint a = 1; 
         //uint b = 1; 
         //uint c;
         //uint nrIntr;

         //Console.WriteLine("introduceti numar");
         //nrIntr = uint.Parse(Console.ReadLine());

         //do
         //{
         //   c = a + b;
         //   a = b;
         //   b = c;
         //}
         //while (c <= nrIntr);

         //Console.WriteLine("nr din sirul lui Fibonnaci cel mai aproape de {0} este {1}", nrIntr, (c == nrIntr ? c : a));

         //uint nrIntr;
         //nrIntr = uint.Parse(Console.ReadLine());

         //switch (nrIntr)
         //{
         //   case 1:
         //         Console.WriteLine("Ati apasat stanga jos");
         //      break;
         //   case 2:
         //      Console.WriteLine("Ati apasat jos");
         //      break;
         //   case 3:
         //      Console.WriteLine("Ati apasat dreapta jos");
         //      break;
         //   case 4:
         //      Console.WriteLine("Ati apasat stanga");
         //      break;
         //   case 5:
         //      Console.WriteLine("Ati apasat centru");
         //      break;
         //   case 6:
         //      Console.WriteLine("Ati apasat dreapta");
         //      break;
         //   case 7:
         //      Console.WriteLine("Ati apasat stanga sus");
         //      break;
         //   case 8:
         //      Console.WriteLine("Ati apasat sus");
         //      break;
         //   case 9:
         //      Console.WriteLine("Ati apasat dreapta sus");
         //      break;
         //   default:
         //      Console.WriteLine("Ati apasat tasta gresita");
         //      break;
         //}
         //


         //string[] orase = new string[]
         //{
         //   "Cluj-Napoca",
         //   "Brasov",
         //   "Iasi",
         //   "Bucuresti",
         //   "Oradea",
         //   "Timisoara",
         //   "Alba-Iulia"
         //};

         //string primu = orase[0];

         //for (int i = 1; i < orase.Length; i++) 
         //{
         //   string temp = orase [i];
         //   if(String.Compare(temp, primu)<0)
         //   {
         //      primu = temp;
         //   }

         //}

         //Console.WriteLine("Primu oras: {0}", primu);

         ////solutia mea imperfecta
         //string poppins = "supercalifragilisticexpialidocious";
         //string input = Console.ReadLine();
         //int contor = 0;
         //int pas = 0;
         //bool go = true;

         //while (go) 
         //{ 
         //   if(poppins.IndexOf(input, pas) >0)
         //   {
         //      contor++;
         //      pas = poppins.IndexOf(input, pas) + 1;
         //   }
         //   else
         //   {
         //      go = false;
         //   }


         //}

         //Console.WriteLine("caracterul apare de {0}", contor);

         ////solutia corecta
         //char caracter = char.Parse(Console.ReadLine());
         //int lastPos = -1;
         //int contr = 0;

         //do
         //{
         //   lastPos = poppins.IndexOf(caracter, lastPos + 1);
         //   if(lastPos!=-1) contr++;

         //} while (lastPos != -1);

         //if (contr == 0)
         //   Console.WriteLine("caracterul de {0} nu apare ", caracter);
         //else 
         //   Console.WriteLine("caracterul apare de {0}", contr);


         //string textArray = "Invatam sirurile";

         //string[] cuvintele = textArray.Split(" ");

         //for (int i = 0; i < cuvintele.Length; i++)
         //{
         //   if(string.Compare(cuvintele[i],"sirurile") == 0)
         //   {
         //      cuvintele[i] = "figurile";
         //   }
         //}

         ////Console.WriteLine(cuvintele[0] + " " + cuvintele[1]);
         //textArray = cuvintele[0] + " " + cuvintele[1];

         //string output = textArray.ToLower().Trim('i', 'n', 'l', 'e');
         //Console.WriteLine(output);

         //string newOutPut = output.Replace("vat", "");
         //Console.WriteLine(newOutPut);

         //StringBuilder input = new StringBuilder("Jimba de Coana mare", 30);

         //Console.WriteLine(input.ToString());

         //input[0] = 'L';

         //Console.WriteLine(input.ToString());

         ////for (int i = 1; i < 10; i++) 
         ////{
         ////   if(input[i] == ' ')
         ////   {
         ////      input[i] = 'jul';
         ////      break;
         ////   }
         ////}

         //int indexSpatiu = input.ToString().IndexOf(' ');
         //input.Insert(indexSpatiu, "jul");

         //input.Replace("Coana ", "progra");

         //Console.WriteLine(input.ToString());

         //input.Append(" C# este bestial!");

         //Console.WriteLine(input.ToString());

         //string one = "cateva";
         //string two = "multi";

         //float a = 2.55f;
         //float b = 4.69f;

         //string output = $"Ana are {one} kg de mere, ce costa {a}lei";
         //Console.WriteLine(output);
         //string outputTwo = String.Format(output, two, b);
         //Console.WriteLine(outputTwo);
         //string outputThree = String.Format(output, two, b*a);
         //Console.WriteLine(outputThree);




      }
   }
}
