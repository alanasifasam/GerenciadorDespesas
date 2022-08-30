﻿
//carregar valores do grafico sempre que a lista de seleção mudar. 
$(".escolhaMes").on('change', function () {
    var mesId = $(".escolhaMes").val();


    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: mesId },
        success: function (dados) {
            $("canvas#GraficoGastoTotalMes").remove();
            $("div.GraficoGastoTotalMes").append('<canvas id="GraficoGastoTotalMes" style="width:400px; height:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets:
                        [{
                            label: "Total gasto",
                            backgroundColor: ["#27ae60", "#c0392b"],
                            data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                        }]

                },
                options:
                {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }

            });
        }

    });
});



 function CarregarDadosGastosTotaisMes() {
    


    $.ajax({
        url: "Despesas/GastosTotaisMes",
        method: "POST",
        data: { mesId: 1 },
        success: function (dados) {
            $("canvas#GraficoGastoTotalMes").remove();
            $("div.GraficoGastoTotalMes").append('<canvas id="GraficoGastoTotalMes" style="width:400px; height:400px;"></canvas>');

            var ctx = document.getElementById('GraficoGastoTotalMes').getContext('2d');

            var grafico = new Chart(ctx, {
                type: 'doughnut',

                data:
                {
                    labels: ['Restante', 'Total gasto'],
                    datasets:
                        [{
                            label: "Total gasto",
                            backgroundColor: ["#27ae60","#c0392b"],
                            data: [(dados.salario - dados.valorTotalGasto), dados.valorTotalGasto]
                        }]

                },
                options:
                {
                    responsive: false,
                    title: {
                        display: true,
                        text: "Total gasto no Mês"
                    }
                }

            });
        }

    });
}