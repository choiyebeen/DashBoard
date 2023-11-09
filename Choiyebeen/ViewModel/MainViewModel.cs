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
        public static int m_price;
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

        public MainViewModel()
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
            CartList.Add(new CartModel { ItemName = "아메리카노", ItemCount = 1, ItemPrice = 4000 });
            CartList.Add(new CartModel { ItemName = "카페라떼", ItemCount = 2, ItemPrice = 4500 });
            CartList.Add(new CartModel { ItemName = "카푸치노", ItemCount = 3, ItemPrice = 4500 });
            for(int i = 0; i < 10; i++)
            {
                CartList.Add(new CartModel { ItemName = "카푸치노", ItemCount = 3, ItemPrice = 4500 });
            }

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteCancleCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecutePayCommand(object obj)
        {
           MessageBoxResult result = MessageBox.Show("결제 하시겠습니까?","결제",MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MessageBoxResult receipt = MessageBox.Show("영수증을 출력하시겠습니까?", "영수증", MessageBoxButton.YesNo);
                if(receipt == MessageBoxResult.Yes)
                {
                    MessageBoxResult Thx = MessageBox.Show("감사합니다");
                }
            }
            

        }

        private void ExecuteShowDesertCommand(object obj)
        {
            CurrentChildView = new DesertViewModel();
            Caption = "Desert";
            Icon = IconChar.Home;
        }

        private void ExecuteShowAdeCommand(object obj)
        {
            CurrentChildView = new AdeViewModel();
            Caption = "Ade";
            Icon = IconChar.Home;
        }

        private void ExecuteShowSmoothieCommand(object obj)
        {
            CurrentChildView = new SmoothieViewModel();
            Caption = "Smoothie";
            Icon = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowTeaCommand(object obj)
        {
            CurrentChildView = new TeaViewModel();
            Caption = "Tea";
            Icon = IconChar.Home;
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
