using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti 5 studenti");
            List<Student> students = new List<Student>();

            int i = 5;
            while (i > 0)
            {
                i--;
                Console.WriteLine("Nume student: ");
                string nume = Console.ReadLine();
                Console.WriteLine("Varsta student: ");
                int varsta = Int32.Parse(Console.ReadLine());

                students.Add(new Student(varsta, nume));    

            }

            foreach (Student student in students) 
            {
               Console.WriteLine(student.m_info);
            }

            

            Random rnd = new Random();
            List<int> pozCatalog = new List<int>();
            int catePoz = rnd.Next(5);

            Console.WriteLine($"Vom introduce cateva note la {catePoz} elevi");

            while (catePoz > 0)
            {
                int pozDeAdaugat = rnd.Next(5);
                if (!pozCatalog.Contains(pozDeAdaugat))
                {
                    pozCatalog.Add(pozDeAdaugat);
                    catePoz--;
                }
            }

            foreach (int item in pozCatalog)
            {
                Console.WriteLine($"Elevul {students.ElementAt(item).Nume} primeste nota: ");
                students.ElementAt(item).Mark = Int32.Parse(Console.ReadLine());
            }

            double mediaClasei = 0;

            foreach(Student student in students)
            {
                if(student.Mark != 0)
                {
                    mediaClasei += student.Mark;
                }
            }
            mediaClasei = mediaClasei / pozCatalog.Count;
            Console.WriteLine($"Media clasei este {mediaClasei}");
        }
    }
}
