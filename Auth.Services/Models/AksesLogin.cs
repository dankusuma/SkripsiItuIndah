using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

namespace Auth.Services.Models
{
    public class AksesLogin
    {

        private SiatmaGabung_Connection sqlConn_Gabungan = new SiatmaGabung_Connection();
        private SqlConnection sqlConn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public AksesLogin()
        {

        }

        public string choiceConnection(string username)
        {
            try
            {

                sqlConn = sqlConn_Gabungan.getConnection();


                return null;

            }
            catch (Exception e)
            {

                throw;
            }
        }


        public string choiceConnection2(string username)
        {
            try
            {

                sqlConn = sqlConn_Gabungan.getConnection();

                return null;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        //get ID_PRODI kode prodi 70 atau yg lain
        public string getKD_Prodi(string NPM)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select ID_PRODI FROM  MST_MHS_AKTIF WHERE NPM = @NPM";
                cmd.Parameters.AddWithValue("@NPM", NPM);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    return reader.GetValue(0).ToString();
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                //throw;
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //cek Koneksi by ID_PRODI
        public string choiceConnectionbyID_PRODI(string ID_PRODI)
        {
            try
            {
                if (ID_PRODI == "01" || ID_PRODI == "02" || ID_PRODI == "13")
                {
                    sqlConn = sqlConn_Gabungan.getConnection();
                }

                return null;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public string choiceConnectionFakultas(string fakultas)
        {
            try
            {
                if (fakultas.Equals("Teknik"))
                {
                    sqlConn = sqlConn_Gabungan.getConnection();

                }

                return null;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ArrayList getBatasKRS()
        {
            ArrayList _BatasWaktu = new ArrayList();
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM  TBL_TGL_KRS where getdate() between tgl_buka and tgl_tutup";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(ds, "TBL_TGL_KRS");
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    _BatasWaktu.Add(dr[0].ToString());
                    _BatasWaktu.Add(dr[1].ToString());
                    _BatasWaktu.Add(dr[2].ToString());
                    _BatasWaktu.Add(dr[3].ToString());
                }
                dr.Close();
                return _BatasWaktu;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }



        public string getDateNow()
        {
            try
            {
                string query = "select getdate()";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlCommand command = new SqlCommand(query, sqlConn);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetValue(0).ToString();
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
            }
        }

        public string getPassword(string username)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select PASSWORD from MST_MHS_AKTIF where NPM = @username";
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    return reader.GetValue(0).ToString();
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                //throw;
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool otentifikasiUserNonMahasiswa(string username, string password)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(*) from TBL_PENGGUNA where USERNAME COLLATE Latin1_General_CS_AS = @username and PASSWORD COLLATE Latin1_General_CS_AS = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (int.Parse(reader.GetValue(0).ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                //throw;
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public UserData getDataUser(string username, string fakultas)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                int num;
                if ((username.Length == 9) && int.TryParse(username, out num))
                {
                    cmd.CommandText = "select NAMA_MHS, NPM, 'MAHASISWA',ID_FAKULTAS from MST_MHS_AKTIF where NPM = @username AND (ID_PRODI = N'01' or ID_PRODI >= 50)";
                }
                else
                {

                    cmd.CommandText = "SELECT  USERNAME, NPP, KD_ROLE, ID_FAKULTAS  FROM  TBL_PENGGUNA  WHERE    USERNAME = @username";
                }
                cmd.Parameters.AddWithValue("@username", username);

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    UserData user = new UserData();
                    user.Username = reader.GetValue(0).ToString();
                    user.Id = reader.GetValue(1).ToString();
                    user.Role = reader.GetValue(2).ToString();
                    user.Fakultas = reader.GetValue(3).ToString();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                //throw;
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //insert Log Login
        public void InsertLogLogin(string idProdi, string npm, string keterangan, string ipKomputer, DateTime tglLogin)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into TBLTEMP_KRSLOGIN_LOG values (@idProdi,@npm,@keterangan,@ip,@tglLogin,@tglLogout)";
                cmd.Parameters.AddWithValue("@idProdi", idProdi);
                cmd.Parameters.AddWithValue("@npm", npm);
                cmd.Parameters.AddWithValue("@keterangan", "Remedi");
                cmd.Parameters.AddWithValue("@ip", ipKomputer);
                cmd.Parameters.AddWithValue("@tglLogin", String.Format("{0:MM/dd/yyyy H:mm:ss}", tglLogin));
                cmd.Parameters.AddWithValue("@tglLogout", String.Format("{0:MM/dd/yyyy H:mm:ss}", tglLogin));
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool UpdateLogLogin(string idProdi, string npm, DateTime tglLogin, DateTime tglLogout)
        {
            try
            {
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [TBLTEMP_KRSLOGIN_LOG] SET WktLogout = @tglLogout WHERE [ID_PRODI] = @idProdi AND  [NPM] =@npm AND [WktLogin] =@tglLogin  ";
                cmd.Parameters.AddWithValue("@idProdi", idProdi);
                cmd.Parameters.AddWithValue("@npm", npm);
                cmd.Parameters.AddWithValue("@tglLogin", String.Format("{0:MM/dd/yyyy H:mm:ss}", tglLogin));
                cmd.Parameters.AddWithValue("@tglLogout", String.Format("{0:MM/dd/yyyy H:mm:ss}", tglLogout));
                reader = cmd.ExecuteReader();
                reader.Read();
                return true;
            }
            catch (Exception e)
            {
                //throw;
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public ArrayList getBataskrs()
        {
            ArrayList _BatasWaktu = new ArrayList();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM  TBL_TGL_KRS";
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(ds, "TBL_TGL_KRS");
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    _BatasWaktu.Add(dr[0].ToString());
                    _BatasWaktu.Add(dr[1].ToString());
                    _BatasWaktu.Add(dr[2].ToString());
                    _BatasWaktu.Add(dr[3].ToString());
                }
                dr.Close();
                return _BatasWaktu;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }


    }
}