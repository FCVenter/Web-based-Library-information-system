<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="Venter__FC_42468000_Assignment2.BookDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Detail</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <style>
        body {
            background-color: #121212;
            padding: 20px;
            color: #ffffff;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        h1, h2, h3, h4, h5, h6 {
            font-weight: bold;
            color: #ffffff;
        }
        .book-detail {
            width: 100%;
            max-width: 800px;
            padding: 20px;
            background-color: #1f1f1f;
            border: 1px solid #4f4f4f;
            border-radius: 5px;
            text-align: center;
        }
        .book-detail-title {
            font-size: 32px;
            margin-bottom: 20px;
        }
        .book-detail-info {
            font-size: 24px;
            margin-bottom: 10px;
        }
        .action-links {
            margin-top: 20px;
            display: flex;
            justify-content: center;
        }
        .btn {
            background-color: #2ecc71;
            color: #ffffff;
            border-color: #2ecc71;
            margin: 0 10px;
        }
        .btn:hover {
            background-color: #27ae60;
            color: #ffffff;
            border-color: #27ae60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="book-detail">
            <h1 class="book-detail-title">BOOKEDIN - BOOK DETAILS</h1>
            <div class="book-detail-info">
                <div>Book Title: <asp:Label ID="lblBookTitle" runat="server" Text="Book 1"></asp:Label></div>
                <div>Author: <asp:Label ID="lblBookAuthor" runat="server" Text="Author 1"></asp:Label></div>
                <div>Start Date: <asp:Label ID="lblBookStartDate" runat="server" Text="12/01/2023"></asp:Label></div>
                <div>End Date: <asp:Label ID="lblBookEndDate" runat="server" Text="01/30/2023"></asp:Label></div>
                <div>Details: <asp:Label ID="lblBookDetails" runat="server" Text=""></asp:Label></div>
            </div>


            <div class="action-links">
                <a href="UpdateBook.aspx" class="btn btn-warning btn-lg">Update Book Details</a>
                <asp:Button ID="btnDeleteBook" runat="server" Text="Delete Book" CssClass="btn btn-danger btn-lg" OnClick="btnDeleteBook_Click" />
                <a href="Dashboard.aspx" class="btn btn-primary btn-lg">Back to Dashboard</a>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
