
namespace Utility
{
    public class Constants
    {
        public const string BLANKNUMERIC = "0";

        public enum RedirectType
        {
            ResponseRedirect,
            ServerTransfer
        }

        public enum LockMemberModule
        {
            Member = 1,
            BusinessUnderwriting,
            MedicalUnderwriting,
            PendingActivation,
            MemberMaintenance,
            MemberTransfer,
            MassMemberTransfer,
            Referral,
            Claim,
            Recoveries,
            MemberSuspension,
            ClaimRegistration,
            PendingClaims,
            CancelSuspension,
            VoidMember
        }


        public enum PageAction
        {
            SearchBack,
            SearchBack1,
            Search,
            AddNew,
            AddEditBack,
            Save,
            Cancel,
            EditData,
            DeleteData,
            ViewData,
            Add,
            Next,
            Previous,
            Select,
            CopyData,
            Print,
            Complete,
            Back,
            CompletePlan,
            Approve,
            Reject,
            CancelReferral,
            Pending,
            Void,
            AddSPFee,
            Exporttoexcel,
            DeleteDrugFormulary,
            ClearAll,
            Transfer,
            Upload,
            Remove,
            Update,
            Refresh,
            SelectAll,
            UnSelectAll,
            MassApprove,
            Accept,
            Appeal,
            Reversal
        }
        public enum ExclusionCapType
        {
            Exclusion = 1,
            CapSingle = 2,
            CapCombined = 3
        }

        public enum ClaimType
        {
            Provider = 1,
            Member = 2
        }

        //ClaimType Query String
        public enum ClaimTypeQS
        {
            Provider = 'P',
            Member = 'M'
        }

        public enum LimitType
        {
            PL0, //PlanLimit
            LTL, // LifetimeLimit
            CCL, // CombinedClassLimit
            CL0, //CombinedLimit
            CSL, // CombinedSubLimit
            CIL, // CoInsLimit
            DL0, // DeductibleLimit
            CLS,// ClassLimit
            FIE,//Family Limit(Including Employee)
            FEE,//Family Limit(Excluding Employee),
            GF0, //Grandfathering            
            FDI,//Family Deductible(Including Employee)
            FDE//Family Deductible(Excluding Employee),
        }

        public enum RangeType
        {
            F001, //Frequency Range Type
            A001 //Amount Range Type
        }

        public enum PageMode
        {
            New,
            View,
            Edit,
            Delete
        }

        public enum IPRules
        {
            WardEntitlement = 6,
            CashBenefits = 7,
            Proration = 8,
            ShieldDeductible = 9
        }
        public enum ValidationTypes
        {

            DateYYYYMMDD,
            PositiveInteger,
            AlphaNumeric,
            PositiveIntAndDecimal,
            Alphabet,
            Numeric4Digits,
            AlphaNumericWithSpecialChars,
            DateDDMMYYYY,
            AlphaNumericCheck
        }
        public enum SurgicalType
        {
            Surgical,
            InHospConsult,
            Anaesthetist
        }

        public enum ClaimStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3,
            Cancelled = 4,
            Reopen = 5,
            PendingForApproval = 6,
            Reversal = 8,
            Paid = 9,
            Reclass = 10,
            Tagged = 12
        }

        //ClaimStatus Query String
        public enum ClaimStatusQS
        {
            Pending = 'P',
            Approved = 'E',
            Rejected = 'R',
            Cancelled = 'C',
            Reopened = 'O',
            Enquiry = 'E',
            PendingForApproval = 'A'
        }

        public enum BenefitType
        {
            NONE,//None
            DRG,//Drug Formulary
            FSCH,//Fee Schedule
            SPS,//SP Surgical Fee
            ICU,//Intensive Care Unit
            RB,//Room and Board
            MISC,//Miscellaneous
            IHC//In Hospital Consiltation
        }

        public enum PaymentType
        {
            PROVIDER,
            CLIENT,
            MEMBER,
            MEDISAVE,
            SHIELD
        }                  
    }
}