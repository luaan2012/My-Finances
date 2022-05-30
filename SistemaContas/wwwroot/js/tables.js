$(document).ready(function () {
    var id = $('.get').attr('data-get');
    $("#datatablesSimple2,#datatablesSimple").on("dblclick", "td", function () {
        if ($('td > input').length > 0) {
            return;
        }
        if ($(this).attr('id') == 'trashBills' || $(this).attr('id') == 'trashDebts') {
            return;
        }
        if ($(this).attr('class') == 'statusDebts' || $(this).attr('class') == 'statusBills') {
            return;
        }
        var cond = $(this).parent().parent().parent().parent().find('.tb').attr('id');
        var wid = $(this).width();
        var container = $(this).text();
        var newElement = $('<input/>', { type: 'text', value: container, width: wid })
        var content = $(this).attr('class').split(' ');
        var id = $(this).parent().find('.id').attr('value');
        $(this).html(newElement.bind('blur keydown', function (e) {
            var keyCode = e.which;
            if (keyCode == 13) {
                var newContainer = $(this).val();
                if (newContainer != "") {
                    $(this).parent().html(newContainer)
                    var name;
                    var initialDate;
                    var finalDate;
                    var value;
                    var dateExpired;

                    if (content[0] == "name") {
                        name = newContainer;
                    } else if (content[0] == "initialData") {
                        initialDate = newContainer ? moment(newContainer, 'DD/MM/YYYY').format('YYYY/MM/DD') : moment(container, 'DD/MM/YYYY').format('YYYY/MM/DD');
                    } else if (content[0] == "finalData") {
                        finalDate = newContainer ? moment(newContainer, 'DD/MM/YYYY').format('YYYY/MM/DD') : moment(container, 'DD/MM/YYYY').format('YYYY/MM/DD');
                    } else if (content[0] == "valor") {
                        value = newContainer.replace("$", "").replace(" ", "").replace('R', '');
                    } else if (content[0] == "data") {
                        dateExpired = newContainer ? moment(newContainer, 'DD/MM/YYYY').format('YYYY/MM/DD') : moment(container, 'DD/MM/YYYY').format('YYYY/MM/DD');
                    }
                    console.log(finalDate, initialDate, dateExpired)
                    if (cond == "datatablesSimple") {
                        $.post('/Home/UpdateTableBills', { Name: name, InitialDate: initialDate, FinalDate: finalDate , Value: value, Id: id }, function (data) {
                            console.log(data)
                        })
                    } else {
                        $.post('/Home/UpdateTableDebts', { Name: name, DateExpired: dateExpired, Value: value, Id: id }, function (data) {
                            console.log(data)
                        })
                    }

                }
            }
            if (e.type == "blur") {
                $(this).parent().html(container);
            }
        }))

        $(this).children().select();
    });

    $('.save').click(function () {
        if ($('select#add').val() == "debts") {
            var name = $('#nomeDebito').val();
            var dateExpired = $('#dataDebito').val();
            var value = $('#valorDebito').val();
            console.log(value)
            $.post('/Home/SaveDebts', { Name: name, Value: value, dateExpired: dateExpired, Status: 0, UserId: id }, function (data, status) {
                if (status == "success") {
                    alert("Salvo com sucesso");
                    $('#area').html('');
                    location.reload();
                }
            })
        }else if ($('select#add').val() == "bills") {
            var name = $('#nomeBills').val();
            var dateInitial = $('#dataInitial').val();
            var dateFinal = $('#dataFinal').val();
            var value = $('#valorBills').val();
            $.post('/Home/SaveBills', { Name: name, Value: value, InitialDate: dateInitial, FinalDate: dateFinal, Status: 0, UserId: id }, function (data, status) {
                if (status == "success") {
                    alert("Salvo com sucesso");
                    $('#area').html('');
                    location.reload();
                }
            })
        }else if ($('select#add').val() == "today") {
            var data = $('#dataGanhos').val() ? $('#dataGanhos').val() : $('#dataGanhosDate').val();
            var value = $('#valorGanhos').val();
            $.post('/Home/SaveEarnings', { EarningDay: value, Date: data, UserId: id }, function (data, status) {
                if (status == "success") {
                    alert("Salvo com sucesso");
                    $('#area').html('');
                    location.reload();
                }
            })
        }else if ($('select#add').val() == "goals") {
            var name = $('#nomeMeta').val();
            var value = $('#valorMeta').val();
            var valueGoal = $('#valorMetaTotal').val();
            $.post('/Home/SaveGoals', { Name: name, Value: value, ValueGoal: valueGoal, UserId: id }, function (data, status) {
                if (status == "success") {
                    alert("Salvo com sucesso");
                    $('#area').html('');
                    location.reload();
                }
            })
        }
    })

    $('.trashBills').click(function () {
        var id = $(this).attr('value');
        let text = "Tem certeza que deseja excluir?";
        if (confirm(text)) {
            $.post('/Home/DeleteBills', { Id: id }, function (data, status) {
                location.reload();
            })
        }
    })

    $('.trashDebts').on('click', function () {
        var id = $(this).attr('value');
        let text = "Tem certeza que deseja excluir?";
        if (confirm(text)) {
            $.post('/Home/DeleteDebts', { Id: id }, function (data, status) {
                location.reload();
            })
        }
    })

    $('.statusDebts').on('click', function () {
        var id = $(this).parent().find('.trashDebts').attr('value');
        if ($(this).children().html() == "Pago") {
            return;
        }
        let text = "Tem certeza que essa divida foi paga?";
        if (confirm(text)) {
            $.post('/Home/UpdateDebts', { Id: id, Status: 1, UserId: id}, function (data, status) {
                location.reload();
            })
        }
    })

    $('.statusBills').on('click', function () {
        var id = $(this).parent().find('.trashBills').attr('value');
        if ($(this).children().html() == "Pago") {
            return;
        }
        let text = "Tem certeza que essa divida foi paga?";
        if (confirm(text)) {
            $.post('/Home/UpdateBills', { Id: id, Status: 1 }, function (data, status) {
                location.reload();
            })
        }
    })
})

