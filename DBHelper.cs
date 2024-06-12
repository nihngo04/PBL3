using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PBL3_fi
{
    internal class DBHelper
    {
        private SqlConnection _cnn;
        private static DBHelper _Instance;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper();
                }
                return _Instance;
            }
            private set { }
        }

        private DBHelper()
        {
            try
            {
                string strCon = ConfigurationManager.ConnectionStrings["GymDatabase"].ConnectionString;
                _cnn = new SqlConnection(strCon);
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing connection: " + ex.Message);
            }
        }

        public DataTable GetRecord(string query, params SqlParameter[] p)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, _cnn);
                da.SelectCommand.Parameters.AddRange(p);
                _cnn.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting records: " + ex.Message);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }
            return dt;
        }

        public void ExecuteDB(string sql, params SqlParameter[] p)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _cnn);
                cmd.Parameters.AddRange(p);
                _cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing database command: " + ex.Message);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            object result;
            try
            {
                using (SqlCommand command = new SqlCommand(query, _cnn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    _cnn.Open();
                    result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing scalar query: " + ex.Message);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                {
                    _cnn.Close();
                }
            }
            return result;
        }
        public DataTable GetSalesStatistics(string type)
        {
            string query;
            if (type == "Tháng")
            {
                query = @"
        SELECT 
            YEAR(Ngay_xuat_hoa_don) AS Nam,
            MONTH(Ngay_xuat_hoa_don) AS Thang,
            Ma_goi_tap,
            Ten_goi_tap,
            SUM(Thanh_tien) AS Tong_tien_thu_ve,
            COUNT(Ma_goi_tap) AS So_luong_goi_tap_ban
        FROM 
            hoa_don
        GROUP BY 
            YEAR(Ngay_xuat_hoa_don), 
            MONTH(Ngay_xuat_hoa_don),
            Ma_goi_tap,
            Ten_goi_tap
        ORDER BY 
            Nam, 
            Thang, 
            Ma_goi_tap";
            }
            else // Năm
            {
                query = @"
        SELECT 
            YEAR(Ngay_xuat_hoa_don) AS Nam,
            Ma_goi_tap,
            Ten_goi_tap,
            SUM(Thanh_tien) AS Tong_tien_thu_ve,
            COUNT(Ma_goi_tap) AS So_luong_goi_tap_ban
        FROM 
            hoa_don
        GROUP BY 
            YEAR(Ngay_xuat_hoa_don),
            Ma_goi_tap,
            Ten_goi_tap
        ORDER BY 
            Nam, 
            Ma_goi_tap";
            }

            return GetRecord(query);
        }

    }
}


/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_fi
{
    internal class DBHelper
    {
        private SqlConnection _cnn;
        private static DBHelper _Instance;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper();
                }
                return _Instance;
            }
            private set { }
        }
        public DBHelper()
        {
            string strCon = @"Data Source=LAPTOP-IL246S2S\SQLEXPRESS01;Initial Catalog=DEMO_GYMSYSTEM;Integrated Security=True";
            _cnn = new SqlConnection(strCon);
        }
        public DataTable GetRecord(string query, params SqlParameter[] p)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, _cnn);
            da.SelectCommand.Parameters.AddRange(p);
            _cnn.Open();
            da.Fill(dt);
            _cnn.Close();
            return dt;
        }
        public void ExecuteDB(string sql, params SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            cmd.Parameters.AddRange(p);
            _cnn.Open();
            cmd.ExecuteNonQuery();
            _cnn.Close();
        }
        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, _cnn))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                _cnn.Open();
                object result = command.ExecuteScalar();
                _cnn.Close();
                return result;
            }
        }
    }
}
*/