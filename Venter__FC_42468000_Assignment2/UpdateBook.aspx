<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="Venter__FC_42468000_Assignment2.UpdateBook" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Book Details</title>
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
        .update-form {
            width: 100%;
            max-width: 600px;
            padding: 20px;
            background-color: #1f1f1f;
            border: 1px solid #4f4f4f;
            border-radius: 5px;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-label {
            font-weight: bold;
            color: #ffffff;
            font-size: 16px;
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
        .btn-update, .btn-back {
            background-color: #27ae60;
            color: #ffffff;
            border-color: #27ae60;
            margin: 5px;
        }
        .btn-update:hover, .btn-back:hover {
            background-color: #2ecc71;
            color: #ffffff;
            border-color: #2ecc71;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="update-form">
            <h1>Update Book Details</h1>

            <div class="form-group">
                <label for="txtTitle" class="form-label">Title</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtAuthor" class="form-label">Author</label>
                <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtStartDate" class="form-label">Start Date</label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtEndDate" class="form-label">End Date</label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtDetails" class="form-label">Details</label>
                <asp:TextBox ID="txtDetails" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-update" OnClick="btnUpdate_Click" Text="Update" />
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-back" OnClick="btnBackToDetails_Click">Back to Details</asp:LinkButton>
            </div>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
