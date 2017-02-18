using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
using System.Data.SqlClient;
using System.Data;

namespace MvcApplication2.DAL
{
    public class UserDAL
    {
        public LaunchDBContext db = new LaunchDBContext();
        public int Save(UserModel user)
        {
            customer custobj = new customer();
            custobj.first_name = user.first_name;
            custobj.last_name = user.last_name;
            custobj.gender = user.gender;
            custobj.email = user.email;
            custobj.contact_no = user.contact_no;
            custobj.address = user.address;
            custobj.password = user.password;
            custobj.confirmpassword = user.confirmpassword;
            custobj.occupation = user.occupation;
            custobj.user_name = user.user_name;
            db.customers.Add(custobj);




            return db.SaveChanges();
            
            



            

        }

       

        //public int Save(UserModel classObj)
        //{
        //    string dataString = "EXEC spCustomer 1,0,'"
        //        + classObj.user_name
        //        + "','" + classObj.first_name
        //        + "','" + classObj.last_name
        //        + "','" + classObj.address
        //        + "','" + classObj.contact_no
        //        + "','" + classObj.gender
        //        + "','" + classObj.occupation
        //        + "','" + classObj.password
        //        + "','" + classObj.confirmpassword
        //        + "','" + classObj.email + "'";

        //    //const string storedProcName = "spCustomer";
        //    //EXEC spCustomer 1,0,'','','','','','','','','',''

        //    int changeInRecord;
        //    try
        //    {
        //        using (SqlConnection sqlCon = new DbConnection().getConnection())
        //        {
        //            using (SqlCommand sqlCommand = new SqlCommand(dataString, sqlCon))
        //            {
        //                sqlCommand.CommandType = CommandType.Text;


        //                if (sqlCon.State != ConnectionState.Open)
        //                {
        //                    sqlCon.Open();
        //                }

        //                changeInRecord = sqlCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    };
        //    return changeInRecord;
        //}


        public UserModel SelectUser(int userID)
        {
            UserModel userModel = new UserModel();

            string dataString = "Select top 1 * from customer where ID=" + userID;

            try
            {
                using (SqlConnection sqlCon = new DbConnection().getConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(dataString, sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }

                        SqlDataReader dr = sqlCommand.ExecuteReader();
                        using (dr)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    userModel.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    userModel.user_name = dr.GetValue(1).ToString();
                                    userModel.first_name = dr.GetValue(2).ToString();
                                    userModel.last_name = dr.GetValue(3).ToString();
                                    userModel.address = dr.GetValue(4).ToString();
                                    userModel.contact_no = dr.GetValue(5).ToString();
                                    userModel.gender = dr.GetValue(6).ToString();
                                    userModel.occupation = dr.GetValue(7).ToString();
                                    userModel.password = dr.GetValue(8).ToString();
                                    userModel.confirmpassword = dr.GetValue(9).ToString();
                                    userModel.email = dr.GetValue(10).ToString();

                                }
                            }

                        }
                        return userModel;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<UserModel> SelecAlltUser()
        {

            List<UserModel> userModelList = new List<UserModel>();

            string dataString = "Select * from customer";

            try
            {
                using (SqlConnection sqlCon = new DbConnection().getConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(dataString, sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }

                        SqlDataReader dr = sqlCommand.ExecuteReader();
                        using (dr)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    UserModel userModel = new UserModel();
                                    userModel.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    userModel.user_name = dr.GetValue(1).ToString();
                                    userModel.first_name = dr.GetValue(2).ToString();
                                    userModel.last_name = dr.GetValue(3).ToString();
                                    userModel.address = dr.GetValue(4).ToString();
                                    userModel.contact_no = dr.GetValue(5).ToString();
                                    userModel.gender = dr.GetValue(6).ToString();
                                    userModel.occupation = dr.GetValue(7).ToString();
                                    userModel.password = dr.GetValue(8).ToString();
                                    userModel.confirmpassword = dr.GetValue(9).ToString();
                                    userModel.email = dr.GetValue(10).ToString();
                                    userModelList.Add(userModel);
                                }
                            }

                            ;
                        }
                        return userModelList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}