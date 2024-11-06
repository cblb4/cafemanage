using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CafeManagementSystem
{
    class AdminAddUsersdata
    {
        connection kon = new connection();
        SqlConnection con;

        public AdminAddUsersdata()
        {
            con = kon.getConnect();
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string DataRegistered { get; set; }

        public List<AdminAddUsersdata> usersListData()
        {
            List<AdminAddUsersdata> ldata = new List<AdminAddUsersdata>();

            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    string selData = "SELECT * FROM [Cafe].[dbo].[cafe]";

                    using (SqlCommand cmd = new SqlCommand(selData, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            AdminAddUsersdata data = new AdminAddUsersdata
                            {
                                ID = (int)dr["id"],
                                Username = dr["Username"].ToString(),
                                Password = dr["Password"].ToString(),
                                Role = dr["role"].ToString(),
                                Status = dr["status"].ToString(),
                                DataRegistered = dr["date_reg"].ToString()
                            };

                            ldata.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection Failed: " + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return ldata;
        }
    }
}
