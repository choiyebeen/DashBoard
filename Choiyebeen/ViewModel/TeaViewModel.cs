using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Choiyebeen.ViewModel
{
    public class TeaViewModel : ViewModelBase
    {
        public ICommand CteaCommand { get; }
        public ICommand GteaCommand { get; }
        public ICommand HteaCommand { get; }
        public ICommand HbteaCommand { get; }
        public ICommand JteaCommand { get; }
        public ICommand LteaCommand { get; }
        public ICommand OteaCommand { get; }
        public ICommand PPteaCommand { get; }

        public TeaViewModel()
        {
            CteaCommand = new ViewModelCommand(ExecuteCteaCommand);
            GteaCommand = new ViewModelCommand(ExecuteGteaCommand);
            HteaCommand = new ViewModelCommand(ExecuteHteaCommand);
            HbteaCommand = new ViewModelCommand(ExecuteHbteaCommand);
            JteaCommand = new ViewModelCommand(ExecuteJteaCommand);
            LteaCommand = new ViewModelCommand(ExecuteLteaCommand);
            OteaCommand = new ViewModelCommand(ExecuteOteaCommand);
            PPteaCommand = new ViewModelCommand(ExecutePPteaCommand);
        }

        private void ExecutePPteaCommand(object obj)
        {
            MessageBox.Show("복숭아 티");
        }

        private void ExecuteOteaCommand(object obj)
        {
            MessageBox.Show("오미자 차");
        }

        private void ExecuteLteaCommand(object obj)
        {
            MessageBox.Show("레몬차");
        }

        private void ExecuteJteaCommand(object obj)
        {
            MessageBox.Show("자스민 차");
        }

        private void ExecuteHbteaCommand(object obj)
        {
            MessageBox.Show("히비스커스 차");
        }

        private void ExecuteHteaCommand(object obj)
        {
            MessageBox.Show("한라봉 차");
        }

        private void ExecuteGteaCommand(object obj)
        {
            MessageBox.Show("생강차");
        }

        private void ExecuteCteaCommand(object obj)
        {
            MessageBox.Show("시트러스 차");
        }
    }
}
