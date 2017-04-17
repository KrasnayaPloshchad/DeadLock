using System;
using System.Reflection;
using System.Windows;
using DeadLock.Classes;

namespace DeadLock.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Variables
        private readonly UpdateManager.UpdateManager _updateManager;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            _updateManager = new UpdateManager.UpdateManager(Assembly.GetExecutingAssembly().GetName().Version, "http://codedead.com/Software/DeadLock/update.xml", "DeadLock");

            LoadTheme();
            LoadSettings();
        }

        /// <summary>
        /// Load the user settings
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (Properties.Settings.Default.AutoUpdate)
                {
                    Update(true, false);
                }
                if (Properties.Settings.Default.StartMinimized)
                {
                    WindowState = WindowState.Minimized;
                }
                MniDetails.IsChecked = Properties.Settings.Default.ShowDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Change the visual style of the window, depending on user settings
        /// </summary>
        internal void LoadTheme()
        {
            StyleManager.ChangeStyle(this);
        }

        /// <summary>
        /// Check for application updates
        /// </summary>
        /// <param name="showErrors">Show a message if an error occurs</param>
        /// <param name="showNoUpdate">Show a message if no updates are available</param>
        private void Update(bool showErrors, bool showNoUpdate)
        {
            _updateManager.CheckForUpdate(showErrors, showNoUpdate);
        }

        private void DetailsItem_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (LsvDetails == null || LblDetails == null) return;

            if (MniDetails.IsChecked)
            {
                LblDetails.Visibility = Visibility.Visible;
                LsvDetails.Visibility = Visibility.Visible;
            }
            else
            {
                LblDetails.Visibility = Visibility.Collapsed;
                LsvDetails.Visibility = Visibility.Collapsed;
            }

            SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void RefreshMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
