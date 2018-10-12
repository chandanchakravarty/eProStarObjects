using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsLedgerClass
    {
        public int LedgerClassId { get; set; }
        public int CompanyId { get; set; }
        public int ClassId { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public int isSelected { get; set; }
        public string Pagemode { get; set; }

        
    }

    public class clsLedgerClassList
    {
        //List<clsLedgerClass> objList=new List<clsLedgerClass>();
        public List<clsLedgerClass> LedgerList { get; set; }

    }

    public class clsLedgerClassDepartment
    {
        public int LedgerClassId { get; set; }
        public int TeamId { get; set; }
        public int ClassId { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public int isSelected { get; set; }
        public string Pagemode { get; set; }
    }
    public class clsLedgerClassDepartmentList
    {
        //List<clsLedgerClass> objList=new List<clsLedgerClass>();
        public List<clsLedgerClassDepartment> LedgerDepttList { get; set; }

    }

   
    
}
