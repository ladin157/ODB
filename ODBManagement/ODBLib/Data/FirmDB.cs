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
    class FirmDB : DataLayer
    {
        private FirmDB() : base() { }

        private static FirmDB _instance = new FirmDB();

        public static FirmDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirmDB();
                }
                return _instance;
            }
        }

        public List<Firm> GetFirms()
        {
            List<Firm> firms = new List<Firm>();
            string sqlStr = "GET_ALL_FIRMS";
            DataTable dt = Execute(sqlStr);

            foreach (DataRow row in dt.Rows)
            {
                int idFirm = int.Parse(row[0].ToString());
                string firmName = row[1].ToString();
                string address = row[2].ToString();
                string headQuarter = row[3].ToString();
                Firm firm = new Firm(idFirm, firmName, address, headQuarter);
                firms.Add(firm);
            }
            return firms;
        }

        public Firm GetFirmById(int idFirm)
        {
            Firm firm = new Firm();
            List<Firm> firms = GetFirms();
//            for (int i = 0; i < firms.Count; i++)
//            {
//                if (idFirm == firms[i].IdFirm)
//                {
//                    firm = firms[i];
//                    break;
//                }
//            }

            foreach (Firm f in firms)
            {
                if (f.IdFirm == idFirm)
                {
                    firm = f;
                    break;
                }
            }
            return firm;
        }

        public bool AddFirm(Firm firm, ref string error)
        {
            bool res = false;
            string sqlStr = "ADD_FIRM";
            SqlParameter pFirmName = new SqlParameter("@FirmName", firm.FirmName);
            SqlParameter pAddress = new SqlParameter("@Address", firm.Address);
            SqlParameter pHeadQuarter = new SqlParameter("@HeadQuarter", firm.HeadQuarter);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pFirmName, pAddress, pHeadQuarter))
            {
                res = true;
            }
            return res;
        }

        public bool UpdateFirm(int idFirm, Firm firm, ref string error)
        {
            bool res = false;
            string sqlStr = "UPDATE_FIRM";
            SqlParameter pIdFirm = new SqlParameter("@IdFirm", idFirm);
            SqlParameter pFirmName = new SqlParameter("@FirmName", firm.FirmName);
            SqlParameter pAddress = new SqlParameter("@Address", firm.Address);
            SqlParameter pHeadQuarter = new SqlParameter("@HeadQuarter", firm.HeadQuarter);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdFirm, pFirmName, pAddress, pHeadQuarter))
            {
                res = true;
            }
            return res;
        }

        public bool DeleteFirm(int idFirm, ref string error)
        {
            bool res = false;
            string sqlStr = "DELET_FIRM";
            SqlParameter pIdUser = new SqlParameter("@IdFirm", idFirm);
            if (ExecuteNonQuery(sqlStr, CommandType.StoredProcedure, ref error, pIdUser))
            {
                res = true;
            }
            return res;
        }

    }
}
