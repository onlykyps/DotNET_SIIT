using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWithExceptionsAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dog dog = new Dog(5, "Rex")
                {
                    Age = 5,
                    Name = "Rex"
                };

                Console.WriteLine($"Dog Name: {dog.Name}, Age: {dog.Age}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException: {ex.Message}");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"ApplicationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }


    }
}

