using BondGadgetsList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BondGadgetsList.Data
{
    internal class GadgetDAO
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BondGadget;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        // perform all operations in the database. get all, create, delete, get one, search etc.

        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            // access the database

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets";

                SqlCommand command = new SqlCommand(sqlQuery , connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        // create a single new obj. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                        returnList.Add(gadget);
                    }
                }
            }

            return returnList;

        }

        internal int Delete(int id)
        {
            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                 string   sqlQuery = "DELETE FROM  dbo.Gadgets WHERE Id = @Id";
               


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;
              

                connection.Open();
                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }

        }

        public GadgetModel FetchOne(int id)


        {
           

            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE Id = @id";
                //associate @id with the parameter Id...

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                GadgetModel gadget = new GadgetModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a single new obj. Add it to the list to return.
                       
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                       
                    }
                }
                return gadget; 
            }

           

        }

        internal List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE NAME LIKE @searchForMe";
               

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a single new obj. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                        returnList.Add(gadget);
                    }
                }
            }

            return returnList;
        }


        // create one

        public int CreateOrUpdate(GadgetModel gadgetModel)


        {
            //if gadgetmodel.id <=1 then create

            // if gadgetmodel.id > 1then update is meant.


            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (gadgetModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @Id";
                }
               
                

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;

                connection.Open();
                int newID = command.ExecuteNonQuery();
               
                return newID;
            }



        }


        // delete one


        //update one


        //search for name 


        //search for discription
        internal List<GadgetModel> SearchForDescription(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE DESCRIPTION LIKE @searchForMe";


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a single new obj. Add it to the list to return.
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                        returnList.Add(gadget);
                    }
                }
            }

            return returnList;
        }
    }
}