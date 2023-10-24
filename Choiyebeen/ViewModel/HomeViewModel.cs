using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class HomeViewModel : ViewModelBase // 상속 -> 자료형 맞춰줘야함 
    {
        public ICommand CiderCommand { get; }
        public ICommand CocaCommand { get; }

        public HomeViewModel()
        {
            CiderCommand = new ViewModelCommand(ExecuteCiderCommand);
            CocaCommand = new ViewModelCommand(ExecuteCocaCommand);
        }

        private void ExecuteCocaCommand(object obj)
        {
            MessageBox.Show("콜라");
        }

        private void ExecuteCiderCommand(object obj)
        {
            MessageBox.Show("사이다");
        }
    }
}
