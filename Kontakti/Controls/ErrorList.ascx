<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorList.ascx.cs" Inherits="Controls_ErrorList" %>
<div class="ErrorMessage" style="color: #FF0000">
<asp:Repeater ID="ErrorList" runat="server">
    
	<HeaderTemplate>
		<asp:Localize ID="locHeader" runat="server" meta:resourcekey="locHeaderResource1" Text="Obavijest:"></asp:Localize><br />
		<ul class="ErrorMessage">
	</HeaderTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
	<ItemTemplate>
		<li><asp:Literal ID="Label1" runat="server" Text='<%# Eval("Message") %>'></asp:Literal></li>
	</ItemTemplate>
</asp:Repeater>
    </div>