using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Culoare
   {
		private byte _alpha;
      private byte _red;  
      private byte _green;
      private byte _blue;

		public byte Alpha
		{
			get { return _alpha; }
			set { _alpha = value; }
		}

      public byte Red
      {
         get { return _red; }
         set { _red = value; }
      }

      public byte Green
      {
         get { return _green; }
         set { _green = value; }
      }
      
      public byte Blue
      {
         get { return _blue; }
         set { _blue = value; }
      }

   }
}
