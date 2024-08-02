using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Venter__FC_42468000_Assignment2.DatabaseOperations;

namespace Venter__FC_42468000_Assignment2
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            LoadBooks(); // Fill GridView with all books in database

            loadLastViewedBook(); // If cookie exists of a previously viewed book, display book's details
        }

        private void LoadBooks()
        {
            displaySQL("SELECT * FROM Books ORDER BY StartDate ASC", BookListGrid);
        }

        protected void ReadingCalendar_SelectionChanged(object sender, EventArgs e)
        {
            string selectedDate = ReadingCalendar.SelectedDate.ToShortDateString();
            displaySQL($"SELECT * FROM Books WHERE StartDate < '{selectedDate}' OR EndDate < '{selectedDate}'", BookListGrid);
        }

        private void loadLastViewedBook()
        {
            if (Request.Cookies["LastViewedBook"] == null) // User has not viewed a book in last 30 days, so stay in dashboard
                return;

            // Check if the Session variable is null, which means this is the user's first visit
            // If it is null, return. (This means they have an active session on the site)
            if (Session["IsFirstVisit"] != null)
                return;

            Session["IsFirstVisit"] = false; // Set the Session variable to indicate that the user has visited the site

            int bookId = Convert.ToInt32(Request.Cookies["LastViewedBook"].Value);

            // Go to last viewed book's Details
            Response.Redirect("BookDetail.aspx?BookID=" + bookId);

        }

    }
}
