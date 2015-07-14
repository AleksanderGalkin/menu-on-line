<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Sorts>" %>

   <h2>Удаление</h2>

    <h3>Вы действительно хотите удалить эту запись?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.Sort%></div>
        
        <div class="display-label">Наименование</div>
        <div class="display-field"><%: Model.Sort%></div>

        
    </fieldset>
    
   <% using (Ajax.BeginForm("Delete", "Sorts", new { id = Model.ID }, new AjaxOptions { UpdateTargetId = "aj" }))
      {%>
        <p>
		    <input type="submit" value="Delete" />
		    
        </p>
        
    <% } %>

    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                            new { metName = "PVIndex", modName = "Sorts", pageNum = 1 },
                            new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Sorts") },
                    new { @class = "btBody btToList" })%>