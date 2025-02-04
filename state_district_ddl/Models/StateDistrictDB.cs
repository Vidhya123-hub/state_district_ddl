using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace state_district_ddl.Models
{
    public class StateDistrictDB
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString;
        SqlConnection con;
        public StateDistrictDB()
        {
            con = new SqlConnection(connectionstring);
        }
        public List<stclass> Selectstates()
        {
            var getdata = new List<stclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_state", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var a = new stclass
                    {
                        sId = Convert.ToInt32(dr["StateId"]),
                        sName = dr["StateName"].ToString()
                    };
                    getdata.Add(a);
                }
                con.Close();
                return getdata;
            }
            catch(Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            } 
        }
        public List<Dclass> selectdistricts(int stateid)
        {
            var getdata = new List<Dclass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_district", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stid", stateid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var a = new Dclass
                    {
                        DId = Convert.ToInt32(dr["Did"]),
                        DName = dr["DName"].ToString()
                    };
                    getdata.Add(a);
                }
                con.Close();
                return getdata;
            }
            catch(Exception ex)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
  
}