using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODBLib.Entities;

namespace ODBLib.Data
{
    class VehicleErrorDB : DataLayer
    {
        private VehicleErrorDB() : base() { }

        private static VehicleErrorDB _instance = new VehicleErrorDB();

        public static VehicleErrorDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VehicleErrorDB();
                }
                return _instance;
            }
        }

        public List<VehicleError> GetVehicleErrors()
        {
            List<VehicleError> vehicleErrors = new List<VehicleError>();
            return vehicleErrors;
        }

        public VehicleError GetVehicleErrorById(int idVehicleError)
        {
            VehicleError vehicleError = new VehicleError();
            return vehicleError;
        }

        public bool AddVehicleError(VehicleError vehicleError)
        {
            bool res = false;
            return res;
        }

        public bool UpdateVehicleError(int idVehicleError, VehicleError vehicleError)
        {
            bool res = false;
            return res;
        }

        public bool DeleteVehicleError(int idVehicleError)
        {
            bool res = false;
            return res;
        }
    }
}
