<%@ Page Title="" Language="C#" MasterPageFile="~/Views/UserPage/user.master" AutoEventWireup="true" CodeBehind="UserProduct.aspx.cs" Inherits="figYureD.Views.UserPage.UserProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContent" runat="server">
    <div class="flex justify-center w-full h-fit py-24">
        <div class="w-4/5 py-24 px-12 flex flex-col items-center gap-6 bg-[var(--light-primary)]">
            <span class="text-black text-8xl mb-8 text-[var(--secondary)]">Products</span>
            <div class="flex flex-wrap gap-8 justify-center">
                <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
                    <ItemTemplate>
                        <div class="card bg-[var(--secondary)] w-80 shadow-xl my-2">
                            <figure>
                                <asp:Image CssClass="" ImageUrl='<%# Eval("ImageUrl") %>' runat="server" />
                            </figure>                
                            <div class="card-body">
                                <h2 class="card-title"><%# Eval("Name") %></h2>
                                <p class="truncate"><%# Eval("Description") %></p>
                                <p class="text-2xl font-heavy">Rp. <%# Eval("Price") %></p>
                                <div class="card-action">
                                    <asp:Button ID="BtnAddToCart" CommandName="AddItemToCart" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Add to Cart" CssClass="btn glass text-white bg-[var(--secondary)] hover:bg-[var(--light-secondary)]" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
