using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class BenhNhanDAO : DBConnection
    {
        public DataTable getBenhNhan()
        {
            string sql = "select b.ma_bn, b.ten_bn," +
                " (CASE WHEN b.gioi_tinh = 0 THEN 'Nam' ELSE N'Nữ' END) as gioi_tinh," +
                " b.ngay_sinh, b.nghe_nghiep, b.dia_chi, b.sdt, b.email " +
                "from benhnhan as b";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daBenhNhan = new DataTable();

            da.Fill(daBenhNhan);
            daBenhNhan.Columns.Add("ord");
            for (int i = 1; i <= daBenhNhan.Rows.Count; i++)
                daBenhNhan.Rows[i - 1]["ord"] = i.ToString();

            return daBenhNhan;
        }

        public DataTable searchBenhNhan(String key)
        {
            string sql = string.Format("select b.ma_bn, b.ten_bn," +
                " (CASE WHEN b.gioi_tinh = 0 THEN 'Nam' ELSE N'Nữ' END) as gioi_tinh," +
                " b.ngay_sinh, b.nghe_nghiep, b.dia_chi, b.sdt, b.email " +
                "from benhnhan as b where b.ten_bn like N'%{0}%' or b.nghe_nghiep like N'%{0}%' or b.dia_chi like N'%{0}%' or b.sdt like '%{0}%' or b.email like '%{0}%'", key);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable daBenhNhan = new DataTable();

            da.Fill(daBenhNhan);
            daBenhNhan.Columns.Add("ord");
            for (int i = 1; i <= daBenhNhan.Rows.Count; i++)
                daBenhNhan.Rows[i - 1]["ord"] = i.ToString();

            return daBenhNhan;
        }
        public bool insertBenhNhan(BenhNhanDTO bn)
        {
            string sql = string.Format("insert into benhnhan(ten_bn, gioi_tinh, ngay_sinh, nghe_nghiep, dia_chi, sdt, email)" +
                "values(N'{0}','{1}','{2}',N'{3}',N'{4}','{5}','{6}')", bn.TenBN, bn.GioiTinh, bn.NgaySinh, bn.NgheNghiep, bn.DiaChi, bn.Sdt, bn.Email);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }

        public bool updateBenhNhan(BenhNhanDTO bn)
        {
            string sql = string.Format("update benhnhan " +
                "set ten_bn=N'{0}', gioi_tinh={1}, ngay_sinh='{2}', nghe_nghiep=N'{3}', dia_chi=N'{4}', sdt='{5}', email='{6}' where ma_bn={7}",
                bn.TenBN, bn.GioiTinh, bn.NgaySinh, bn.NgheNghiep, bn.DiaChi, bn.Sdt, bn.Email, bn.MaBN);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }

        public bool deleteBenhNhan(int maBN)
        {
            string sql = string.Format("delete benhnhan where ma_bn = {0}", maBN);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            con.Close();
            return true;
        }
    }
}
