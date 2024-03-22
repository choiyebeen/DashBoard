using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Choiyebeen.Repositories;
using Choiyebeen.Model;



namespace Choiyebeen.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;



        //properties
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }


        // -> Commands

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordcommand { get; }
        public ICommand showPasswordcommand { get; }
        public ICommand RememberPasswordcommand { get; }




        //constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordcommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }



        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (Username == "dpqlsdl8" && Password == "1234") //절대 아이디 비번
            {
                IsViewVisible = false;
            }
            else
            {
                var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password)); //sql없으면 실행안됨
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null);
                    IsViewVisible = false;
                }
                else
                {
                    ErrorMessage = "* Invalid username or password";
                }

            }

        }
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
