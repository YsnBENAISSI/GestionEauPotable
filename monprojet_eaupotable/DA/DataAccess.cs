using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace monprojet_eaupotable
{
    class DataAccess
    {
        SqlConnection cnx;

        //Intialisation du connection
        public void connection()
        {
            cnx = new SqlConnection(@"Server = YASSINE\SQLEXPRESS; Database = GestionEau; Integrated Security = true");
        }
        //l'ouverture du Connection
        public void Open()
        {
            if (cnx.State != ConnectionState.Open)
            {
                cnx.Open();
            }
        }

        //la fermeture du Connection
        public void Close()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
        //read
        
        public DataTable Select(string proc_stock, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc_stock;
            cmd.Connection = cnx;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //CRUD
        public void ExecutCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stored_procedure;
            cmd.Connection = cnx;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }

            cmd.ExecuteNonQuery();
        }

    }
}
