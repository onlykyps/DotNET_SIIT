using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colectii
{
   internal class Program
   {
      static void Main(string[] args)
      {
         //ArrayList lista = new ArrayList();
         //lista.Add(13);
         //lista.Add(13.13);

         ArrayList lista = new ArrayList { 13, 13.13 };
         lista.Add("13");
         lista.Add('1');
         lista.Add('3');

         string[] stringuri = { "13", "13.13", "31" };

         lista.Add(stringuri);
         //lista.Add(new string[3]{ "13", "13.13", "31" });

         foreach (var l in lista) 
         {
            if (l is string[])
            {
               string raspuns = "";
               foreach (var i in l as string[])
               {
                  raspuns = raspuns + i.ToString() + " ";

               }
               Console.WriteLine(raspuns);
            }
            else
            {
               Console.WriteLine(l);
            }
         }

         List<int> inturi = new List<int> {9,5,7,6,8,12,13,65}; 

         Console.WriteLine($"Inainte de insert, Capacity este {inturi.Capacity}");

         inturi.Insert(4, 200);

         Console.WriteLine($"Dupa insert, Capacity este {inturi.Capacity}");

         inturi.Remove(8);

         Console.WriteLine($"Dupa remove, Capacity este {inturi.Capacity}");

         inturi.Add(300);

         Console.WriteLine("Elementele listei sunt:");

         foreach (var l in inturi)
         {
            Console.WriteLine(l);
         }

         Console.WriteLine("********LinkedList<T>********");

         string[] words = { "incepe", "acolo", "unde", "se", "termina" };

         LinkedList<string> listaLinked = new LinkedList<string>(words);

         LinkedListNode<string> node = listaLinked.Find("se");
         listaLinked.AddBefore(node, "frica");

         listaLinked.AddFirst("Viata");

         foreach(var l in listaLinked)
         {
            Console.WriteLine(l);
         }

         Console.WriteLine("********Hashtable********");

         string textToHash = "Hash tables are efficient data structures. " +
                           "Hash tables provide fast, quick and efficient lookups. " +
                           "Using a hash table is very efficient!";
         string[] textHashArray = textToHash.ToLower()
                                          .Split(
                                                   new[] { ',', '.', '!', ' ' }, 
                                                   StringSplitOptions.RemoveEmptyEntries
                                                )
                                          .ToArray(); 
         Hashtable textHashtable = new Hashtable();

         foreach (var txt in textHashArray) 
         {
            if (textHashtable.ContainsKey(txt))
            {
               int contor = (int)textHashtable[txt];
               textHashtable[txt] = ++contor; // ++ se executa inainte de asignare
            }
            else 
            {
               textHashtable.Add(txt, 1);
            }
         }


         //foreach (var txt in textHashtable.Keys)
         //{
         //   Console.WriteLine (txt);
         //}

         foreach (DictionaryEntry pair in textHashtable)
         {
            Console.WriteLine($"Word {pair.Key} appears {pair.Value} times");
         }
      }
   }
}
