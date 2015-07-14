<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<SLTest.Models.shipTo>>" %>
<div id='menu'>
</div>

<table>
    <tr>
 
        <th>
           Номер столика
        </th>
        <th>
            Время заказа
        </th>
        <th>
            Комментарий
        </th>
        <th>
            Форма оплаты
        </th>
        <th>
            Официант
        </th>
        <th>
            Состояние
        </th>
        <th>
            Оплата
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr class="rowDashBoard">
        <td align="center"  data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
       <%-- %> new { metName = "PVIndex", modName = "Users", pageNum = 1 } --%>
            <%: item.Tables.numTable%>
        </td>
        <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <%: String.Format("{0:g}", item.OrderDateTime)%>
        </td>
        <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <%: item.comment%>
        </td>

        <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <%: item.formOfP1.Descr.Trim()%>
        </td>
        <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <%: item.Tables.Waiters.name%>  
        </td>
         <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <a href="#" id=<%=item.ID%> class="btSignal btOState <%=item.getOState.Style%>"><%=item.getOState.Descr%></a>
        </td>
         <td data-url='<%:Url.Action("Detail","OrderDashBoard",new{ID=item.ID,m=ViewBag.mode}) %>'>
            <a href="#" id=<%=item.ID%> class="btSignal btPState <%=item.getPState.Style%>"><%=item.getPState.Descr%></a>
        </td> 
     </tr>  
<% } %>

</table>

<script type="text/javascript">
 $(document).ready(function () {
        $('td').click(function () {
            document.location.href = $(this).data('url');
        });
    });

</script>