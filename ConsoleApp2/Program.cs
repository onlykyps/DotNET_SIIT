using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
   internal class Program
   {
      static void Main(string[] args)
      {
         StringBuilder sb = new StringBuilder("In main!");
         Double dodo = 1.5;

         Console.WriteLine($"Valori initiale: sb= {sb.ToString()}, dodo={dodo}");
         ModifValTypeParVal(dodo);
         Console.WriteLine($"Value type dupa ModifValTypeParVal parametru dodo={dodo}");
         ModifRefTypeParVal(sb);
         Console.WriteLine($"Value type dupa ModifRefTypeParVal parametru sb={sb.ToString()}");
         ModifValTypeParValRef(ref dodo);
         Console.WriteLine($"Value type dupa ModifValTypeParValRef parametru dodo={dodo}");
         sb = new StringBuilder("In main!");
         dodo = 1.5;
         ModifRefTypeParRef(ref sb);
         Console.WriteLine($"Value type dupa ModifRefTypeParRef parametru sb={sb.ToString()}");
         ModifParOut(out sb, out dodo);
         Console.WriteLine($"Valori finale: sb= {sb.ToString()}, dodo={dodo}");

      }

      static void ModifValTypeParVal(double d)
      {
         d = 22.55;
      }

      static void ModifRefTypeParVal(StringBuilder stringBuilder) 
      {
         stringBuilder.Append(" Hell yeah!");
         stringBuilder = null;
      }

      static void ModifValTypeParValRef(ref double d) 
      {
         d = 77.55;
      }

      static void ModifRefTypeParRef(ref StringBuilder stringBuilderRef)
      {
         stringBuilderRef.Append(" yup yup!");
         //stringBuilderRef = null; 
      }

      static void ModifParOut(out StringBuilder sbOut, out double d)
      {
         sbOut = new StringBuilder("Valoare noua - din metoda");
         d = 5.5;
      }
   }
}
