using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseMosteniriInterfete
{
   public class Culoare
   {
		private byte _alpha;
      private byte _red;  
      private byte _green;
      private byte _blue;

      private static short _cnt = 0;

      public static short Contor
      {
         get { return _cnt; }
         //set { _cnt = value; }
      }

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

         _cnt++;
      }

      public void Afiseaza()
      {
         Console.WriteLine($"Cei patru membrii ai oiectului sunt " +
            $"Alpha={_alpha},Red={_red},Green={_green},Blue={_blue}");
      }

      public void Complementeaza() 
      {
         _red = (byte)(0xFF - _red);
         _green = (byte)(0xFF - _green);
         _blue = (byte)(0xFF - _blue);    
      }

   }
}
