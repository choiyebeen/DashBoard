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
    public class CustomerViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged;
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
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "바닐라 라떼",
                ItemCount = 1,
                ItemPrice = 3800
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteMochalatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "모카 라떼",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteIceCoffeeCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "아메리카노",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteIceLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "카페라떼",
                ItemCount = 1,
                ItemPrice = 3800
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "카라멜 마끼아또",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHLatteCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "헤이즐넛 라떼",
                ItemCount = 1,
                ItemPrice = 4300
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }


    }


}
