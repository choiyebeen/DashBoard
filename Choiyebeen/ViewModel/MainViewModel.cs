using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Choiyebeen.Model;
using Choiyebeen.Repositories;

namespace Choiyebeen.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

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

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName};)";
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
