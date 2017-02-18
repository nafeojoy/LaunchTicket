using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
using System.Data.SqlClient;
using System.Data;


namespace MvcApplication2.DAL
{
    public class TrainDetailsDAL
    {

        public int Save(TrainDetailsModel classObj)
        {
            string dataString = "EXEC spTrainDetails 1,0,'"
                + "','" + classObj.trainName
                + "','" + classObj.departureTime
                + "','" + classObj.departurePlace
                + "','" + classObj.destinationPlace
                + "','" + classObj.noOfBogie
                + "','" + classObj.fare + "'";

            //const string storedProcName = "spCustomer";
            //EXEC spCustomer 1,0,'','','','','','','','','',''

            int changeInRecord;
            try
            {
                using (SqlConnection sqlCon = new DbConnection().getConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(dataString, sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        #region DUMMY
                        /*
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@ExeType", SqlDbType.Int).Value = 1;
                        sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = classObj.ID;
                        sqlCommand.Parameters.Add("@user_name", SqlDbType.NVarChar).Value = classObj.user_name;
                        sqlCommand.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = classObj.first_name;
                        sqlCommand.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = classObj.last_name;
                        sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar).Value = classObj.address;
                        sqlCommand.Parameters.Add("@contact_no", SqlDbType.NVarChar).Value = classObj.contact_no;
                        sqlCommand.Parameters.Add("@gender", SqlDbType.NVarChar).Value = classObj.gender;
                        sqlCommand.Parameters.Add("@occupation", SqlDbType.NVarChar).Value = classObj.occupation;
                        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = classObj.password;
                        sqlCommand.Parameters.Add("@confirmpassword", SqlDbType.NVarChar).Value = classObj.confirmpassword;
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = classObj.email;
                        */
                        #endregion

                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }

                        changeInRecord = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return changeInRecord;
        }


        public TrainDetailsModel SelectTrain(int trainID)
        {
            TrainDetailsModel traindetailModel = new TrainDetailsModel();

            string dataString = "Select top 1 * from TrainDetails where ID=" + trainID;

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
                                    traindetailModel.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    traindetailModel.trainName = dr.GetValue(1).ToString();
                                    traindetailModel.departureTime = Convert.ToDateTime(dr.GetValue(2).ToString());
                                    traindetailModel.departurePlace = dr.GetValue(3).ToString();
                                    traindetailModel.destinationPlace = dr.GetValue(4).ToString();
                                    traindetailModel.noOfBogie = Convert.ToInt16(dr.GetValue(5).ToString());
                                    traindetailModel.fare = Convert.ToInt16(dr.GetValue(6).ToString());

                                }
                            }

                        }
                        return traindetailModel;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<TrainDetailsModel> SelecAllTrains()
        {

            List<TrainDetailsModel> traindetailsModelList = new List<TrainDetailsModel>();

            string dataString = "Select ID,trainName, CONVERT(varchar(15),CAST(departureTime AS TIME),100) as [departureTime],departurePlace,destinationPlace,noOfBogie,fare from TrainDetails";

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
                                    TrainDetailsModel trainDetailModel = new TrainDetailsModel();
                                    trainDetailModel.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    trainDetailModel.trainName = dr.GetValue(1).ToString();
                                    trainDetailModel.depertureTimeString = Convert.ToDateTime(dr.GetValue(2).ToString()).ToShortTimeString();
                                    trainDetailModel.departureTime = Convert.ToDateTime(dr.GetValue(2).ToString());
                                    trainDetailModel.departurePlace = dr.GetValue(3).ToString();
                                    trainDetailModel.destinationPlace = dr.GetValue(4).ToString();
                                    trainDetailModel.noOfBogie = Convert.ToInt16(dr.GetValue(5).ToString());
                                     trainDetailModel.fare = Convert.ToInt16(dr.GetValue(6).ToString());
                                    traindetailsModelList.Add(trainDetailModel);
                                }
                            }

                        }
                        return traindetailsModelList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<BogieModel> SelecBogieByTrainID(int trainID)
        {

            List<BogieModel> bogieList = new List<BogieModel>();

            string dataString = "Select * from BogieDetails Where trainID=" + trainID;

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
                                    BogieModel bogie = new BogieModel();
                                    bogie.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    bogie.bogieTitle = dr.GetValue(1).ToString();
                                    bogie.noOfSeats = Convert.ToInt16(dr.GetValue(2).ToString());
                                    bogie.trainID = Convert.ToInt16(dr.GetValue(3).ToString());
                                    //trainDetailModel.departurePlace = dr.GetValue(3).ToString();
                                    //trainDetailModel.destinationPlace = dr.GetValue(4).ToString();
                                    //trainDetailModel.noOfBogie = Convert.ToInt16(dr.GetValue(5).ToString());
                                    bogieList.Add(bogie);
                                }
                            }

                        }
                        return bogieList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<SeatModel> SelectSeatByBogieID(int bogieID)
        {

            List<SeatModel> seatList = new List<SeatModel>();

            string dataString = "Select * from SeatDetails Where bogieID=" + bogieID;

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
                                    SeatModel seat = new SeatModel();
                                    seat.ID = Convert.ToInt16(dr.GetValue(0).ToString());
                                    seat.SeatNumber = dr.GetValue(1).ToString();
                                    seat.IsAvailable = Convert.ToBoolean(dr.GetValue(2).ToString());
                                    seat.BogieID = Convert.ToInt16(dr.GetValue(3).ToString());
                                    //trainDetailModel.departurePlace = dr.GetValue(3).ToString();
                                    //trainDetailModel.destinationPlace = dr.GetValue(4).ToString();
                                    //trainDetailModel.noOfBogie = Convert.ToInt16(dr.GetValue(5).ToString());
                                    seatList.Add(seat);
                                }
                            }

                        }
                        return seatList;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public int UpdateSeat(SeatModel classObj)
        {
            string dataString = "EXEC spSeatDetails 2," + "" + classObj.ID + ",'" + classObj.SeatNumber
                + "','" + classObj.IsAvailable
                + "','" + classObj.BogieID + "'";

            //EXEC spSeatDetails 2,1,'SHISHIR',1,1

            int changeInRecord;
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

                        changeInRecord = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return changeInRecord;
        }
    }
}