using System;
using System.Windows;
using DeadLock.Classes;

namespace DeadLock.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        #region Variables
        private readonly MainWindow _mw;
        #endregion

        public SettingsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mw = mainWindow;

            LoadTheme();
            LoadSettings();
        }

        /// <summary>
        /// Change the visual style of the window, depending on user settings
        /// </summary>
        private void LoadTheme()
        {
            StyleManager.ChangeStyle(this);
        }

        /// <summary>
        /// Change the GUI elements to represent the latest settings
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                ChbAutoUpdate.IsChecked = Properties.Settings.Default.AutoUpdate;
                ChbAdminWarning.IsChecked = Properties.Settings.Default.AdminWarning;
                ChbStartMinimized.IsChecked = Properties.Settings.Default.StartMinimized;
                ChbDragDrop.IsChecked = Properties.Settings.Default.AllowDragDrop;
                ChbShowDetails.IsChecked = Properties.Settings.Default.ShowDetails;

                CboStyle.SelectedValue = Properties.Settings.Default.VisualStyle;
                CpMetroBrush.Color = Properties.Settings.Default.MetroColor;
                IntBorderThickness.Value = Properties.Settings.Default.BorderThickness;

                ChbAutoOwnership.IsChecked = Properties.Settings.Default.AutoOwnership;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to reset all settings?", "DeadLock", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;
            try
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();

                LoadSettings();
                LoadTheme();

                _mw.LoadTheme();

                MessageBox.Show("All settings have been reset!", "DeadLock", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChbAutoUpdate.IsChecked != null) Properties.Settings.Default.AutoUpdate = (bool)ChbAutoUpdate.IsChecked;
                if (ChbAdminWarning.IsChecked != null) Properties.Settings.Default.AdminWarning = (bool)ChbAdminWarning.IsChecked;
                if (ChbStartMinimized.IsChecked != null) Properties.Settings.Default.StartMinimized = (bool)ChbStartMinimized.IsChecked;
                if (ChbDragDrop.IsChecked != null) Properties.Settings.Default.AllowDragDrop = (bool) ChbDragDrop.IsChecked;
                if (ChbShowDetails.IsChecked != null) Properties.Settings.Default.ShowDetails = (bool)ChbShowDetails.IsChecked;

                Properties.Settings.Default.VisualStyle = (string)CboStyle.SelectedValue;
                Properties.Settings.Default.MetroColor = CpMetroBrush.Color;
                if (IntBorderThickness.Value != null) Properties.Settings.Default.BorderThickness = (int)IntBorderThickness.Value;
                if (ChbAutoOwnership.IsChecked != null) Properties.Settings.Default.AutoOwnership = (bool)ChbAutoOwnership.IsChecked;

                Properties.Settings.Default.Save();

                LoadTheme();
                _mw.LoadTheme();

                MessageBox.Show("All settings have been saved!", "DeadLock", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
