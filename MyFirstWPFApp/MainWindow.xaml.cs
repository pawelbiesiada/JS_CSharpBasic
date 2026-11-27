using Persistence.Models;
using Persistence.Repositories;
using System.IO;
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

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //event Click               eventHandler -> btnLoad_Click
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(tbFilePath.Text))
                    File.Create(tbFilePath.Text);

                var text = File.ReadAllText(tbFilePath.Text);
                tbContent.Text = text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.WriteAllText(tbFilePath.Text, tbContent.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tbFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbFilePath.Text.Length < 3)
            {
                btnLoad.IsEnabled = false;
            }
            else
            {
                btnLoad.IsEnabled = true;
            }
        }

        private async void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = tbFilePath.Text.Length > 3;

            try
            {
                var users = await new EFRepository().GetUsersAsync();
                cbUsers.ItemsSource = users.ToList();
                cbUsers.DisplayMemberPath = "Name";
                cbUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbContent.Text +=
                ((UserDto)cbUsers.SelectedValue).Id + ":" +
                ((UserDto)cbUsers.SelectedValue).Name + Environment.NewLine;
        }
    }
}