<%@ Page Title="figYureD | Login" Language="C#" MasterPageFile="~/Views/main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="figYureD.Views.Auth.Login" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex bg-[var(--light-primary)] w-full h-screen overflow-hidden items-center justify-center">
        <div class="h-fit gap-4 px-8 py-4 max-w-sm w-3/5 flex flex-col bg-white">
            <span class="text-[var(--light-secondary)] text-5xl text-center mb-2">Login</span>
            <asp:TextBox placeholder="Email" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtEmail" runat="server">  </asp:TextBox>
            <asp:TextBox placeholder="Password" CssClass="input input-bordered bg-[var(--secondary)] text-white placeholder:text-white focus:outline-[var(--light-secondary)] focus:bg-white focus:text-black duration-100 ease-in-out" ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <div class="form-control">
                <label class="label cursor-pointer">
                    <span class="label-text text-[var(--light-secondary)] text-lg">Remember Me?</span>
                    <asp:CheckBox ID="CbRememberMe" CssClass="checkbox checkbox-lg border-2 border-[var(--secondary)] flex items-center justify-center bg-white" runat="server" />
                </label>
            </div>
            <asp:Label CssClass="label text-red-800 text-md " ID="LblError" Text=" " runat="server" />
            <asp:Button CssClass="btn bg-[var(--secondary)] hover:bg-[var(--light-secondary)] text-white glass w-1/2 self-center mt-4" ID="BtnLogin" runat="server" Text="Login" />
            <span class="text-center text-[var(--light-secondary)]">Don't have an account? <a class="text-[var(--primary)] hover:underline" href="/register">Register Here</a></span>
        </div>
    </div>
</asp:Content>
