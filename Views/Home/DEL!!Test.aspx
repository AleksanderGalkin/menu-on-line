
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<KeyValuePair<SLTest.Models.itCart, int>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Test</h2>
<% using(Html.BeginForm()){ %>
<table>
        <tr>
            <th>
                №
            </th>
            <th>
                наименовние
            </th>
            <th>
                цена
            </th>
            <th>
                количество
            </th>
            <th>
                стоимость
            </th>
        </tr>

  <% 
                   int n = 1;
                   for (int e = 0; e < Model.Count;e++ )
                   {%>

    
        <tr>
<%--        <td>
        <input type="hidden" name="[0].key" value="Первый"/>
        <input type="text" name="[0].value" value="Галкин"/>
        <input type="hidden" name="[1].key" value="Второй"/>
        <input type="text" name="[1].value" value="Поверенных"/>
        </td>--%>



            <td>
              <%: n++%>
            
              <%: Html.HiddenFor(m =>m[e].Key.drink)%> 
              <%: Html.HiddenFor(m =>m[e].Key.opt)%>
            </td>
            <td>
                <%: Html.TextBoxFor(m => m[e].Value, new { @class = "tbItCartCount" })%>
            </td>
        </tr>

               
    <%}
    %>
     </table>
             <p>
                <input type="submit" value="Поместить в заказ" />
            </p>
     <%} %>
</asp:Content>
