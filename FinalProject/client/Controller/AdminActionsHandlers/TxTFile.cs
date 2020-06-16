using core.Models;
using client.Controller.AdminActionsHandlers.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client.Controller.AdminActionsHandlers
{
    public class TxTFile : IFile
    {
       // private Assignment_3Entities _model = new Assignment_3Entities();
       // private RReport rReport;

       public void GetReport(string title)
        {
            //List<Report> reports = rReport.GetAll().ToList();
            List<Report> reports = (List<Report>)Request.SendRequest("GetReports", null);
            string text = "";
            foreach (Report r in reports)
            {
                if (r.movie == title)
                {
                    text += r.ToString();
                    text += "\n";
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, text);
            }
        }
    }
}
