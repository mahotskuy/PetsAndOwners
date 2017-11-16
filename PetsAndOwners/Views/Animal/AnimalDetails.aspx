<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnimalDetails.aspx.cs" Inherits="PetsAndOwners.Views.Animal.AnimalDetails"  EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<form>
		<h3 class="text-center page-header">Owner Details</h3>
		<asp:TextBox runat="server" ID="ItemPK" Visible="False"></asp:TextBox>
		
		<div class="form-group form-horizontal">
			<label for="Name">Animal Name:</label>
			<asp:TextBox CssClass="form-control" runat="server" ID="Name"></asp:TextBox>
		</div>
		
		<asp:Button UseSubmitBehavior="False" runat="server" CssClass="btn btn-default" OnClick="OnCancel" Text="Cancel"/>
		<asp:Button UseSubmitBehavior="<%# IsAddMode %>" runat="server" CssClass="btn btn-default" OnClick="OnSave" Text="Save" Visible="<%#IsAddMode %>"/>
		<asp:Button UseSubmitBehavior="<%# !IsAddMode %>" runat="server" CssClass="btn btn-default" OnClick="OnUpdate" Text="Update" Visible="<%#!IsAddMode %>"/>
	</form>

</asp:Content>
