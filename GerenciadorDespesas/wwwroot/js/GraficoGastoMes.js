﻿
//carregar valores do grafico sempre que a lista de seleção mudar. 
$(".escolhaMes").on('change', function () {
    var mesId = $(".escolhaMes").val();


    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastosMes").remove();
            $("div.GraficoGastosMes").append('<canvas id="GraficoGastosMes" style="width:400px; height:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets:
                        [{
                            label: "Gastos por despesas",
                            backgroundColor: PegarCores(dados.length),
                            hoverBackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }]

                },
                options:
                {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }

            });
        }

    });
});



function CarregarDadosGastosMes() {
    var mesId = $(".escolhaMes").val();


    $.ajax({
        url: "Despesas/GastoMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastosMes").remove();
            $("div.GraficoGastosMes").append('<canvas id="GraficoGastosMes" style="width:400px; height:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastosMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: PegarTiposDespesas(dados),
                    datasets:
                        [{
                            label: "Gastos por despesas",
                            backgroundColor: PegarCores(dados.length),
                            hoverBackgroundColor: PegarCores(dados.length),
                            data: PegarValores(dados)
                        }]

                },
                options:
                {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Gastos por despesa"
                    }
                }

            });
        }

    });
}

