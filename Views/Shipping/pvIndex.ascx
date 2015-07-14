<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.shipTo>" %>

<% using (Ajax.BeginForm(null,null,new AjaxOptions
   {
       UpdateTargetId = "aj",
       Url = Url.Action("CartSubmit","Shipping"),
       HttpMethod = "Post"
   }, new { id = "Forma",@class="Forma" }
   ))
   {%>

<%: Html.ValidationSummary(true)%>
    <fieldset>
        <legend>Оформление заказа</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.tableNum) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model=>model.tableNum,new SelectList (ViewBag.Tables,"ID","numTable",1)) %>
            <%: Html.ValidationMessageFor(model => model.tableNum) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.formOfP) %>
        </div>
        <div class="editor-field">
         <%: Html.DropDownListFor(model => model.formOfP, new SelectList(ViewBag.stList, "ID", "Descr", 1))%>
         <%: Html.ValidationMessageFor(model => model.formOfP)%>
        </div>
        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.flImmediateBill) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.flImmediateBill) %>
            <%: Html.ValidationMessageFor(model => model.flImmediateBill) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.comment) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.comment)%>
            <%: Html.ValidationMessageFor(model => model.comment)%>
        </div>
        <div class="editor-field">
            <%: Html.Hidden("userName",Page.User.Identity.Name)%>
        </div>
        <input type="hidden" class="sendCart" name="sendCart" value="" />

    </fieldset>


<% 
  }//form    
%>
     <ul class='buttons'>
        <li>
            <a href="#" id="aButton">Оправить</a> 
        </li>
    </ul>


<script type="text/javascript">
    document.getElementById('aButton').onclick = function ()
	{
	    $('.sendCart').val('Оправить');
        $('.Forma').trigger('submit');
	}
</script>