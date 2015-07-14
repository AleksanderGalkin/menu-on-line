<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Sorts>" %>

    <h2>Добавить вид (подкатегорию) блюд</h2>

<% using (Ajax.BeginForm("Create", "Sorts", new AjaxOptions { UpdateTargetId = "aj" }))
   {%>
<%--  <% using (Html.BeginForm()) {%>--%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Характеристика вида</legend>

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sort)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sort)%>
                <%: Html.ValidationMessageFor(model => model.Sort)%>
            </div>
              
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
            <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                                 new { metName = "PVIndex", modName = "Sorts", pageNum = 1 },
                                 new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Sorts") })%>
    </li>
</ul>
