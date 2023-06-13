<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="InventoryWF_N_Layer_.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Welcome to Inventory Management System Orders!!</h2>
    <br />
    <h2><span class="badge badge-info btn-lg btn-block">Enter an Order</span></h2>
    <br />
    
    <div class="form-group row">
        <label for="purchaseAmount" class="col-sm-2 col-form-label">Purchase Amount</label>
        <div class="col-sm-10">
            <asp:TextBox class="form-control" ID="txtPurchaseAmount" runat="server" placeholder="Enter Purchase Amount" ValidationGroup="error"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="purchase amount is required" ForeColor="Red" ControlToValidate="txtPurchaseAmount" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group row">
        <label for="orderDate" class="col-sm-2 col-form-label">Order Date</label>
        <div class="col-sm-10">
            <asp:Calendar ID="orderDateCalendar" runat="server" ValidateRequestMode="Enabled"></asp:Calendar>
            
        </div>

    </div>
    
    <div class="dropdown">
        <div class="form-group row">
            <label for="customerId" class="col-sm-2 col-form-label">Customer Name</label>
            <div class="col-sm-2">
                <asp:DropDownList class="btn btn-secondary dropdown-toggle form-control" ID="dropDownListOfCustomers" runat="server"
                    ForeColor="Black" BackColor="White">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    
    <div class="dropdown">
        <div class="form-group row">
            <label for="salesmanId" class="col-sm-2 col-form-label">Salesman Name</label>
            <div class="col-sm-2">
                <asp:DropDownList class="btn btn-secondary dropdown-toggle form-control" ID="dropDownListOfSalesman" runat="server" 
                    ForeColor="Black" BackColor="White"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-sm-10">
            <asp:Button CssClass="btn btn-primary" ID="btnSubmit" runat="server" Text="Enter Order" OnClick="btnSubmit_Click"></asp:Button>
        </div>
    </div>

    <br />
    <br /><br />
    <h1><span class="badge badge-success btn-lg btn-block">Existing Orders</span></h1>

    
    <asp:GridView ID="GridViewOfOrders" runat="server">
       
    </asp:GridView>

      
     


    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
        <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"  
        AutoPostBack="True" DataTextField="order_no" DataValueField="order_no">  
                        <asp:ListItem Value="0">-- Select OrderNo--</asp:ListItem>  
    </asp:DropDownList>  
     
    <asp:Button ID="Button1" runat="server" BackColor="#FFFF66"
        BorderColor="#CC3300" ForeColor="#6600FF" OnClick="Button1_Click"
        Text="Click Here to show the Data" ValidationGroup="error" />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   
    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"   
    CellPadding="4" DataKeyNames="order_no" GridLines="Horizontal">  
    <Columns>  
        <asp:TemplateField HeaderText="order_no">  
            <EditItemTemplate>  
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("order_no") %>'>  
                </asp:TextBox>  
            </EditItemTemplate>  
            <ItemTemplate>  
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("order_no") %>'>  
                </asp:Label>  
            </ItemTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="purch_amt">  
            <EditItemTemplate>  
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("purch_amt") %>'>  
                </asp:TextBox>  
            </EditItemTemplate>  
            <ItemTemplate>  
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("purch_amt") %>'>  
                </asp:Label>  
            </ItemTemplate>  
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="ord_date">  
            <EditItemTemplate>  
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ord_date") %>'>  
                </asp:TextBox>  
            </EditItemTemplate>  
            <ItemTemplate>  
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ord_date") %>'>  
                </asp:Label>  
            </ItemTemplate>  

        </asp:TemplateField>  
         <asp:TemplateField HeaderText="customer_id">  
            <EditItemTemplate>  
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("customer_id") %>'>  
                </asp:TextBox>  
            </EditItemTemplate>  
            <ItemTemplate>  
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("customer_id") %>'>  
                </asp:Label>  
            </ItemTemplate>  

        </asp:TemplateField> 
         <asp:TemplateField HeaderText="salesman_id">  
            <EditItemTemplate>  
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("salesman_id") %>'>  
                </asp:TextBox>  
            </EditItemTemplate>  
            <ItemTemplate>  
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("salesman_id") %>'>  
                </asp:Label>  
            </ItemTemplate>  

        </asp:TemplateField> 

    </Columns>  
    <FooterStyle BackColor="White" ForeColor="#333333" />  
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />  
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />  
    <RowStyle BackColor="White" ForeColor="#333333" />  
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />  
    <SortedAscendingCellStyle BackColor="#F7F7F7" />  
    <SortedAscendingHeaderStyle BackColor="#487575" />  
    <SortedDescendingCellStyle BackColor="#E5E5E5" />  
    <SortedDescendingHeaderStyle BackColor="#275353" />  
    </asp:GridView> 

</asp:Content>
