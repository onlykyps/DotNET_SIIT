using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Punct
   {

		private Double _x, _y;
      private Culoare _culoare;

		//private Double _coordX;
		//private Double _coordY;

		private static short _cnt  = 0;

		public static short Contor
      {
			get { return _cnt; }
         //set { _cnt = value; }
      }


      public Double CoordX
		{
			get { return _x; }
			set { _x = value; }
		}

		public Double CoordY
		{
			get { return _y; }
			set { _y = value; }
		}

		public Culoare Culoare
      {
			get { return _culoare; }
			set { _culoare = value; }
		}

      public Punct(Double _x, Double _y, Culoare culoare)
      {
			this._x = _x;
			this._y = _y;
			this._culoare = culoare;

         _cnt++;
      }

   }
}
