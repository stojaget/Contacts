<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kontakti._Default" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

    </script>
    <div class="well well-lg">
        <h4>
            <asp:Label ID="lblHead" runat="server" Text="PREGLED KONTAKATA" meta:resourcekey="lblHeadResource"></asp:Label>
            </h4>


    </div>
    <div class="row">

        &nbsp;&nbsp;&nbsp;&nbsp;

      <asp:Label ID="Label7" runat="server" Text="Ime:" meta:resourcekey="lblFirstNameResource1"  CssClass="label label-info"></asp:Label> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="input" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
&nbsp;&nbsp;
       <asp:Label ID="Label8" runat="server" Text="Prezime:" meta:resourcekey="lblLastNameResource1" CssClass="label label-info"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtLastName" runat="server" CssClass="input" meta:resourcekey="txtLastNameResource1"></asp:TextBox>

    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn-sm" OnClick="btnSearch_Click" Text="Traži" meta:resourcekey="btnSearchResource" ToolTip="Traženje kontakata" Height="24px" Width="66px" />

    </div>
    <div>

        <asp:Label ID="lblSize" runat="server" Text="Veličina stranice:" meta:resourcekey="lblSizeResource" CssClass="label label-info"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PageSize_Changed" meta:resourcekey="ddlPageSizeResource1">
                    <asp:ListItem Text="10" Value="10" meta:resourcekey="ListItemResource1" />
                    <asp:ListItem Text="20" Value="20" meta:resourcekey="ListItemResource2" />
                    <asp:ListItem Text="30" Value="30" meta:resourcekey="ListItemResource3" />
                </asp:DropDownList>
        <hr />
        <asp:GridView ID="gdvKontakti" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowCommand="gdvKontakti_RowCommand" OnRowDataBound="gdvKontakti_RowDataBound" meta:resourcekey="gdvKontaktiResource1">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Width="90%" />
            <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkId" runat="server" CommandName="Sort"  ForeColor="#E8EBEC"
                            CommandArgument="id" meta:resourcekey="lnkIdResource1">ID</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderId" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>' meta:resourcekey="Label1Resource1"></asp:Label>
                    </ItemTemplate>

                    <ControlStyle Font-Size="Medium" />
                    <ItemStyle Width="7%" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkFirstName" runat="server" CommandName="Sort" ForeColor="#E8EBEC"
                            CommandArgument="FirstName" meta:resourcekey="lnkFirstNameResource1">Ime</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderFirstName" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>' meta:resourcekey="Label2Resource1"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Font-Size="Medium" />
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource3">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkLastName" runat="server" CommandName="Sort" ForeColor="#E8EBEC"
                            CommandArgument="LastName" meta:resourcekey="lnkLastNameResource1">Prezime</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderLastName" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>' meta:resourcekey="Label3Resource1"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Font-Size="Medium" />
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkEmail" runat="server" CommandName="Sort" ForeColor="#E8EBEC"
                            CommandArgument="Email" meta:resourcekey="lnkEmailResource1">E-mail</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderEmail" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Email") %>' meta:resourcekey="Label4Resource1"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Font-Size="Medium" />
                    <ItemStyle Width="32%" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
                 <HeaderTemplate>
                        <asp:LinkButton ID="lnkPhone" runat="server" CommandName="Sort" ForeColor="#E8EBEC"
                            CommandArgument="Phone" meta:resourcekey="lnkPhoneResource1">Telefon</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderPhone" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Phone") %>' meta:resourcekey="Label5Resource1"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Font-Size="Medium" />
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource6">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkDateCreated" runat="server" CommandName="Sort" ForeColor="#E8EBEC"
                            CommandArgument="DateCreated" meta:resourcekey="lnkDateCreatedResource1">Datum i vrijeme kreiranja</asp:LinkButton>
                        <asp:PlaceHolder ID="placeholderDateCreated" runat="server"></asp:PlaceHolder>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DateCreated") %>' meta:resourcekey="Label6Resource1"></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Font-Size="Small" />
                    <ItemStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" CommandArgument='<%# Eval("id") %>' Text="Uredi" meta:resourcekey="lnkEditResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%# Eval("id") %>' Text="Brisanje" OnClientClick="return confirm('Zaista želite obrisati kontakt?')" meta:resourcekey="lnkDeleteResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Repeater ID="rptPager" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%# Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed" meta:resourcekey="lnkPageResource1"></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <p></p>
    <div>
        <asp:Label ID="lblTotalRows" runat="server" Font-Bold="True" Font-Size="Medium" CssClass="label label-success" meta:resourcekey="lblTotalRowsResource1"></asp:Label>
        <br />
    </div>
    <p></p>
    <p>
        <asp:Button ID="btnNew" runat="server" class="btn btn-primary btn-md" OnClick="btnNew_Click" Text="Novi kontakt" meta:resourcekey="btnNewResource1" ToolTip="Unos novog kontakta" /><br />

    </p>

    <div class="row">
    </div>


</asp:Content>
