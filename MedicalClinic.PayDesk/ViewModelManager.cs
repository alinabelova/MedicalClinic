using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mita.Mvvm.ViewModels;

namespace MedicalClinic.PayDesk
{
    [Export(typeof(IViewModelManager<IChildViewModel>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ViewModelManager : ChildViewModelManager
    {
    }
}
