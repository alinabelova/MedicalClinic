using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalClinic;
using MedicalClinic.Model;
using Mita.Core;
using Mita.DataAccess;
using Mita.Mvvm;

namespace MedicalClinic.PayDesk.ViewModels
{

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TimetableViewModel:ChildViewModel
    {
        private string _doctor;
        private string _lastName;
        private Employee _employee;
        private ICollection<Doctor> _doctors;

        public TimetableViewModel()
        {
            SearchCommand = new DelegateCommand(() => Task.Run((Action)Search));
            CreateTalonCommand = new DelegateCommand((Action)CreateTalon);
        }
        
        public DelegateCommand CreateTalonCommand { get; private set; }
        public DelegateCommand SearchCommand { get; private set; }
        
        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IRepositoryProvider RepositoryProvider { get; set; }

        public string Doctor
        {
            get { return _doctor; }
            set
            {
                if (value == _doctor) return;
                _doctor = value;
                OnPropertyChanged();
            }
        }
        public ICollection<Doctor> Doctors
        {
            get { return _doctors; }
            set
            {
                if (Equals(value, _doctors)) return;
                _doctors = value;
                OnPropertyChanged();
            }
        }
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
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private void CreateTalon()
        {
            var vm = ServiceLocator.GetInstance<TalonViewModel>();
            vm.InitializeAsync();
            vm.Parent = this;
            vm.Show();
        }

        public Task InitializeAsync(int userId)
        {
            return Task.Run(() => Initialize(userId));
        }
        public void Initialize(int userId)
        {
            using (StartOperation())
            {
                Title = "Timetable ";
                var query = RepositoryProvider.GetRepository<Doctor>().GetAll();
                Doctors = query.ToList();
            }
        }

        private void Search()
        {
            using (StartOperation())
            {
                var query = RepositoryProvider.GetRepository<Doctor>().GetAll();

                if (!Doctor.IsNullOrEmpty())
                {
                    query = query.Where(d => d.Speciality.Contains(Doctor));
                }
                else if (!LastName.IsNullOrEmpty())
                {
                    query = query.Where(d => d.LastName.Contains(LastName));
                }
                else
                {
                    Doctors = new Doctor[] { };
                    return;
                }

                Doctors = query.ToList();
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }

    }
}
