<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SLTest.Models.shipTo>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Оплата заказа
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >

<%using (Html.BeginForm(null, null, new { shipId = Model.ID },FormMethod.Post, new { id = "Forma" }))
  { %>
<%: Html.ValidationSummary(true)%>
<h2>Оплата заказа от <%:Model.OrderDateTime%></h2>
<div>
Вы выбрали способ оплаты <%:Html.DropDownListFor(m => m.formOfP, new SelectList(ViewBag.stList, "ID", "Descr", 1)
                            , new { onChange = "onClickFormOfP(this)", id = "selformOdP" })%>
<br/>
При желании Вы можете измениь свой выбор.
</div>
<fieldset id="fsPSselection"  >
<legend>Выбор платёжной системы</legend>
<ul>
<% foreach (var i in Model.getListPSystems())
   {%>
   <li>
        <%:Html.RadioButtonFor(m => m.PSystem, i)%>
        <%:Html.Label(i)%>
   </li>
<%}%>
</ul>
</fieldset>
<%:Html.HiddenFor(m => m.tableNum)%>

<ul class="buttons">
    <li>
        <a href="#" onclick="document.forms['Forma'].submit();">Оплатить</a>
    </li>
</ul>
<%} %>

<script type="text/javascript">
    var onClickFormOfP = function (par) {
        var fsPSselection = document.getElementById("fsPSselection");
        if (par[par.value - 1].text == "Банковская карта") {
            fsPSselection.disabled = false;
        }
        else {
            fsPSselection.disabled = true;
        }

    }
    $(document).ready(function () {
        var t = document.getElementById("selformOdP");
        onClickFormOfP(t);
    });
</script>

</asp:Content>
