using System.Data.SqlClient;

namespace Auth.Services.Models
{ 
    public class SiatmaGabung_Connection
    {
        private SqlConnection koneksi;

        public SiatmaGabung_Connection()
        {
            koneksi = new SqlConnection("Data Source=172.17.0.1,1433;Initial Catalog=krs_online_dev;Persist Security Info=True;User ID=SA;Password=Danang12345");
        }

        public SqlConnection getConnection()
        {
        return koneksi;
        }

    }

 
}