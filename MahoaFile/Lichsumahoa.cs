using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace btlatbmtt
{
    public partial class Lichsumahoa : UserControl
    {
        private const string chuoiketnoi = "Data Source=VU\\SQLEXPRESS;Initial Catalog=atbm;Integrated Security=True;";
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào Datatable
        SqlDataAdapter lich_su = null;
        //Đối tượng hiển thị dữ liệu lên form
        DataTable atbm = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;

        //hàm kiểm tra kết nối 
        void test_conn()
        {
            try
            {
                SqlConnection test = new SqlConnection(chuoiketnoi);
                test.Open();

            }
            catch
            {
                MessageBox.Show("Kết nối không thành công");
            }
        }
        void loaddata()
        {
            conn = new SqlConnection(chuoiketnoi);
            //vận chuyển dữ liệu vào datatable dtmh
            lich_su = new SqlDataAdapter("SELECT * FROM lich_su", conn);
            atbm = new DataTable();
            atbm.Clear();
            lich_su.Fill(atbm);
            //Đưa dữ liệu lên Datagrid view
            dgv_tk.DataSource = atbm;
        }
        public Lichsumahoa()
        {
            InitializeComponent();
            test_conn();
            loaddata();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }
        private void RefreshFileList()
        {
            try
            {
                // Clear the current data
                atbm.Clear();

                // Reload data from the database
                loaddata();

                MessageBox.Show("Làm mới danh sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới danh sách file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
