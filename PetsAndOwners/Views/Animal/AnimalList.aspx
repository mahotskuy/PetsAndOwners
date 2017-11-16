<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnimalList.aspx.cs" Inherits="PetsAndOwners.Views.Animal.AnimalsList" %>

<asp:Content ID="OwnerListContainer" ContentPlaceHolderID="MainContent" runat="server">
	
		<div class="row">
			<h3 class="text-center page-header">Owners</h3>
		</div>

		<div class="row panel">
			<asp:HyperLink NavigateUrl="AnimalDetails.aspx" runat="server" CssClass="btn btn-default col-md-2">Add Animal</asp:HyperLink>
		</div>

		<div class="row">
			<table class="table table-bordered table-striped table-hover">
			<thead >
				<tr>
					<th>Anima Name</th>
					<th>Options</th>
				</tr>
			</thead>
			<asp:Repeater runat="server"
				ID="AnimalList"
				ItemType="PetsAndOwners.Models.AnimalModel">
				<ItemTemplate>
					<tr>
						<td><%# Item.Name %></td>
						<td>
							<span class="text-center">
								<asp:LinkButton CssClass="btn btn-default" runat="server" OnCommand="OnDelete" CommandArgument="<%#Item.AnimalPk%>">Delete</asp:LinkButton>
								<asp:HyperLink CssClass="btn btn-default" NavigateUrl=<%# "AnimalDetails.aspx?detailsPK=" + Item.AnimalPk %> runat="server" >Edit</asp:HyperLink>
							</span>
						</td>
					</tr>
				</ItemTemplate>
			</asp:Repeater>
			</table>
		</div>
	
</asp:Content>
