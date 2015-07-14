<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Categories>" %>

   <h2>Удаление</h2>

    <h3>Вы действительно хотите удалить эту запись?</h3>
    <fieldset>
        <legend>Реквизиты</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">Наименование</div>
        <div class="display-field"><%: Model.Category%></div>
        
        <div class="display-label">Сортировка</div>
        <div class="display-field"><%: String.Format("{0:f0}", Model.Arrange) %></div>

        
    </fieldset>
    
   <% using (Ajax.BeginForm("Delete", "Categories", new { id = Model.ID }, new AjaxOptions { UpdateTargetId = "aj" }))
      {%>
        <p>
		    <input type="submit" value="Delete" />
		    
        </p>
        
    <% } %>

    <%: Ajax.ActionLink("Back to List", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Categories", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Categories")},
                    new { @class = "btBody btToList" })%>