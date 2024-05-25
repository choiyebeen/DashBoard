using Choiyebeen.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Choiyebeen.View
{
    /// <summary>
    /// MembershipView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MembershipView : Window
    {
        public MembershipView()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is MembershipViewModel viewModel)
            {
                var passwordBox = sender as PasswordBox;
                viewModel.Password = passwordBox.Password;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
