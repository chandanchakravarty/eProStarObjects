using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;
using DataAccessLayer;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class ClaimAgentMasterManager    
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadAgentInformation(clsClaimAgentMaster objAgent)
        {
            object[] parameter = new object[3] { objAgent.CAgentType, objAgent.CAgentFor, objAgent.CAgentID };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentMaster_Select", "AgentSelect");

        }
        #region Search particular record for claim admin

        public DataSet LoadAllAgentInformationAll(clsClaimAgentMaster objAgent)
        {
            object[] parameter = new object[] { objAgent.CAgentType, objAgent.CAgentFor, objAgent.CAgentID, objAgent.EffectivefromDate, objAgent.EffectivefromDate2, objAgent.Effectivetodate, objAgent.Effectivetodate2, objAgent.ContactPerson, objAgent.CAgentCode };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentMaster_SelectALL", "AgentSelect");

        }
        #endregion
        public DataSet LoadAgentContactsDetail(AgentContacts objAgentCont)
        {
            object[] parameter = new object[2] { objAgentCont.CAgentID, objAgentCont.ContactId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentContacts_Select", "AgentContactSelect");

        }
        public DataSet DeleteAgentContactsDetail(int ContactId)
        {
            object[] parameter = new object[1] { ContactId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentContacts_Delete", "AgentContactDelete");

        }
        public DataSet SaveAgentInformation(clsClaimAgentMaster  objAgent)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[28]{
                                             objAgent.CAgentID,
                                             objAgent.CAgentCode,
                                             objAgent.CAgentType,
                                             objAgent.CAgentFor,
                                             objAgent.CAgentSource,
                                             objAgent.CAgentLocationType,
                                             objAgent.CompanyName,
                                             objAgent.Address1,
                                             objAgent.Address2,
                                             objAgent.Address3,
                                             objAgent.Salutation,
                                             objAgent.ContactPerson,
                                             objAgent.Email,
                                             objAgent.PrivateEMail,
                                             objAgent.TelNoResPref,
                                             objAgent.TelNoRes,
                                             objAgent.TelNoOffPref,
                                             objAgent.TelNoOff,
                                             objAgent.MobileNoPref,
                                             objAgent.MobileNo,
                                             objAgent.FaxNoPref,
                                             objAgent.FaxNo,
                                             objAgent.Country,
                                             objAgent.Remarks,
                                             objAgent.EffectivefromDate,
                                             objAgent.Effectivetodate,
                                             objAgent.User,
                                             objAgent.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentMaster_InsertUpdate", "AgentDetail");

        }
        public DataSet SaveAgentContactDetail(AgentContacts objAgentContact )
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[32]{
                                             objAgentContact.ContactId,
                                             objAgentContact.CAgentID,
                                             objAgentContact.Salutation,
                                             objAgentContact.ContactName,
                                             objAgentContact.Designation,
                                             objAgentContact.Address1,
                                             objAgentContact.Address2,
                                             objAgentContact.Address3,
                                             objAgentContact.BuildingName,
                                             objAgentContact.Email,
                                             objAgentContact.TelNoResPref,
                                             objAgentContact.TelNoRes,
                                             objAgentContact.TelNoOffPref,
                                             objAgentContact.TelNoOff,
                                             objAgentContact.MobileNoPref,
                                             objAgentContact.MobileNo,
                                             objAgentContact.FaxNoPref,
                                             objAgentContact.FaxNo,
                                             objAgentContact.Country,
                                             objAgentContact.Nationality,
                                             objAgentContact.PlaceOfBirth,
                                             objAgentContact.Occupation,
                                             objAgentContact.Gender,
                                             objAgentContact.PassportNo,
                                             objAgentContact.Dob,
                                             objAgentContact.PassportAttached,
                                             objAgentContact.LatestEducation,
                                             objAgentContact.ICAttached,
                                             objAgentContact.ICNo,
                                             objAgentContact.Remarks,
                                             objAgentContact.User,
                                             objAgentContact.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimAgentContacts_InsertUpdate", "AgentContactDetail");

        }
    }
}
