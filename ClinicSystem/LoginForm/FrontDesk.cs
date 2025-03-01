using System;

namespace ClinicSystem
{
    public class FrontDesk
    {
        private string username;
        private string password;
        private int id;
        
        public FrontDesk(string username, string password,int id)
        {
            this.username = username;
            this.password = password;
            this.id = id;
        }
        public int getId()
        {
            return id;
        }   

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }
    }
}
