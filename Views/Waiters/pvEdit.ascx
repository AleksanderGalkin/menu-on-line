<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Waiters>" %>

     <% using (Ajax.BeginForm("Edit", "Waiters", new { id = Model.ID, pageNum = ViewBag.pageNum }, new AjaxOptions { UpdateTargetId = "aj" }))
        {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Характеристика</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.login)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.login)%>
                <%: Html.ValidationMessageFor(model => model.login)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.name)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.name)%>
                <%: Html.ValidationMessageFor(model => model.name)%>
            </div>        
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>

    <% } %>

   <ul class="buttons">
      <li>
         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                                              new { metName = "PVIndex", modName = "Waiters", pageNum = ViewBag.pageNum },
                                 new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Waiters", new { pageNum = ViewBag.pageNum }) })%>
    </li>
</ul>
