<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.UserAndRoles>" %>

  <% using (Ajax.BeginForm("EditUsers", "Users", new { id = Model.ID }, new AjaxOptions { UpdateTargetId = "aj",HttpMethod="Post" }, new { id = "fu",name="nu" }))
     {%>
        <%: Html.ValidationSummary(true)%>
        <%: Html.HiddenFor(model => model.roleName)%>
        <fieldset>
            <legend>Пользователи данной группы</legend>
             <div>
                <div style="display:inline-block;">
                    <p>Все</p>
                    <%: Html.ListBox("null", new SelectList(ViewBag.Users), new { style = "width:110px", id = "uList" })%>
                </div>  
                <div class="moveButtonBlock">
                   <div class="moveButton">      
                            <a href="#" id="moveButtonIn"> >> </a>
                   </div>
                   <div class="moveButton">      
                            <a href="#" id="moveButtonOut"> << </a>
                   </div>
                </div>                      
                <div style="display:inline-block;">
                    <p><%: Html.DisplayFor(model => model.roleName)%></p>
                    <%: Html.ListBoxFor(model => model.users, new SelectList(Model.users), new { style = "width:110px", id = "rList" })%>
                </div>
                <%: Html.ValidationMessageFor(model => model.users)%>
            </div>
        
            <p>
                <input type="submit" value="Сохранить" />
            </p>
       </fieldset>

    <% } %>

   <ul class="buttons">
      <li>
         <%: Ajax.ActionLink("Назад к списку", "Administration", "Home",
                                 new { metName = "PVIndex", modName = "Users", pageNum = 1 },
                                 new AjaxOptions { UpdateTargetId = "aj", Url = Url.Action("PVIndex", "Users") })%>
    </li>
</ul>

<script type="text/javascript">
    $(document).ready(function () {
        $('#fu').on('submit', function () {
            $('#rList option').attr('selected', 'selected');
        }); 

        $('#moveButtonIn').click(function (event) {
            var user = $('#uList option:selected').val();
            if (user == undefined) {
                alert('Выберите учётную запись');
                return false;
            }
            var $o = $('<option/>').attr('value', user).text(user);
            $('#rList').append($o);
            $('#uList option:selected').remove();

        });
        $('#moveButtonOut').click(function (event) {
            var user = $('#rList option:selected').val();
            if (user == undefined) {
                alert('Выберите учётную запись'); 
                return false;
            }
            var $o = $('<option/>').attr('value', user).text(user);
            $('#uList').append($o);
            $('#rList option:selected').remove();
        });

    });


    
</script>