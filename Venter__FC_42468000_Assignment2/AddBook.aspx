<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="Venter__FC_42468000_Assignment2.AddBook" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD NEW BOOK</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
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
        .container {
            max-width: 600px;
            background-color: #1f1f1f;
            padding: 20px;
            border: 1px solid #4f4f4f;
            border-radius: 5px;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-label {
            font-weight: bold;
            color: #ffffff;
        }
        .form-control {
            width: 100%;
            padding: 6px 12px;
            font-size: 16px;
            background-color: #2c2c2c;
            color: #ffffff;
            border: 1px solid #4f4f4f;
            border-radius: 4px;
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
        .error-message {
        color: #ff0000; /* Set color of text to red */
        background-color: #1f1f1f; /* Set background color to black */
        padding: 10px; /* Add some padding */
        margin-bottom: 20px; /* Add some margin */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center">BOOKEDIN - ADD NEW BOOK</h1>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" />
            <h2>Enter Book Details:</h2>
            <div class="form-group">
                <label for="txtTitle" class="form-label">Title:</label>
                <input type="text" id="txtTitle" class="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtAuthor" class="form-label">Author:</label>
                <input type="text" id="txtAuthor" class="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtStartDate" class="form-label">Start Date:</label>
                <input type="date" id="txtStartDate" class="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtEndDate" class="form-label">End Date:</label>
                <input type="date" id="txtEndDate" class="form-control" runat="server" />
                <div class="form-group">
                    <label for="txtDetails" class="form-label">Details:</label>
                        <textarea id="txtDetails" class="form-control" runat="server"></textarea>
                </div>

            </div>
            <div class="d-flex justify-content-between mt-3">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                <a href="Dashboard.aspx" class="btn btn-primary">Back to Dashboard</a>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
