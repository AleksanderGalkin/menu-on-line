<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Recipe>" %>

    <h2>Добавить блюдо в ассортимент</h2>

<% using (Ajax.BeginForm("Create","Recipe", new AjaxOptions { UpdateTargetId = "aj" }))
   {%>
<%--  <% using (Html.BeginForm()) {%>--%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Описание блюда</legend>

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RecName)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.RecName)%>
                <%: Html.ValidationMessageFor(model => model.RecName)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price)%>
                <%: Html.ValidationMessageFor(model => model.Price)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Describe)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Describe)%>
                <%: Html.ValidationMessageFor(model => model.Describe)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sort) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Sort, (SelectList)ViewData["List1"], new { @class="sel_edit"})%>
                <%: Html.ValidationMessageFor(model => model.Sort) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Category) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Category, (SelectList)ViewData["List2"], new { @class="sel_edit"})%>
                <%: Html.ValidationMessageFor(model => model.Category) %>
            </div>     
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
            <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Recipe", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Recipe") })%>
    </li>
</ul>
