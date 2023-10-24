using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class AdeViewModel : ViewModelBase
    {
        public ICommand GadeCommand { get; }
        public ICommand GGadeCommand { get; }
        public ICommand LadeCommand { get; }

        public AdeViewModel()
        {
            GadeCommand = new ViewModelCommand(ExecuteGadeCommand);
            GGadeCommand = new ViewModelCommand(ExecuteGGadeCommand);
            LadeCommand = new ViewModelCommand(ExecuteLadeCommand);

        }

        private void ExecuteLadeCommand(object obj)
        {
            MessageBox.Show("레몬 에이드");
        }

        private void ExecuteGGadeCommand(object obj)
        {
            MessageBox.Show("청포도 에이드");
        }

        private void ExecuteGadeCommand(object obj)
        {
            MessageBox.Show("자몽 에이드");
        }
    }
}
