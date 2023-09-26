﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Choiyebeen.Model
{
   public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredntial credntial);
        void add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
        object AuthenticateUser(NetworkCredential networkCredential);
        //...
    }
}
