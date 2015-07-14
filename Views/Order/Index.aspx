<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SLTest.Models.shipTo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Много диких обезьян
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Ваши заказы</h2>


<table>
    <tr>
        <th>
        
        </th>
        <th>
            Столик
        </th>
        <th>
            Дата заказа
        </th>
        <th>
            Ваш комментарий
        </th>
        <th>
            Официант
        </th>
        <th>
            Форма оплаты
        </th>

        <th>
            Дата оплаты
        </th>
         <th>
            Оплачено?
        </th>
        <th>
            Статус
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr  class="rowOrders" >
        <td>
        <%if (item.getOState.Descr.Contains("Создан заказ"))
          { %>
            <%: Html.ActionLink(" ", "DeleteOrder", new { id = item.ID }, new { @class = "icon-trash btRecords"
                                                                                , onclick="return(confirm('Удалить запись?'));"})%> 
            <%}
          else
          { %>
          <font class = "icon-trash" color="LightGray"></font>
        <%} %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%: item.Tables.numTable %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%: String.Format("{0:g}", item.OrderDateTime) %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'
            title="<%:item.comment %>">
            <%: item.comment.Substring(0,25)+(item.comment.Trim().IsEmpty()?"":"...") %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%: item.Tables.Waiters.name %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%: item.formOfP1.Descr %>
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%: String.Format("{0:g}", item.dtPaid) %>
        </td>
        
        <td>
            <% if (item.flPaid)
               { %>
               Да
            <%}
               else
               { %>
            <%: Html.ActionLink("Оплатить", "Payment", new { id = item.ID }, new { @class = "btOrders btToPay" })%>
            <%} %> 
        </td>
        <td onclick='clickDetail("<%:Url.Action("Detail","Order",new{ID=item.ID}) %>")'>
            <%:item.getOState.Descr %>
        </td>
    </tr>  
<% } %>


</table>
<script type="text/javascript">

    var clickDetail = function (parID) {

        document.location.href = parID;
    }
</script>

</asp:Content>

