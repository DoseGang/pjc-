using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApp2
{
    [Serializable]
    class Session
    {
        static IFormatter formatter = new BinaryFormatter();
        public string myuser;
        public string mypassword;
        List<Tuple<string, string>> Users = new List<Tuple<string, string>>();
        public Session getUser()
        {
            Stream stream = new FileStream("C:\\Users\\Dose\\Desktop\\Accounts.txt", FileMode.Open, FileAccess.Read);
            Session user= new Session();
            if (stream.Length != 0)
            {
                user = (Session)formatter.Deserialize(stream);
                stream.Close();
                return user;
            }
            stream.Close();
            return user;
            
        }
        public void updateUsers(Session user)
        {
       
            Users = Users.Distinct().ToList();
            Stream stream = new FileStream("C:\\Users\\Dose\\Desktop\\Accounts.txt", FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, user);
            stream.Close();
        }
        public void getList()
        {
            int cpt = 0;
            foreach (var user in Users)
            {
                
                Console.WriteLine(cpt+") "+user.ToString());
                cpt++;

            }
            
            
        }
        public bool createAccount (string sessionUser, string sessionPassword)
        {
            myuser = sessionUser;
            mypassword = sessionPassword;
           
            foreach (var user in Users) 
            {
                if (user.Item1.ToString() == myuser)
                {
                    Console.WriteLine("not adding");
                        return false;
                }

                
            }
            Users.Add(Tuple.Create(myuser, mypassword));
            Console.WriteLine("adding");
            return true;
            
        }
        public bool LoginUser(string SessionUser,string SessionPassword)
        {
            foreach(var user in Users)
            {
                Console.WriteLine("USER IN DB"+user.ToString());
                if (user.Item1.ToString() == SessionUser && user.Item2.ToString() == SessionPassword)
                {
                    
                    return true;
                }
                
            }

            return false;
            
        }
        

    }
}
