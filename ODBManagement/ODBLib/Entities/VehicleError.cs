namespace ODBLib.Entities
{
    class VehicleError
    {
        private readonly int _idVehicleError;
        private int _idVehicle;
        private string _errorCode;
        private string _linkToFile;
        private string _engDescription;
        private string _vieDescription;

        public int IdVehicleError
        {
            get { return _idVehicleError; }
        }

        public int IdVehicle
        {
            get { return _idVehicle; }
            set { _idVehicle = value; }
        }

        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        public string LinkToFile
        {
            get { return _linkToFile; }
            set { _linkToFile = value; }
        }

        public string EngDescription
        {
            get { return _engDescription; }
            set { _engDescription = value; }
        }

        public string VieDescription
        {
            get { return _vieDescription; }
            set { _vieDescription = value; }
        }

        public VehicleError()
        {
            _idVehicleError = 0;
            _idVehicle = 0;
            _errorCode = "";
            _linkToFile = "";
            _engDescription = "";
            _vieDescription = "";
        }

        public VehicleError(int idVehicleError, int idVehicle, string errorCode, string linkToFile,
            string engDescription, string vieDescription)
        {
            _idVehicleError = idVehicleError;
            _idVehicle = idVehicle;
            _errorCode = errorCode;
            _linkToFile = linkToFile;
            _engDescription = engDescription;
            _vieDescription = vieDescription;
        }

        public VehicleError(int idVehicle, string errorCode, string linkToFile,
            string engDescription, string vieDescription)
        {
            _idVehicle = idVehicle;
            _errorCode = errorCode;
            _linkToFile = linkToFile;
            _engDescription = engDescription;
            _vieDescription = vieDescription;
        }

    }
}
