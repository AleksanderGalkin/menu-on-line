<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Tables>" %>

   <h2>Создать новый столик</h2>

    <% using (Ajax.BeginForm("Create", "Tables", new AjaxOptions { UpdateTargetId = "aj" }))
        {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Описание столика</legend>

            <div class="editor-label">
                
                <%: Html.LabelFor(model => model.waiterID) %>
                
            </div>
            <div class="editor-field">
             <%: Html.DropDownListFor(model => model.waiterID, (SelectList)ViewData["RecList"])%>
             <%: Html.ValidationMessageFor(model => model.waiterID)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.numTable) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.numTable)%>
                <%: Html.ValidationMessageFor(model => model.numTable)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.comment) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.comment)%>
                <%: Html.ValidationMessageFor(model => model.comment)%>
            </div>
      


            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
            <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Tables", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Tables")})%>
    </li>
</ul>