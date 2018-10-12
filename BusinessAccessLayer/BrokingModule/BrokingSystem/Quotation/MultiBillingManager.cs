using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using DataAccessLayer;


namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class MultiBillingManager
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveMultiBilling(clsMultiBilling objMultiBill,string strXml,string Locationid)
        {
            object[] parameters = new object[10] {
                                                 objMultiBill.PolicyId,
                                                 objMultiBill.PolicyVerId,
                                                 objMultiBill.ClientId,
                                                 objMultiBill.UwriterId,
                                                 objMultiBill.Remarks,
                                                 objMultiBill.IsActive,
                                                 objMultiBill.User,
                                                 objMultiBill.PageMode,
                                                 strXml,
                                                 Locationid
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_MultiBilling_InsertUpdate", "Pol_Policy_MultiBilling_MultiBillingDetails");

        }
        public DataSet LoadMultiBilling(Int64 policyid,Int16 policyVerid, string Id)
        {
            object[] parameters = new object[3] {policyid,policyVerid,Id };
            dataAccessDS = new DataAccess();
            string[] Tables = { "Client", "UWriter", "MultiBillingDetial","PolDetail","UnserwriterMaster","Introducer" };
            return dataAccessDS.LoadDataSets(parameters, "P_Pol_Policy_MultiBilling_Select", Tables);

        }
        public DataSet GetEndorUWPremium(clsPolicyUnderwriter objpolUW)
        {
            object[] parameters = new object[4] { objpolUW.PolicyId, objpolUW.PolVersionId, objpolUW.UWId, objpolUW.ID };
            dataAccessDS = new DataAccess();
            string[] Tables = { "GetTotalPremiumByID", };
            return dataAccessDS.LoadDataSets(parameters, "P_Pol_Policy_MultiBilling_Indors_Select_UWPremium", Tables);

        }
        public DataSet GetEndorUWTotalDue(clsPolicyUnderwriter objpolUW)
        {
            object[] parameters = new object[4] { objpolUW.PolicyId, objpolUW.PolVersionId, objpolUW.UWId, objpolUW.ID };
            dataAccessDS = new DataAccess();
            string[] Tables = { "UnderwriterDue", };
            return dataAccessDS.LoadDataSets(parameters, "P_Pol_Policy_MultiBilling_Indors_Select_UWTotalDue", Tables);

        }
        public DataSet GetEndorUWTotalDueLeadBilling(clsPolicyUnderwriter objpolUW)
        {
            object[] parameters = new object[4] { objpolUW.PolicyId, objpolUW.PolVersionId, objpolUW.UWId, objpolUW.ID };
            dataAccessDS = new DataAccess();
            string[] Tables = { "UnderwriterDue", };
            return dataAccessDS.LoadDataSets(parameters, "P_Pol_Policy_MultiBilling_Indors_Select_UWTotalDue_LeadBilling", Tables);

        }
        public DataSet DeleteMultiBillingDetail(Int64 policyid, Int16 policyVerid,int clientid)
        {
            object[] parameters = new object[3] { policyid, policyVerid,clientid };
            dataAccessDS = new DataAccess();

            return dataAccessDS.LoadDataSet(parameters, "P_Pol_Policy_MultiBilling_MultiBillingDetails_Delete", "DeleteDetial");

        }
    }
}
