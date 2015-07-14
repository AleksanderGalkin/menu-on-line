<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.Sorts>>" %>



    <h2>Виды блюд (подкатегории)</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Наименование
            </th>
        </tr>

    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td class="btTd">
                <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Edit", modName = "Sorts", id = item.ID,pageNum = Model.paginginfo.CurrentPage },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("Edit", "Sorts", new { id = item.ID,pageNum = Model.paginginfo.CurrentPage })},new {@class="btRecords icon-pencil"})%> 
                                                         
                 <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Delete", modName = "Sorts", id = item.ID },
                            new AjaxOptions { UpdateTargetId = "aj",
                                              Url = Url.Action("Delete", "Sorts", new { id = item.ID }),
                                                Confirm="Вы действительно хотите удалить эту запись?",
                                                HttpMethod="Post"},new {@class="btRecords icon-trash"})%>
            </td>

            <td>
                <%: item.Sort %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <ul class="buttons">
      <li>
        <%: Ajax.ActionLink("добавить", "Administration", "Home",
                                    new{metName="Create",modName="Sorts"},
                                                            new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("Create", "Sorts") },
                                                            new { @class = "icon-plus" })%>
      </li>
    </ul>
    <p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "Sorts", metName = "PVIndex", pageNum = x }),
                                                        x => Url.Action("PVIndex", "Sorts", new { pageNum = x }), "aj")%>
    </p>

