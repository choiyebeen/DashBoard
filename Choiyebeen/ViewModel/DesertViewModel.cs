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
    public class DesertViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged; //얘를 통해서 뷰모델끼리 데이터를 주고 받음
        public ICommand CupcookieCommand { get; }
        public ICommand CookieCommand { get; }
        public ICommand IcecreamCommand { get; }
        public ICommand MacaronCommand { get; }
        public ICommand BeanbreadCommand { get; }

        public DesertViewModel() //생성자 먼저사용됨
        {
            CupcookieCommand = new ViewModelCommand(ExecuteCupcookieCommand);
            CookieCommand = new ViewModelCommand(ExecuteCookieCommand);
            IcecreamCommand = new ViewModelCommand(ExecuteIcecreamCommand);
            MacaronCommand = new ViewModelCommand(ExecuteMacaronCommand);
            BeanbreadCommand = new ViewModelCommand(ExecuteBeanbreadCommand);

        }

        private void ExecuteBeanbreadCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "커피콩 빵",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteMacaronCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "마카롱",
                ItemCount = 1,
                ItemPrice = 2500
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteIcecreamCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "구슬 아이스크림",
                ItemCount = 1,
                ItemPrice = 3000
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteCookieCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "쿠키",
                ItemCount = 1,
                ItemPrice = 2000
            };
            PriceChanged?.Invoke(this, item);
        }

        private void ExecuteCupcookieCommand(object obj)
        {
            CartModel item = new CartModel()
            {
                ItemName = "컵쿠키",
                ItemCount = 1,
                ItemPrice = 2700
            };
            PriceChanged?.Invoke(this, item);
        }
    }
}
