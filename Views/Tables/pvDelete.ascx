<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Tables>" %>

  <h2>Удаление</h2>

    <h3>Вы действительно хотите удалить эту запись?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
      <div class="display-label">ID</div>
        <div class="display-field"><%: Model.waiterID %></div>
        
        <div class="display-label">Официант</div>
        <div class="display-field"><%: Model.Waiters.name %></div>
        
        <div class="display-label">Номер столика</div>
        <div class="display-field"><%: Model.numTable %></div>
        
        <div class="display-label">Комментарий</div>
        <div class="display-field"><%:  Model.comment %></div>   
    </fieldset>
    
   <% using (Ajax.BeginForm("Delete","Options", new{id=Model.ID}, new AjaxOptions { UpdateTargetId = "aj" }))
      {%>
        <p>
		    <input type="submit" value="Delete" />
		    
        </p>
        
    <% } %>

    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Tables", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Tables")},
                    new { @class = "btBody btToList" })%>