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

      public Culoare(byte _alpha, byte _red, byte _green, byte _blue )
      {
         this._alpha = _alpha;
         this._red = _red;
         this._green = _green;
         this._blue = _blue;
      }
   }
}
