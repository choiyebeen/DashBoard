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
    public class TeaViewModel : ViewModelBase
    {
        public event EventHandler<CartModel> PriceChanged;
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
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "복숭아 아이스티",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteOteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "오미자 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteLteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "레몬 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteJteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "자스민 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHbteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "히비스커스 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteHteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "한라봉 차",
                ItemCount = 1,
                ItemPrice = 4500
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteGteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "생강차",
                ItemCount = 1,
                ItemPrice = 5000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }

        private void ExecuteCteaCommand(object obj)
        {
            CartModel item = new CartModel() //cartmodel생성
            {
                ItemName = "시트러스 차",
                ItemCount = 1,
                ItemPrice = 4000
            };
            PriceChanged?.Invoke(this, item); //변수넘김
        }
    }
}
