using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
   public class ClientReassignment
    {

        public int ClientReassignmentId { get; set; }
        public int ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientShortName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int SEUserId { get; set; }
        public string SEFirstName { get; set; }
        public string SELastName { get; set; }
        public string SeEffectiveDateFrom { get; set; }
        public string SeEffectiveDateTo { get; set; }
        public int MEUserId { get; set; }
        public string MEFirstName { get; set; }
        public string MElastName { get; set; }
        public string MeEffectiveDateFrom { get; set; }
        public string MeEffectiveDateTo { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
