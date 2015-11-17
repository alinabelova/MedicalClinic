using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalClinic.Model;
using Mita.DataAccess;
using Mita.Mvvm;

namespace MedicalClinic.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PriceViewModel:ChildViewModel
    {

        private string _doctor;
        private string _lastName;
        private string _workHours;
        private Employee _employee;
        private ICollection<Service> _services;

        public PriceViewModel()
        {
         //   CreateTalonCommand = new DelegateCommand((Action)CreateTalon);
        }

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IRepositoryProvider RepositoryProvider { get; set; }

      //  public DelegateCommand CreateTalonCommand { get; private set; }


        public Employee Employee
        {
            get { return _employee; }
            private set
            {
                if (Equals(value, _employee)) return;
                _employee = value;
                OnPropertyChanged();
            }
        }
        public ICollection<Service> Services
        {
            get { return _services; }
            set
            {
                if (Equals(value, _services)) return;
                _services = value;
                OnPropertyChanged();
            }
        }
        public Task InitializeAsync(int userId)
        {
            return Task.Run(() => Initialize(userId));
        }
        public void Initialize(int userId)
        {
            using (StartOperation())
            {
                Title = "Price List of Procedure ";
                var query = RepositoryProvider.GetRepository<Service>().GetAll();
                Services = query.ToList();
            }
        }
        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }
    }
}
