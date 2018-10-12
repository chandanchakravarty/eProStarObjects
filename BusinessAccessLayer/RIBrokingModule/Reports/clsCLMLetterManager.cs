using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
//using BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims;
using BusinessObjectLayer.RIBrokingModule.Reports;

namespace BusinessAccessLayer.RIBrokingModule.Reports
{
    public class clsCLMLetterManager
    {
        DataAccess dataAccess = null;
        public DataSet GetClaimLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_CLMLetter_Select", "EB_LetterList");
        }

        public DataSet GetInvoiceDebitNoteLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_INVDebitNoteLetter_Select", "EB_LetterList");
        }

        public DataSet GetInvoiceLetterList(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_PaidClaimAckLetter_Select", "EB_LetterList");
        }

        public DataSet GetEBInsurerInpatientLetterList(string UWCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { UWCode };
            return dataAccess.LoadDataSet(parameters, "P_Ltr_EBInsurerInpatient_Select", "EB_LetterList");
        }

        public DataSet GetFooterCountry(string strModule)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strModule };
            return dataAccess.LoadDataSet(parameters, "P_TM_FooterCountry_Select", "FooterCountryList");
        }

        public DataSet GetCurrencyCountry(int CountryCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { CountryCode };
            return dataAccess.LoadDataSet(parameters, "P_TM_CurrencyDataBycountry_Select", "CurrencyCountry");
        }
    }
}
