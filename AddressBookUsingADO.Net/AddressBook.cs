using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookUsingADO.Net
{
        public class AddressBook
        {

            SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");  
            SqlCommand command;

            public bool AddContacts(AddressBookModel model)
            {
                try
                {
                    using (Connection)
                    {
                        command = new SqlCommand("SpAddContacts", Connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Action", "Insert");
                        command.Parameters.AddWithValue("@FirstName", model.FirstName);
                        command.Parameters.AddWithValue("@LastName", model.LastName);
                        command.Parameters.AddWithValue("@Address", model.Address);
                        command.Parameters.AddWithValue("@City", model.City);
                        command.Parameters.AddWithValue("@State", model.State);
                        command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                        command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                        command.Parameters.AddWithValue("@EmailId", model.EmailId);

                        Connection.Open();
                        var result = command.ExecuteNonQuery();
                        Connection.Close();

                        if (result != 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Connection.Close();
                }
                return false;
            }

            public bool EditContact(AddressBookModel model)
            {
                try
                {
                    using (Connection)
                    {
                        command = new SqlCommand("SpAddContacts", Connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Action", "Update");
                        command.Parameters.AddWithValue("@FirstName", model.FirstName);
                        command.Parameters.AddWithValue("@LastName", model.LastName);
                        command.Parameters.AddWithValue("@Address", model.Address);
                        command.Parameters.AddWithValue("@City", model.City);
                        command.Parameters.AddWithValue("@State", model.State);
                        command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                        command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                        command.Parameters.AddWithValue("@EmailId", model.EmailId);

                        Connection.Open();
                        var result = command.ExecuteNonQuery();
                        Connection.Close();

                        if (result != 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Connection.Close();
                }
                return false;
            }

            public bool DeleteContact(AddressBookModel model)
            {
                try
                {
                    command = new SqlCommand("SpAddContacts", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Action", "Delete");
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", model.EmailId);

                    Connection.Open();
                    var result = command.ExecuteNonQuery();
                    Connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Connection.Close();
                }
                return false;
            }

        public bool DisplayByCityOrState(AddressBookModel model)
        {
            try
            {
                string query = @"Select * from AddressBook where City = 'Austin'";
                SqlCommand cmd = new SqlCommand(query, Connection);
                Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        model.FirstName = dr.GetString(1);
                        model.LastName = dr.GetString(2);
                        model.Address = dr.GetString(3);
                        model.City = dr.GetString(4);
                        model.State = dr.GetString(5);
                        model.ZipCode = dr.GetString(6);
                        model.PhoneNumber = dr.GetString(7);
                        model.EmailId = dr.GetString(8);

                        Console.WriteLine($"{model.FirstName} {model.LastName}, " +
                            $"{model.Address}, {model.City}, {model.State}" +
                            $", {model.ZipCode}, {model.PhoneNumber}, {model.EmailId}");

                        Console.WriteLine("\n");

                        dr.Close();
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No data found");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }
    }
}

