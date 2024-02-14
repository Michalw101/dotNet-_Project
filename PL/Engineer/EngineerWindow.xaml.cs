using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace PL.Engineer
{
    /// <summary>
    /// Interaction logic for EngineerWindow.xaml
    /// </summary>
    public partial class EngineerWindow : Window
    {
        /// <summary>
        /// The business logic instance.
        /// </summary>
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

        /// <summary>
        /// Represents the state of the EngineerWindow.
        /// </summary>
        int state;

        /// <summary>
        /// Initializes a new instance of the EngineerWindow class.
        /// </summary>
        /// <param name="id">The ID of the engineer (optional).</param>

        public EngineerWindow(int id = -1)
        {
            InitializeComponent();
            if (id != -1)
            {
                state = 1;
                CurrentEngineer = new ObservableCollection<BO.Engineer> { s_bl.Engineer.Read(id)! };
            }
            else
            {
                state = 0;
                CurrentEngineer = new ObservableCollection<BO.Engineer> { new BO.Engineer() { Id = -1, Name = "", Email = "", Level = 0, Cost = 0 } };
            }
        }

        /// <summary>
        /// Gets or sets the current engineer being displayed.
        /// </summary>

        public ObservableCollection<BO.Engineer> CurrentEngineer
        {
            get { return (ObservableCollection<BO.Engineer>)GetValue(CurrentEngineerProperty); }
            set { SetValue(CurrentEngineerProperty, value); }
        }

        /// <summary>
        /// The dependency property for CurrentEngineer.
        /// </summary>

        public static readonly DependencyProperty CurrentEngineerProperty =
            DependencyProperty.Register("CurrentEngineer", typeof(ObservableCollection<BO.Engineer>), typeof(EngineerWindow), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the experience of the engineer.
        /// </summary>
        public BO.EngineerExperience Experience { get; set; } = BO.EngineerExperience.None;

        /// <summary>
        /// Handles the click event of the btnAddUpdate button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAddUpdate_Click(object sender, RoutedEventArgs e)
        {
            BO.Engineer engineer = CurrentEngineer[0];
            if (state == 0)
            {
                try
                {
                    s_bl.Engineer.Create(engineer);
                    MessageBox.Show("Engineer Added :)");
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
                    s_bl.Engineer.Update(engineer);
                    MessageBox.Show("Engineer Updated :)");
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
