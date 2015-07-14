<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SLTest.Models.shipTo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Заказ от <%: String.Format("{0:g}", Model.OrderDateTime) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Заказ от <%: String.Format("{0:g}", Model.OrderDateTime) %></h2>

<fieldset>
    <legend>Детали</legend>
    <div id="wrapper">
    <div class="section">
            <div class="display-label">Столик</div>
            <div class="display-field"><%: Model.Tables.numTable %></div>
    </div>
    <div class="section comment">
            <div class="display-label">Комментарий</div>
            <div class="display-field"><%: Model.comment %></div>
    </div>
    <div class="section">
            <div class="display-label">Счёт сразу?</div>
            <div class="display-field"><%: Model.flImmediateBill?"Да":"Нет" %></div>
    </div>
    <div class="section">
            <div class="display-label">Форма оплаты</div>
            <div class="display-field"><%: Model.formOfP1.Descr %></div>
    </div>
    <div class="section">
            <div class="display-label">Оплачено?</div>
            <div class="display-field"> <% if (Model.flPaid)
               { %>
               Да
            <%}
               else
               { %>
                Нет
            <%} %> </div>
    </div>
    <div class="section">
            <div class="display-label">Дата оплаты</div>
            <div class="display-field"><%: String.Format("{0:g}", Model.dtPaid) %></div>
    </div>
    <div class="section">
            <div class="display-label">Официант</div>
            <div class="display-field"><%: Model.Tables.Waiters.name %></div>
    </div>
    </div>
    <div class="orderDetails">
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
                   decimal amount = 0;
                   var mo = Model.itCart.ToList();
                   for (int i = 0; i < Model.itCart.ToList().Count;i++ )
                   {%>

    
        <tr>
             <td>
              <%: n++%>
              <%: Html.HiddenFor(m => mo[i].drink)%> 
              <%: Html.HiddenFor(m => mo[i].opt)%> 
             </td>
            <td>
                <%: mo[i].drinkName() + (mo[i].opt != null ? " и " : "") + (mo[i].opt != 0 ? mo[i].optName() : "")%>
            </td>
            <td>
               <%: string.Format(@"{0:#0.00р\.}", mo[i].drinkPrice() + mo[i].optPrice())%>
            </td>
            <td align="right">
               <%:mo[i].num%>
      
            </td>
            <td align="right" >
               <%: string.Format(@"{0:#0.00р\.}", mo[i].num * (mo[i].drinkPrice() + mo[i].optPrice()))%>
               <% amount=amount+mo[i].num * (mo[i].drinkPrice() + mo[i].optPrice()); %>
            </td>
         </tr>
               
    <%}
    %>
    <tr>
        <td colspan="4" align="right" class="stImpInfo">
            Стоимость счёта:
        </td>
        <td align="right" class="stImpInfo">
            <%:string.Format(@"{0:#0.00р\.}", amount)%>
        </td>
    </tr>
    <tr  class="trNoBorder" >
        <td colspan="5" align="right" class="trNoBorder">
        
        </td>
    </tr>
   </table>
  </div>
    
</fieldset>
<ul class="buttons">
    <li>

    <%: Html.ActionLink("назад", "DachBoardView", "OrderDashBoard", new { m = ViewBag.mode }, null)%>
    </li>
</ul>

</asp:Content>