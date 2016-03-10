using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ODBLib.Configure;

namespace ODBLib.Data
{
    public class DataLayer
    {
        //dinh nghia chuoi ket noi de ket noi vao CSDL
        private string _connStr;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataAdapter _adapter;

        protected DataLayer()
        {
            bool updateSettings = true;
            if (File.Exists(Settings.Instance.FileSettingName))
            {
                try
                {
                    updateSettings = false;
                }
                catch (Exception)
                {
                    _connStr = Settings.Instance.ConnectionString;
                    throw;
                }
            }
            else
            {
                _connStr = Settings.DefaultConnectionString;
            }
            _connection = new SqlConnection(_connStr);
            TestConnection(updateSettings);
        }

        private void TestConnection(bool updateSettings)
        {
            try
            {
                _connection.Open();
                if (updateSettings)
                {

                }
                _connection.Close();
            }
            catch (Exception exception)
            {
                Settings.Instance.Log(exception.Message);
                _connection = new SqlConnection(_connStr);
            }
        }

        #region Functional Methods

        protected DataTable Execute(string sqlStr)
        {
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = CommandType.Text;
            _adapter = new SqlDataAdapter(_command);
            DataTable dt = new DataTable();
            _adapter.Fill(dt);
            _connection.Close();
            return dt;
        }

        protected DataTable Execute(string sqlstr, CommandType commandType)
        {
            _connection = new SqlConnection();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlstr;
            _command.CommandType = commandType;
            _adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _adapter.Fill(dt);
            _connection.Close();
            return dt;
        }

        protected DataTable Execute(string sqlStr, CommandType commandType, params SqlParameter[] param)
        {
            _connection = new SqlConnection();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            foreach (SqlParameter p in param)
            {
                _command.Parameters.Add(p);
            }
            _adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            _adapter.Fill(dt);
            _connection.Close();
            return dt;
        }

        protected string ExecuteQueryXml(string sqlStr)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = CommandType.Text;
            _adapter = new SqlDataAdapter(_command);
            DataSet ds = new DataSet();
            _adapter.Fill(ds);
            _connection.Close();
            return ds.GetXml();
        }

        protected string ExecuteQueryXml(string sqlStr, CommandType commandType)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            _adapter = new SqlDataAdapter(_command);
            DataSet ds = new DataSet();
            _adapter.Fill(ds);
            _connection.Close();
            return ds.GetXml();
        }


        protected string ExecuteQueryXml(string sqlStr, CommandType commandType, params SqlParameter[] param)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;

            foreach (SqlParameter p in param)
            {
                _command.Parameters.Add(p);
            }
            _adapter = new SqlDataAdapter(_command);
            DataSet ds = new DataSet();
            _adapter.Fill(ds);
            _connection.Close();
            return ds.GetXml();
        }

        protected bool ExecuteNonQuery(string sqlStr, ref string error)
        {
            bool f = false;
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = CommandType.Text;
            try
            {
                int res = _command.ExecuteNonQuery();
                if (res > 0)
                {
                    f = true;
                }
            }
            catch (SqlException exception)
            {
                error = exception.Message;
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return f;
        }

        protected bool ExecuteNonQuery(string sqlStr, CommandType commandType, ref string error)
        {
            bool f = false;
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            try
            {
                int res = _command.ExecuteNonQuery();
                if (res > 0)
                {
                    f = true;
                }
            }
            catch (SqlException exception)
            {
                error = exception.Message;
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return f;
        }

        protected bool ExecuteNonQuery(string sqlStr, CommandType commandType, ref string error,
            params SqlParameter[] param)
        {
            bool f = false;
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            foreach (SqlParameter p in param)
            {
                _command.Parameters.Add(p);
            }
            try
            {
                int res = _command.ExecuteNonQuery();
                if (res > 0)
                {
                    f = true;
                }
            }
            catch (SqlException exception)
            {
                error = exception.Message;
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return f;
        }

        protected object ExecuteScalar(string sqlStr)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = CommandType.Text;
            object obj;
            try
            {
                obj = _command.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                Settings.Instance.Log(exception.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return obj;
        }

        protected object ExecuteScalar(string sqlStr, CommandType commandType)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            object obj;
            try
            {
                obj = _command.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                Settings.Instance.Log(exception.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return obj;
        }

        protected object ExecuteScalar(string sqlStr, CommandType commandType, params SqlParameter[] param)
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connStr);
            }
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandText = sqlStr;
            _command.CommandType = commandType;
            foreach (SqlParameter p in param)
            {
                _command.Parameters.Add(p);
            }
            object obj;
            try
            {
                obj = _command.ExecuteScalar();
            }
            catch (SqlException exception)
            {
                Settings.Instance.Log(exception.Message);
                throw;
            }
            finally
            {
                _connection.Close();
            }
            return obj;
        }


        #endregion

    }
}