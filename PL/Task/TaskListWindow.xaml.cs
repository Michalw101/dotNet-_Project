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
        /// <summary>
        /// The business logic instance.
        /// </summary>
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        /// <summary>
        /// Gets or sets the selected engineer experience.
        /// </summary>
        public BO.EngineerExperience engineerExperience { get; set; } = BO.EngineerExperience.None;

        /// <summary>
        /// Gets or sets the list of tasks.
        /// </summary>
        public ObservableCollection<BO.Task> TaskList
        {
            get { return (ObservableCollection<BO.Task>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }

        /// <summary>
        /// Dependency property for the list of tasks.
        /// </summary>
        public static readonly DependencyProperty TaskListProperty =
            DependencyProperty.Register("TaskList", typeof(ObservableCollection<BO.Task>), typeof(TaskListWindow), new PropertyMetadata(null));

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListWindow"/> class.
        /// </summary>
        public TaskListWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the selection change in the task level selector.
        /// </summary>
        private void cbTaskLevelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = engineerExperience == BO.EngineerExperience.None ?
            s_bl?.Task.ReadAll() :
            s_bl?.Task.ReadAll(item => item.ComplexityLevel == engineerExperience);
            TaskList = temp == null ? new() : new(temp!);
        }

        /// <summary>
        /// Event handler for the add task button click.
        /// </summary>
        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            new TaskWindow().ShowDialog();
        }

        /// <summary>
        /// Event handler for the update task button click.
        /// </summary>
        private void BtnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            BO.Task? Task = (sender as ListView)?.SelectedItem as BO.Task;
            new TaskWindow(Task!.Id).ShowDialog();
        }

        /// <summary>
        /// Event handler for the window activation.
        /// </summary>
        private void WindowActivated(object sender, EventArgs e)
        {
            var temp = s_bl?.Task.ReadAll();
            TaskList = temp == null ? new() : new(temp!);
        }

    }
}
