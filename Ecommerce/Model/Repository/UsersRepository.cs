using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ecommerce.Model.Context;
using Ecommerce.Model.Entity;
using Ecommerce.Helper;

namespace Ecommerce.Model.Repository
{
    public class UsersRepository
    {
        private SqlConnection _conn;
        private GrabUser grabUser;

        public UsersRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int FindByPhone(string phone)
        {
            int result = 0;

            string sql = @"select count(*) from users where phone = @phone";
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@phone", phone);

                try
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.Print("Find By Phone error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Create(Users user)
        {
            int result = 0;

            if (FindByPhone(user.PhoneUser) > 0)
            {
                return result = 69;
            }

            string sql = @"insert into users (name, phone, address, password) values (@name, @phone, @address, @password)";
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@name", user.NameUser);
                cmd.Parameters.AddWithValue("@phone", user.PhoneUser);
                cmd.Parameters.AddWithValue("@address", user.AddressUser);
                cmd.Parameters.AddWithValue("@password", Password.BuatMD5Hash(user.PasswordUser));
                
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            
            return result;
        }

        public int Show(Users user)
        {
            int result = 0;

            string sql = @"select * from users where id = @id";
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", user.IdUser);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.Print("Show error: {0}", ex.Message);
                }
            }

            return result;
        }

        public Users LoginAttempt(string phone, string password)
        {
            Users user = new Users();

            string sql = @"select * from users where phone = @phone and password = @password";
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@password", Password.BuatMD5Hash(password));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user.IdUser = Convert.ToInt32(reader["id"]);
                        user.NameUser = reader["name"].ToString();
                        user.PhoneUser = reader["phone"].ToString();
                        user.AddressUser = reader["address"].ToString();
                        user.RoleUser = reader["role"].ToString();
                        user.PasswordUser = reader["password"].ToString();

                        grabUser = new GrabUser();
                        grabUser.WriteSession(user);
                    }
                }
            }

            return user;
        }

        public List<Users> ReadAll()
        {
            List<Users> list = new List<Users>();
            try
            {
                string sql = @"select * from users order by id";

                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    using (SqlDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Users user = new Users();
                            user.IdUser = Convert.ToInt32(dtr["id"]);
                            user.NameUser = dtr["name"].ToString();
                            user.PhoneUser = dtr["phone"].ToString();
                            user.RoleUser = dtr["role"].ToString();
                            user.AddressUser = dtr["address"].ToString();

                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }
    }
}
