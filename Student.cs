using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
	public class Student
	{
		private int m_Age;
		private string m_Nume;
        private int m_Mark;

        const int MAX_AGE = 99;
		const int MIN_AGE = 18;

		public readonly string m_info;

		public int Mark
		{
			get { return m_Mark; }
			set { m_Mark = value; }
		}

		public int Age
		{
			get { return m_Age; }
			set { m_Age = value; }
		}

		public string Nume
		{
			get { return m_Nume; }
			set { m_Nume = value; }
		}

        public Student(int age, string name)
        {
            this.m_info = name + " " + age.ToString();
			this.m_Age = age;
			this.m_Nume = name;	
        }
		
    }
}
