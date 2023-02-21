
document.body.classList.toggle('sb-sidenav-toggled');

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');

    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        if (localStorage.getItem('sb|sidebar-toggled') === 'true') {
            document.body.classList.toggle('sb-sidenav-toggled');
        }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

function moeda(a, e, r, t) {
    if (a.value.replace(/[^\d]/g, '').length > a.getAttribute("maxlength") - 1)
        return

    let n = "",
        h = j = 0,
        u = tamanho2 = 0,
        l = ajd2 = "",
        o = window.Event ? t.which : t.keyCode;
    if (13 == o || 8 == o)
        return !0;
    if (n = String.fromCharCode(o),
        -1 == "0123456789".indexOf(n))
        return !1;
    for (u = a.value.length,
        h = 0; h < u && ("0" == a.value.charAt(h) || a.value.charAt(h) == r); h++);
    for (l = ""; h < u; h++) - 1 != "0123456789".indexOf(a.value.charAt(h)) && (l += a.value.charAt(h));
    if (l += n, 0 == (u = l.length) && (a.value = ""), 1 == u && (a.value = "0" + r + "0" + l), 2 == u && (a.value = "0" + r + l), u > 2) {
        for (ajd2 = "",
            j = 0,
            h = u - 3; h >= 0; h--)
            3 == j && (ajd2 += e,
                j = 0),
                ajd2 += l.charAt(h),
                j++;
        for (a.value = "",
            tamanho2 = ajd2.length,
            h = tamanho2 - 1; h >= 0; h--)
            a.value += ajd2.charAt(h);
        a.value += r + l.substr(u - 2, u)
    }
    return !1
}

$(document).ready(function () {
    
    var alt = $('.metas').height();
    $('.anotacoes').height(`${alt}` + 'px')

    var soma = 0;
    var cont = 0;
    $('span.float-right').each(function () {
        soma += parseInt($(this).html().replace("%", ""));
        cont++;
    })
    var total = soma / cont;
    $('.porc').html((total > 0 ? total : 0).toFixed(2) + '%');
    $('.goal').css('width', soma / cont + '%')

    $('.fechar').on('click', function () {
        $('#add').val('Escolha uma opção');
        $('#area').html('');
    })

    var verification = true;

    function verificarData() {
        if (verification) {
            $('#dataGanhos').val('');
            $('#dataGanhos').css('display', 'inline');
            $('#dataGanhos').attr('type', 'date');
            $('#dataGanhosDate').show();
            verification = false;
        }
    }

})

function limparLembrete() {
    $('#hora').val('');
    $('#data').val('');
}

function excluirNotificacao(id) {
    if (window.confirm('Deseja excluir essa notificação?')) {
        $.post('/Home/DeleteRemember', { Id: id }, function () {
            $(`.mb-0[data-atr="${id}`).remove();
        })
    }
}

function trashGoal(id) {
    if (window.confirm('Deseja excluir essa meta?')) {
        $.post('/Home/DeleteGoal', { Id: id }, function () {
            $(`.trashGoal[data-atr="${id}`).remove();
            $(`.trashGoalDiv[data-atr="${id}`).remove(); 
            window.location.reload()
        })
    }
}

