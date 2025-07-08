using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqLambda
{
   public class Program
   {
      static void Main(string[] args)
      {
         Hashtable ht = new Hashtable();
         int index = 99;
         Random rnd = new Random();
         while (index >= 0)
         {
            ht.Add(index, rnd.Next(1000));
            index--;
         }

         var keys = ht.OfType<DictionaryEntry>().
                                     Where(entry => (int)entry.Value > 500)
                                     .Select(entry => (entry.Key, entry.Value));
         foreach (var pair in keys)
         {
            Console.WriteLine(pair);
         }

         XDocument xDocument = XDocument.Load("Customers.xml");



      }
   }
}
