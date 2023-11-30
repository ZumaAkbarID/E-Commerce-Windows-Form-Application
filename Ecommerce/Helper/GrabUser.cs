using Ecommerce.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce.Helper
{
    public class GrabUser
    {
        private Users user;
        private string SessionPath;

        public GrabUser()
        {
            SessionPath = Path.Combine(Application.StartupPath, "Session.json");
        }

        public bool CheckSession()
        {
            return (File.Exists(SessionPath)) ? true : false;
        }

        public Users Data()
        {
            if (CheckSession())
            {
                string data = File.ReadAllText(SessionPath);
                if (!String.IsNullOrEmpty(data))
                {
                    Users user = JsonConvert.DeserializeObject<Users>(data);
                    return user;
                } else
                {
                    return user;
                }
            } else
            {
                return user;
            }
        }

        public bool WriteSession(Users user)
        {
            if(CheckSession())
            {
                DeleteSession();
            }

            string json = JsonConvert.SerializeObject(user);
            File.WriteAllText(SessionPath, json);

            return (CheckSession()) ? true : false;
        }

        public bool DeleteSession()
        {
            if (CheckSession())
            {
                File.Delete(SessionPath);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
