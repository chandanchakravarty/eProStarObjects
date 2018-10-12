using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
  public class DivisionalGroupingManager
  {
      DataSet ds;
        DataAccess dataAccess = null;
        public DataSet getDivisionalGroupingDetails(clsDivisionalGrouping objDiv)
        {
            dataAccess = new DataAccess();
            //Object[] parameters = new Object[] { objDiv.DivType, objDiv.Channel, objDiv.SubChannel, "", "", objDiv.EffFrom, objDiv.EffFrom1, objDiv.EffTo, objDiv.EffTo1, jDiv.ID };
            //test check
            Object[] parameters = new Object[] { "", "", "", objDiv.DivCode, objDiv.DivName, objDiv.EffFrom, objDiv.EffFrom1, objDiv.EffTo, objDiv.EffTo1, objDiv.ID };
            
            return dataAccess.LoadDataSet(parameters, "P_Pol_DivisionalGroupingMasterSelectAll", "DivisionalGroupingDetails");
        }
        public DataSet SaveDivisionalGroupingDetails(clsDivisionalGrouping objDiv)
        {
            //dataAccess = new DataAccess();
            //Object[] parameters = new Object[] {objDiv.ID ,objDiv.DivType, objDiv.Channel,objDiv.Channel,
            //    objDiv.EffFrom ,
            //    objDiv.EffTo  ,
            //    objDiv.CreatedBy,
            // "" , 
            //   ""};

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objDiv.ID ,"","","",
                objDiv.EffFrom ,
                objDiv.EffTo  ,
                objDiv.CreatedBy,
             objDiv.DivCode , 
                objDiv.DivName};

            return dataAccess.LoadDataSet(parameters, "P_Pol_DivisionalGroupingMaster_InsertUpdate", "DivisionalGroupingInsertUpdate");
        }
        public DataSet getDivisionalGroupingDetailsLCHLAW(clsDivisionalGrouping objDiv)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { "", "", "", objDiv.DivCode, objDiv.DivName, objDiv.EffFrom, objDiv.EffFrom1, objDiv.EffTo, objDiv.EffTo1, objDiv.ID };
            return dataAccess.LoadDataSet(parameters, "P_Pol_DivisionalGroupingMasterSelectAll", "DivisionalGroupingDetails");
        }
        public DataSet SaveDivisionalGroupingDetailsLCHLAW(clsDivisionalGrouping objDiv)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objDiv.ID ,"","","",
                objDiv.EffFrom ,
                objDiv.EffTo  ,
                objDiv.CreatedBy,
             objDiv.DivCode , 
                objDiv.DivName};
            return dataAccess.LoadDataSet(parameters, "P_Pol_DivisionalGroupingMaster_InsertUpdate", "DivisionalGroupingInsertUpdate");
        }
    }
}
