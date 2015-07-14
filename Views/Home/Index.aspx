<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SLTest.Models.VMMenu<SLTest.Models.VMMenuItem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Много диких обезьян
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2></h2>

        <% using (Html.BeginForm("Index","Home",FormMethod.Post, new { id = "MenuForm" }))
           {%>
        <%: Html.ValidationSummary(true) %>
        

    <table class="single">
    <col  class="s_col_small">
    <col  class="s_col_middle">
    <col  class="s_col_middle">
    <col  class="s_col_middle">

        <tr>
            <th></th>   

            <th>
                Наименование блюда
            </th>
            <th>
                Цена
            </th>
            <th>
                Дополнитльный ингредиент
            </th>
        </tr>
        
    <% foreach (var item in Model.items) { %>
    
        <tr>
            <td>
                
                <%--<%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> --%>
                <%=Html.CheckBox("" + item.ID, new {style="outline:none;" })%> 
            

            </td>

            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: String.Format(@"{0:#0.00р\.}", item.Price)%>
            </td>
            <td>
                 <%: Html.DropDownListFor(p => item.OptID, new SelectList(item.GetSprOpt().ToList(), "OptID", "StringForSelectList"),new{@class="sel_table"})%>
            </td>
        </tr>
    
    <% } %>

    <% for (int i = 0; i < Model.paginginfo.ItemsPerPage-Model.items.Count();i++ )
       { %>
    <tr>
            <td>
                <%=Html.CheckBox("empty",new  {disabled="disabled"})%>
            </td>
            <td>
                
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    
    <% } %>
    </table>
    <p>
        
        <%: Html.PageLinks(Model.paginginfo, x => Url.Action("Index","Home",new{pageNum=x}))%>
       
    </p>

    <ul class="buttons">
        <li>
            <a href="#" onclick="document.forms['MenuForm'].submit();">Поместить в заказ</a>
        </li>
    </ul>

     <% } %>

     <%  var count = 0;
       
         var ses=Session["sKorzina"] as Dictionary<SLTest.Models.itCart, int>;
         if (ses != null)
             foreach (var key in ses.Keys)
            {
              count = count + ses[key];
            }
    %>


     <ul class="buttons">
        <li>               
            <%: Html.ActionLink("Ваш заказ:"+count, "Korzina")%> 
        </li>
    </ul>
   

</asp:Content>

