using Music.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.service
{
    interface IUserService:Service<User>
    {
        List<User> getAllUser();
        bool isRegistered(User user);
        bool isExist(User user);

        User readByName(string name);
        List<User> getAllRegisterUser();
        //string encryptPassword(string pass);
        // string decryptPassword(string encryptPass);
    }
}
