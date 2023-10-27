using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class DesertViewModel : ViewModelBase
    {
        public ICommand CupcookieCommand { get; }
        public ICommand CookieCommand { get; }
        public ICommand IcecreamCommand { get; }
        public ICommand MacaronCommand { get; }
        public ICommand BeanbreadCommand { get; }

        public DesertViewModel()
        {
            CupcookieCommand = new ViewModelCommand(ExecuteCupcookieCommand);
            CookieCommand = new ViewModelCommand(ExecuteCookieCommand);
            IcecreamCommand = new ViewModelCommand(ExecuteIcecreamCommand);
            MacaronCommand = new ViewModelCommand(ExecuteMacaronCommand);
            BeanbreadCommand = new ViewModelCommand(ExecuteBeanbreadCommand);

        }

        private void ExecuteBeanbreadCommand(object obj)
        {
            MessageBox.Show("커피콩 모양 빵");
        }

        private void ExecuteMacaronCommand(object obj)
        {
            MessageBox.Show("마카롱");
        }

        private void ExecuteIcecreamCommand(object obj)
        {
            MessageBox.Show("구슬 아이스크림");
        }

        private void ExecuteCookieCommand(object obj)
        {
            MessageBox.Show("쿠키");
        }

        private void ExecuteCupcookieCommand(object obj)
        {
            MessageBox.Show("컵 쿠키");
        }
    }
}
