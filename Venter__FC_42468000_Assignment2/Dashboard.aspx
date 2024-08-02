<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Venter__FC_42468000_Assignment2.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <style>
        body {
            background-color: #121212;
            padding: 20px;
            color: #ffffff;
        }
        h1 {
            color: #ffffff;
        }
        h2.text-success {
            color: #27ae60;
            margin-top: 20px;
        }
        .container {
            max-width: 800px;
            background-color: #1f1f1f;
            padding: 20px;
            border: 1px solid #4f4f4f;
            border-radius: 5px;
        }
        .mb-4 {
            margin-bottom: 20px;
        }
        .table {
            color: #ffffff;
        }
        .table th,
        .table td {
            border-color: #4f4f4f;
        }
        .btn-primary {
            background-color: #27ae60;
            color: #ffffff;
            border-color: #27ae60;
        }
        .btn-primary:hover {
            background-color: #2ecc71;
            color: #ffffff;
            border-color: #2ecc71;
        }
        a.gridview-link {
            color: #008000; /* green color for gridview link */
        }
        a.gridview-link:hover {
            color: #32CD32; /* lighter green on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center">BOOKEDIN - DASHBOARD</h1>
            <h2 class="text-success">Reading Calendar</h2>
            <asp:Calendar ID="ReadingCalendar" runat="server" CssClass="mb-4" SelectionMode="DayWeekMonth" BackColor="White" TitleStyle-ForeColor="#000000" NextPrevStyle-ForeColor="#000000" DayStyle-ForeColor="#000000" OtherMonthDayStyle-ForeColor="#000000" SelectedDayStyle-ForeColor="#000000" TodayDayStyle-ForeColor="#000000" DayHeaderStyle-ForeColor="#000000" OnSelectionChanged="ReadingCalendar_SelectionChanged" />
            <h2 class="text-success">Reading List:</h2>
            <asp:GridView ID="BookListGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <%# Eval("StartDate", "{0:d}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date">
                        <ItemTemplate>
                            <%# Eval("EndDate", "{0:d}") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Details">
                        <ItemTemplate>
                            <asp:HyperLink NavigateUrl='<%# String.Format("BookDetail.aspx?BookID={0}", Eval("BookID")) %>' Text="Details" CssClass="gridview-link" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <a href="AddBook.aspx" class="btn btn-primary">Add a new book</a>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
