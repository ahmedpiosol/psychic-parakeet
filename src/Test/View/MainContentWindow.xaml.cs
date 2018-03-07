using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainContentWindow : MetroWindow
    {
        public MainContentWindow()
        {
            InitializeComponent();
        }

        private void MainContentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainContentsWindow_ContentRendered(object sender, EventArgs e)
        {
            DataContext db1 = new DataContext();
            var AllUnit = new List<Model.Items.Unit>(db1.Units);
            dsad.ItemsSource = AllUnit;
            var AllItems1 = new ObservableCollection<Model.Items.Item>(db1.Items);
            ItemsDataGrid.ItemsSource = AllItems1;
            /*
             //also tried
             using (var db2 = new DataContext())
             {
                 var AllItems2 = new ObservableCollection<Model.Items.Item>(db2.Items);
                 ItemsDataGrid.ItemsSource = AllItems2;
             }
             */
        }
    }
}
