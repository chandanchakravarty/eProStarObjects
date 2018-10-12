using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsRenewalChkList
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string PolicyNo { get; set; }
        public string Insurer { get; set; }
        public string PaymentMode { get; set; }
        public string RenewalDate { get; set; }
        public bool ClmsExpForLast2YrsYN { get; set; }
        public string ClmsExpForLast2YrsDate { get; set; }
        public string ClmsExpForLast2YrsRemarks { get; set; }
        public bool RenewalOfferYN { get; set; }
        public string RenewalOfferDate { get; set; }
        public string RenewalOfferRemarks { get; set; }
        public string RenOfferFrwdToMrkgClgsDate { get; set; }
        public bool UpdateCensusYN { get; set; }
        public string UpdateCensusDate { get; set; }
        public string UpdateCensusRemarks { get; set; }
        public bool OverageOverseaLoadingYN { get; set; }
        public string OverageOverseaLoadingRemarks { get; set; }
        public bool PrpslToClientYN { get; set; }
        public string PrpslToClientDate { get; set; }
        public string PrpslToClientRemarks { get; set; }
        public bool PrpslToClientRevised1YN { get; set; }
        public string PrpslToClientRvsd1Date { get; set; }
        public string PrpslToClientRvsd1Remarks { get; set; }
        public bool PrpslToClientRvsd2YN { get; set; }
        public string PrpslToClientRvsd2Date { get; set; }
        public string PrpslToClientRvsd2Remarks { get; set; }
        public bool CntctClientDscussRnwlYN { get; set; }
        public string CntctClientDscussRnwlDate { get; set; }
        public bool MediTopPromotionYN { get; set; }
        public string MediTopPromotionDate { get; set; }
        public bool MeetingWithClientYN { get; set; }
        public string MeetingWithClientDate { get; set; }

        public bool VaccinationYN { get; set; }
        public string VaccinationDate { get; set; }
        public bool MeetingWithClient2ndYN { get; set; }
        public string MeetingWithClient2ndDate { get; set; }
        public bool StaffBriefingYN { get; set; }
        public string StaffBriefingDate { get; set; }
        public bool MeetingWithClient3rdYN { get; set; }
        public string MeetingWithClient3rdDate { get; set; }
        public bool AfterSalesServiceYN { get; set; }
        public string AfterSalesServiceDate { get; set; }
        public bool RcvdCnfmtnSlpFrmClientYN { get; set; }
        public string RcvdCnfmtnSlpFrmClientDate { get; set; }
        public string RcvdCnfmtnSlpFrmClientRemarks { get; set; }
        public bool MakeCnfmtnToInsurerYN { get; set; }

        public string MakeCnfmtnToInsurerDate { get; set; }
        public string MakeCnfmtnToInsurerRemarks { get; set; }
        public bool PolicyEndrsmntIssuedYN { get; set; }
        public string PolicyEndrsmntDate { get; set; }
        public string PolicyEndrsmntRemarks { get; set; }
        public bool SOSCardMdclCardYN { get; set; }
        public string SOSCardMdclCardDate { get; set; }
        public string SOSCardMdclCardRemarks { get; set; }

        public bool MmbrBookletLeafletYN { get; set; }
        public string MmbrBookletLeafletDate { get; set; }
        public string MmbrBookletLeafletRemarks { get; set; }
        public bool PanelDoctorLstYN { get; set; }
        public string PanelDoctorLstDate { get; set; }
        public string PanelDoctorLstRemarks { get; set; }
        public bool PremiumBillYN { get; set; }
        public string PremiumBillDate { get; set; }

        public string PremiumBillRemarks { get; set; }
        public bool PremiumBillAdjstmntYN { get; set; }
        public string PremiumBillAdjstmntDate { get; set; }
        public string PremiumBillAdjstmntRemarks { get; set; }
        public string ExistingBrokerage { get; set; }
        public string ExistingPremium { get; set; }
        public string RenewalBrokerage { get; set; }
        public string RenewalPremium { get; set; }
        public string InsurerName { get; set; }
        public string Marketing { get; set; }
        public string Admin { get; set; }
        public string DcmntsFrwdToAdminColleagueOn { get; set; }
        public string User { get; set; }
    }
    public class clsRenRemarket
    {
        public int RenRemarketId { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public string InvitationSendOutDate { get; set; }
        public string QuotationReceivedDate { get; set; }
    }

    public class clsRenRemarketList
    {
        public List<clsRenRemarket> RenRemarketList { get; set; }
    }
    public class clsRenSubClasses
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int SubClassId { get; set; }
        
    }
    public class clsRenSubClassList
    {
        public List<clsRenSubClasses> RenSubClassList { get; set; }
    }


}
