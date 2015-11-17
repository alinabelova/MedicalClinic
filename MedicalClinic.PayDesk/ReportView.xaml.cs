using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MedicalClinic.Model;
using MedicalClinic;
using Mita.DataAccess;
using Mita.Mvvm.Views;

namespace MedicalClinic.PayDesk
{
   /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    [Export("ReportView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ReportView :  IView
    {
        public ReportView()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }
        private bool _isReportViewerLoaded;

        [Import]
        private IRepositoryProvider RepositoryProvider { get; set; }

       private void ReportViewer_Load(object sender, EventArgs e)
       {
           ICollection<Talon> list = RepositoryProvider.GetRepository<Talon>().GetAll().ToList(); //get list of students

           _reportViewer.LocalReport.DataSources.Clear(); //clear report
           _reportViewer.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; // bind reportviewer with .rdlc

           Microsoft.Reporting.WinForms.ReportDataSource dataset1 = new Microsoft.Reporting
               .WinForms.ReportDataSource("TalonDS", list); // set the datasource
           _reportViewer.LocalReport.DataSources.Add(dataset1);
           dataset1.Value = list;

           _reportViewer.Show();
           _reportViewer.LocalReport.Refresh();
           _reportViewer.RefreshReport(); // refresh report

       }
    }
}
