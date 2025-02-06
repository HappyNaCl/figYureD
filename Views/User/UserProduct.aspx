<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User/user.master" AutoEventWireup="true" CodeBehind="UserProduct.aspx.cs" Inherits="figYureD.Views.User.UserProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContent" runat="server">
    <div class="flex justify-center w-full h-fit py-24">
        <div class="w-4/5 py-24 flex flex-col items-center gap-6 bg-[var(--light-primary)]">
            <span class="text-black text-5xl">Products</span>
            <div class="flex flex-wrap gap-4 justify-center">
                <asp:Repeater ID="RepeaterProducts" runat="server">
                    <ItemTemplate>
                        <div class="card bg-[var(--secondary)] w-80 shadow-xl">
                            <figure>
                                <asp:Image CssClass="" ImageUrl='<%# Eval("ImageUrl") %>' runat="server" />
                            </figure>                
                            <div class="card-body">
                                <h2 class="card-title"><%# Eval("Name") %></h2>
                                <p class="truncate"><%# Eval("Description") %></p>
                                <p class="text-2xl font-heavy">Rp. <%# Eval("Price") %></p>
                                <div class="card-action">
                                    <asp:Button ID="BtnAddToCart" runat="server" Text="Add to Cart" CssClass="btn glass text-white bg-[var(--secondary)] hover:bg-[var(--light-secondary)]" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
