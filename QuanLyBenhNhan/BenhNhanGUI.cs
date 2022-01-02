using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyBenhNhan
{
    public partial class BenhNhanGUI : Form
    {
        private BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
        private int id;
        public BenhNhanGUI()
        {
            InitializeComponent();
            btnUpdate.Enabled = btnDelete.Enabled = false;
        }

        private void BenhNhanGUI_Load(object sender, EventArgs e)
        {
            dgvBenhNhan.DataSource = benhNhanBUS.getBenhNhan();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BenhNhanDTO benhNhan = new BenhNhanDTO();
            bool check = true;
            //Ho ten 
            if (!String.IsNullOrEmpty(txtHoTen.Text))
            {
                benhNhan.TenBN = txtHoTen.Text;
                //Nghe Nghiep
                if (!String.IsNullOrEmpty(txtNgheNghiep.Text))
                {
                    benhNhan.NgheNghiep = txtNgheNghiep.Text;
                    //sdt
                    if (!String.IsNullOrEmpty(txtSDT.Text))
                    {
                        benhNhan.Sdt = txtSDT.Text;
                        //Dia Chi
                        if (!String.IsNullOrEmpty(txtDiaChi.Text))
                        {
                            benhNhan.DiaChi = txtDiaChi.Text;
                            //Email
                            if (!String.IsNullOrEmpty(txtEmail.Text))
                            {
                                benhNhan.Email = txtEmail.Text;
                            }
                            else
                            {
                                txtEmail.Focus();
                                check = false;
                                MessageBox.Show("Vui lòng nhập email.", "Information");
                            }
                        }
                        else
                        {
                            txtDiaChi.Focus();
                            check = false;
                            MessageBox.Show("Vui lòng nhập địa chỉ.", "Information");
                        }
                    }
                    else
                    {
                        txtSDT.Focus();
                        check = false;
                        MessageBox.Show("Vui lòng nhập số điện thoại.", "Information");
                    }
                }
                else
                {
                    txtNgheNghiep.Focus();
                    check = false;
                    MessageBox.Show("Vui lòng nhập nghề nghiệp.", "Information");
                }
            }
            else
            {
                txtHoTen.Focus();
                check = false;
                MessageBox.Show("Vui lòng nhập họ tên.", "Information");
            }

            //Gioi Tinh
            if (rdtNam.Checked && !rdtNu.Checked)
                benhNhan.GioiTinh = 0;
            else if (!rdtNam.Checked && rdtNu.Checked)
                benhNhan.GioiTinh = 1;
            else
            {
                check = false;
                MessageBox.Show("Vui lòng chọn giới tính.", "Information");
            }

            //Ngay Sinh
            benhNhan.NgaySinh = dtpNgaySinh.Value;
           
            if (check)
            {
                if (benhNhanBUS.insertBenhNhan(benhNhan))
                {
                    MessageBox.Show("Đã thêm bệnh nhân thành công.", "Information");
                    clear();
                    dgvBenhNhan.DataSource = benhNhanBUS.getBenhNhan();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi", "Information");
                }
            }
        }

        private void dgvBenhNhan_Click(object sender, EventArgs e)
        {
            int i = dgvBenhNhan.CurrentRow.Index;
            id = int.Parse(dgvBenhNhan[0, i].Value.ToString());
            txtHoTen.Text = dgvBenhNhan[1, i].Value.ToString();
            if (dgvBenhNhan[2, i].Value.ToString() == "Nam")
            {
                rdtNam.Checked = true;
            }
            else
            {
                rdtNu.Checked = true;
            }
            dtpNgaySinh.Value =Convert.ToDateTime(dgvBenhNhan[3, i].Value.ToString());
            txtNgheNghiep.Text = dgvBenhNhan[4, i].Value.ToString();
            txtDiaChi.Text = dgvBenhNhan[5, i].Value.ToString();
            txtSDT.Text = dgvBenhNhan[6, i].Value.ToString();
            txtEmail.Text = dgvBenhNhan[7, i].Value.ToString();
            btnUpdate.Enabled = btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BenhNhanDTO benhNhan = new BenhNhanDTO();
            bool check = true;
            benhNhan.MaBN = id;

            //Ho ten 
            if (!String.IsNullOrEmpty(txtHoTen.Text))
            {
                benhNhan.TenBN = txtHoTen.Text;
                //Nghe Nghiep
                if (!String.IsNullOrEmpty(txtNgheNghiep.Text))
                {
                    benhNhan.NgheNghiep = txtNgheNghiep.Text;
                    //sdt
                    if (!String.IsNullOrEmpty(txtSDT.Text))
                    {
                        benhNhan.Sdt = txtSDT.Text;
                        //Dia Chi
                        if (!String.IsNullOrEmpty(txtDiaChi.Text))
                        {
                            benhNhan.DiaChi = txtDiaChi.Text;
                            //Email
                            if (!String.IsNullOrEmpty(txtEmail.Text))
                            {
                                benhNhan.Email = txtEmail.Text;
                            }
                            else
                            {
                                txtEmail.Focus();
                                check = false;
                                MessageBox.Show("Vui lòng nhập email.", "Information");
                            }
                        }
                        else
                        {
                            txtDiaChi.Focus();
                            check = false;
                            MessageBox.Show("Vui lòng nhập địa chỉ.", "Information");
                        }
                    }
                    else
                    {
                        txtSDT.Focus();
                        check = false;
                        MessageBox.Show("Vui lòng nhập số điện thoại.", "Information");
                    }
                }
                else
                {
                    txtNgheNghiep.Focus();
                    check = false;
                    MessageBox.Show("Vui lòng nhập nghề nghiệp.", "Information");
                }
            }
            else
            {
                txtHoTen.Focus();
                check = false;
                MessageBox.Show("Vui lòng nhập họ tên.", "Information");
            }

            //Gioi Tinh
            if (rdtNam.Checked && !rdtNu.Checked)
                benhNhan.GioiTinh = 0;
            else if (!rdtNam.Checked && rdtNu.Checked)
                benhNhan.GioiTinh = 1;
            else
            {
                check = false;
                MessageBox.Show("Vui lòng chọn giới tính.", "Information");
            }

            //Ngay Sinh
            benhNhan.NgaySinh = dtpNgaySinh.Value;

            if (check)
            {
                if (benhNhanBUS.updateBenhNhan(benhNhan))
                {
                    MessageBox.Show("Đã cập nhật bệnh nhân thành công.", "Information");
                    clear();
                    dgvBenhNhan.DataSource = benhNhanBUS.getBenhNhan();
                    btnUpdate.Enabled = btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi", "Information");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (benhNhanBUS.deleteBenhNhan(id))
            {
                MessageBox.Show("Đã xóa bệnh nhân thành công.", "Information");
                dgvBenhNhan.DataSource = benhNhanBUS.getBenhNhan();
                clear();
                btnUpdate.Enabled = btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Information");
            }
        }

        private void clear()
        {
            txtHoTen.Text = null;
            rdtNam.Checked = false;
            rdtNu.Checked = false;
            
            dtpNgaySinh.Value = DateTime.Today;
            txtNgheNghiep.Text = null;
            txtDiaChi.Text = null;
            txtSDT.Text = null;
            txtEmail.Text = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvBenhNhan.DataSource = benhNhanBUS.getBenhNhan();
            clear();
            txtTimKiem.Text = null;
            btnUpdate.Enabled = btnDelete.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTimKiem.Text))
            {
                dgvBenhNhan.DataSource = benhNhanBUS.searchBenhNhan(txtTimKiem.Text);
            }
            else
            {
                txtTimKiem.Focus();
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Information");
            } 
        }
    }
}
