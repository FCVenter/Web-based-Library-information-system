using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Venter__FC_42468000_Assignment2.DatabaseOperations;

namespace Venter__FC_42468000_Assignment2
{
    public partial class UpdateBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if it is a PostBack, if so, return
            if (IsPostBack)
                return;

            // Set focus to first (top) control
            txtTitle.Focus();

            // Get the BookID from the query string
            int bookId = Convert.ToInt32(Session["BookID"]);

            // Retrieve the book based on the BookID
            Book existingBook = GetBookById(bookId);

            // If the book is null, return
            if (existingBook == null)
            {
                lblErrorMessage.Text = "Error fetching book: ";
                lblErrorMessage.Visible = true;
                return;
            }

            // Set the session variables for the book details
            SetBookSession(existingBook);

            // Set the book details to the input fields from the session
            SetBookFieldsFromSession();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the BookID from the query string
                int bookId = Convert.ToInt32(Session["BookID"]);

                // Create the updated book object from the session
                Book updatedBook = CreateBookFromForm(bookId);

                // Call the UpdateBook() method to update the book details
                UpdateBook(updatedBook);

                // Redirect to the BookDetail page after the update
                Response.Redirect("BookDetail.aspx?BookID=" + bookId);
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                lblErrorMessage.Visible = true;
            }
        }

        // This method sets the session variables for the book details
        private void SetBookSession(Book book)
        {
            Session["Title"] = book.Title;
            Session["Author"] = book.Author;
            Session["StartDate"] = book.StartDate.ToShortDateString();
            Session["EndDate"] = book.EndDate.ToShortDateString();
            Session["Details"] = book.Details;
        }

        // This method sets the book details to the input fields from the session
        private void SetBookFieldsFromSession()
        {
            txtTitle.Text = Session["Title"].ToString();
            txtAuthor.Text = Session["Author"].ToString();

            // So that the control displays the date properly
            if (DateTime.TryParse(Session["StartDate"].ToString(), out DateTime startDate))
            {
                txtStartDate.Text = startDate.ToString("yyyy-MM-dd");
            }

            // So that the control displays the date properly
            if (DateTime.TryParse(Session["EndDate"].ToString(), out DateTime endDate))
            {
                txtEndDate.Text = endDate.ToString("yyyy-MM-dd");
            }

            txtDetails.Text = Session["Details"].ToString();
        }


        // This method creates the updated book object from controls on the form
        private Book CreateBookFromForm(int bookId)
        {
            // Check if any of the inputs are empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
                throw new Exception("Title is required.");

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                throw new Exception("Author is required.");

            if (string.IsNullOrWhiteSpace(txtStartDate.Text))
                throw new Exception("Start date is required.");

            if (string.IsNullOrWhiteSpace(txtEndDate.Text))
                throw new Exception("End date is required.");

            if (string.IsNullOrWhiteSpace(txtDetails.Text))
                throw new Exception("Details are required.");

            // Check if the StartDate is in valid format
            if (!DateTime.TryParse(txtStartDate.Text, out DateTime startDate))
                throw new Exception("Start date is in an invalid format.");

            // Check if the EndDate is in valid format
            if (!DateTime.TryParse(txtEndDate.Text, out DateTime endDate))
                throw new Exception("End date is in an invalid format.");

            // Create and return the new Book object
            return new Book
            {
                BookID = bookId,
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Details = txtDetails.Text,
                StartDate = startDate,
                EndDate = endDate
            };
        }

        protected void btnBackToDetails_Click(object sender, EventArgs e)
        {
            string bookId = Session["BookId"].ToString();
            Response.Redirect("BookDetail.aspx?BookID=" + bookId);
        }
    }
}
