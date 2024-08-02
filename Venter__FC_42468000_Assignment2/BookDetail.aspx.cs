using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using static Venter__FC_42468000_Assignment2.DatabaseOperations;

namespace Venter__FC_42468000_Assignment2
{
    public partial class BookDetail : Page
    {
        // This method is called every time the page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is being loaded in response to a client postback,
            // otherwise, it's the first time the page is being loaded.
            if (IsPostBack)
                return;

            // Get book ID from the query string
            int bookId = Convert.ToInt32(Request.QueryString["BookID"]);

            // Set BookID session variable to use in update page
            Session["BookID"] = bookId;

            // Retrieve the book from the database using the provided ID
            Book book = GetBookById(bookId);

            // If the book is null (not found), stop further execution
            if (book == null)
                return;

            // Set the labels on the page to display the details of the retrieved book
            SetBookLabels(book);

            // Set the last viewed book [cookie] to current book
            setLastViewedBook(bookId);
        }

        // This method is called when the Delete Book button is clicked
        protected void btnDeleteBook_Click(object sender, EventArgs e)
        {
            // Get book ID from the query string
            int bookId = Convert.ToInt32(Request.QueryString["BookID"]);

            // Delete the book from the database using the provided ID
            DeleteBook(bookId);

            // Redirect the user back to the Dashboard page
            Response.Redirect("Dashboard.aspx");
        }

        // This private method sets the text of labels to the details of the provided book
        private void SetBookLabels(Book book)
        {
            // Set the title label to the book's title
            lblBookTitle.Text = book.Title;

            // Set the author label to the book's author
            lblBookAuthor.Text = book.Author;

            // Set the start date label to the book's start date
            lblBookStartDate.Text = book.StartDate.ToShortDateString();

            // Set the end date label to the book's end date
            lblBookEndDate.Text = book.EndDate.ToShortDateString();

            // Set the details label to the book's details
            lblBookDetails.Text = book.Details;
        }

        private void setLastViewedBook(int bookID)
        {
            HttpCookie lastviewedBook = new HttpCookie("LastViewedBook");
            lastviewedBook.Value = bookID.ToString();
            lastviewedBook.Expires = DateTime.Now.AddDays(30); // The cookie will expire in 30 days
            Response.Cookies.Add(lastviewedBook);
        }

    }
}
