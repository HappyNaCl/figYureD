<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminProduct.aspx.cs" Inherits="figYureD.Views.Admin.AdminProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="flex flex-col p-24 w-full items-center justify-center text-black">
        <div class="w-4/5">
            <div class="flex flex-row justify-evenly items-center">
                <span class="text-5xl text-black">Products</span>
                <label for="add-modal" class="btn border-none text-white text-lg hover:bg-[var(--light-secondary)] bg-[var(--secondary)]">Add Products</label>
            </div>
            <asp:GridView CssClass="table" ID="GVProduct" runat="server" AutoGenerateColumns="False" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                    <asp:ImageField DataImageUrlField="ImageUrl" DataImageUrlFormatString="ImageUrl" HeaderText="Image"></asp:ImageField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description"></asp:BoundField>
                    <asp:BoundField DataField="Series" HeaderText="Series" SortExpression="Series"></asp:BoundField>
                    <asp:BoundField DataField="Character" HeaderText="Character" SortExpression="Character"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock"></asp:BoundField>
                    <asp:BoundField DataField="Manufacturer" HeaderText="Manufacturer" SortExpression="Manufacturer"></asp:BoundField>
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Actions" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <input type="checkbox" id="add-modal" class="modal-toggle" />
    <div class="modal" role="dialog">
        <div class="modal-box bg-[var(--light-primary)]">
            <div class="flex w-full overflow-hidden justify-center py-4">
                 <div class="h-fit gap-4 px-8 py-4 w-4/5 flex flex-col bg-white justify-center">
                    <span class="text-[var(--light-secondary)] text-5xl text-center mb-2">Add<br />Product</span>
                    <asp:TextBox placeholder="Product Name" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductName" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Product Description" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductDescription" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Product Price" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductPrice" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Product Quantity" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductQuantity" runat="server"></asp:TextBox>
                    <asp:DropDownList CssClass="bg-[var(--secondary)] p-3 rounded-box" ID="DDLManufacturer" runat="server"></asp:DropDownList>
                    <asp:Label CssClass="label text-red-800 text-md " ID="LblError" Text=" " runat="server" />
                 </div>
            </div>
            <div class="modal-action">
                <label for="add-modal" class="btn btn-error text-white">Close</label>
                <asp:Button ID="SubmitBtn" CssClass="btn border-none hover:bg-[var(--light-secondary)] bg-[var(--secondary)] text-white" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
</asp:Content>
