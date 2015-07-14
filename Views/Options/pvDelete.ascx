<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Options>" %>

  <h2>Удаление</h2>

    <h3>Вы действительно хотите удалить эту запись?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
      <div class="display-label">ID</div>
        <div class="display-field"><%: Model.OptID %></div>
        
        <div class="display-label">Применимо к...</div>
        <div class="display-field"><%: Model.Recipe.RecName %></div>
        
        <div class="display-label">Наименование</div>
        <div class="display-field"><%: Model.OptionName %></div>
        
        <div class="display-label">Цена</div>
        <div class="display-field"><%: String.Format("{0:F2}", Model.Price) %></div>   
    </fieldset>
    
   <% using (Ajax.BeginForm("Delete","Options", new{id=Model.OptID}, new AjaxOptions { UpdateTargetId = "aj" }))
      {%>
        <p>
		    <input type="submit" value="Delete" />
		    
        </p>
        
    <% } %>

    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Options", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Options")},
                    new { @class = "btBody btToList" })%>