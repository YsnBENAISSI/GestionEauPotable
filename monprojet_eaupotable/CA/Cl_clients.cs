using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace monprojet_eaupotable
{
    class Cl_clients
    {
        public DataTable SelectClient()
        {
            DataAccess dal = new DataAccess();
            DataTable dt = new DataTable();
            dt = dal.Select("SP_tt_client", null);
            return dt;
        }
        
        // Ajouter des clients
        public void AjoutClien(string numcpt,string cin,string nom,string tel,string adress,byte[] img)
        {
            DataAccess da = new DataAccess();
            da.Open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@numcpt", SqlDbType.NVarChar, 50);
            param[0].Value = numcpt;
            param[1] = new SqlParameter("@cin", SqlDbType.NVarChar, 50);
            param[1].Value = cin;
            param[2] = new SqlParameter("@nomclient", SqlDbType.NVarChar, 50);
            param[2].Value = nom;
            param[3] = new SqlParameter("@telclient", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@adresseclient", SqlDbType.NVarChar, 50);
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[3].Value = tel;
            param[4].Value = adress;
            param[5].Value = img;

            da.ExecutCommand("SP_add_client", param);
            da.Close();
        }
        //Supprimer un Client
        public void SuppClient(string numcpt)
        {
            DataAccess da = new DataAccess();
            da.Open();
            SqlParameter[] param = new SqlParameter[0];
            param[0] = new SqlParameter("numCpt", SqlDbType.NVarChar, 50);
            param[0].Value = numcpt;
            da.ExecutCommand("SP_delete_client", param);
            da.Close();
        }
        //modification d'un client
        public void ModifyClient(string numcpt, string cin, string nom, string tel, string adress, byte[] img)
        {
            DataAccess da = new DataAccess();
            da.Open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@numcpt", SqlDbType.NVarChar, 50);
            param[0].Value = numcpt;
            param[1] = new SqlParameter("@cin", SqlDbType.NVarChar, 50);
            param[1].Value = cin;
            param[2] = new SqlParameter("@nomclient", SqlDbType.NVarChar, 50);
            param[2].Value = nom;
            param[3] = new SqlParameter("@telclient", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@adresseclient", SqlDbType.NVarChar, 50);
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[3].Value = tel;
            param[4].Value = adress;
            param[5].Value = img;
            da.ExecutCommand("SP_update_client", param);
            da.Close();
        }
    }
}
