using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWithExceptionsAssignment
{
    public class Dog
    {
        private int m_age;
        private string m_name;

        public int Age
        {
            get 
            { 
                return m_age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }
                if (value > 100)
                {
                    throw new ApplicationException("Age cannot be greater than 100.");
                }
                m_age = value;
            }
        }

        public string Name
        {
            get
            { 
                return m_name; 
            }
            set
            {
                if (value.Length < 2)
                {
                    throw new ApplicationException("Name must have at least 2 characters.");
                }
                m_name = value;
            }
        }

        public Dog(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }
}
