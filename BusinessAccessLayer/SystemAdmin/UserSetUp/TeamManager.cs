using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class TeamManager
    {
        DataAccess dataAccess = null;
        Team objInfo = new Team();

        public DataSet getTeam(Team objTeam)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objTeam.TeamId};
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamList", "TeamList");
        }

        public DataSet getTeamForLogin(Team objTeam)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objTeam.TeamId, objTeam.LoginUserId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamListForLogin", "P_Adm_TeamListForLogin");
        }

        public DataSet getTeamAll(Team objTeam)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objTeam.TeamCode,objTeam.TeamName,objTeam.EffFromDate,objTeam.EffFromDate1,objTeam.EffToDate,objTeam.EffToDate1 };
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamListAll", "TeamList");
        }
        public DataSet SaveTeam(Team objTeam)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objTeam.TeamId,
                                                objTeam.TeamCode,
                                               objTeam.TeamName,
                                               objTeam.EffFromDate,
                                               objTeam.EffToDate,
                                               //objTeam.Status,
                                               objTeam.LoginUserId,
                                               objTeam.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_Team_InsertUpdate", "Team");
        }

        public DataSet getTeamCompany(int intCompanyID)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { intCompanyID };
            return dataAccess.LoadDataSet(parameters, "P_Adm_TeamListCompany", "TeamList");
        }
        public DataSet SaveJunction(clsJunction objJunction)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                                 objJunction.TeamId,
                                                objJunction.CompanyId,
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_Junction_InsertUpdate", "Junction");
        }

    }
}
