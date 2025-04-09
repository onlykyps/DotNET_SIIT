using System;

namespace ConsoleApp1
{
   class Program
   {
      static void Main(string[] args)
      {
         //Console.WriteLine("Hello World!");

         int aa = 2;
         int bb = 3;

         float cc = aa * bb / (5f / 6f);

         //Console.WriteLine("answer is " + cc);

         int incr = 9;
         //  inainte de trimitere a variabilei la tiparire
         //Console.WriteLine("primu e " + ++incr);
         incr = 9;
         //  dupa trimiterea a variabilei la tiparire
         //  este o usoara diferenta de prioritare
         //Console.WriteLine("al doilea e " + incr++);

         // la fel cu --decr si decr--

         // daca e weekend si nu am obligatii dorm pana la pranz
         // daca sunt promotii sau oferte ma duc la cumparaturi
         // daca nu e weekend ma trezesc la 4

         ushort exp1 = 0x00AB;
         ushort exp2 = 0x00B1;
         //Console.WriteLine("exp1 & exp2 = {0:X}", exp1 & exp2);
         //Console.WriteLine("exp1 | exp2 = {0:X}", exp1 | exp2);
         //Console.WriteLine("~exp1 = {0:X}", ~exp1); // because of integral promotion

         //Console.WriteLine("exp1 ^ exp2 = {0:X}", exp1 ^ exp2);

         // << (deplasare la stanga)
         // >> (deplasare la dreapta)
         // muta informatia, ce se elibereaza este inlocuit cu 0
         // 0101 1000 P XXXX XXXX 
         //             <<2 
         //             XXXX XX00
         //             >>2 
         //             00XX XXXX
         // P de la prapastie

         ushort exp3 = 0x00AB;

         //Console.WriteLine("exp1 <<4 = {0:X}", exp3 << 4); // 0AB0
         //Console.WriteLine("exp1 <<8 = {0:X}", exp3 << 8); // AB00

         //Console.WriteLine("exp1 >>4 = {0:X}", exp3 >> 4); // 000A
         //Console.WriteLine("exp1 >>8 = {0:X}", exp3 >> 8); // 0000

         //Console.WriteLine("Introduceti un numar");
         //short an = short.Parse(Console.ReadLine());

         // varianta 1
         //if(an % 4 != 0)
         //{
         //Console.WriteLine("{0} nu este an bisect", an);
         //}
         //else
         //{
         //if(an % 100 != 0)
         //Console.WriteLine("{0} este an bisect", an);
         //else
         //if(an % 400 == 0)
         //Console.WriteLine("{0} este an bisect", an);
         //else
         //Console.WriteLine("{0} nu este an bisect", an);
         //}

         // varianta 2
         //if (an % 4 != 0 || (an % 100 == 0 && an % 400 !=0))
         //{
         //Console.WriteLine("{0} nu este an bisect", an);
         //}
         //else
         //{
         //Console.WriteLine("{0} este an bisect", an);
         //}


         //int[] array = new int[] { 1, 2, 3, 4, 5 };

         //// get array size
         //int length = array.Length;

         //// declare and create the reversed array
         //int[] reversed = new int[length];

         //// initialize the reversed array
         //for (int i = 0; i < length; i++)
         //{
         //   reversed[length - i - 1] = array[i];
         //}



         int[] array1 = new int[20];
         //int[] array2 = new int[20];

         for (int i = 0; i < array1.Length; i++)
         {
            array1[i] = i * 3 + 33;
            Console.WriteLine("numarul este " + array1[i]);
         }

         //for (int i = 0; i < array2.Length; i++)
         //{
         //   array2[i] = i * 10 + 110;
         //   Console.WriteLine("numarul este " + array2[i]);
         //}

         //for (int i = 0; i < array1.Length; i++)
         //{
         //   int temp = array1[i];
         //   array1[i] = array2[i];
         //   array2[i] = temp;
         //   Console.WriteLine("numarul din array1 este " + array1[i]);
         //   Console.WriteLine("numarul din array2 este " + array2[i]);
         //}

         //for (int i = 0; i < 20; i++)
         //{
         //   Console.WriteLine("array1[{0}] = {1}/array2[{0}]= {2}", i, array1[i], array2[i]);
         //}

         //int[] revArray1 = new int[array1.Length];
         //int[] revArray2 = new int[array2.Length];

         //for (int i = 0; i < revArray1.Length; i++)
         //{
         //   revArray1[revArray1.Length - i - 1] = array1[i];
         //   revArray2[revArray1.Length - i - 1] = array2[i];
         //}

         //for (int i = 0; i < 20; i++)
         //{
         //   Console.WriteLine("revArray1[{0}] = {1}/revArray2[{0}] = {2}", i, revArray1[i], revArray2[i]);
         //}




         string[] arrayStr = new string[5];

         for (int i = 0; i < arrayStr.Length; i++)
         {
            //Console.WriteLine("Introduceti pozitia {0}", i);
            arrayStr[i] = Console.ReadLine();
         }

         foreach (string item in arrayStr)
         {
            //Console.WriteLine(item);
         }

         string[] copyEgalArrayStr = arrayStr;
         copyEgalArrayStr[0] = "Clau";

         foreach (string item in arrayStr)
         {
            //Console.WriteLine(item);
         }

         int[] copyClone = (int[])array1.Clone();

         copyClone[0] = 1988;
         Console.WriteLine("numarul este " + array1[0]);




      }
   }
}
