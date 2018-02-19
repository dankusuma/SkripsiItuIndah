using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;



namespace Auth.Services.Models
{
    public class LoginManager
    {
        public AksesLogin login;
        private UserData user;

        public LoginManager()
        {
            login = new AksesLogin();
        }

        public bool Otentifikasi(string username, string password)
        {
            try
            {
                int num;
                if ((username.Length == 9) && int.TryParse(username, out num))
                {
                    
                    login.choiceConnection2(username);
                    string dbpass = login.getPassword(username);
                    return (cekPassword(password, dbpass));
                }
                else
                {
                    return false;
                }
                
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        

        private bool cekPassword(string password, string passwordDatabase)
        {
            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);
            if (str == passwordDatabase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


       
      
    }

   
}
