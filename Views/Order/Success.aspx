<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Успешная оплата
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%if (ViewBag.formOfP1 == "Банковская карта")
  {%>
<h3>Безналичный платёж завершён успешно. Спасибо!</h3>
<h2>Мы будем рады увидеть Вас еще раз в нашем заведении!</h2>
<%}
  else
  { %>
<h3>Сейчас к Вам подойдёт наш официант с распечаткой счёта.</h3>
<h2>Мы будем рады увидеть Вас еще раз в нашем заведении!</h2>
<%} %>
</asp:Content>
