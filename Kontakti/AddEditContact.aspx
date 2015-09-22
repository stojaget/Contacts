<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Culture="auto" AutoEventWireup="true" CodeBehind="AddEditContact.aspx.cs" Inherits="Kontakti.AddEditContact" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="Controls/ErrorList.ascx" TagName="ErrorList" TagPrefix="err" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p></p>

    <table class="table table-striped table-bordered table-condensed">
        <tr>
            <td class="LabelCell" style="width: 174px">
                <asp:Localize ID="locFirstName" runat="server" meta:resourcekey="locFirstName" Text="Ime"></asp:Localize>
            </td>
            <td>

                <asp:TextBox ID="txtFirstName" runat="server" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>

                <asp:RequiredFieldValidator ID="valRequiredFirstName" ForeColor="Red" ControlToValidate="txtFirstName" ErrorMessage="Ime je obavezno polje" runat="server" meta:resourcekey="valRequiredFirstNameResource1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="width: 174px">
                <asp:Localize ID="locLastName" runat="server" meta:resourcekey="locLastName" Text="Prezime"></asp:Localize>
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequiredLastName" ForeColor="Red" ControlToValidate="txtLastName" ErrorMessage="Prezime je obavezno polje" runat="server" meta:resourcekey="valRequiredLastNameResource1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="width: 174px">
                <asp:Localize ID="locPhone" runat="server" meta:resourcekey="locPhone" Text="Telefon"></asp:Localize>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" meta:resourcekey="txtPhoneResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequiredPhone" ForeColor="Red" ControlToValidate="txtPhone" ErrorMessage="Telefon je obavezno polje" runat="server" meta:resourcekey="valRequiredPhoneResource1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="width: 174px">
                <asp:Localize ID="locEmail" runat="server" meta:resourcekey="locEmail" Text="Email"></asp:Localize>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                <asp:RegularExpressionValidator ID="valCorrectEmail" ForeColor="Red" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Format e-maila nije ispravan." meta:resourcekey="valCorrectEmailResource1" SetFocusOnError="True">*</asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="width: 174px">
                <asp:Localize ID="locDateCreated" runat="server" meta:resourcekey="locDateCreated" Text="Datum i vrijeme kreiranja"></asp:Localize>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" meta:resourcekey="txtDateResource1" ReadOnly="True"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 174px">

                <asp:TextBox ID="txtSifra" runat="server" meta:resourcekey="txtDateResource1" ReadOnly="True" Visible="False"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="LabelCell" style="width: 174px"></td>
            <td>
                <asp:Button class="btn btn-primary btn-sm" ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Spremi" meta:resourcekey="btnSaveResource1" Height="25px" Width="92px" />
                &nbsp;&nbsp;&nbsp;<asp:Button class="btn btn-primary btn-sm" ID="btnCancel" runat="server" Text="Odustani" CausesValidation="False" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1" Height="25px" />
                &nbsp;&nbsp;
					<asp:Button class="btn btn-primary btn-sm" ID="btnDelete" runat="server" Text="Obriši" OnClientClick="return confirm('Zaista želite obrisati kontakt?')"
                        CausesValidation="False" OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1" Height="25px" Width="92px" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <div class="well">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Molimo ispravite sljedeće greške:" ForeColor="Red" meta:resourcekey="ValidationSummary1Resource1" />
    </div>
    <err:ErrorList ID="ErrorList1" runat="server" />
    <asp:PlaceHolder ID="plcErrors" runat="server" Visible="False">


        <div class="ErrorMessage">

            <br />
        </div>
    </asp:PlaceHolder>

</asp:Content>
