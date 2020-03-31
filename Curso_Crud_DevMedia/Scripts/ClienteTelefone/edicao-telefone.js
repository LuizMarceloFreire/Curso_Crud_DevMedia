$(function () {
    let qtdeTelefone = $("#div-telefones .row").length;

    $("#btn-add-telefone").click(function (e) {
        e.preventDefault();

        let divTelefone = '<div class="row">' +
            '<div class="col-md-2">' +
            '<input type="number" name="Telefones[' + qtdeTelefone + '].DDD" maxlength="2" placeholder="DDD" class="form-control txt-ddd" />' +
            '</div>' +

            '<div class="col-md-5">' +
            '<input type="text" name="Telefones[' + qtdeTelefone +'].Numero" placeholder="Número" class="form-control txt-numero" />' +
            '</div>' +

            '<div class="col-md-3">' +
            '<select name="Telefones[' + qtdeTelefone + '].TipoTelefone" class="form-control sel-tipo">' +
            'option value="0">Residencial</option>' +
            '<option value="1">Comercial</option>' +
            '<option value="2">Celular</option>' +
            ' <option value="3">Recado</option>' +
            '</select>' +
            '</div>' +

            '<div class="col-md-2">' +
            '<button class="btn btn-danger btn-remover-telefone">' +
            '<span class="glyphicon glyphicon-trash"></span>' +
            '</button>' +
            '</div>' +
            '</div>';

        $('#div-telefones').append(divTelefone);

        qtdeTelefone++;
    });

    $("#div-telefones").on("click", ".btn-remover-telefone", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        if (id) {
            $.post("/Cliente/RemoverTelefone?id=" + id);
        }
        $(this).parent().parent().remove();

        qtdeTelefone--;

        $("#div-telefones .row").each(function (indice, elemento) {
            $(elemento).find(".txt-ddd").attr("name", "Telefones[" + indice + "].DDD");
            $(elemento).find(".txt-numero").attr("name", "Telefones[" + indice + "].Numero");
            $(elemento).find(".sel-tipo").attr("name", "Telefones[" + indice + "].TipoTelefone");
        });
    });
});
