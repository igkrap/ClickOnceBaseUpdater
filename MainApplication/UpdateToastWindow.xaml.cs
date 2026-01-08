using System;
using System.Windows;

namespace MainApplication
{
    public partial class UpdateToastWindow : Window
    {
        public UpdateToastWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var workingArea = SystemParameters.WorkArea;
            Left = workingArea.Right - Width - 16;
            Top = workingArea.Bottom - Height - 16;
        }

        private void OnYesClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnNoClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
