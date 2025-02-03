<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminEditManufacturer.aspx.cs" Inherits="figYureD.Views.Admin.AdminEditManufacturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="flex justify-center w-full h-screen py-24">
        <div class="w-4/5 py-24 flex flex-col justify-center items-center gap-6 bg-[var(--light-primary)]">
            <span class="text-black text-5xl">Edit Manufacturer</span>
            <asp:TextBox ID="TxtName" runat="server" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out w-2/5"></asp:TextBox>
            <asp:Button ID="BtnUpdate" OnClick="BtnUpdate_Click" CssClass="btn glass text-white bg-[var(--secondary)] hover:bg-[var(--light-secondary)]" Text="Update" runat="server"/>
            <asp:Label ID="LblError" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
