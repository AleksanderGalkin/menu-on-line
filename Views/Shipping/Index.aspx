<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SLTest.Models.shipTo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Оформление заказа</h2>


<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Введите параметры заказа</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.table) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.table) %>
            <%: Html.ValidationMessageFor(model => model.table) %>
        </div>

        <p>
            <input type="submit" value="Перейти к оплате" />
        </p>
    </fieldset>
<% } %>


</asp:Content>

