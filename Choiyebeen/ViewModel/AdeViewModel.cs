using Choiyebeen.Model;
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
        public event EventHandler<CartModel> PriceChanged;
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
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "레몬 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGGadeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "청포도 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGadeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "자몽 에이드",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
