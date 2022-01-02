using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BenhNhanDTO
    {
        private int maBN;
        private String tenBN;
        private int gioiTinh;
        private DateTime ngaySinh;
        private String ngheNghiep;
        private String diaChi;
        private String sdt;
        private String email;

        public BenhNhanDTO() {}

        public int MaBN { get => maBN; set => maBN = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgheNghiep { get => ngheNghiep; set => ngheNghiep = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}
