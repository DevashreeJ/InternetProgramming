using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class UserDataHandler
    {
        private static List<UserRegistration> userList;
        
        public UserDataHandler()
        {
            if (userList == null)
            {
                userList = new List<UserRegistration>()
                {
                    new UserRegistration()
                    {
                        regnumber = 12,
                        name = "Maya",
                        password = "abcd"
                    },
                     new UserRegistration()
                    {
                        regnumber = 13,
                        name = "Riya",
                        password = "d213f"
                    }

                };
            }
        }
        public bool AddUser(UserRegistration newUser)
        {
            bool result = false;

            if (!userList.Any(x => x.regnumber ==newUser.regnumber))
            {
                userList.Add(newUser);
                result = true;
            }

            return result;
        }
        public bool DeleteUser(UserRegistration user)
        {
            UserDataHandler udh = new UserDataHandler();

            bool result = false;

            if (userList.Any(x => x.regnumber == user.regnumber ))
            {
                userList.Remove(user);
                result = true;
            }

            return result;
        }

        public ICollection<UserRegistration> GetAllUsers()
        {
            return userList;
        }

        public UserRegistration GetUserByRegNumber(int num)
        {
            UserRegistration user = new UserRegistration();

            if (userList.Any(x => x.regnumber == num))
            {
                user = userList.Single(x => x.regnumber == num);
            }
            return user;

        }
        public void EditPassword(UserRegistration user)
        {
            UserDataHandler udh = new UserDataHandler();
            UserRegistration temp = userList.Single(x=>x.name==user.name);
            temp.password = user.password;
            DeleteUser(user);
            AddUser(temp);           
        }

        public void EditUser(UserRegistration user)
        {
            UserDataHandler udh = new UserDataHandler();
            UserRegistration temp = userList.Single(x => x.regnumber == user.regnumber);
            temp = user;
            DeleteUser(user);
            AddUser(temp);
        }

    }


}