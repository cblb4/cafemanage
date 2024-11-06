using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    class adminAddProductsData
    {
        public int ID { set; get; }
        public string ProductID { set; get; } 
        public string ProductName { set; get; } 
        public string Type { set; get; } 
        public string Stock { set; get; } 
        public string Price { set; get; } 
        public string Status { set; get; } 
        public string DateInsert { set; get; } 
        public string DateUpdate { set; get; } 

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False");

        public List<adminAddProductsData> productsListData()
        {
            List<adminAddProductsData> listData = new List<adminAddProductsData>();
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string selectData = "SELECT * FROM [Cafe].[dbo].[products] WHERE [date_delete] IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            adminAddProductsData apd = new adminAddProductsData();

                            apd.ID = (int)reader["id"];
                            apd.ProductID = reader["prod_id"].ToString();
                            apd.ProductName = reader["prod_name"].ToString();
                            apd.Type = reader["prod_type"].ToString();
                            apd.Stock = reader["prod_stock"].ToString();
                            apd.Price = reader["prod_price"].ToString();
                            apd.Status = reader["prod_status"].ToString();
                            apd.DateInsert = reader["date_insert"].ToString();
                            apd.DateUpdate = reader["date_update"].ToString();

                            listData.Add(apd);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed connection: " + ex);
                }
                finally
                {
                    con.Close();
                }
            }

            return listData;
        }

        public List<adminAddProductsData> availProductsData()
        {
            List<adminAddProductsData> listData = new List<adminAddProductsData>();

            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();

                    string selectData = "SELECT * FROM [Cafe].[dbo].[products] WHERE [prod_status] = @stats";

                    using (SqlCommand cmd = new SqlCommand(selectData, con))
                    {
                        cmd.Parameters.AddWithValue("@stats", "Available");
                        SqlDataReader rdr = cmd.ExecuteReader();
                        
                        while (rdr.Read())
                        {
                            adminAddProductsData apd = new adminAddProductsData();

                            apd.ID = (int)rdr["id"];
                            apd.ProductID = rdr["prod_id"].ToString();
                            apd.ProductName = rdr["prod_name"].ToString();
                            apd.Type = rdr["prod_type"].ToString();
                            apd.Stock = rdr["prod_stock"].ToString();
                            apd.Price = rdr["prod_price"].ToString();
             

                            listData.Add(apd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect: " + ex);
                }
                finally
                {
                    con.Close() ;
                }
            }
            return listData;
        }

    }
}
