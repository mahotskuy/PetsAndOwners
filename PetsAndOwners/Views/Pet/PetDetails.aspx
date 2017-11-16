<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PetDetails.aspx.cs" Inherits="PetsAndOwners.Views.Pet.PetDetails" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<form>
		<h3 class="text-center page-header">Pet Details</h3>
		<asp:TextBox runat="server" ID="PetPkField" Visible="False"></asp:TextBox>
		
		<div class="form-group">
			<label for="PetName">Pet Name:</label>
			<asp:TextBox CssClass="form-control" runat="server" ID="PetName"></asp:TextBox>
		</div>
		<div class="form-group">
			<label for="PetType">Last Name:</label>
			<asp:DropDownList CssClass="form-control" runat="server" ID="PetType"/>
		</div>
		<div class="form-group">
			<label for="PetOwner">Pets Owner Name:</label>
			<asp:DropDownList CssClass="form-control" runat="server" ID="PetOwner"/>
		</div>
		
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="OnCancel" Text="Cancel"/>
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="OnSave" Text="Save" Visible="<%#IsAddMode %>"/>
		<asp:Button runat="server" CssClass="btn btn-default" OnClick="OnUpdate" Text="Update" Visible="<%#!IsAddMode %>"/>
	</form>

</asp:Content>