using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Ecommerce.Model.Entity;
using Ecommerce.Model.Repository;
using Ecommerce.Model.Context;
using Newtonsoft.Json;
using System.IO;
using Ecommerce.Helper;

namespace Ecommerce.Controller
{
    public class UsersController
    {
        private UsersRepository _userRepository;
        private GrabUser grabUser;

        public int Register(Users user)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _userRepository = new UsersRepository(context);
                result = _userRepository.Create(user);
            }

            return result;
        }

        public int Login(string phone, string password)
        {
            int result = 0;
            Users user = new Users();

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                _userRepository = new UsersRepository(context);
                user = _userRepository.LoginAttempt(phone, password);
                if(user == null)
                {
                    return result;
                }

                grabUser = new GrabUser();

                if(grabUser.Data() != null)
                {
                    return 2;
                } else
                {
                    return 0;
                }                
            }
        }

        public int Logout()
        {
            int result = 0;

            if (File.Exists(Path.Combine(Application.StartupPath, "Session.json")))
            {
                File.Delete(Path.Combine(Application.StartupPath, "Session.json"));
                result = 1;
            }

            return result;
        }
    }
}
