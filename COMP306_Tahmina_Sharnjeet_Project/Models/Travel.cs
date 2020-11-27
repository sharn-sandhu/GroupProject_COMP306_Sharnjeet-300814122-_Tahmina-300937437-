using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP306_Tahmina_Sharnjeet_Project
{

   


    [DynamoDBTable("Travels")]
    class Travel
    {

        public int id { get; set; }
        public string destination { get; set; }
        public int budget { get; set; }



        public override string ToString()
        {
            return base.ToString();
        }

        //public SqlConnection con;

        //public void connection()
        //{


        //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["Comp306Project"].ConnectionString);
        //    con.Open();
        //}
    }


   

}