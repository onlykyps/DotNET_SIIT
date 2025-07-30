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
            
         //Afișați starea fiecărui obiect Candelabru(dacă e aprins sau stins)
         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");
        
        //Afișați puterea maximă a fiecărui obiect Candelabru
         Console.WriteLine($"Puterea maximă a candelabrului 1: {candelabruUnu.PutereMaxima}");
         Console.WriteLine($"Puterea maximă a candelabrului 2: {candelabruDoi.PutereMaxima}");
         
        //Aprindeți obiectele Candelabru
         candelabruUnu.Aprinde();
         candelabruDoi.Aprinde();

         //Afișați starea fiecărui obiect Candelabru(dacă e aprins sau stins)
         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");
           
        //Afișați puterea curentă a fiecărui obiect Candelabru
         Console.WriteLine($"Puterea curentă a candelabrului 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabrului 2: {candelabruDoi.PutereCurenta}");
            
        //Stingeți obiectele Candelabru
         candelabruUnu.Stinge();
         candelabruDoi.Stinge();

        //Afișați starea fiecărui obiect Candelabru(dacă e aprins sau stins)
         Console.WriteLine($"Primul candelabru este aprins? {candelabruUnu.Aprins}");
         Console.WriteLine($"Al doilea candelabru este aprins? {candelabruDoi.Aprins}");
            
        //Măriți lumina la fiecare obiect Candelabru cu 80
         candelabruUnu.MaresteLumina(80);
         candelabruDoi.MaresteLumina(80);
            
        //Afișați starea fiecărui obiect Candelabru(dacă e aprins sau stins)
         Console.WriteLine($"Este candelabru 1 aprins după mărire? {candelabruUnu.Aprins}");
         Console.WriteLine($"Este candelabru 2 aprins după mărire? {candelabruDoi.Aprins}");
            
        //Afișați puterea curentă a fiecărui obiect Candelabru
         Console.WriteLine($"Puterea curentă a candelabru 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabru 2: {candelabruDoi.PutereCurenta}");
        
        //Reduceți lumina la fiecare obiect Candelabru cu 50
         candelabruDoi.ReduceLumina(50);
         candelabruUnu.ReduceLumina(50);

         //Afișați starea fiecărui obiect Candelabru(dacă e aprins sau stins)
         Console.WriteLine($"Este candelabru 1 aprins după reducere? {candelabruUnu.Aprins}");
         Console.WriteLine($"Este candelabru 2 aprins după reducere? {candelabruDoi.Aprins}");

         //Afișați puterea curentă a fiecărui obiect Candelabru
         Console.WriteLine($"Puterea curentă a candelabru 1: {candelabruUnu.PutereCurenta}");
         Console.WriteLine($"Puterea curentă a candelabru 2: {candelabruDoi.PutereCurenta}");

      }


   }
}
