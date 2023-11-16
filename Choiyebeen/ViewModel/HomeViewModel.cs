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
    public class HomeViewModel : ViewModelBase // 상속 -> 자료형 맞춰줘야함 
    {
        public event EventHandler<CartModel> PriceChanged;
        public ICommand CiderCommand { get; }
        public ICommand CocaCommand { get; }

        public HomeViewModel()
        {
            CiderCommand = new ViewModelCommand(ExecuteCiderCommand);
            CocaCommand = new ViewModelCommand(ExecuteCocaCommand);
        }

        private void ExecuteCocaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "콜라",
                ItemCount = 1,
                ItemPrice = 1500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCiderCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "사이다",
                ItemCount = 1,
                ItemPrice = 1500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
