<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OwnersList.aspx.cs" Inherits="PetsAndOwners.Views.Owner.OwnersList" %>

<asp:Content ID="OwnerListContainer" ContentPlaceHolderID="MainContent" runat="server">
	
		<div class="row">
			<h3 class="text-center page-header">Owners</h3>
		</div>

		<div class="row panel">
			<asp:HyperLink NavigateUrl="OwnerDetails.aspx" runat="server" CssClass="btn btn-default col-md-2">Add Owner</asp:HyperLink>
		</div>

		<div class="row">
			<table class="table table-bordered table-striped table-hover">
			<thead >
				<tr>
					<th>Owner Name</th>
					<th>Count Of Pets</th>
					<th>Options</th>
				</tr>
			</thead>
			<asp:Repeater runat="server"
				ID="TableBody"
				ItemType="PetsAndOwners.Models.OwnerModel">
				<ItemTemplate>
					<tr>
						<td><%# Item.FirstName %></td>
						<td><%# Item.LastName %></td>
						<td>
							<span class="text-center">
								<asp:LinkButton CssClass="btn btn-default" runat="server" OnCommand="DeleteOwner" CommandArgument="<%#Item.OwnerPk%>">Delete</asp:LinkButton>
								<asp:HyperLink CssClass="btn btn-default" NavigateUrl=<%# "OwnerDetails.aspx?ownerPK=" + Item.OwnerPk %> runat="server" >Edit</asp:HyperLink>
							</span>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
			</table>
		</div>
	
</asp:Content>
