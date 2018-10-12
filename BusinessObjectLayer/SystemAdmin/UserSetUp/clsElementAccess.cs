using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
   public class clsElementAccess
   {
       public int ElementAccessId { get; set; }
       public string EntityType { get; set; }
       public string EntityId { get; set; }
       public string ScreenID { get; set; }
       public bool ReadAccess { get; set; }
       public bool ModifyAccess { get; set; }
       public bool DeleteAccess { get; set; }
       public string Caption { get; set; }
       public string CreatedBy { get; set; }
       public string LastUpdatedBy { get; set; }
       public string IsActive { get; set; }
       public int ElementRefID { get; set; }
       public int UserID { get; set; }
   }

  public class ElementAccessList
   {
       public List<clsElementAccess> AccessList { get; set; }
   }
}
