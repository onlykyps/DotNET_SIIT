using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightAssignment
{
   public class Program
   {
      static void Main(string[] args)
      {
         Candelabru candelabruUnu = new Candelabru(60, 75, 100);
         Candelabru candelabruDoi = new Candelabru(40, 60, 75, 75, 100);

         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");

         Console.WriteLine($"Puterea maximă a candelabrului 1: {candelabruUnu.PutereMaxima}");
         Console.WriteLine($"Puterea maximă a candelabrului 2: {candelabruDoi.PutereMaxima}");

         candelabruUnu.Aprinde();
         candelabruDoi.Aprinde();

         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");

         Console.WriteLine($"Puterea curentă a candelabrului 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabrului 2: {candelabruDoi.PutereCurenta}");


         candelabruUnu.Stinge();
         candelabruDoi.Stinge();

         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");

         candelabruUnu.MaresteLumina(80);
         candelabruDoi.MaresteLumina(80);

         Console.WriteLine($"Este candelabru 1 aprins după mărire? {candelabruUnu.Aprins}");
         Console.WriteLine($"Este candelabru 2 aprins după mărire? {candelabruDoi.Aprins}");

         Console.WriteLine($"Puterea curentă a candelabru 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabru 2: {candelabruDoi.PutereCurenta}");

         candelabruUnu.ReduceLumina(50);
         candelabruDoi.ReduceLumina(50);

         Console.WriteLine($"Este candelabru 1 aprins după reducere? {candelabruUnu.Aprins}");
         Console.WriteLine($"Este candelabru 2 aprins după reducere? {candelabruDoi.Aprins}");

         Console.WriteLine($"Puterea curentă a candelabru 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabru 2: {candelabruDoi.PutereCurenta}");

      }


   }
}
