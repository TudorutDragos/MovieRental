using core.Models;


namespace client.Controller
{
    public class ReportHandler
    {
        //private Assignment_2Entities _model = new Assignment_2Entities();
        //private RReport rReport;

        public void CreateReport(Report rep)
        {
            //    rReport.Insert(rep);
            Request.SendRequest("InsertReport", rep);
        }

        public Report GetLastReport()
        {
            //    return rReport.GetLastReport();
            return (Report)Request.SendRequest("LastReport", null);
        }

        public Review GetLastReview()
        {
            //    return rReport.GetLastReport();
            return (Review)Request.SendRequest("LastReview", null);
        }
    }
}
