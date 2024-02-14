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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
      
        public BO.EngineerExperience engineerExperience { get; set; } = BO.EngineerExperience.None;
        
        public ObservableCollection<BO.Task> TaskList
        {
            get { return (ObservableCollection<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }

        public static readonly DependencyProperty TaskListProperty =
            DependencyProperty.Register("TaskList", typeof(ObservableCollection<BO.Task>), typeof(TaskListWindow), new PropertyMetadata(null));

        public TaskListWindow()
        {
            InitializeComponent();
        }

        private void cbTaskLevelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = engineerExperience == BO.EngineerExperience.None ?
            s_bl?.Task.ReadAll() :
            s_bl?.Task.ReadAll(item => item.ComplexityLevel == engineerExperience);
            TaskList = temp == null ? new() : new(temp!);
        }
        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            new TaskWindow().ShowDialog();
        }

        private void BtnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            BO.Task? Task = (sender as ListView)?.SelectedItem as BO.Task;
            new TaskWindow(Task!.Id).ShowDialog();
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            var temp = s_bl?.Task.ReadAll();
            TaskList = temp == null ? new() : new(temp!);
        }

    }
}
