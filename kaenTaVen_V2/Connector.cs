using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace kaenTaVen_V2
{
    class Connector
    {

        public string con = "Data Source=ANOULUCK;Initial Catalog=kaenTaVen;Integrated Security=True";
        public SqlConnection conder = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public void Connect()
        {
            conder.ConnectionString = con;
            conder.Open();
        }
        public void Close() { conder.Close(); }
    }
}
