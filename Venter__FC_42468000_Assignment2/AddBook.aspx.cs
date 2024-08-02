using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Venter__FC_42468000_Assignment2.DatabaseOperations;

namespace Venter__FC_42468000_Assignment2
{
    public partial class AddBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            // Clear the form fields on initial load
            ClearForm();

            // Set focus to first (top) control
            txtTitle.Focus();
        }

        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

        private bool ValidateInput(string title, string author, string details, string startDateString, string endDateString, out DateTime startDate, out DateTime endDate)
        {
            // Initialize startDate and endDate to default values
            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;

            // Validate the inputs
            if (string.IsNullOrEmpty(title))
            {
                ShowErrorMessage("Title is required.");
                return false;
            }
            if (string.IsNullOrEmpty(author))
            {
                ShowErrorMessage("Author is required.");
                return false;
            }
            if (string.IsNullOrEmpty(details))
            {
                ShowErrorMessage("Details are required.");
                return false;
            }

            // Parse the dates, ensuring they're in the correct format
            if (!DateTime.TryParse(startDateString, out startDate))
            {
                ShowErrorMessage("Invalid Start Date format.");
                return false;
            }
            if (!DateTime.TryParse(endDateString, out endDate))
            {
                ShowErrorMessage("Invalid End Date format.");
                return false;
            }

            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the values from the form
                string title = txtTitle.Value;
                string author = txtAuthor.Value;
                string details = txtDetails.Value;

                // Validate the inputs
                DateTime startDate, endDate;

                if (!ValidateInput(title, author, details, txtStartDate.Value, txtEndDate.Value, out startDate, out endDate))
                    return;

                // Create a new Book object with the form values
                Book newBook = new Book(title, author, details, startDate, endDate);

                // Call the InsertBook() method to add the new book
                int bookId = InsertBook(newBook);

                // Redirect to the book detail page after adding the book
                Response.Redirect("BookDetail.aspx?BookID=" + bookId);
            }
            catch (Exception ex)
            {
                // Handle the exception (Display an error message)
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                lblErrorMessage.Visible = true;
            }
        }


        private void ClearForm()
        {
            txtTitle.Value = string.Empty;
            txtAuthor.Value = string.Empty;
            txtStartDate.Value = string.Empty;
            txtEndDate.Value = string.Empty;
        }
    }
}