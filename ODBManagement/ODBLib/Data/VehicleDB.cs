using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODBLib.Entities;

namespace ODBLib.Data
{
    class VehicleDB : DataLayer
    {
        private VehicleDB() : base() { }

        private static VehicleDB _instance = new VehicleDB();

        public static VehicleDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleDB();
                }
                return _instance;
            }
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string sqlStr = "GET_ALL_VEHICLES";
            DataTable dt = Execute(sqlStr);
            foreach (DataRow row in dt.Rows)
            {
                int idVehicle = int.Parse(row[0].ToString());
                int idFirm = int.Parse(row[1].ToString());
                string name = row[2].ToString();
                Vehicle vehicle = new Vehicle(idVehicle, idFirm, name);
                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        public bool AddVehicle(Vehicle vehicle, ref string error)
        {
            bool res = false;
            string sqlStr = "ADD_VEHICLE";
            SqlParameter pIdFirm =new SqlParameter("@IdFirm", vehicle.IdFirm);
            SqlParameter pName = new SqlParameter("@SensorName", vehicle.VehicleName);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdFirm, pName))
            {
                res = true;
            }
            return res;
        }

        public bool UpdateVehicle(int idVehicle, Vehicle vehicle, ref string error)
        {
            bool res = false;
            string sqlStr = "UPDATE_VEHICLE";
            SqlParameter pIdVehicle = new SqlParameter("@IdVehicle", idVehicle);
            SqlParameter pIdFirm = new SqlParameter("@IdFirm", vehicle.IdFirm);
            SqlParameter pName = new SqlParameter("@SensorName", vehicle.VehicleName);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdVehicle, pIdFirm, pName))
            {
                res = true;
            }
            return res;
        }

        public bool DeleteVehicle(int idVehicle, ref string error)
        {
            bool res = false;
            string sqlStr = "DELETE_VEHICLE";
            SqlParameter pIdVehicle =new SqlParameter("@IdVehicle", idVehicle);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdVehicle))
            {
                res = true;
            }
            return res;
        }
    }
}
