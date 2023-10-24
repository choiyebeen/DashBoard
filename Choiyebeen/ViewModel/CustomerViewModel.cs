using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        public ICommand IceCoffeeCommand { get; }
        public ICommand IceLatteCommand {get;}
        public ICommand CLatteCommand { get; }
        public ICommand HLatteCommand { get; }
        public ICommand MochalatteCommand { get; }
        public ICommand VlatteCommand { get; }

        public CustomerViewModel()
        {
            IceCoffeeCommand = new ViewModelCommand(ExecuteIceCoffeeCommand);
            IceLatteCommand = new ViewModelCommand(ExecuteIceLatteCommand);
            CLatteCommand = new ViewModelCommand(ExecuteCLatteCommand);
            HLatteCommand = new ViewModelCommand(ExecuteHLatteCommand);
            MochalatteCommand = new ViewModelCommand(ExecuteMochalatteCommand);
            VlatteCommand = new ViewModelCommand(ExecuteVlatteeCommand);

        }

        private void ExecuteVlatteeCommand(object obj)
        {
            MessageBox.Show("바닐라라떼");
        }

        private void ExecuteMochalatteCommand(object obj)
        {
            MessageBox.Show("모카라떼");
        }

        private void ExecuteIceCoffeeCommand(object obj)
        {
            MessageBox.Show("아이스커피");
        }

        private void ExecuteIceLatteCommand(object obj)
        {
            MessageBox.Show("아이스라떼");
        }

        private void ExecuteCLatteCommand(object obj)
        {
            MessageBox.Show("카라멜라떼");
        }

        private void ExecuteHLatteCommand(object obj)
        {
            MessageBox.Show("헤이즐럿라떼");
        }


    }


}
