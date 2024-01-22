using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

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
            if (Id == 0) //Create
            {
                BO.Engineer? newEngineer = new BO.Engineer()
                {
                    Id = 0,
                    Name = "",
                    Email = "",
                    Level = BO.EngineerExperience.None,
                    Cost = 0
                };
                try
                {
                    s_bl.Engineer.Create(newEngineer);
                }
                catch
                {
                    //catch errors
                }
            }
            else //Update
            {
                try
                {
                    s_bl.Engineer.Read(Id);
                }
                catch
                {
                    //catch errors
                }
            }

        }

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
