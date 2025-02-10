<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminTransaction.aspx.cs" Inherits="figYureD.Views.Admin.AdminTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
<div class="flex flex-col p-24 w-full h-fit items-center text-black">
    <div class="flex flex-col gap-12 w-4/5">
        <div class="flex flex-row justify-evenly items-center">
            <span class="text-5xl text-black">Transaction History</span>
            <asp:Label CssClass="text-5xl text-black" ID="lblTotal" Text="" runat="server" />
        </div>
        
        <asp:Repeater ID="rptHeader" runat="server">
            <ItemTemplate>
                <div class="collapse collapse-arrow">
                <input type="radio" name="my-accordion" checked="checked" />
                <div class="collapse-title text-xl font-medium">
                    <%# Eval("CustomerName") %>
                    <%# Eval("CreatedAt") %>
                    <p class="ml-auto">Rp. <%# Eval("Total") %></p>
                </div>
                <div class="collapse-content">
                    <asp:GridView CssClass="table table-lg" runat="server" DataSource='<%# Eval("Details") %>' AutoGenerateColumns="false">
                        <Columns>
                            <asp:ImageField HeaderText="Image" DataImageUrlField="ImageUrl" ItemStyle-CssClass="flex justify-center" ControlStyle-CssClass="w-[40%]"/>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    Rp. <%# Eval("Price") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
