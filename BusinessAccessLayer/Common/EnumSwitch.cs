using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.Common
{
    public enum TransactionType
    {
        policy,
        Client,
        DebitNoteWOCovernote,
        DebitNoteWCovernote,
        Claims,
        SYSADMIN,
        BMADMIN,
        RIBMADMIN,
        EBClaim,
        ClaimAdmin
    }
}
