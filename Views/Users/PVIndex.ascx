<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.UserAndRoles>>" %>


    <h2>Группы (роли)</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Наименование
            </th>
        </tr>


<% foreach(var item in Model.items){ %>
        <tr>
            <td class="btTd">
                <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "EditUsers", modName = "Users", id = item.ID },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("EditUsers", "Users", new { id = item.ID })},new {@class="btRecords icon-pencil"})%> 
            </td>

            <td>
                <%: item.roleName%>
            </td>
       </tr>
<%} %>

</table>
<p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "UserAndRoles", metName = "PVIndex", pageNum = x }),
                                            x => Url.Action("PVIndex", "Users", new { pageNum = x }),"aj")%>
</p>