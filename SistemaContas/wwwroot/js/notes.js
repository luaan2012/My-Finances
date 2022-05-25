$(document).ready(function () {
    $("#titulo1,#titulo2,#titulo3").on("dblclick", function () {
        if ($('h5 > input').length > 0) {
            return;
        }
        var titulo = $(this).attr('id');
        var num = titulo.substring(6, 7)
        var wid = $('#conteudo').width();
        var container = $(this).text();
        var newElement = $('<input/>', { type: 'text', value: container, width: wid })
        $(this).html(newElement.bind('blur keydown', function (e) {
            var keyCode = e.which;
            if (keyCode == 13) {
                var newContainer = $(this).val();
                if (newContainer != "") {
                    $(this).parent().html(newContainer)
                    var title = newContainer;
                    var content = $('#anotacao' + num).text();
                    var id = $('#id' + num).text();

                    if (id == "-1") {
                        $.post('/Home/SaveNote', { Title: title, Content: content, Id: id, Titulo: titulo, Adicionar: "add" }, function (data) {
                            console.log(data)
                        })
                    }
                    else {
                        $.post('/Home/SaveNote', { Title: title, Content: content, Id: id, Titulo: titulo }, function (data) {
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

    $("#anotacao1,#anotacao2,#anotacao3").on("dblclick", function () {
        if ($('p > textarea').length > 0) {
            return;
        }
        var titulo = $(this).attr('id');
        var num = titulo.substring(8, 9)
        var alt = $('#conteudo').height();
        var wid = $('#conteudo').width();
        var container = $(this).text();
        var newElement = $('<textarea/>', { type: 'text', width: wid, height: alt }).html(container)
        $(this).html(newElement.bind('blur keydown', function (e) {
            var keyCode = e.which;
            if (keyCode == 13) {
                var newContainer = $(this).val();
                if (newContainer != "") {
                    $(this).parent().html(newContainer)
                }
                var content = newContainer;
                var title = $('#titulo' + num).text();
                var id = $('#id' + num).text();

                if (id == "-1") {
                    $.post('/Home/SaveNote', { Title: title, Content: content, Id: id, Titulo: titulo, Adicionar: "add" }, function (data) {
                        console.log(data)
                    })
                } else {
                    $.post('/Home/SaveNote', { Title: title, Content: content, Id: id, Titulo: titulo }, function (data) {
                        console.log(data)
                    })
                }
            }
            if (e.type == "blur") {
                $(this).parent().html(container);
            }
        }))

        $(this).children().select();
    });

    $("#excluir1,#excluir2,#excluir3").on("click", function () {
        let text = "Tem certeza que deseja excluir?";
        if (confirm(text) == true) {
            var excluir = $(this).attr('id')
            var num = excluir.substring(7)
            var id = $('#id' + num).text();

            console.log(excluir, id)
            $.post('/Home/ExcluirNote', { Excluir: excluir, Id: id }, function (data) {
                console.log(data)
            });

            $('#titulo' + num).html("Titulo");
            $('#anotacao' + num).html("Escreva algo aqui..");
        }

    });

    var debts = false;
    var today = false;
    var goals = false;
    var bills = false;

    $('select#add').on('click', function (e) {
        var options = $(this).val();
        if ($(this).val() == "Escolha uma opção") {
            $('#area').html('');
        }

        if (options == 'debts') {
            if (!debts) {
                $('#area').html('');
                var content = document.querySelector('#um').content;
                document.querySelector('#area').appendChild(
                document.importNode(content, true));
                debts = true;
            }
        }
        else {
            debts = false;
        }

        if (options == 'today') {
            if (!today) {
                $('#area').html('');
                var content = document.querySelector('#tres').content;
                document.querySelector('#area').appendChild(
                    document.importNode(content, true));
                today = true;
            }
        }
        else {
            today = false;
        }

        if (options == 'goals') {
            if (!goals) {
                $('#area').html('');
                var content = document.querySelector('#dois').content;
                document.querySelector('#area').appendChild(
                    document.importNode(content, true));
                goals = true;
            }
        }
        else {
            goals = false;
        }

        if (options == 'bills') {
            if (!bills) {
                $('#area').html('');
                var content = document.querySelector('#quatro').content;
                document.querySelector('#area').appendChild(
                    document.importNode(content, true));
                bills = true;
            }
        }
        else {
            bills = false;
        }
    })
})

