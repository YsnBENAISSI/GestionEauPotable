using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace monprojet_eaupotable.DA
{
    class Cl_login
    {
        public DataTable login(string id,string pw)
        {
            DataAccess da = new DataAccess();
            da.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@pw", SqlDbType.NVarChar, 50);
            param[0].Value = id;
            param[1].Value = pw;
            DataTable dt = new DataTable();
            dt = da.Select("SP_cnx", param);
            da.Close();

            
            return dt;
        }
    }
}
