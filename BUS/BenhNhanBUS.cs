using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace BUS
{
    public class BenhNhanBUS
    {
        private BenhNhanDAO benhNhanDAO = new BenhNhanDAO();

        public DataTable getBenhNhan()
        {
            return benhNhanDAO.getBenhNhan();
        }

        public DataTable searchBenhNhan(String key)
        {
            return benhNhanDAO.searchBenhNhan(key);
        }

        public bool insertBenhNhan(BenhNhanDTO bn)
        {
            return benhNhanDAO.insertBenhNhan(bn);
        }

        public bool updateBenhNhan(BenhNhanDTO bn)
        {
            return benhNhanDAO.updateBenhNhan(bn);
        }

        public bool deleteBenhNhan(int maBN)
        {
            return benhNhanDAO.deleteBenhNhan(maBN);
        }
    }
}
