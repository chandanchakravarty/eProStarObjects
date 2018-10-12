using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;


namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
   public class VAT_SBT_WHT_Manager
    {
       DataAccess dataAccess = null;
       clsVAT_SBT_WHT objinfo = new clsVAT_SBT_WHT();
       public DataSet get_VAT_SBT_WHT(clsVAT_SBT_WHT objinfo)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[2] { objinfo.ID ,objinfo.Text_Type };
           return dataAccess.LoadDataSet(parameters, "P_Adm_VAT_SBT_WHT_List", "VAT_SBT_WHT_List");
       }
       public DataSet Save_VAT_SBT_WHT(clsVAT_SBT_WHT objsave)
       {

           dataAccess = new DataAccess();
           Object[] parameters = new Object[] {
               objsave.ID,
            
               objsave.Description,
               objsave.Rate,
               objsave.EffFromDate,
               objsave.EffToDate,                                            
               objsave.LoginUserId,
               objsave.PageMethod,
               objsave.Text_Type,
               objsave.VSWType};
           return dataAccess.LoadDataSet(parameters, "P_Adm_VAT_SBT_WHT_InsertUpdate", "VAT_SBT_WHT_InsertUpdate");
       }
       public DataSet get_VAT_SBT_WHTAll(clsVAT_SBT_WHT objinfo)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[8] { objinfo.Description, objinfo.Rate, objinfo.EffFromDate, objinfo.EffFromDate1, objinfo.EffToDate, objinfo.EffToDate1, objinfo.Text_Type, objinfo.VSWType };
           return dataAccess.LoadDataSet(parameters, "P_Adm_VAT_SBT_WHT_ListAll", "VAT_SBT_WHT_ListAll");
       }

       public DataSet getVAT_SBT_WHT_Rate( string TextType,string AllRecords = "N")
       {
           string[] parameters = new string[] { TextType, AllRecords };
           dataAccess = new DataAccess();
           return dataAccess.LoadDataSet(parameters ,"P_Get_VAT_SBT_WHT", "TM_VSW");
       }

       public DataSet getVAT_SBT_WHT_ExpiredRec(string TextType)
       {
           string[] parameters = new string[1] { TextType };
           dataAccess = new DataAccess();
           return dataAccess.LoadDataSet(parameters, "P_VAT_SBT_WHT_GetRecord", "TM_VSW_Expired");
       }

       public DataSet get_VAT_SBT_WHT_Active(clsVAT_SBT_WHT objinfo)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[2] { objinfo.ID, objinfo.Text_Type };
           return dataAccess.LoadDataSet(parameters, "P_Adm_VAT_SBT_WHT_List_Active", "VAT_SBT_WHT_List");
       }

       public DataSet get_WHT_Active()
       {
           dataAccess = new DataAccess();
           //Object[] parameters = new Object[2] { objinfo.ID, objinfo.Text_Type };
           return dataAccess.LoadDataSet("P_Adm_WHT_List_Active", "WHT_List");
       }

       public DataSet CheckVSWTypeExist(clsVAT_SBT_WHT objinfo)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[3] { objinfo.ID, objinfo.Text_Type, objinfo.VSWType };
           return dataAccess.LoadDataSet(parameters, "P_Adm_VAT_SBT_Exist", "P_Adm_VAT_SBT_Exist");
       }

       public DataSet getGSTRate(string Taxype)
       {
           string[] parameters = new string[] { Taxype };
           dataAccess = new DataAccess();
           return dataAccess.LoadDataSet(parameters, "P_Get_GSTExchaneRate", "TM_GSTRate");
       }

       public DataSet BindDefaultGST(string PolicyID, string PolicyVerID)
       {
           string[] parameters = new string[] { PolicyID, PolicyVerID };
           dataAccess = new DataAccess();
           return dataAccess.LoadDataSet(parameters, "P_Bind_Default_GST", "P_Bind_Default_GST");
       }
    }
}
