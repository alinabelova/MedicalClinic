using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalClinic.Model;
using Mita.DataAccess;

namespace MedicalClinic.PayDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [Import]
        private IRepositoryProvider RepositoryProvider { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            List<Talon> list = RepositoryProvider.GetRepository<Talon>().GetAll().ToList();//get list of students

            reportViewer1.LocalReport.DataSources.Clear(); //clear report
            reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("StudentDS", list); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
