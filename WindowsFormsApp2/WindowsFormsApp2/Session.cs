using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    class Session
    {
        

        public string myuser;
        public string mypassword;

       
        
        public void createAccount (string sessionUser, string sessionPassword)
        {
            myuser = sessionUser;
            mypassword = sessionPassword;
            
        }
        

        public bool LoginUser(string SessionUser,string SessionPassword)
        {
            if (SessionUser == myuser && SessionPassword == mypassword)
            {
                return true;
            }
            else return false;
        }

    }
}
