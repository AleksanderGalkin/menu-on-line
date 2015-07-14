<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SLTest.Models.Options>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Удалить добавку</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
        
        <div class="display-label">OptID</div>
        <div class="display-field"><%: Model.OptID %></div>
        
        <div class="display-label">RecID</div>
        <div class="display-field"><%: Model.Recipe.RecName %></div>
        
        <div class="display-label">OptionName</div>
        <div class="display-field"><%: Model.OptionName %></div>
        
        <div class="display-label">Price</div>
        <div class="display-field"><%: String.Format("{0:F2}", Model.Price) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Recipe", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Recipe")})%>
        </p>
    <% } %>

</asp:Content>

