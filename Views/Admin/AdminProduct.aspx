<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminProduct.aspx.cs" Inherits="figYureD.Views.Admin.AdminProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="flex flex-col p-24 w-full h-fit items-center text-black">
        <div class="flex flex-col gap-12 w-6/7">
            <div class="flex flex-row justify-evenly items-center">
                <span class="text-5xl text-black">Products</span>
                <label for="add-modal" class="btn border-none text-white text-lg hover:bg-[var(--light-secondary)] bg-[var(--secondary)]">Add Products</label>
            </div>
            <asp:GridView OnRowDeleting="GVProducts_RowDeleting" OnRowEditing="GVProducts_RowEditing" CssClass="table zebra" ID="GVProducts" runat="server" AutoGenerateColumns="False" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                    <asp:ImageField ControlStyle-CssClass="max-w-[70%]" DataImageUrlField="ImageUrl" HeaderText="Image"></asp:ImageField>
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
                 <div class="h-fit gap-4 px-8 py-4 w-4/5 flex flex-col bg-white justify-center overflow-hidden">
                    <span class="text-[var(--light-secondary)] text-5xl text-center mb-2">Add<br />Figurine</span>
                    <asp:TextBox placeholder="Figurine Name" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductName" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Description" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductDescription" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Character" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductCharacter" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Series" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductSeries" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Price" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductPrice" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Quantity" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductQuantity" runat="server"></asp:TextBox>
                    <asp:TextBox placeholder="Figurine Image" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtImageUrl" runat="server"></asp:TextBox>
                    <asp:DropDownList CssClass="bg-[var(--secondary)] p-3 rounded-box" ID="DDLManufacturer" runat="server"></asp:DropDownList>
                    <asp:Label CssClass="label text-red-800 text-md " ID="LblError" Text=" " runat="server" />
                 </div>
            </div>
            <div class="modal-action">
                <label for="add-modal" class="btn btn-error text-white">Close</label>
                <asp:Button ID="SubmitBtn" OnClick="BtnAdd_Click" CssClass="btn border-none hover:bg-[var(--light-secondary)] bg-[var(--secondary)] text-white" runat="server" Text="Add" />
            </div>
        </div>
    </div>
</asp:Content>
