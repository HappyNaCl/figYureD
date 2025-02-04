<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/admin.master" AutoEventWireup="true" CodeBehind="AdminEditProduct.aspx.cs" Inherits="figYureD.Views.Admin.AdminEditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="flex justify-center w-full h-screen py-24">
        <div class="w-4/5 py-24 flex flex-col justify-center items-center gap-6 bg-[var(--light-primary)]">
            <span class="text-black text-5xl">Edit Product</span>
            <asp:TextBox placeholder="Figurine Name" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductName" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Figurine Description" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductDescription" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Figurine Character" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductCharacter" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Figurine Series" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductSeries" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Figurine Price" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductPrice" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Figurine Quantity" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtProductQuantity" runat="server"></asp:TextBox>
            <asp:PlaceHolder ID="PHTextboxes" runat="server" />
            <asp:Button ID="BtnAddTb" OnClick="BtnAddTB_Click" Text="Add Images" runat="server" />
            <asp:Button ID="BtnUpdate" CssClass="btn glass text-white bg-[var(--secondary)] hover:bg-[var(--light-secondary)]" Text="Update" runat="server"/>
            <asp:Label ID="LblError" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
