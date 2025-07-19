using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightAssignment
{
   public class BecReglabil
   {
      #region props full
      private int m_PutereMaxima;
      private int m_PutereCurenta;
      private bool m_Aprins;


      public int PutereMaxima
      {
         get { return m_PutereMaxima; }
         set { m_PutereMaxima = value; }
      }

      public int PutereCurenta
      {
         get { return m_PutereCurenta; }
         set { m_PutereCurenta = value; }
      }

      public bool Aprins
      {
         get { return PutereCurenta > 0; }
         //set { m_Aprins = value; }
      }
      #endregion

      #region ctors
      public BecReglabil(int PutereMaxima, int PutereCurenta)
      {
         this.PutereCurenta = PutereCurenta;
         this.PutereMaxima = PutereMaxima;

      }

      public BecReglabil()
      {

      }

      public BecReglabil(int putereMaxima)
      {
         this.PutereMaxima = putereMaxima;
         this.PutereCurenta = 0;
      }
      #endregion

      #region methods
      public void Aprinde()
      {
         PutereCurenta = PutereMaxima;
      }

      public void Stinge()
      {
         PutereCurenta = 0;
      }

      public void MaresteLumina(int lumen)
      {
         PutereCurenta += lumen;

         if (PutereCurenta > PutereMaxima)
         {
            PutereCurenta = PutereMaxima;
         }

      }
      public void ReduceLumina(int lumen)
      {
         PutereCurenta -= lumen;

         if (PutereCurenta < 0)
         {
            PutereCurenta = 0;
         }
      }
      #endregion

   }
}
