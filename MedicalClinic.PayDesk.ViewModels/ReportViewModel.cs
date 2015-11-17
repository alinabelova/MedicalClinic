using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.DataAccess;

namespace MedicalClinic.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReportViewModel:ChildViewModel
    {
        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IRepositoryProvider RepositoryProvider { get; set; }
        public Task InitializeAsync()
        {
            return Task.Run(() => Initialize());
        }

        public void Initialize()
        {
            using (StartOperation())
            {
                Title = "Report";
            }
        }
        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }
    }
}
