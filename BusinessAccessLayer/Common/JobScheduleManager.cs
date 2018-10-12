using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.Common;

namespace BusinessAccessLayer.Common
{
    public class JobScheduleManager
    {
        DataAccess dataAccess = new DataAccess();
        public DataSet GetJobScheduleList(JobSchedule objJobSchedule)
        {
            Object[] parameters = new Object[5] {
                objJobSchedule.JobNumber		,
                objJobSchedule.JobType			,
                objJobSchedule.JobStatus		,
                objJobSchedule.ScheduledStartDateTimeFrom,
                objJobSchedule.ScheduledStartDateTimeTo	    
            };
            return dataAccess.LoadDataSet(parameters, "P_IT_GetJobScheduleList", "GetJobScheduleList");
        }
        public DataSet GetJobSchedulePageLoadData()
        {
            return dataAccess.LoadDataSet("P_IT_GetJobSchedulePageLoadData", "GetJobSchedulePageLoadData");
        }
        public DataSet UpdateJobScheduleStatus(JobSchedule objJobSchedule)
        {
            Object[] parameters = new Object[6] {
                objJobSchedule.JobNumber		,
                objJobSchedule.JobStatus		,
                objJobSchedule.JobStartDate	    ,
                objJobSchedule.JobFinishDate	,
                objJobSchedule.QueueEndDate	    ,
                objJobSchedule.Remarks	    
            };
            return dataAccess.LoadDataSet(parameters, "P_IT_UpdateJobScheduleStatus", "GetJobScheduleList");
        }
        public DataSet CheckQueueToPerformMemberUpload()
        {
            return dataAccess.LoadDataSet("P_IT_CheckQueueToPerformMemberUpload", "CheckQueueToPerformMemberUpload");
        }
        public DataSet CheckQueueToPerformDeferredPosting()
        {
            return dataAccess.LoadDataSet("AC_P_CheckQueueToPerformDefPosting", "CheckQueueToPerformDeferredPosting");
        }
        public DataSet CreateJobQueue(JobSchedule objJobSchedule)
        {
            Object[] parameters = new Object[] {
                objJobSchedule.JobType,
                objJobSchedule.QueueStartDate,
                objJobSchedule.ScheduledStartDateTime ,
                objJobSchedule.ProcessRefNo
            };
            return dataAccess.LoadDataSet(parameters, "P_IT_CreateJobQueue", "CreateJobQueue");
        }
                
    }
}
