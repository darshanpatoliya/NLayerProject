<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="InventoryWF_N_Layer_.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Welcome to Customer Page!!</h2>

    <br />

    <h2><span class="badge badge-info btn-lg btn-block">Enter a Customer</span></h2>
    <br />
    
    <div class="form-group row">
        <label for="customerName" class="col-sm-2 col-form-label">Customer Name</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtCustomerName" runat="server" placeholder="customerName"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="name is required" ForeColor="Red" ControlToValidate="txtCustomerName" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <label for="cityOfCustomer" class="col-sm-2 col-form-label">City</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtcityOfCustomer" runat="server" placeholder="City"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="city is required" ForeColor="Red" ControlToValidate="txtcityOfCustomer" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <label for="grade" class="col-sm-2 col-form-label">Grade</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtGrade" runat="server" placeholder="Grade"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="grade is required" ForeColor="Red" ControlToValidate="txtGrade" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="dropdown">
        <div class="form-group row">
            <label for="salesmanId" class="col-sm-2 col-form-label">Salesman Name</label>
            <div class="col-sm-10">
                <asp:DropDownList class="btn btn-secondary dropdown-toggle" ID="DropDownListOfSalesmanId" runat="server" ForeColor="Black" BackColor="White"></asp:DropDownList>
            </div>
        </div>
    </div>
      
    <div class="form-group row">
        <div class="col-sm-10">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Enter Customer" OnClick="btnSubmit_Click"></asp:Button>
        </div>
    </div>

      <h1><span class="badge badge-success btn-lg btn-block">Existing Customers</span></h1>

    <br />

    <asp:GridView ID="gvCustomer" runat="server"></asp:GridView>
</asp:Content>
