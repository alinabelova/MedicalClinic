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
using Mita.Mvvm.Views;

namespace MedicalClinic.PayDesk
{
    /// <summary>
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    [Export("TimetableView", typeof(IView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TimetableView : IView
    {
        public TimetableView()
        {
            InitializeComponent();
        }
    }
}
