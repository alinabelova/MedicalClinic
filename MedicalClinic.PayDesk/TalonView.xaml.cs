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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MedicalClinic.Model;
using MedicalClinic.PayDesk.ViewModels;
using Mita.Mvvm.Views;

namespace MedicalClinic.PayDesk
{
    /// <summary>
    /// Логика взаимодействия для Talon.xaml
    /// </summary>
    [Export("TalonView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TalonView : IView
    {
        public TalonView()
        {
           InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((TalonViewModel) DataContext).SelectedDoctor.Add((Doctor)e.AddedItems[0]);
        }
    }
}
