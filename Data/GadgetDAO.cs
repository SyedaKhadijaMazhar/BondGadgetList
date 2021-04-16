﻿using BondGadgetsList.Models;
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

        public GadgetModel FetchOne(int id)
        {
           

            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Gadgets WHERE Id = @id";
                //associate @id with the parameter Id

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

    }
}