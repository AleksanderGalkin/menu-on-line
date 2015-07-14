<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Tables>" %>

  <% using (Ajax.BeginForm("Edit","Tables", new{id=Model.ID, pageNum = ViewBag.pageNum},new AjaxOptions { UpdateTargetId = "aj",HttpMethod="Post" })) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Характеристики</legend>
            
           
            <div class="editor-label">
                <%: Html.LabelFor(model => model.waiterID) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.waiterID, (SelectList)ViewData["RecList"], new { @class = "sel_edit" })%>
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
                <%: Html.TextBoxFor(model => model.comment) %>
                <%: Html.ValidationMessageFor(model => model.comment) %>
            </div>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Tables", pageNum = ViewBag.pageNum },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Tables", new { pageNum = ViewBag.pageNum }) })%>
    </li>
</ul>
