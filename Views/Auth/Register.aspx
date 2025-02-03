<%@ Page Title="figYureD | Register" Language="C#" MasterPageFile="~/Views/main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="figYureD.Views.Auth.Register" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex bg-[var(--light-primary)] w-full h-screen overflow-hidden items-center justify-center">
        <div class="h-fit gap-4 px-8 py-4 max-w-sm w-3/5 flex flex-col bg-white">
            <span class="text-[var(--light-secondary)] text-5xl text-center mb-2">Register</span>
            <asp:TextBox placeholder="Username" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtName" runat="server" />
            <asp:TextBox placeholder="Email" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtEmail" runat="server" />
            <asp:TextBox placeholder="Password" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtPassword" TextMode="Password" runat="server" />
            <asp:TextBox placeholder="Confirm Password" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label CssClass="label text-red-800 text-md " ID="LblError" Text=" " runat="server" />
            <asp:Button OnClick="BtnRegister_Click" CssClass="btn bg-[var(--secondary)] hover:bg-[var(--light-secondary)] text-white glass w-1/2 self-center mt-4" ID="BtnLogin" runat="server" Text="Register" />
            <span class="text-center text-[var(--light-secondary)]">Already have an account? <a class="text-[var(--primary)] hover:underline" href="/login">Login Here</a></span>
        </div>
    </div>
</asp:Content>
