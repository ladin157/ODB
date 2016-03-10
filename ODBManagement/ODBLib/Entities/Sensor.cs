using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODBLib.Entities
{
    class Sensor
    {
        private int _idSensor;
        private int _idVehicle;
        private string _sensorName;
        private string _description;
        private string _imagePath;

        public int IdSensor
        {
            get { return _idSensor; }
        }

        public int IdVehicle
        {
            get { return _idVehicle; }
            set { _idVehicle = value; }
        }

        public string SensorName
        {
            get { return _sensorName; }
            set { _sensorName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        public Sensor() { }

        public Sensor(int idSensor, int idVehicle, string sensorName, string description, string imagePath)
        {
            _idSensor = idSensor;
            _idVehicle = idVehicle;
            _sensorName = sensorName;
            _description = description;
            _imagePath = imagePath;
        }

        public Sensor(int idVehicle, string sensorName, string description, string imagePath)
        {
            _idVehicle = idVehicle;
            _sensorName = sensorName;
            _description = description;
            _imagePath = imagePath;
        }
    }
}
