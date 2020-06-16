using core.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using client.Controller.AdminActionsHandlers.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace client.Controller.AdminActionsHandlers
{
    public class PdfFile : IFile
    {
        //private Assignment_3Entities _model = new Assignment_3Entities();
        //private RReport rReport;

        public void GetReport(string title)
        {
            //  List<Report> reports = rReport.GetAll().ToList();
            List<Report> reports = (List<Report>)Request.SendRequest("GetReports", null);
            string file = "";
            Document document = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog.FileName;
            }

            PdfWriter.GetInstance(document, new FileStream(file, FileMode.OpenOrCreate));
            document.Open();

            var columnWidths = new[] { 0.5f, 1.5f, 0.5f, 1.5f, 0.5f, 1.5f };


            var table = new PdfPTable(columnWidths)
            {
                WidthPercentage = 100,
                DefaultCell = { MinimumHeight = 22f }
            };

            var cell = new PdfPCell(new Phrase("Report"))
            {
                Colspan = 6,
                HorizontalAlignment = 1,
                MinimumHeight = 30f
            };

            table.AddCell(cell);
            foreach (Report r in reports)
            {
                if (r.movie == title)
                {
                    table.AddCell(r.ID.ToString());
                    table.AddCell(r.client);
                    table.AddCell(r.borrowedNow.ToString());
                    table.AddCell(r.movie);
                    table.AddCell(r.movieID.ToString());
                    table.AddCell(r.clientCnp);
                }
            }

            document.Add(table);
            document.Close();
        }
    }
}
