<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OwnerDetails.aspx.cs" Inherits="PetsAndOwners.Views.Owner.OwnerDetails" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<form>
		<h3 class="text-center page-header">Owner Details</h3>
		<asp:TextBox runat="server" ID="OwnerPK" Visible="False"></asp:TextBox>
		
		<div class="form-group form-horizontal">
			<label for="FirstName">First Name:</label>
			<asp:TextBox CssClass="form-control" runat="server" ID="FirstName"></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="LastName">Last Name:</label>
			<asp:TextBox CssClass="form-control" runat="server" ID="LastName"></asp:TextBox>
		</div>
		<asp:ValidationSummary runat="server" ShowSummary="True" DisplayMode="BulletList" CssClass="text-danger"/>
		
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="OnCancel" Text="Cancel"/>
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="AddOwner" Text="Save" Visible="<%#IsAddMode %>"/>
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="UpdateOwner" Text="Update" Visible="<%#!IsAddMode %>"/>
	</form>

</asp:Content>
