using System.Security;

namespace Choiyebeen.Model
{
    public class NetworkCredntial
    {
        public NetworkCredntial(string username, SecureString password)
        {
            UserName = username;
            Password = password;
        }

        public object UserName { get; internal set; }
        public object Password { get; internal set; }
    }
}