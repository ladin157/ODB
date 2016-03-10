using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ODBLib.Entities
{
    internal enum UserType

    {
        Administrator = 1,
        Technician = 2,
        Other = 3
    }

    class User
    {
        private int _idUser;
        private string _username;
        private string _password;
        private string _fullname;
        private UserType _userType;
        private string _email;
        private string _phoneNumber;

        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }


        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public UserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public User()
        {
            _idUser = 0;
            _username = "";
            _password = "";
            _userType = UserType.Administrator;
            _email = "";
            _phoneNumber = "";
            _fullname = "";
        }

        public User(int idUser, string username, string password, UserType userType, string email, string phoneNumber,
            string fullname)
        {
            _idUser = idUser;
            _username = username;
            _password = password;
            _userType = userType;
            _email = email;
            _phoneNumber = phoneNumber;
            _fullname = fullname;
        }

        public User(string username, string password, UserType userType, string email, string phoneNumber,
            string fullname)
        {
            _username = username;
            _password = password;
            _userType = userType;
            _email = email;
            _phoneNumber = phoneNumber;
            _fullname = fullname;
        }
    }
}
