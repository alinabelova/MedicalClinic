using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalClinic.Model;
using MedicalClinic.PayDesk;
using Mita.Core;
using Mita.DataAccess;
using Mita.Mvvm;

namespace MedicalClinic.PayDesk.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TalonViewModel : ChildViewModel
    {
        private ICollection<Client> _clients;
        private Client _currentClient;
        private Doctor _currentDoctor;
        private Talon _currentTalon;
        private string _doctor;
        private ICollection<Doctor> _doctors;
        private ObservableCollection<Doctor> _selectedDoctor = new ObservableCollection<Doctor>();
        private ICollection<Talon> _talons;
 
        public TalonViewModel()
        {
            SaveCommand = new DelegateCommand(() => Task.Run((Action) Save), () => CurrentClient != null);
        }

        [Import]
        private IRepositoryProvider RepositoryProvider { get; set; }

        public ICollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                if (Equals(value, _clients)) return;
                _clients = value;
                OnPropertyChanged();
            }
        }

        //выбранный врач
        public Doctor CurrentDoctor
        {
            get
            {
        
                return _currentDoctor;
            }
            set
            {
                if (Equals(value, _currentDoctor)) return;
                _currentDoctor = value;
                OnPropertyChanged();
            }
        }

        //текущий талон
        public Talon CurrentTalon
        {
            get
            {
                return _currentTalon;
            }
            set
            {
                if (Equals(value, _currentTalon)) return;
                _currentTalon = value;
                OnPropertyChanged();
            }
        }

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

        public ObservableCollection<Doctor> SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged();
            }
        }
        public ICollection<Talon> Talons
        {
            get { return _talons; }
            set
            {
                if (Equals(value, _talons)) return;
                _talons = value;
               OnPropertyChanged();
            }
        }

        [CommandDependency("SaveCommand")]
        public Client CurrentClient
        {
            get { return _currentClient; }
            set
            {
                if (Equals(value, _currentClient)) return;
                _currentClient = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand SaveCommand { get; private set; }

        public void Initialize()
        {
            using (StartOperation())
            {
                Title = "Create Talon";
                //Загрузка БД
                var t = RepositoryProvider.GetRepository<Talon>().GetAll().Where(ta => ta.ClientsId == 0);//загружаем только те талоны, которые без ид клиента
                Talons = t.ToList();
                Clients = RepositoryProvider.GetRepository<Client>().GetAll().ToList();
                Doctors = RepositoryProvider.GetRepository<Doctor>().GetAll().ToList();
            }
        }

        public Task InitializeAsync()
        {
            return Task.Run(() => Initialize());
        }
        
        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }

        private void Save()
        {
            using (StartOperation())
            {
                foreach (var talon in Talons)
                {
                    //Сохранение БД
                    var talonOrder =
                        Talons.Where(t => t.DoctorId == CurrentDoctor.Id)
                            .First(t => t.DateStart == CurrentTalon.DateStart);
                    talonOrder.ClientsId = CurrentClient.Id;

                }
                RepositoryProvider.SaveChanges();
                Report();
                Close(true);
            }
        }
        private void Report()
        {
            using (StartOperation())
            {
                var reportViewModel = ServiceLocator.GetInstance<ReportViewModel>();
                reportViewModel.InitializeAsync();
                reportViewModel.Show();
                Close(true);
            }
        }
    }
}
