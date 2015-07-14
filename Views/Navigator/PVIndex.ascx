<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SLTest.Models.Navigator>" %>
<h2></h2>

        <% using (Html.BeginForm("PVIndexPost", "Navigator",FormMethod.Post, new { id = "NavForm" }))
           {%>
        <%: Html.ValidationSummary(true)%>
<ul class='navMenu'>
<%foreach (var i in Model.GetSortedList())
  { %>
      <li class='navCat'><a href='#'><%:i.stDescr%></a>
      
      <div class='navAnnot'>
        <%foreach (var j in i.GetContent())
        {
            if (j.cbItem)
            {%>
            
                <%:j.nmItem %> 
            
            <%}
        }%>
      </div>
      <ul class='navPop'>
      <%foreach (var j in i.GetContent())
        {%>
            <li>
                 <%=Html.CheckBox(j.nmItem, j.cbItem, new {@class="cbNavigator", style = "outline:none;" })%> <%:j.nmItem%>
            </li>
        <% }%>
      </ul>
      </li>
  <%}%>
  </ul>

            <ul class="buttons">
                <li>
                    <a href="#" onclick="document.forms['NavForm'].submit();">Найти</a>
                </li>
                <li>
                    <a href="#" onclick="unCheckAll();">Сбросить</a>
                </li>
            </ul>
            <%
           }
               %>
<div class="EditButton">
    <div class="b">
        <ul id = "siteSearch" class="schbuttons">
            <li>
                <a href="#"><i class="icon-search"></i></a>
             </li>
        </ul>
    </div>
    <div class="i">
        <input type="search" id="schEdit" >
    </div>

</div >
<%--<div class="EditButtonG">
    <script id="scriptG">
        (function () {
            var cx = '003969753695913680039:kxxj-cuz9s8';
            var gcse = document.createElement('script');
            gcse.type = 'text/javascript';
            gcse.async = true;
            gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') +
        '//www.google.com/cse/cse.js?cx=' + cx;
            var s = document.getElementById('scriptG');
            s.parentNode.insertBefore(gcse, s);

        })();
    </script>
<gcse:search></gcse:search>
</div>
--%>
<div class="EditButton">
    <script id="scriptG">
        (function () {
            var cx = '003969753695913680039:kxxj-cuz9s8';
            var gcse = document.createElement('script'); 
            gcse.type = 'text/javascript'; gcse.async = true;
            gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//www.google.com/cse/cse.js?cx=' + cx;
            var s = document.getElementById('scriptG');
            s.parentNode.insertBefore(gcse, s);
        })();
    </script>
    <div style="width:0px;overflow:hidden;height:0px;"> <!-- if you use display:nonw here it doesn't work-->
        <gcse:search></gcse:search>
    </div>
    <form id="searchbox_003969753695913680039:kxxj-cuz9s8" action="">
        <input value="003969753695913680039:kxxj-cuz9s8" name="cx" type="hidden"/>
        <input value="FORID:11" name="cof" type="hidden"/>
        <input id="q" name="q" type="text"/>
        <div class="b">
           <ul id = "googleSearch" class="schbuttons">
             <li>
                 <a href="#">G</a>
             </li>
           </ul>
        </div>
    </form>
</div>


<script>

    function unCheckAll() {
        if (document.getElementsByClassName == undefined) {
            document.getElementsByClassName = function (cl) {
                var retnode = [];
                var myclass = new RegExp('\\b' + cl + '\\b');
                var elem = this.getElementsByTagName('*');
                for (var i = 0; i < elem.length; i++) {
                    var classes = elem[i].className;
                    if (myclass.test(classes)) {
                        retnode.push(elem[i]);
                    }
                }
                return retnode;
            }
        }; 
        var all = document.getElementsByClassName("cbNavigator");
       
        for (var i = 0; i < all.length; i++) {
         //   if (all.item(i).type && all.item(i).type=="checkbox") //IE>8
            //       all.item(i).checked = false;                      //IE>8
              if (all[i].type && all[i].type=="checkbox") //IE8
                     all[i].checked = false;                      //IE8
        }
        document.forms["NavForm"].submit();
    }
    $(document).ready(function () {
        $('.cbNavigator').click(function (event) {
            var currentAnnotation = $(this).parents('li.navCat').children('.navAnnot').text();
            var isChecked = $(this).attr('checked');
            if (isChecked)
                $(this).parents('li.navCat').children('.navAnnot').text(currentAnnotation + ' ' + $(this).attr('name'));
            else
                $(this).parents('li.navCat').children('.navAnnot').text(currentAnnotation.replace(new RegExp($(this).attr('name'), "g"), ""));
        });

        $('ul.navMenu li').mouseenter(function (event) {

            $(this).parent().children('li').not(this).children('ul').hide(200).css('min-height', '0em');
            $(this).parent().children('li').not(this).children('.navAnnot').css('min-height', '0em');
            $(this).children('ul').show(400);
            $(this).children('.navAnnot').css('min-height', '1em');

        });

        $('#siteSearch.schbuttons li a').click(function (event) {
            $.post('<%=Url.Action("getFilteredRecords", "Navigator")%>', [
                                                        { name: 'schStr', value: $('.EditButton input').val() }
                                                      ]
                                                      , function () {
                                                          window.location.href = '<%=Url.Action("Index", "Home")%>'
                                                      }
         );


        });

        $('.EditButton .i input').keypress(function (event) {

            if (event.keyCode == 13)
                $('.schbuttons li a').click();
        });

        $('#googleSearch.schbuttons li a').click(function (event) {
            document.forms["searchbox_003969753695913680039:kxxj-cuz9s8"].submit();
        });

    });

</script>