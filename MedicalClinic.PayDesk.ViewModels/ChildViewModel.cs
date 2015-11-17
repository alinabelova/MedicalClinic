using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;

namespace MedicalClinic.PayDesk.ViewModels
{
    public class ChildViewModel : ChildViewModelBase
    {
        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected virtual IServiceLocator ServiceLocator { get; set; }

        [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
        protected override IViewModelManager<IChildViewModel> ViewModelManager
        {
            get { return base.ViewModelManager; }
            set { base.ViewModelManager = value; }
        }
    }
}
