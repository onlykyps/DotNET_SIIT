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

         XElement root = xDocument.Root;
         //Console.WriteLine(root);

         IEnumerable<XElement> descendants = root.Descendants();
         Console.WriteLine(descendants.Count());

         Console.WriteLine("--------------- Lista nume noduri -----------------");
         IEnumerable<XName> johnSql = 
            from xElem in descendants
            select xElem.Name;

         //XName MetSelect (XElement xElem)
         //{
         //   return xElem.Name;
         //}

         IEnumerable<XName> paulSql = descendants.Select(x => x.Name);  

         foreach (XName name in johnSql)
         {
            Console.WriteLine(name);
         }

         Console.WriteLine("--------------- Lista noduri customer -----------------");

         IEnumerable<XElement> stapaniiNostri = descendants.Select(x => x)
            .Where(y => y.Name == "Customer");

         foreach (XElement item in stapaniiNostri)
         {
               Console.WriteLine(item);
         }


         Console.WriteLine("--------------- Hourly Fee -----------------");

         IEnumerable<string> hourlyFeeNodeValues = descendants.Where(x => x.Name == "HourlyFee")
                                                               .Select(y => y.Value);

         double medie = hourlyFeeNodeValues.Average(m => int.Parse(m));
         double valMax = hourlyFeeNodeValues.Max(vmx => int.Parse(vmx));
         double valMin = hourlyFeeNodeValues.Min(vmn => int.Parse(vmn));

         Console.WriteLine($"Media {medie}, Maxim {valMax}, Minim {valMin}");

         Console.WriteLine("--------------- Ordine desc -----------------");

         IEnumerable<XElement> listaProiecte = descendants.Select(x => x)
                                                         .Where(y => y.Name == "Project")
                                                         .OrderByDescending(z => z.Attribute("numsize").Value);

         foreach (XElement item in listaProiecte)
         {
            Console.WriteLine(item);
         }

      }
   }
}
