using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DL_Clients
    {
        string dbTable = "clients";     //Example "table"

        DL_Connection dbConnection = new DL_Connection();

        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        
        //Retrieve the data of the DB to store it in a DataTable
        public DataTable Show()
        {
            try
            {
                //Get the data in the selected DB
                adapter = new MySqlDataAdapter("SELECT * FROM " + dbTable, dbConnection.DBConnection);

                dbConnection.OpenConnection();

                //Add the data to the DataTable
                DataSet ds = new DataSet();
                adapter.Fill(ds, dbTable);
                table = ds.Tables[dbTable];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return table;
        }

        //Inserts a new row in the DB with all the data provided
        public string Insert(string firstName, string lastName, string email, string phone, string idDocument)
        {
            string cmd = "INSERT INTO " + dbTable + " (firstName, lastName, email, phone, idDocument) VALUES ('"
                    + firstName + "','" + lastName + "','" + email + "','" + phone + "','" + idDocument + "')";
            
            try
            {
                dbConnection.OpenConnection();

                MySqlCommand command = new MySqlCommand(cmd, dbConnection.DBConnection);
                command.ExecuteNonQuery();

                return "Inserted succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        //Updates a row in the DB with all the data changes provided
        public string Update(string id, string firstName, string lastName, string email, string phone, string idDocument)
        {
            string cmd = "UPDATE " + dbTable + " " +
                "SET " +
                    "firstName='" + firstName + "', " +
                    "lastName='" + lastName + "', " +
                    "email='" + email + "', " +
                    "phone='" + phone + "', " +
                    "idDocument='" + idDocument + "' " +
                "WHERE id='" + id + "'";

            try
            {
                dbConnection.OpenConnection();

                MySqlCommand command = new MySqlCommand(cmd, dbConnection.DBConnection);
                command.ExecuteNonQuery();

                return "Updated succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        //Deletes a row in the DB by just providing the id
        public string Delete(string id)
        {
            string cmd = "DELETE FROM " + dbTable + " WHERE id=" + id;

            try
            {
                dbConnection.OpenConnection();

                MySqlCommand command = new MySqlCommand(cmd, dbConnection.DBConnection);
                command.ExecuteNonQuery();

                return "Deleted succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        //Search through the DB a data that matches the id
        public DataTable Search(string searchKeyword, string column)
        {
            string cmd;

            column = column.ToLower();

            if (column == "id document")
            {
                column = "idDocument";
                cmd = "SELECT * FROM " + dbTable + " WHERE " + column + "='" + searchKeyword + "'";
            }
            else if (column == "full name")
            {
                cmd = "SELECT * FROM " + dbTable + " WHERE CONCAT(firstName, ' ', lastName) LIKE '%" + searchKeyword + "%'";
            }
            else
            {
                cmd = "SELECT * FROM " + dbTable + " WHERE " + column + "='" + searchKeyword + "'";
            }

            try
            {
                //Get the data in the selected DB
                adapter = new MySqlDataAdapter(cmd, dbConnection.DBConnection);

                dbConnection.OpenConnection();

                //Add the data to the DataTable
                DataSet ds = new DataSet();
                adapter.Fill(ds, dbTable);
                table = ds.Tables[dbTable];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return table;
        }
    }
}
