<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PetsList.aspx.cs" Inherits="PetsAndOwners.Views.Pet.PetsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	
	<div class="row">
			<h3 class="text-center page-header">Pets List</h3>
		</div>

		<div class="row panel">
			<asp:HyperLink NavigateUrl="PetDetails.aspx" runat="server" CssClass="btn btn-default col-md-2">Add Pet</asp:HyperLink>
		</div>

		<div class="row">
			<table class="table table-bordered table-striped table-hover">
			<thead >
				<tr>
					<th>Pet Name</th>
					<th>Pet Type</th>
					<th>Pet Owner Name</th>
					<th>Options</th>
				</tr>
			</thead>
			<asp:Repeater runat="server"
				ID="TableBody"
				ItemType="PetsAndOwners.Models.PetModel">
				<ItemTemplate>
					<tr>
						<td><%# Item.PetName %></td>
						<td><%# Item.PetType %></td>
						<td><%# Item.OwnerFullName %></td>
						<td>
							<span class="text-center">
								<asp:LinkButton CssClass="btn btn-default" runat="server" OnCommand="Delete" CommandArgument="<%#Item.PetPk%>">Delete</asp:LinkButton>
								<asp:HyperLink CssClass="btn btn-default" NavigateUrl=<%# "PetDetails.aspx?petPk=" + Item.PetPk %> runat="server" >Edit</asp:HyperLink>
							</span>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
			</table>
		</div>

</asp:Content>
