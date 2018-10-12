using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Flex
{
    public class FlexBsToCsv
    {
           public Int64 csvId{get;set;}
           public string InternalFileName{get;set;}
           public string DisplayFileName{get;set;}
           public string ImportFor{get;set;}
           public string FileType{get;set;}
           public int Total_No_of_Records{get;set;}
           public int BatchRefId{get;set;}
           
    }
}
