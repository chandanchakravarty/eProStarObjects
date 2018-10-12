using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Web.UI.WebControls;


namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
   public class VIPClassificationManager
    {
           DataAccess dataAccess = null;
           clsVIPClassification objinfo = new clsVIPClassification();

           public DataSet get_Jurisdiction(clsJurisdiction objinfo)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[1] { objinfo.JurisID };
               return dataAccess.LoadDataSet(parameters, "P_Adm_JurisdictionList", "Jurisdiction_List");
           }

          


           public DataSet get_VIPClassification(clsVIPClassification  objinfo)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[1] {objinfo.VipID};
               return dataAccess.LoadDataSet(parameters, "P_Adm_VIPClassification_List", "VIPClassification_List");
           }

           public DataSet get_VIPClassificationClient(clsVIPClassification objinfo)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[1] { objinfo.VipID };
               return dataAccess.LoadDataSet(parameters, "P_Client_VIPClassification_List", "VIPClassification_List");
           }
           public DataSet get_VIPClassificationAll(clsVIPClassification objinfo)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[6] { objinfo.VipType ,objinfo.VipDescription,objinfo.EffFromDate,objinfo.EffFronDate1,objinfo.EffToDate,objinfo.EffToDate1};
               return dataAccess.LoadDataSet(parameters, "P_Adm_VIPClassification_ListAll", "VIPClassification_List");
           }

           public DataSet get_JurisdictionAll(clsJurisdiction objinfo)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[5] { objinfo.Juris, objinfo.EffFromDate, objinfo.EffFronDate1, objinfo.EffToDate, objinfo.EffToDate1 };
               return dataAccess.LoadDataSet(parameters, "P_Adm_Jurisdiction_ListAll", "Jurisdiction_List");
           }

           public DataSet Save_VIPClassification(clsVIPClassification objsave)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[] {
               objsave.VipID,
               objsave.VipType ,
               objsave.VipDescription ,
               objsave.EffFromDate,
               objsave.EffToDate,                                            
               objsave.LoginUserId,
               objsave.PageMethod};
               return dataAccess.LoadDataSet(parameters, "P_Adm_VIPClassification_InsertUpdate", "VIPClassification_InsertUpdate");
           }

           #region for binding BindVIPType dropdowns
           public void BindVIPType(DropDownList ddlVIPType)
           {
               clsVIPClassification objVIPInfo = new clsVIPClassification();
               string VIPType = string.Empty;
               objVIPInfo.VipID = 0;
               DataSet dsVIPType = new DataSet();
               dsVIPType = get_VIPClassificationClient(objVIPInfo);
               if (dsVIPType.Tables[0].Rows.Count > 0)
               {
                   ddlVIPType.DataSource = dsVIPType;
                   ddlVIPType.DataTextField = "VipType";
                   ddlVIPType.DataBind();
                   ddlVIPType.Items.Insert(0, new ListItem("None", "0"));
               }
           }
           #endregion

           public DataSet SaveJurisdication(clsJurisdiction objsave)
           {
               dataAccess = new DataAccess();
               Object[] parameters = new Object[] {
               objsave.JurisID,
               objsave.Juris ,
           
               objsave.EffFromDate,
               objsave.EffToDate,                                            
               objsave.LoginUserId,
               objsave.PageMethod};
               return dataAccess.LoadDataSet(parameters, "P_Adm_Jurisdiction_InsertUpdate", "Jurisdiction_InsertUpdate");
           }

    }
}
