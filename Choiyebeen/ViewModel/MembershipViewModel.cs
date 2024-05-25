using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Input;
using Mysqlx.Prepare;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Choiyebeen.ViewModel
{
    public class MembershipViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private string _password;


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand CloseWindowCommand { get; }
        public ICommand SignUpCommand { get; }

        public MembershipViewModel()
        {
            CloseWindowCommand = new ViewModelCommand(ExecuteCloseWindowCommand);
            SignUpCommand = new ViewModelCommand(ExecuteSignUpCommand);
        }

        private void ExecuteSignUpCommand(object obj)
        {
           // MessageBox.Show($"Name: {Name}\nEmail: {Email}\nPassword: {Password}");

            string connectionString = "Server=localhost; Database=MVVMLoginDb; Integrated Security=true;"; // 실제 연결 문자열로 바꾸기

            string sql = "INSERT INTO [MVVMLoginDb].[dbo].[User] ([Username], [Password], [Name],[LastName],[Email]) VALUES (@Username, @Password, @Name, @Name ,@Email);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", Name);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@LastName", Name);
                command.Parameters.AddWithValue("@Email", Email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBoxResult result=MessageBox.Show("사용자 등록에 성공했습니다.");

                    if (result == MessageBoxResult.OK)
                    {
                        // obj가 Window인지 확인하고 창을 닫음
                        if (obj is Window window)
                        {
                            window.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
                }
            }

        }



            private void ExecuteCloseWindowCommand(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
    
}
