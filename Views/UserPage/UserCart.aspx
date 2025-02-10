<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserPage/user.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="figYureD.Views.UserPage.UserCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContent" runat="server">
  <div class="flex flex-col p-24 w-full h-fit items-center text-black">
    <div class="flex flex-col gap-12 w-4/5">
        <div class="flex flex-row justify-evenly items-center">
            <span class="text-5xl text-black">Cart</span>
        </div>
        <asp:GridView ID="GvCart" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hfProductId" runat="server" Value='<%# Bind("Id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField HeaderText="Image" ControlStyle-CssClass="w-[60%]" DataImageUrlField="ImageUrl" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" CssClass="bg-white input input-bordered" runat="server" TextMode="Number" Text='<%# Bind("Quantity") %>' OnTextChanged="TxtQuantity_Changed" AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-CssClass="flex justify-center items-center" HeaderText="Checkout">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbCheckout" CommandName="" runat="server" CssClass="checkbox checkbox-lg" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button Text="Checkout" OnClick="BtnCheckout_Click" CssClass="btn bg-[var(--secondary)] hover:bg-[var(--light-secondary)] text-white glass w-1/2 self-center mt-4" runat="server" />
    </div>
</div>
</asp:Content>
