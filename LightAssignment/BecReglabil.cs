using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightAssignment
{
   public class BecReglabil
   {
      private int m_PutereMaxima;
      private int m_PutereCurenta;
      
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

      private bool m_Aprins;

      public bool Aprins
      {
         get { return m_Aprins; }
         set { m_Aprins = value; }
      }



      public BecReglabil(int PutereMaxima, int PutereCurenta) 
      {
         this.PutereCurenta = PutereCurenta;
         this.PutereMaxima = PutereMaxima;
         
      }

      public BecReglabil()
      {
            
      }

      public void Aprinde()
      {

      }
      public void Stinge()
      {

      }
      public void MaresteLumina()
      {


      }
      public void ReduceLumina()
      {

      }

   }
}
