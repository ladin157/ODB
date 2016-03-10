using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ODBLib.Entities;

namespace ODBLib.Data
{
    class SensorDB : DataLayer
    {
        private SensorDB() : base() { }

        private static SensorDB _instance = new SensorDB();

        public static SensorDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SensorDB();
                }
                return _instance;
            }
        }

        public List<Sensor> GetSensors()
        {
            List<Sensor> sensors = new List<Sensor>();
            string sqlStr = "GET_ALL_SENSORS";
            DataTable dt = Execute(sqlStr, CommandType.StoredProcedure);
            foreach (DataRow row in dt.Rows)
            {
                int idSensor = int.Parse(row[0].ToString());
                int idVehicle = int.Parse(row[1].ToString());
                string name = row[2].ToString();
                string description = row[3].ToString();
                string imagePath = row[4].ToString();
                Sensor sensor = new Sensor(idSensor, idVehicle, name, description, imagePath);
            }
            return sensors;
        }

        public Sensor GetSensorById(int idSensor)
        {
            Sensor sensor = new Sensor();
            List<Sensor> sensors = GetSensors();
            foreach (Sensor s in sensors)
            {
                if (s.IdSensor == idSensor)
                {
                    sensor = s;
                    break;
                }
            }
            return sensor;
        }

        public bool AddSensor(Sensor sensor, ref string error)
        {
            bool res = false;
            string sqlStr = "ADD_SENSOR";
            SqlParameter pIdSensor = new SqlParameter("@IdSensor", sensor.IdSensor);
            SqlParameter pIdVehicle = new SqlParameter("@IdVehicle", sensor.IdVehicle);

            return res;
        }

        public bool UpdateSensor(int idSensor, Sensor sensor)
        {
            bool res = false;
            return res;
        }

        public bool DeleteSensor(int idSensor)
        {
            bool res = false;

            return res;
        }
    }
}
