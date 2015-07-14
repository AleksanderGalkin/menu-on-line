<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.VMMenu<SLTest.Models.Recipe>>" %>



    <h2>Ассортимент</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Наименование
            </th>
            <th>
                Цена
            </th>
            <th>
                Описание
            </th>
            <th>
                Сорт
            </th>
            <th>
                Категория
            </th>
        </tr>

    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td class="btTd">
                <%: Ajax.ActionLink(" ", "Administration", "Home", new { metName = "Edit", modName = "Recipe", id = item.RecID, pageNum =Model.paginginfo.CurrentPage  },
                                              new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("Edit", "Recipe", new { id = item.RecID,pageNum =Model.paginginfo.CurrentPage })},new {@class=" icon-pencil btRecords"})%> 
                                                              
                 <%: Ajax.ActionLink(" ","Administration", "Home", new {metName="Delete",modName="Recipe", id = item.RecID },
                            new AjaxOptions { UpdateTargetId = "aj",
                                                Url = Url.Action("Delete", "Recipe", new { id = item.RecID }),
                                                Confirm="Вы действительно хотите удалить эту запись?",
                                                HttpMethod="Post"},new {@class="icon-trash btRecords"})%>
            </td>

            <td>
                <%: item.RecName %>
            </td>
            <td>
                <%: String.Format(@"{0:#0.00р\.}", item.Price)%>
            </td>
            <td>
                <%: item.Describe %>
            </td>
            <td>
                <%: item.Sorts == null ? "(пусто)" : item.Sorts.Sort%>
            </td>
            <td>
                <%: item.Categories == null ? "(пусто)" : item.Categories.Category%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <ul class="buttons">
      <li>
        <%: Ajax.ActionLink("добавить", "Administration", "Home",
                                    new{metName="Create",modName="Recipe"},
                                                new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("Create", "Recipe") },
                                                new { @class = "icon-plus" })%>
      </li>
    </ul>
    <p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Administration", "Home", new { modName = "Recipe",metName="PVIndex", pageNum = x }),
                                            x => Url.Action("PVIndex", "Recipe", new { pageNum = x }),"aj")%>
    </p>

