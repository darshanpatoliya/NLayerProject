<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Salesman.aspx.cs" Inherits="InventoryWF_N_Layer_.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Welcome to Salesman Page!!</h2>

    <br />

    <h2><span class="badge badge-info btn-lg btn-block">Enter a New Salesman</span></h2>
    <br />
    <div class="form-group row">
        <label for="salesmanName" class="col-sm-2 col-form-label">Salesman Name</label>
        <div class="col-sm-10">
            
            <asp:TextBox class="form-control" ID="txtSalesmanName" runat="server" placeholder="salesmanName"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="name is required" ForeColor="Red" ID="txtSalesmanName01" ControlToValidate="txtSalesmanName" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <label for="city" class="col-sm-2 col-form-label">City</label>
        <div class="col-sm-10">
            
            <asp:TextBox class="form-control" ID="txtCity" runat="server" placeholder="city"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="city is requried" ForeColor="Red" ControlToValidate="txtCity" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <label for="commission" class="col-sm-2 col-form-label">Commission</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtCommission" runat="server" placeholder="Commission"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="commission is required" ControlToValidate="txtCommission" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-10">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Enter Salesman" OnClick="btnSubmit_Click"></asp:Button>
        </div>
    </div>

      <h1><span class="badge badge-success btn-lg btn-block">Existing Salesman</span></h1>

    <br />

    <asp:GridView ID="gvSalesman" runat="server"></asp:GridView>
</asp:Content>
