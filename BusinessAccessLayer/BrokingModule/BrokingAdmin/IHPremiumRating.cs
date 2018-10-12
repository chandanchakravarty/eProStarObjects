using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;


namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class IHPremiumRating
    {
       DataAccess dataAccessDS = null;

       public DataSet getDropDownValuesFroIHRating(clsIHPremiumRating ObjIHPremiumRating)
       {

           dataAccessDS = new DataAccess();
           object[] parameters = new object[] { ObjIHPremiumRating.UnderWriterName, ObjIHPremiumRating.ProductName };
           return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Values", "P_Get_IHPremuimRating_Values");

       }
       public DataSet getProductCodeAndUWCode(clsIHPremiumRating ObjIHPremiumRating)
       {

           dataAccessDS = new DataAccess();
           object[] parameters = new object[] { ObjIHPremiumRating.PolicyId, ObjIHPremiumRating.PolVersionId };
           return dataAccessDS.LoadDataSet(parameters, "Pol_Policy_UWCodeandProductCode", "ProductUWCode");

       }

       public DataSet getProductName(clsIHPremiumRating ObjIHPremiumRating)  
       {

           dataAccessDS = new DataAccess();
           object[] parameters = new object[] { ObjIHPremiumRating.UnderWriterName,ObjIHPremiumRating.ProductName ,ObjIHPremiumRating.calledFrom};
           return dataAccessDS.LoadDataSet(parameters,"P_Get_ProductName_From_UWCode", "P_Get_ProductName_From_UWCode");

       }

       public DataSet getIHCardPrinting(clsIHPremiumRating ObjIHPremiumRating)
       {
           object[] parameters = new object[] { ObjIHPremiumRating.Name, 
               ObjIHPremiumRating.PolicyNo, 
               ObjIHPremiumRating.SixtinthDigitsNo,
               ObjIHPremiumRating.Scheme,
               ObjIHPremiumRating.Program,
               ObjIHPremiumRating.PlanType,
               ObjIHPremiumRating.EffFromDate,
               ObjIHPremiumRating.EffToDate
           };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters, "Get_TMIHCardPrinting", "TM_IH_CardPrinting");

       }
        //added by kavita kaushik//
      
        public DataSet get_IHPremiumData(string underWriter,string product,string unique)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new object[] { underWriter, product, unique };
            return dataAccessDS.LoadDataSet(parameters,"get_Temp_IHPremiumData", "TM_IH_TempPremiumRating");

        }
       //Binding Scheme from Scheme master
        public DataSet getScheme(string data)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new object[] { data };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Scheme", "IHScheme");
        }
        //for bind Programme
        public DataSet getProgram(clsIHPremiumRating objRating)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { objRating.UnderWriterName, objRating.ProductName};
            return dataAccessDS.LoadDataSet(parameters,"P_Get_IHPremuimRating_Program", "IHProgram");
        }
       //end

       //for bind age//
        public DataSet getAge(clsIHPremiumRating objRating)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { objRating.UnderWriterName, objRating.ProductName };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Age", "IHAge");
        }
       //end of age

       //for bind Area
        public DataSet getDeductible(clsIHPremiumRating objRating)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { objRating.UnderWriterName, objRating.ProductName };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Deductible", "IHDeductible");
        }
        public DataSet getDiscount(clsIHPremiumRating objRating)
       {

           dataAccessDS = new DataAccess();
           object[] parameters = new Object[] { objRating.UnderWriterName, objRating.ProductName };
           return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Discount", "IHDiscount");
       }
       //end of area

             //for bind deductible
        public DataSet getArea(clsIHPremiumRating objRating)
        {

            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { objRating.UnderWriterName, objRating.ProductName };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_IHPremuimRating_Area", "IHArea");
        }
       
        //end

       //Function for Search the Record
       public DataSet Search_IHPremiumData( clsIHPremiumRating objclsIHPremium)
       {
           object[] parameters = new object[] {objclsIHPremium.IH_ID,  objclsIHPremium.Program,objclsIHPremium.Area,objclsIHPremium.Dedcutible,
               objclsIHPremium.Age,objclsIHPremium.EffFromDate,objclsIHPremium.EffToDate,objclsIHPremium.Discount,objclsIHPremium.UniqueNo,objclsIHPremium.UnderWriterName,objclsIHPremium.ProductName  };
           dataAccessDS = new DataAccess();

           return dataAccessDS.LoadDataSet(parameters, "P_TM_IHPremiumRating_Search", "TM_IH_TempPremiumRating_Search");

       }
    //end

       //Function for Update the Record
       public DataSet Update_IHPremiumData(clsIHPremiumRating objclsIHPremium)
       {
           object[] parameters = new object[] { objclsIHPremium.IH_ID, objclsIHPremium.Program, objclsIHPremium.Area, 
               objclsIHPremium.Dedcutible, objclsIHPremium.premiumrating , objclsIHPremium.EffToDate,objclsIHPremium.EffFromDate,
               objclsIHPremium.lastupdatedby,objclsIHPremium.Discount ,objclsIHPremium.UnderWriterName,objclsIHPremium.ProductName,objclsIHPremium.UniqueNo };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters, "P_TM_IHPremiumRating_Update", "TM_IH_TempPremiumRating_Update");
          // return dataAccessDS.ExecuteNonQuery("P_TM_IHPremiumRating_Update", parameters);

       }
        //end


       public DataSet Check_Slip(clsIHPremiumRating objclsIHPremium)
       {
           object[] parameters = new object[] { objclsIHPremium.Age, objclsIHPremium.Program, objclsIHPremium.Area, 
              objclsIHPremium.premiumrating, objclsIHPremium.Discount,objclsIHPremium.Dedcutible };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters, "P_IH_PremiumRating_Slip", "P_IH_PremiumRating_Slip");
           // return dataAccessDS.ExecuteNonQuery("P_TM_IHPremiumRating_Update", parameters);

       }
       //Function for Delete the Record
       public DataSet Delete_IHPremiumData(int id)
       {
           object[] parameters=new object[1]{ id};
         dataAccessDS = new DataAccess();
         return dataAccessDS.LoadDataSet(parameters, "P_TM_IHPremiumRating_Delete", "P_TM_IHPremiumRating_Delete");
         //return dataAccessDS.ExecuteNonQuery("P_TM_IHPremiumRating_Delete", parameters);

       }


        //end

       //function for count the record
       public int  Count_IHPremiumData()
       {
           object[] parameters = new object[0] {  };
           dataAccessDS = new DataAccess();
           return dataAccessDS.ExecuteScalar("P_Count_IHPremiumRecord",parameters );

       }

       //Function for TRACK aGE gAP
       public DataSet Check_AgeGap(clsIHPremiumRating objclsIHPremium)
       {
           object[] parameters = new object[1] { objclsIHPremium.Program};
           dataAccessDS = new DataAccess();

           return dataAccessDS.LoadDataSet(parameters, "P_IHPremium_Age_Gap", "Check_AgeGap");

       }
        //end


       //for bind age based on program//
       public DataSet getAgeusingProgram(clsIHPremiumRating objclsIHPremium)
       {
           object[] parameters = new object[1] { objclsIHPremium.Program };
           dataAccessDS = new DataAccess();
           return dataAccessDS.LoadDataSet(parameters,"P_IHPremium_Get_AgebyProgram", "IHAgebyProgram");
       }
        //end of age

       //Function for Delete the Record
       public int Delete_IHPremiumDataforTemp()
       {
           dataAccessDS = new DataAccess();
           return dataAccessDS.ExecuteNonquery("P_TM_IHPremiumRating_TempDelete");

       }


        //end
    }
}
