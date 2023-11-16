using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Choiyebeen.Model;
using Choiyebeen.Repositories;
using FontAwesome.Sharp;

namespace Choiyebeen.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;
        private int m_price;
        private ObservableCollection<CartModel> m_cart_list; //이걸 통해서 표 만들어짐
        

        //properties
        public ObservableCollection<CartModel> CartList
        {
            get
            {
                return m_cart_list;
            }
            set
            {
                m_cart_list = value;
                OnPropertyChanged(nameof(CartList));
            }
        }

        public int Price
        {
            get 
            {
                return m_price; 
            }

            set
            {
                m_price = value;
                OnPropertyChanged(nameof(Price));
            }

        }
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView // 뷰모델 베이스를 넘겨줘야함 / 뷰 모델 베이스로 사용
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return Caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        
        //--> commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowTeaCommand { get; }
        public ICommand ShowSmoothieCommand { get; }
        public ICommand ShowAdeCommand { get; }
        public ICommand ShowDesertCommand { get; }
        public ICommand PayCommand { get; set; }
        public ICommand CancleCommand { get; set; }

        public MainViewModel() //생성자 처음에 사용
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            m_price = 0;

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowTeaCommand = new ViewModelCommand(ExecuteShowTeaCommand);
            ShowSmoothieCommand = new ViewModelCommand(ExecuteShowSmoothieCommand);
            ShowAdeCommand = new ViewModelCommand(ExecuteShowAdeCommand);
            ShowDesertCommand = new ViewModelCommand(ExecuteShowDesertCommand);
            PayCommand = new ViewModelCommand(ExecutePayCommand);
            CancleCommand = new ViewModelCommand(ExecuteCancleCommand);

            CartList = new ObservableCollection<CartModel>(); //생성자에서 객체화
            



            //Default view
            ExecuteShowCustomerViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteCancleCommand(object obj)
        {
            MessageBoxResult cancle = MessageBox.Show("결제 취소하시겠습니까?", "결제 취소", MessageBoxButton.YesNo);

            if (cancle == MessageBoxResult.Yes)
            {
                CartList.Clear();
                Price = 0;
            }
        }

        private void ExecutePayCommand(object obj)
        {
           MessageBoxResult result = MessageBox.Show($"{Price}원을 결제 하시겠습니까?","결제",MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MessageBoxResult receipt = MessageBox.Show("영수증을 출력하시겠습니까?", "영수증", MessageBoxButton.YesNo);
                MessageBoxResult Thx = MessageBox.Show("감사합니다");
                CartList.Clear();
                Price = 0;
            }
        }


        // 구매 장바구니
        private void MainViewModelPriceChanged(object sender, CartModel newValue) //desertViewModel에서 newValue로 값이 넘어옴
        {
            int index = -1;
            for (int i = 0; i < CartList.Count; i++) //CartList.Count는 장바구니에 있는 갯수
            {
                if(CartList[i].ItemName == newValue.ItemName) 
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                CartList[index].ItemCount++;
                CartList[index].ItemPrice += newValue.ItemPrice;
                var tempCartList = new ObservableCollection<CartModel>(CartList);
                CartList = tempCartList; //우회

            }
            else
            {
                CartList.Add(newValue); //못 찾음
            }

            Price += newValue.ItemPrice; //가격 더하기
        }



        private void ExecuteShowDesertCommand(object obj)
        {
            var desertViewModel = new DesertViewModel();
            desertViewModel.PriceChanged += MainViewModelPriceChanged; //priceChanged의 값이 바뀌면 MainViewModelPriceChanged가 자동 사용
            Caption = "Desert";
            Icon = IconChar.Home;
            CurrentChildView = desertViewModel; //화면전환
        }

        private void ExecuteShowAdeCommand(object obj)
        {
            var adeViewModel = new AdeViewModel();
            adeViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Ade";
            Icon = IconChar.Home;
            CurrentChildView = adeViewModel;
        }

        private void ExecuteShowSmoothieCommand(object obj)
        {
            var smoothieViewModel = new SmoothieViewModel();
            smoothieViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Smoothie";
            Icon = IconChar.Home;
            CurrentChildView = smoothieViewModel;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Customers";
            Icon = IconChar.UserGroup;
            CurrentChildView = customerViewModel;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Dashboard";
            Icon = IconChar.Home;
            CurrentChildView = homeViewModel;
        }

        private void ExecuteShowTeaCommand(object obj)
        {
            var teaViewModel = new TeaViewModel();
            teaViewModel.PriceChanged += MainViewModelPriceChanged;
            Caption = "Tea";
            Icon = IconChar.Home;
            CurrentChildView = teaViewModel;
        }

       


        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $" {user.Name} {user.LastName}";
                    CurrentUserAccount.ProfilePicture = null;
              
            }
            else
            {
                CurrentUserAccount.DisplayName="잘못된 사용자입니다. 로그인 되지 않습니다.";
                //hide child view
            }
        }
    }
}
