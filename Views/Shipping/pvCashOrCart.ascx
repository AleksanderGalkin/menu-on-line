<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.shipTo>" %>

<H2>
    Ваш заказ от <%:Model.OrderDateTime%> оправлен исполнителю.
</H2>

<% if(Model.flImmediateBill){ %>
<p>
    Счёт на оплату будет принесён Вам вместе с заказом.
</p>
<%}%>
<% decimal totalSum = 0;
    foreach(var i in Model.itCart)
       totalSum = totalSum + i.totalCost() * i.num;
        %>
<p>
    Сумма Вашего заказа составляет <%:string.Format("{0:F2}",totalSum)%> р.
</p>
<%if (Model.formOfP==1){ %>
<p>
    Вы выбрали форму оплаты наличными деньгами. Ваш официант расчитает Вак как только Вы будете готов к этому.
</p>
<%} else { %>
<p>
    Вы выбрали форму оплаты банковской картой. Выберите Ваш заказ, нажмите кнопк Оплатитьи следуйте инструкциям.
</p>
  
<%} %>
<p>
При желании Вы можете сменить форму оплаты.
</p>