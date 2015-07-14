<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Монитор заказов
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Монитор заказов</h3>

<div id="loader_dashboard">
    <img alt="" src="<%=Url.Content("~/Content/ajax-loader.gif")%>">
</div>
<input type="radio" class="radioMode" name="radioMode" value="Active" <%: ViewBag.mode==OrderDashBoardController.mode.Active?"checked='checked'":"" %>/>Активные &nbsp
<input type="radio" class="radioMode" name="radioMode" value="Archive" <%: ViewBag.mode==OrderDashBoardController.mode.Archive?"checked='checked'":"" %> />Архивные &nbsp
<input type="radio" class="radioMode" name="radioMode" value="All" <%: ViewBag.mode==OrderDashBoardController.mode.All?"checked='checked'":"" %>>Все &nbsp

<div id="UpdateBlock">
<%Html.RenderAction("pvIndex", "OrderDashBoard", new {m=ViewBag.mode}); %>
</div>


<script type="text/javascript">
    flag_endOfTimer = 0;
    $(document).ready(function () {
        blink();
        setTimeout(upd, 5000);
    });

    upd = function () {

        var mode=$('input[name="radioMode"]:checked').val();
        flag_endOfTimer++;
        $('#UpdateBlock').load(('<%=Url.Action("pvIndex","OrderDashBoard")%>' + '?m=' + mode), {
            asd: Math.random() // что б IE не кешировал
        }
        , function () {
            blink();
            setTimeout(upd, 5000);
        }
        );
    }



    blink=function () {

        var objColor = $(".btBlink");

        var ar_objColors = new Array(3);

        objColor.each(function (i, item) {
            ar_objColors[i] = $(this).css("background-color");

        });
        var lFlag = flag_endOfTimer
        var setObjColor = function () {
            objColor.each(function (i, item) {

                $(this).css("background-color", ar_objColors[i]);
            });
            if (lFlag == flag_endOfTimer)
                setObjLightColorID = setTimeout(setObjLightColor, 500);
        }
        var setObjLightColor = function () {
            objColor.each(function (i, item) {
                var cHex = ar_objColors[i];
                var cRGB = getLight(cHex);
                $(this).css("background-color", cRGB);
            });

            setObjColorID = setTimeout(setObjColor, 500);
        }

        setObjLightColorID = setTimeout(setObjLightColor, 300);
    }





    function toR(h) { return parseInt((cutHex(h)).substring(0, 2), 16) }
    function toG(h) { return parseInt((cutHex(h)).substring(2, 4), 16) }
    function toB(h) { return parseInt((cutHex(h)).substring(4, 6), 16) }
    function cutHex(h) { return (h.charAt(0) == "#") ? h.substring(1, 7) : h }
    function getLight(cHex) {
        if (cHex.charAt(0) == "#")
            return 'rgb(' + toR(cHex) * 0.5 + ',' + toG(cHex) + ',' + toB(cHex) * 0.6 + ')';
        else
            var data = cHex.slice(cHex.indexOf('(') + 1, cHex.indexOf(')'));
        a = data.split(',');

        return 'rgb(' + Math.floor(a[0] * 0.9) + ',' + a[1] + ',' + Math.floor(a[2] * 0.6) + ')'; ;
    }


    $(document).ready(function () {

        // Вешаем слушатель события нажатие кнопок мыши для всего документа:
        $(document).mousedown(function (event) {

            // Убираем css класс selected-html-element у абсолютно всех элементов на странице с помощью селектора "*":
            $('*').removeClass('selected-html-element');
            // Удаляем предыдущие вызванное контекстное меню:
            $('.context-menu').remove();
            // Проверяем нажата ли именно правая кнопка мыши:
            if (event.which === 1
            && event.target.className.indexOf("btSignal") >= 0
            ) {

                // Получаем элемент на котором был совершен клик:
                var stageList = [, ['ordCreated', 'Создан заказ']
                                , ['ordCooking', 'Отправлен на кухню']
                                , ['ordCooked', 'Готов заказ']
                                , ['ordShiped', 'Доставлено']
                                , ['notReq', 'Счёт не запрошен']
                                , ['reqed', 'Счёт запрошен']
                                , ['cashed', 'Оплачено наличными']
                                , ['banked', 'Оплачено картой']];
                var stageMap = new Array(9);
                for (var i = 1; i <= 8; i++)
                    stageMap[i] = Array(9);
                stageMap[1][2] = 1;
                stageMap[2][3] = 1;
                stageMap[3][4] = 1;
                stageMap[5][6] = 1;
                stageMap[5][8] = 1;
                stageMap[6][7] = 1;

                var target = $(event.target);
                var targetStageID = 0;
                for (var i = 1; i <= stageList.length; i++) {
                    if (target.hasClass(stageList[i][0])) {
                        targetStageID = i;
                        break;
                    }
                }
                var typeOfStage = 0;
                if (target.hasClass('btOState'))
                    typeOfStage = 1;
                if (target.hasClass('btPState'))
                    typeOfStage = 2;
                var $ul = $('<ul/>');
                for (var j = 1; j <= 8; j++) {
                    if (stageMap[targetStageID][j])
                        $ul.append('<li><a href="#" id="' + stageList[j][0] + '">' + stageList[j][1] + '</a></li>')
                }

                // Создаем меню:
                $('<div/>', {
                    'class': 'context-menu' // Присваиваем блоку наш css класс контекстного меню:
                })
            .css({
                left: (event.pageX - 5) + 'px', // Задаем позицию меню на X
                top: event.pageY + 'px' // Задаем позицию меню по Y
            })
            .appendTo('body') // Присоединяем наше меню к body документа:
            .append( // Добавляем пункты меню:
                 $('<ul/>').append($ul));

                $('.context-menu').show('fast'); // Показываем меню с небольшим стандартным эффектом jQuery. Как раз очень хорошо подходит для меню


            }
            $('.context-menu li a').mousedown(function () {
                $.post('\\OrderDashBoard\\changeStage', [{ name: "id", value: target.attr('id') }, // id заказа
                                                         {name: "nextStageID", value: $(this).attr('id') },
                                                         { name: "typeOfStage", value: typeOfStage }
                                                         ]); // выбранная стадия заказа
            });
        });
    });

    $(document).ajaxStart(function () {
        $('#loader_dashboard').show();
    }).ajaxStop(function () {
        $('#loader_dashboard').hide();
    });



</script>

</asp:Content>
