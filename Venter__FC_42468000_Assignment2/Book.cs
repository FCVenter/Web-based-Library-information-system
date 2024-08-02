using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Venter__FC_42468000_Assignment2
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BookID { get; set; }

        // Constructor for the Book class
        public Book(string title, string author, string details, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Author = author;
            Details = details;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Parameterless constructor (required for serialization and certain ORMs)
        public Book()
        {
        }
    }


    public static class DatabaseOperations
    {
        // Retrieves the connection string from the configuration file.
        public static string GetConnectionString()
        {
            try
            {
                // Retrieve the connection string logic
                return ConfigurationManager.ConnectionStrings["ReadingListDBConnectionString"].ConnectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception("Error retrieving connection string.", ex);
            }
        }

        public static void displaySQL(string sql, GridView gv)
        {
            try
            {
                string connectionString = GetConnectionString();

                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                gv.DataSource = dataReader;
                gv.DataBind();
                dataReader.Close();
            }
            catch (SqlException se)
            {
                throw new Exception("Error displaying sql statement in gridview: ", se);
            }
        }


        // Retrieves a book from the database based on the provided book ID.
        public static Book GetBookById(int bookId)
        {
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE BookID = @BookID", conn);
                command.Parameters.AddWithValue("@BookID", bookId);

                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                {
                    dataReader.Close();
                    conn.Close();
                    return null;
                }

                // Create a new Book object and populate its properties from the dataReader
                Book book = new Book
                {
                    Title = dataReader["Title"].ToString(),
                    Author = dataReader["Author"].ToString(),
                    StartDate = Convert.ToDateTime(dataReader["StartDate"]),
                    EndDate = Convert.ToDateTime(dataReader["EndDate"]),
                    Details = dataReader["Details"].ToString()
                };

                dataReader.Close();
                conn.Close();

                return book;
            }
            catch (SqlException se)
            {
                throw new Exception("Error getting the book by ID.", se);
            }
        }

        // Updates a book in the database with the provided book details.
        public static void UpdateBook(Book book)
        {
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, Details = @Details, StartDate = @StartDate, EndDate = @EndDate WHERE BookID = @BookID", conn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@StartDate", book.StartDate);
                command.Parameters.AddWithValue("@EndDate", book.EndDate);
                command.Parameters.AddWithValue("@BookID", book.BookID);
                command.Parameters.AddWithValue("@Details", book.Details);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception("Error updating book.", se);
            }
        }

        // Deletes a book from the database based on the provided book ID.
        public static void DeleteBook(int bookId)
        {
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand("DELETE FROM Books WHERE BookID = @BookID", conn);
                command.Parameters.AddWithValue("@BookID", bookId);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException se)
            {
                throw new Exception("Error deleting book.", se);
            }
        }

        // Inserts a new book into the database and returns the newly created book's ID.
        public static int InsertBook(Book book)
        {
            try
            {
                string connectionString = GetConnectionString();
                SqlConnection conn = new SqlConnection(connectionString);

                // Create a SQL command with parameters
                SqlCommand command = new SqlCommand("INSERT INTO Books (Title, Author, StartDate, EndDate, Details) OUTPUT INSERTED.BookID VALUES (@Title, @Author, @StartDate, @EndDate, @Details)", conn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@StartDate", book.StartDate);
                command.Parameters.AddWithValue("@EndDate", book.EndDate);
                command.Parameters.AddWithValue("@Details", book.Details);

                conn.Open();
                // Execute the command and get the new book ID
                int newBookId = (int)command.ExecuteScalar();
                conn.Close();

                return newBookId;
            }
            catch (SqlException se)
            {
                throw new Exception("Error inserting book.", se);
            }
        }

    }

}



