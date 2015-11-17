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
    public class MainWindowViewModel:ChildViewModel
    {
        private int _userId;

        [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
        private IRepositoryProvider RepositoryProvider { get; set; }
        public Task InitializeAsync(int userId)
        {
            return Task.Run(() => Initialize(userId));
            _userId = userId;
        }

        public void Initialize(int userId)
        {
            using (StartOperation())
            {
                Title = "Menu";
                TableCommand = new DelegateCommand(()=>Task.Run((Action)Timetable));
                PriceCommand = new DelegateCommand(() => Task.Run((Action)Price));
                TalonCommand = new DelegateCommand(() => Task.Run((Action)Talon));
            }
        }
        public DelegateCommand PriceCommand { get; private set; }
        public DelegateCommand TableCommand{ get; private set; }
        public DelegateCommand TalonCommand { get; private set; }

        private void Talon()
        {
            using (StartOperation())
            {
                var talonViewModel = ServiceLocator.GetInstance<TalonViewModel>();
                talonViewModel.InitializeAsync();
                talonViewModel.Show();
                Close(true);
            }
        }
        private void Timetable()
        {
            using (StartOperation())
            {
                var timeTableViewModel = ServiceLocator.GetInstance<TimetableViewModel>();
                timeTableViewModel.InitializeAsync(_userId);
                timeTableViewModel.Show();
                Close(true);
            }
        }
        private void Price()
        {
            using (StartOperation())
            {
                var priceViewModel = ServiceLocator.GetInstance<PriceViewModel>();
                priceViewModel.InitializeAsync(_userId);
                priceViewModel.Show();
                Close(true);
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            RepositoryProvider.Dispose();
        }
    }
}
