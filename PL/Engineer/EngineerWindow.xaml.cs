using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        public ObservableCollection<BO.Engineer> EngineerList
        {
            get { return (ObservableCollection<BO.Engineer>)GetValue(CurrentEngineer); }
            set { SetValue(CurrentEngineer, value); }
        }

        public static readonly DependencyProperty CurrentEngineer =
            DependencyProperty.Register("Engineer", typeof(ObservableCollection<BO.Engineer>), typeof(EngineerWindow), new PropertyMetadata(null));
        public EngineerWindow(int Id = 0)
        {
            InitializeComponent();
            if(Id == 0)
            {
                //  יש לייצר אוביקט חדש   עם ערכים ריקים או ערכיברירת מחדל, לכל תכונה של האובייקט
            }
            else
                s_bl.Engineer.Read(Id);
            
        }
    }
}
