function parseJsonDate(jsonDate) {
    let parsedDate = new Date(parseInt(jsonDate.substr(6)));
    return parsedDate.toLocaleDateString();
}

function formatCurrency(value) {
    return new Intl.NumberFormat('it-IT', { style: 'currency', currency: 'EUR' }).format(value);
}

$(document).ready(function () {
    $("#cerca").click(function () {
        $("#tablePren").slideDown();
        var cf = $("#CF").val();
        $.ajax({
            method: 'POST',
            url: "getPrenotazioneByCF",
            data: { cf: cf },
            success: function (data) {
                $("#tablePren tbody").empty();
                $.each(data, function (i, v) {
                    var row = "<tr><td>" + v.IdCliente + "</td><td>" + v.IdCamera + "</td><td>" + parseJsonDate(v.InizioSoggiorno) + "</td><td>" + parseJsonDate(v.FineSoggiorno) + "</td><td>" + formatCurrency(v.Caparra) + "</td><td>" + formatCurrency(v.Tariffa) + "</td></tr>";
                    $("#tablePren tbody").append(row);
                })
            }
        })
    })

    $("#pensioneCompleta").click(function () {
        $("#tablePren2").slideDown();
        $.ajax({
            method: "GET",
            url: "getPrenotazionePensioneCompleta",
            success: function (data) {
                $("#tablePren2 tbody").empty();
                $.each(data, function (i, v) {
                    var row = "<tr><td>" + v.IdCliente + "</td><td>" + v.IdCamera + "</td><td>" + parseJsonDate(v.InizioSoggiorno) + "</td><td>" + parseJsonDate(v.FineSoggiorno) + "</td><td>" + formatCurrency(v.Caparra) + "</td><td>" + formatCurrency(v.Tariffa) + "</td></tr>";
                    $("#tablePren2 tbody").append(row);
                })
            }
        })
    })
})