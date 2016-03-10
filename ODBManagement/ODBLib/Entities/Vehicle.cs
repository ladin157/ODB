using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODBLib.Entities
{
    class Vehicle
    {
        private int _idVehicle;
        private int _idFirm;
        private string _vehicleName;

        public int IdVehicle
        {
            get { return _idVehicle; }
        }

        public int IdFirm
        {
            get { return _idFirm; }
            set { _idFirm = value; }
        }

        public string VehicleName
        {
            get { return _vehicleName; }
            set { _vehicleName = value; }
        }

        public Vehicle()
        {
            _idVehicle = 0;
            _idFirm = 0;
            _vehicleName = "";
        }

        public Vehicle(int idVehicle, int idFirm, string vehicleName)
        {
            _idVehicle = idVehicle;
            _idFirm = idFirm;
            _vehicleName = vehicleName;
        }

        public Vehicle(int idFirm, string vehicleName)
        {
            _idFirm = idFirm;
            _vehicleName = vehicleName;
        }
    }
}
