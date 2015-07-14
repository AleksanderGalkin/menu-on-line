<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.Tables>>" %>

 <h2>Столы</h2>

    <table>
        <tr>
            <th></th>
     
            <th>
                официант
            </th>
            <th>
                номер столика
            </th>
            <th>
                комментарий
            </th>
        </tr>

    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td class="btTd">
                 <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Edit", modName = "Tables", id = item.ID,pageNum = Model.paginginfo.CurrentPage },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                                Url = Url.Action("Edit", "Tables", new { id = item.ID, pageNum = Model.paginginfo.CurrentPage })
                                              }, new { @class = "btRecords icon-pencil" })%>

              
                <%: Ajax.ActionLink(" ","Administration", "Home", new {metName="Delete",modName="Tables", id = item.ID },
                            new AjaxOptions { UpdateTargetId = "aj",
                                              Url = Url.Action("Delete", "Tables", new { id = item.ID }),
                                                Confirm="Вы действительно хотите удалить эту запись?",
                                              HttpMethod = "Post"
                            }, new { @class = "btRecords icon-trash" })%>

            </td>

            <td>
                <%: item.Waiters.name %>
            </td>
            <td>
                <%: item.numTable %>
            </td>
            <td>
                <%: item.comment%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <ul class="buttons">
      <li>
        <%: Ajax.ActionLink("добавить", "Administration", "Home",
                                new{metName="Create",modName="Tables"},
                                            new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("Create", "Tables") },
                                            new { @class = "icon-plus" })%>
      </li>
    </ul>
     <p>
     
       <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "Tables", metName = "PVIndex", pageNum = x }),
                                            x => Url.Action("PVIndex", "Tables", new { pageNum = x }),
                                            "aj")%>

    </p>
