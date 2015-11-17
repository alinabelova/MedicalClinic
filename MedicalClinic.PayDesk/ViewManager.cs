using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Mita.Mvvm.ViewModels;
using Mita.Mvvm.Views;

namespace MedicalClinic.PayDesk
{
    [Export(typeof(IViewManager<IChildViewModel>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewManager : ChildViewManager
    {
        [ImportingConstructor]
        public ViewManager(IViewModelManager<IChildViewModel> vmManager, IServiceLocator serviceLocator)
            : base(vmManager, serviceLocator)
        {
        }
    }
}
