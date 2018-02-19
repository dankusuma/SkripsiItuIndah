using System;


namespace Auth.Services.Models
{
    public class UserData
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        private string fakultas;

        public string Fakultas
        {
            get { return fakultas; }
            set { fakultas = value; }
        }

       
    }
}
