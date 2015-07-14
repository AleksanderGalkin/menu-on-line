<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Options>" %>

  <% using (Ajax.BeginForm("Edit","Options", new{id=Model.OptID,pageNum=ViewBag.pageNum},new AjaxOptions { UpdateTargetId = "aj",HttpMethod="Post" })) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Описание ингредиента</legend>
            
           
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RecID) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.RecID, (SelectList)ViewData["RecList"], new { @class="sel_edit"})%>
                <%: Html.ValidationMessageFor(model => model.RecID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.OptionName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.OptionName) %>
                <%: Html.ValidationMessageFor(model => model.OptionName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price, String.Format("{0:F2}", Model.Price)) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Options", pageNum = ViewBag.pageNum },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Options", new { pageNum = ViewBag.pageNum }) })%>
    </li>
</ul>
