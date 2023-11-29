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
        public Users Data()
        {

            string SessionPath = Path.Combine(Application.StartupPath, "Session.json");

            if (File.Exists(SessionPath))
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
    }
}
