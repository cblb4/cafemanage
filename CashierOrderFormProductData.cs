using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace CafeManagementSystem
{
    class CashierOrderFormProductData
    {
        public int ID { set; get; }
        public string ProductID { set; get; }
        public string ProductName { set; get; }
        public string Type { set; get; }
        public string Stock { set; get; }
        public string Price { set; get; }
        public string Status { set; get; }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MV98GJ7M;Initial Catalog=Cafe;Integrated Security=True;Encrypt=False");

        public List<CashierOrderFormProductData> availProductsData()
        {
            List<CashierOrderFormProductData> listData = new List<CashierOrderFormProductData>();

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
                            CashierOrderFormProductData apd = new CashierOrderFormProductData();

                            apd.ID = (int)rdr["id"];
                            apd.ProductID = rdr["prod_id"].ToString();
                            apd.ProductName = rdr["prod_name"].ToString();
                            apd.Type = rdr["prod_type"].ToString();
                            apd.Stock = rdr["prod_stock"].ToString();
                            apd.Price = rdr["prod_price"].ToString();
                            apd.Status = rdr["prod_status"].ToString();


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
                    con.Close();
                }
            }
            return listData;
        }
    }
}
