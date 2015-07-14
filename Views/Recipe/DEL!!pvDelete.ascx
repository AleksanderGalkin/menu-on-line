<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Recipe>" %>

   <h2>Удаление</h2>

    <h3>Вы действительно хотите удалить эту запись?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.RecID %></div>
        
        <div class="display-label">Наименование</div>
        <div class="display-field"><%: Model.RecName %></div>
        
        <div class="display-label">Цена</div>
        <div class="display-field"><%: String.Format("{0:f}", Model.Price) %></div>
        
        <div class="display-label">Описание</div>
        <div class="display-field"><%: Model.Describe %></div>
        
    </fieldset>
    
   <% using (Ajax.BeginForm("Delete","Recipe", new{id=Model.RecID}, new AjaxOptions { UpdateTargetId = "aj" }))
      {%>
        <p>
		    <input type="submit" value="Delete" />
		    
        </p>
        
    <% } %>

    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Recipe", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Recipe")},
                    new { @class = "btBody btToList" })%>