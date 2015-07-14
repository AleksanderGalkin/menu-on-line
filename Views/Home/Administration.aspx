<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Administration
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <div id="loader">
            <img alt="" src="<%=Url.Content("~/Content/ajax-loader.gif")%>"> 
        </div>

    <h3>Администрирование</h3>

    <ul id="popup">
        
        <li><%: Ajax.ActionLink("Блюда", "Administration", "Home",
                    new { metName = "PVIndex",modName = "Recipe", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Recipe")})%></li> 
        <li><%: Ajax.ActionLink("Опции", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Options", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId="aj", Url=Url.Action("PVIndex","Options")})%></li>              
        <li><%: Ajax.ActionLink("Виды", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Sorts", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Sorts") })%></li> 
        <li><%: Ajax.ActionLink("Категории", "Administration", "Home",
                    new { metName = "PVIndex", modName = "Categories", pageNum = 1 },
                    new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Categories") })%></li> 
         <li><%: Html.ActionLink("Пользователи","Administration", "Home"
                                  ,new { metName = "PVIndex", modName = "Users", pageNum = 1 },null) %></li>
        <li><%: Html.ActionLink("Официанты","Administration", "Home"
                                  ,new { metName = "PVIndex", modName = "Waiters", pageNum = 1 },null) %></li>
        <li><%: Html.ActionLink("Столы","Administration", "Home"
                                  ,new { metName = "PVIndex", modName = "Tables", pageNum = 1 },null) %></li>
         <li><%: Html.ActionLink("Монитор заказов", "DachBoardView", "OrderDashBoard",new {m=OrderDashBoardController.mode.Active},null)%></li>
    </ul>


    <div id="aj">
            <%=Html.Action((string)ViewBag.mtn, (string)ViewBag.mn, new { pageNum = ViewBag.pn,id=ViewBag.id })%>
    </div>
    <ul class="buttons">
        <li>
            <%: Html.ActionLink("Назад в магазин", "Index", "Home")%>
        </li>
    </ul>

    <script type="text/javascript">
        $(document).ajaxStart(function () {
            $('#loader').show();
        }).ajaxStop(function () {
            $('#loader').hide();
        });
</script>

</asp:Content>

