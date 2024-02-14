using PL.Engineer;
using PL.Task;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event handler for the Engineer button click.
        /// </summary>
        private void btnEnginner_Clicked(object sender, RoutedEventArgs e)
        {
            new EngineerListWindow().Show();
        }
        /// <summary>
        /// Event handler for the Task button click.
        /// </summary>
        private void btnTask_Clicked(object sender, RoutedEventArgs e)
        {
            new TaskListWindow().Show();
        }
        /// <summary>
        /// Event handler for the Initialization button click.
        /// </summary>
        private void btnInitalization_Clicked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to initialization?",
                    "Initalization",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DalTest.Initialization.Do();
            }
        }
    }
}