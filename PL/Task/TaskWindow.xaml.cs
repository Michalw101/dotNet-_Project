using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        int state;
        public TaskWindow(int id = -1)
        {
            InitializeComponent();
            if (id != -1)
            {
                state = 1; //update
                CurrentTask = new ObservableCollection<BO.Task> { s_bl.Task.Read(id)! };
            }
            else
            {
                state = 0; //add
                CurrentTask = new ObservableCollection<BO.Task> { new BO.Task() {
                Id = -1, Description = "", Alias="", CreatedAtDate = DateTime.Now, Status=BO.Status.Unscheduled} };
            }
        }

        public ObservableCollection<BO.Task> CurrentTask
        {
            get { return (ObservableCollection<BO.Task>)GetValue(CurrentTaskProperty); }
            set { SetValue(CurrentTaskProperty, value); }
        }

        public static readonly DependencyProperty CurrentTaskProperty =
            DependencyProperty.Register("CurrentTask", typeof(ObservableCollection<BO.Task>), typeof(TaskWindow), new PropertyMetadata(null));

        public BO.EngineerExperience ComplexityLevel { get; set; } = BO.EngineerExperience.None;

        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            BO.Task task = CurrentTask[0];
            if (state == 0)
            {
                try
                {
                    s_bl.Task.Create(task);
                    MessageBox.Show("Task Added :)");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    s_bl.Task.Update(task);
                    MessageBox.Show("Task Updated :)");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
