<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Categories>" %>

     <% using (Ajax.BeginForm("Edit", "Categories", new { id = Model.ID, pageNum = ViewBag.pageNum }, new AjaxOptions { UpdateTargetId = "aj" }))
        {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Характеристика категории</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Category) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Category)%>
                <%: Html.ValidationMessageFor(model => model.Category)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Arrange) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Arrange, String.Format("{0:F0}", Model.Arrange)) %>
                <%: Html.ValidationMessageFor(model => model.Arrange) %>
            </div>
  
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

<ul class="buttons">
      <li>
         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                                 new { metName = "PVIndex", modName = "Categories", pageNum = ViewBag.pageNum },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Categories", new { pageNum = ViewBag.pageNum }) })%>
     </li>
</ul>
