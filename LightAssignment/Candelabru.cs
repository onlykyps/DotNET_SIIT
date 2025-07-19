using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LightAssignment
{
   public class Candelabru
   {
      #region props full
      private BecReglabil[] m_ListaBecReg;

		public BecReglabil[] ListaBecReg
      {
			get { return m_ListaBecReg; }
			set { m_ListaBecReg = value; }
		}
      #endregion
      
      #region props
      public bool Aprins
      {
         get { return ListaBecReg.Any(x => x.Aprins); }
      }

      public int PutereMaxima
      {
         get { return ListaBecReg.Sum(x => x.PutereMaxima); }
      }

      public int PutereCurenta
      {
         get { return ListaBecReg.Sum(x => x.PutereCurenta); }
      }
      #endregion
      
      public Candelabru(params int[] puteriMax)
      {
         ListaBecReg = new BecReglabil[puteriMax.Length];

         for (int i = 0; i < puteriMax.Length; i++) 
         {
            ListaBecReg[i] = new BecReglabil(puteriMax[i]);
         }

      }

      #region methods
      public void Aprinde()
      {
         foreach (var bec in ListaBecReg)
         {
            bec.Aprinde();
         }
      }
      public void Stinge()
      {
         foreach (var bec in ListaBecReg)
         {
            bec.Stinge();
         }
      }
      public void MaresteLumina(int lumen)
      {
         foreach (var bec in ListaBecReg)
         {
            bec.MaresteLumina(lumen);
         }

      }
      public void ReduceLumina(int lumen)
      {
         foreach (var bec in ListaBecReg)
         {
            bec.ReduceLumina(lumen);
         }
      }
      #endregion
     
   }
}
