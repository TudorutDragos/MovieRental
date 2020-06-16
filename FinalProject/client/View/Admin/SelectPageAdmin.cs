using client.Controller.AdminActionsHandlers;
using System;
using System.Windows.Forms;

namespace client.View.Admin
{
    public partial class SelectPageAdmin : Form
    {
        TxTFile txtFile;
        PdfFile pdfFile;
        public SelectPageAdmin()
        {
            txtFile = new TxTFile();
            pdfFile = new PdfFile();
            InitializeComponent();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            MoviePage moviePage = new MoviePage();
            moviePage.Show();
            this.Close();
        }

        private void btnRaport_Click(object sender, EventArgs e)
        {
            pdfFile.GetReport(textBox1.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFile.GetReport(textBox1.Text.Trim());
        }

        private void btnClients_Click_1(object sender, EventArgs e)
        {
            ClientPage clientPage = new ClientPage();
            clientPage.Show();
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
