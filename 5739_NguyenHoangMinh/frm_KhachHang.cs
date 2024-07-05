using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5739_NguyenHoangMinh
{
    public partial class frm_KhachHang : Form
    {
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\Học Tập\Lập Trình Ứng Dụng .NET\5739_NguyenHoangMinh\5739_NguyenHoangMinh\5739_NguyenHoangMinh.mdf"";Integrated Security=True";
            SqlConnection conn = new SqlConnection(chuoikn);
            string sql = "Insert into KhachHang values ('" + txt_MSKH.Text + "',N'" + txt_HoTen.Text + "',N'" + txt_DiaChi.Text + "')";
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1) MessageBox.Show("Thêm khách hàng thành công");
            else MessageBox.Show("Thêm khách hàng thất bại");
            load_kh();

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\Học Tập\Lập Trình Ứng Dụng .NET\5739_NguyenHoangMinh\5739_NguyenHoangMinh\5739_NguyenHoangMinh.mdf"";Integrated Security=True";
            SqlConnection conn = new SqlConnection(chuoikn);
            string sql = "UPDATE KhachHang SET HoTen = '" + txt_HoTen.Text + "', DiaChi = '" + txt_DiaChi.Text + "' WHERE MSKH = '" + txt_MSKH.Text + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1) MessageBox.Show("Sửa khách hàng thành công");
            else MessageBox.Show("Sửa khách hàng thất bại");
            load_kh();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\Học Tập\Lập Trình Ứng Dụng .NET\5739_NguyenHoangMinh\5739_NguyenHoangMinh\5739_NguyenHoangMinh.mdf"";Integrated Security=True";
            SqlConnection conn = new SqlConnection(chuoikn);
            string sql = "DELETE FROM KhachHang WHERE MSKH = '" + txt_MSKH.Text + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1) MessageBox.Show("Xóa khách hàng thành công");
            else MessageBox.Show("Xóa khách hàng thất bại");
            load_kh();
        }

        public void load_kh()
        {
            string chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\Học Tập\Lập Trình Ứng Dụng .NET\5739_NguyenHoangMinh\5739_NguyenHoangMinh\5739_NguyenHoangMinh.mdf"";Integrated Security=True";
            string sql = "Select * From KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(sql, chuoikn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt_GridKH.DataSource = dt;
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            load_kh();
        }

        private void dt_GridKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MSKH.Text = dt_GridKH.CurrentRow.Cells["MSKH"].Value.ToString();
            txt_HoTen.Text = dt_GridKH.CurrentRow.Cells["HoTen"].Value.ToString();
            txt_DiaChi.Text = dt_GridKH.CurrentRow.Cells["DiaChi"].Value.ToString();
        }
    }
}
