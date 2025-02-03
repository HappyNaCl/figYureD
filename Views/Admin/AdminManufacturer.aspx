<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminManufacturer.aspx.cs" Inherits="figYureD.Views.Admin.AdminManufacturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
     <div class="flex flex-col p-24 w-full h-screen items-center text-black">
        <div class="flex flex-col gap-12 w-4/5">
            <div class="flex flex-row justify-evenly items-center">
                <span class="text-5xl text-black">Manufacturer</span>
                <label for="add-modal" class="btn border-none text-white text-lg hover:bg-[var(--light-secondary)] bg-[var(--secondary)]">Add New Manufacturer</label>
            </div>
            <asp:GridView CssClass="table text-lg" ID="GVManufacturer" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="CreatedAt" HeaderText="Created At" SortExpression="CreatedAt"></asp:BoundField>
                </Columns>
            
            </asp:GridView>
        </div>
    </div>
    <input type="checkbox" id="add-modal" class="modal-toggle" />
    <div class="modal" role="dialog">
        <div class="modal-box bg-[var(--light-primary)]">
            <div class="flex w-full overflow-hidden justify-center py-4">
                 <div class="h-fit gap-4 px-8 py-4 w-4/5 flex flex-col bg-white justify-center">
                    <span class="text-[var(--light-secondary)] text-4xl text-center mb-2">Add<br />Manufacturer</span>
                    <asp:TextBox placeholder="Manufacturer" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtName" runat="server"></asp:TextBox>
                    <asp:Label CssClass="label text-red-800 text-md " ID="LblError" Text=" " runat="server" />
                 </div>
            </div>
            <div class="modal-action">
                <label for="add-modal" class="btn btn-error text-white">Close</label>
                <asp:Button ID="SubmitBtn" OnClick="BtnSubmit_Click" CssClass="btn border-none hover:bg-[var(--light-secondary)] bg-[var(--secondary)] text-white" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
</asp:Content>
