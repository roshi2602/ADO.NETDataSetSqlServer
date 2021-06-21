using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ADO.NETDataSetSqlServer
{
    class Program
    {
        //create database Employee and add 1 more table Team in it
        static void Main(string[] args)
        {
            try
            {
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee; select * from Team", con); ;

                    //create dataset oject
                    DataSet ds = new DataSet();

                    //filling data set
                    sda.Fill(ds);
                    //iterate through data set
                    //table 1 for Employee
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(r["id"] + "" + r["name"] + "" + r["email"]+r["join_date"]);  //to fetch data from database
                    }

                    //table 2 for Team
                    foreach (DataRow r in ds.Tables[1].Rows)
                    {
                        Console.WriteLine(r["id"] + "" + r["pname"] + "" +r["page"]+ r["pgender"]);  //to fetch data from database
                    }
                }
                Console.ReadKey();

            }
            catch (Exception er)
            {
                Console.WriteLine("not found", er);
            }
            Console.ReadKey();
        }
    }
}