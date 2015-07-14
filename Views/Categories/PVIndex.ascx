<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.Categories>>" %>



    <h2>Категории</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Наименование
            </th>
            <th>
                Сортировка
            </th>
        </tr>

    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td class="btTd">
                <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Edit", modName = "Categories", id = item.ID, pageNum = Model.paginginfo.CurrentPage },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("Edit", "Categories", new { id = item.ID,pageNum = Model.paginginfo.CurrentPage })},new {@class="btRecords icon-pencil"})%> 
                                                              
                 <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Delete", modName = "Categories", id = item.ID },
                            new AjaxOptions { UpdateTargetId = "aj",
                                              Url = Url.Action("Delete", "Categories", new { id = item.ID }),
                                                Confirm="Вы действительно хотите удалить эту запись?",
                                                HttpMethod="Post"},new {@class="btRecords icon-trash"})%>
            </td>

            <td>
                <%: item.Category%>
            </td>
            <td>
                <%: String.Format("{0:F0}", item.Arrange) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <ul class="buttons">
      <li>
        <%: Ajax.ActionLink("добавить", "Administration", "Home",
                                    new{metName="Create",modName="Categories"},
                                                new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("Create", "Categories") },
                                                new { @class = "icon-plus" })%>
      </li>
    </ul>
    <p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "Categories",metName="PVIndex", pageNum = x }),
                                            x => Url.Action("PVIndex", "Categories", new { pageNum = x }),"aj")%>
    </p>

