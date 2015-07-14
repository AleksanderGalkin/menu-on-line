<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Categories>" %>

    <h2>Добавить категорию блюд</h2>

<% using (Ajax.BeginForm("Create", "Categories", new AjaxOptions { UpdateTargetId = "aj" }))
   {%>
<%--  <% using (Html.BeginForm()) {%>--%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Характеристика</legend>

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Category)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Category)%>
                <%: Html.ValidationMessageFor(model => model.Category)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Arrange)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Arrange)%>
                <%: Html.ValidationMessageFor(model => model.Arrange)%>
            </div>
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>

         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Categories", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Categories") })%>
    </li>
</ul>
