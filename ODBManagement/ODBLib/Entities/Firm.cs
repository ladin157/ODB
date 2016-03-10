using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODBLib.Entities
{
    class Firm
    {
        private int _idFirm;
        private string _firmName;
        private string _address;
        private string _headQuarter;

        public int IdFirm
        {
            get { return _idFirm; }
        }

        public string FirmName
        {
            get { return _firmName; }
            set { _firmName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string HeadQuarter
        {
            get { return _headQuarter; }
            set { _headQuarter = value; }
        }

        public Firm()
        {
            _idFirm = 0;
            _firmName = "";
            _address = "";
            _headQuarter = "";
        }

        public Firm(int idFirm, string firmName, string address, string headQuarter)
        {
            _idFirm = idFirm;
            _firmName = firmName;
            _address = address;
            _headQuarter = headQuarter;
        }

        public Firm(string firmname, string address, string headQuarter)
        {
            _firmName = firmname;
            _address = address;
            _headQuarter = headQuarter;
        }


    }
}
