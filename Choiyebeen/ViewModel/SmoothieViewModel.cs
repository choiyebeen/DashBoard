using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class SmoothieViewModel : ViewModelBase //상속 자료형 맞춰줘야함
    {
        public ICommand PyogurtCommand { get; }
        public ICommand ByogurtCommand { get; }
        public ICommand SyogurtCommand { get; }
        public ICommand MyogurtCommand { get; }

        public SmoothieViewModel()
        {
            PyogurtCommand = new ViewModelCommand(ExecutePyogurtCommand);
            ByogurtCommand = new ViewModelCommand(ExecuteByogurtCommand);
            SyogurtCommand = new ViewModelCommand(ExecuteSyogurtCommand);
            MyogurtCommand = new ViewModelCommand(ExecuteMyogurtCommand);
        }

        private void ExecuteMyogurtCommand(object obj)
        {
            MessageBox.Show("망고 요거트 스무디");
        }

        private void ExecuteSyogurtCommand(object obj)
        {
            MessageBox.Show("딸기 요거트 스무디");
        }

        private void ExecuteByogurtCommand(object obj)
        {
            MessageBox.Show("블루베리 요거트 스무디");
        }

        private void ExecutePyogurtCommand(object obj)
        {
            MessageBox.Show("플레인 요거트 스무디");
        }
    }
}
