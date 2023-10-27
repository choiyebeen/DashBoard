using System;
using System.Collections.Generic;
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
        private CartModel cartModel;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;

        //properties
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

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowTeaCommand = new ViewModelCommand(ExecuteShowTeaCommand);
            ShowSmoothieCommand = new ViewModelCommand(ExecuteShowSmoothieCommand);
            ShowAdeCommand = new ViewModelCommand(ExecuteShowAdeCommand);
            ShowDesertCommand = new ViewModelCommand(ExecuteShowDesertCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
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
