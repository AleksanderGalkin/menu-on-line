<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.Waiters>>" %>



    <h2>Официанты</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Логин
            </th>
            <th>
                Имя
            </th>
        </tr>

    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td class="btTd">
                <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Edit", modName = "Waiters", id = item.ID, pageNum = Model.paginginfo.CurrentPage },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("Edit", "Waiters", new { id = item.ID,pageNum = Model.paginginfo.CurrentPage })},new {@class="btRecords icon-pencil"})%> 
                                                         
                 <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Delete", modName = "Waiters", id = item.ID },
                            new AjaxOptions { UpdateTargetId = "aj",
                                              Url = Url.Action("Delete", "Waiters", new { id = item.ID }),
                                                Confirm="Вы действительно хотите удалить эту запись?",
                                                HttpMethod="Post"},new {@class="btRecords icon-trash"})%>
            </td>

            <td>
                <%: item.login %>
            </td>
            <td>
                <%: item.name %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <ul class="buttons">
      <li>
        <%: Ajax.ActionLink("добавить", "Administration", "Home",
                                    new{metName="Create",modName="Waiters"},
                                                            new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("Create", "Waiters") },
                                                            new { @class = "icon-plus" })%>
      </li>
    </ul>
    <p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "Waiters", pageNum = x }),
                                                        x => Url.Action("PVIndex", "Waiters", new { pageNum = x }), "aj")%>
    </p>

