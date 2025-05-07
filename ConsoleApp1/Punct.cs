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

		public void Afiseaza()
		{
         Console.WriteLine($"Coordonate:X={_x}, Y={_y}");
			//_culoare.Afiseaza();
      }

      public void ComplementeazaCuloarea()
      {
         _culoare.Complementeaza();
      }

		public void Inverseaza()
		{
			_x = -1*_x;
			_y = -1*_y;
		}

		public void Muta(double _x, double _y)
		{
         //this.Afiseaza();

         _y = this._y;
         _x = this._x;

			this._x -= _y;
			this._y -= _x;

			this.Afiseaza();

		}

   }
}
