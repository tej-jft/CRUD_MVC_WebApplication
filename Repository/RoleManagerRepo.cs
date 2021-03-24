using CRUD_MVC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_MVC_WebApplication.Repository
{
    public class RoleManagerRepo
    {
        private SqlConnection con;

        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddRole(RolesModel role)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewRole", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RoleName", role.RoleName);
            com.Parameters.AddWithValue("@Controller", role.ControllerName);
            com.Parameters.AddWithValue("@CreatedBy", role.CreatedBy);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<RolesModel> GetAllRoles()
        {
            connection();
            List < RolesModel> RoleList = new List<RolesModel>();

            SqlCommand com = new SqlCommand("GetRoles", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(

                    new RolesModel
                    {
                        RoleId = Convert.ToInt32(dr["RoleID"]),
                        RoleName = Convert.ToString(dr["RoleName"]),
                        ControllerName = Convert.ToString(dr["Controller"]),
                        CreationDate = Convert.ToString(dr["CreationDate"]),
                        CreatedBy=Convert.ToString(dr["CreatedBy"]),
                        ModificationDate=Convert.ToString(dr["ModificationDate"]),
                        ModifiedBy=Convert.ToString(dr["ModifiedBy"])
                    }
                    );
            }

            return RoleList;
        }

    }
   }