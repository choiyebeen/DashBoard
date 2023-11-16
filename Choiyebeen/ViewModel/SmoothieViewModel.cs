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
    public class SmoothieViewModel : ViewModelBase //상속 자료형 맞춰줘야함
    {
        public event EventHandler<CartModel> PriceChanged;
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
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "망고 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteSyogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "딸기 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteByogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "블루베리 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecutePyogurtCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "플레인 요거트 스무디",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
