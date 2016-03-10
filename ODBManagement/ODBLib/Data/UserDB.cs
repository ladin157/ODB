using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ODBLib.Entities;

namespace ODBLib.Data
{
    internal class UserDB : DataLayer
    {
        private UserDB() : base()
        {
        }

        private static UserDB _instance = new UserDB();

        public static UserDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDB();
                }
                return _instance;
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string sqlStr = "select * from dbo.User";
            DataTable dt = Execute(sqlStr);
            foreach (DataRow row in dt.Rows)
            {
                int idUser = int.Parse(row[0].ToString());
                string username = row[1].ToString();
                string password = row[2].ToString();
                string type = row[3].ToString();
                UserType userType = UserType.Administrator;
                switch (type)
                {
                    case "Administrator":
                        userType = UserType.Administrator;
                        break;
                    case "Technician":
                        userType = UserType.Technician;
                        break;
                    case "Other":
                        userType = UserType.Other;
                        break;
                }
                string email = row[4].ToString();
                string phoneNumber = row[5].ToString();
                string fullname = row[6].ToString();
                User user = new User(idUser, username, password, userType, email, phoneNumber, fullname);
                users.Add(user);
            }
            return users;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            string sqlStr = "GET_USER_BY_ID";
            DataTable dt = Execute(sqlStr, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];
                int idUser = int.Parse(dataRow[0].ToString());
                string username = dataRow[1].ToString();
                string password = dataRow[2].ToString();
                UserType userType;
                Enum.TryParse(dataRow[3].ToString(), out userType);
                string email = dataRow[4].ToString();
                string phoneNumber = dataRow[5].ToString();
                string fullname = dataRow[6].ToString();
                user = new User(idUser, username, password, userType, email, phoneNumber, fullname);

            }
            return user;
        }

        public int GetIdByUserNamePassword(string username, string password)
        {
            string sqlStr = "GET_ID_BY_USERNAME_PASSWORD";
            int id = -1;
            SqlParameter pUsername = new SqlParameter("@Username", username);
            SqlParameter pPassword = new SqlParameter("@Password", password);
            object obj = ExecuteScalar(sqlStr, CommandType.StoredProcedure, pUsername, pPassword);
            if (obj != null)
            {
                id = (int) obj;
            }
            return id;
        }

        public bool UpdateUser(int idUser, User user, ref string error)
        {
            bool res = false;
            const string sqlStr = "UPDATE_USER";
            SqlParameter pIdUser = new SqlParameter("@IdUser", idUser);
            SqlParameter pUserName = new SqlParameter("@Username", user.Username);
            SqlParameter pPassword = new SqlParameter("@Password", user.Password);
            SqlParameter pUsertype = new SqlParameter("@Usertype", user.UserType);
            SqlParameter pEmail = new SqlParameter("@Email", user.Email);
            SqlParameter pPhoneNumber = new SqlParameter("@PhoneNumber", user.PhoneNumber);
            SqlParameter pFullname = new SqlParameter("@Fullname", user.Fullname);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdUser, pUserName, pPassword, pUsertype,
                pEmail, pPhoneNumber, pFullname))
            {
                res = true;
            }
            return res;
        }

        public bool DeleteUser(int idUser, ref string error)
        {
            bool res = false;
            string sqlStr = "DELETE_USER";
            SqlParameter pIdUser = new SqlParameter("@IdUser", idUser);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdUser))
            {
                res = true;
            }
            return res;
        }

        public bool ChangeUserType(int idUser, UserType userType, ref string error)
        {
            bool res = false;
            string sqlStr = "SET_USER_TYPE";
            SqlParameter pIdUser = new SqlParameter("@IdUser", idUser);
            SqlParameter pUserType = new SqlParameter("@UserType", userType);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdUser, pUserType))
            {
                res = true;
            }
            return res;
        }

        public bool CheckLogin(string username, string password)
        {
            bool res = false;
            int idUser = GetIdByUserNamePassword(username, password);
            if (idUser != -1)
            {
                res = true;
            }
            return res;
        }
    }
}