<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<KeyValuePair<SLTest.Models.itCart, int>>>" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ваш заказ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ваш заказ</h2>

   <% if (Model == null || Model.Count == 0)
{%>
    Корзина пуста
<%}
else
{
    //decimal price = 0;
    %>


   
    <div id="aj">

<%=Html.Action("pvKorzina", "Shipping")%>

    </div>
 
          <% 
}//if (Model == null || Model.Count == 0)

%>


</asp:Content>
