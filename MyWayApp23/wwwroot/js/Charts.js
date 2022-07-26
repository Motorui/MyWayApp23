window.paxDemandChart = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let dias = chartData.map(a => a.dias);
    let total = chartData.map(a => a.total);
    let partidas = chartData.map(a => a.partidas);
    let chegadas = chartData.map(a => a.chegadas);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: dias,
            datasets: [{
                label: 'Total',
                data: total,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Dep.',
                data: partidas,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Arr.',
                data: chegadas,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: true
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
}

window.demandByShiftChart = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let dias = chartData.map(a => a.dias);
    let manha = chartData.map(a => a.manha);
    let tarde = chartData.map(a => a.tarde);
    let noite = chartData.map(a => a.noite);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: dias,
            datasets: [{
                label: 'Manha',
                data: manha,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Tarde',
                data: tarde,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Noite',
                data: noite,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: true
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false
        }
    });
}

window.demandByWeekDay = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let diaSemana = chartData.map(a => a.diaSemana);
    let jan = chartData.map(a => a.jan);
    let fev = chartData.map(a => a.fev);
    let mar = chartData.map(a => a.mar);
    let abr = chartData.map(a => a.abr);
    let mai = chartData.map(a => a.mai);
    let jun = chartData.map(a => a.jun);
    let jul = chartData.map(a => a.jul);
    let ago = chartData.map(a => a.ago);
    let set = chartData.map(a => a.set);
    let out = chartData.map(a => a.out);
    let nov = chartData.map(a => a.nov);
    let dez = chartData.map(a => a.dez);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: diaSemana,
            datasets: [{
                label: 'Jan',
                data: jan,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Fev',
                data: fev,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Mar',
                data: mar,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Abr',
                data: abr,
                backgroundColor: [
                    'rgba(204, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Mai',
                data: mai,
                backgroundColor: [
                    'rgba(204, 102, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 102, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Jun',
                data: jun,
                backgroundColor: [
                    'rgba(204, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Jul',
                data: jul,
                backgroundColor: [
                    'rgba(102, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Ago',
                data: ago,
                backgroundColor: [
                    'rgba(0, 204, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 204, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Set',
                data: set,
                backgroundColor: [
                    'rgba(0, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Out',
                data: out,
                backgroundColor: [
                    'rgba(102, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Nov',
                data: nov,
                backgroundColor: [
                    'rgba(204, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Dez',
                data: dez,
                backgroundColor: [
                    'rgba(96, 96, 96, 0.25)'
                ],
                borderColor: [
                    'rgba(96, 96, 96, 1)'
                ],
                borderWidth: 1,
                fill: true
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        filter: (legendItem, chartData) => (!chartData.datasets[legendItem.datasetIndex].data.every(item => item === 0))
                    }
                }
            }
        }
    });
}

window.remoteParkingDemand = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let diaSemana = chartData.map(a => a.diaSemana);
    let jan = chartData.map(a => a.jan);
    let fev = chartData.map(a => a.fev);
    let mar = chartData.map(a => a.mar);
    let abr = chartData.map(a => a.abr);
    let mai = chartData.map(a => a.mai);
    let jun = chartData.map(a => a.jun);
    let jul = chartData.map(a => a.jul);
    let ago = chartData.map(a => a.ago);
    let set = chartData.map(a => a.set);
    let out = chartData.map(a => a.out);
    let nov = chartData.map(a => a.nov);
    let dez = chartData.map(a => a.dez);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: diaSemana,
            datasets: [{
                label: 'Jan',
                data: jan,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Fev',
                data: fev,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Mar',
                data: mar,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Abr',
                data: abr,
                backgroundColor: [
                    'rgba(204, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Mai',
                data: mai,
                backgroundColor: [
                    'rgba(204, 102, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 102, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Jun',
                data: jun,
                backgroundColor: [
                    'rgba(204, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Jul',
                data: jul,
                backgroundColor: [
                    'rgba(102, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Ago',
                data: ago,
                backgroundColor: [
                    'rgba(0, 204, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 204, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Set',
                data: set,
                backgroundColor: [
                    'rgba(0, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Out',
                data: out,
                backgroundColor: [
                    'rgba(102, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Nov',
                data: nov,
                backgroundColor: [
                    'rgba(204, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: 'Dez',
                data: dez,
                backgroundColor: [
                    'rgba(96, 96, 96, 0.25)'
                ],
                borderColor: [
                    'rgba(96, 96, 96, 1)'
                ],
                borderWidth: 1,
                fill: true
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        filter: (legendItem, chartData) => (!chartData.datasets[legendItem.datasetIndex].data.every(item => item === 0))
                    }
                }
            }
        }
    });
}

window.preNotificationChart = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let dias = chartData.map(a => a.dias);
    let total = chartData.map(a => a.total);
    let nnotif = chartData.map(a => a.nNotif);
    let notif = chartData.map(a => a.notif);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: dias,
            datasets: [{
                label: 'Total',
                data: total,
                backgroundColor: [
                    'rgba(0, 0, 255, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 255, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: '>36h',
                data: nnotif,
                backgroundColor: [
                    'rgba(0, 255, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 255, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: '<36h',
                data: notif,
                backgroundColor: [
                    'rgba(255, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: true
            }
            ]
        },
        options: {
            locale: 'pt-PT',
            responsive: true,
            maintainAspectRatio: false
        }
    });
}

window.nonNotifiedVsPaxDemand = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let dias = chartData.map(a => a.dias);
    let total = chartData.map(a => a.total);
    let notif = chartData.map(a => a.notif);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: dias,
            datasets: [{
                label: 'Total',
                yAxisID: 'A',
                data: total,
                backgroundColor: [
                    'rgba(0, 0, 255, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 255, 1)'
                ],
                borderWidth: 1,
                fill: true
            },
            {
                label: '%<36h',
                yAxisID: 'B',
                data: notif,
                backgroundColor: [
                    'rgba(255, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: false,
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            let label = context.dataset.label;
                            let value = context.formattedValue;

                            if (!label)
                                label = 'Unknown'

                            let percentage = value + '%';
                            return label + ": " + percentage;
                        }
                    }
                }
            }
            ]
        },
        options: {
            locale: 'pt-PT',
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                A: {
                    type: 'linear',
                    position: 'left',
                },
                B: {
                    type: 'linear',
                    position: 'right',
                    ticks: {
                        beginAtZero: true,
                        max: 100,
                        min: 0,
                        precision: 0,
                        callback: function (label) {
                            return label + "%"
                        }
                    }
                }
            },
        }
    });
}

window.avgNonNotifiedChart = (id, chartLabels, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }


    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: chartLabels,
            datasets: [{
                axis: 'y',
                label: '%>36h',
                data: chartData,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)',
                    'rgba(54, 162, 235, 0.25)',
                    'rgba(255, 205, 86, 0.25)',
                    'rgba(204, 0, 0, 0.25)',
                    'rgba(204, 102, 0, 0.25)',
                    'rgba(204, 204, 0, 0.25)',
                    'rgba(102, 204, 0, 0.25)',
                    'rgba(0, 204, 204, 0.25)',
                    'rgba(0, 0, 204, 0.25)',
                    'rgba(102, 0, 204, 0.25)',
                    'rgba(204, 0, 204, 0.25)',
                    'rgba(96, 96, 96, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 205, 86, 1)',
                    'rgba(204, 0, 0, 1)',
                    'rgba(204, 102, 0, 1)',
                    'rgba(204, 204, 0, 1)',
                    'rgba(102, 204, 0, 1)',
                    'rgba(0, 204, 204, 1)',
                    'rgba(0, 0, 204, 1)',
                    'rgba(102, 0, 204, 1)',
                    'rgba(204, 0, 204, 1)',
                    'rgba(96, 96, 96, 1)'
                ],
                borderWidth: 1,
                fill: false,
                tooltip: {
                    callbacks: {
                        label: function (context) {
                            let label = context.dataset.label;
                            let value = context.formattedValue;

                            if (!label)
                                label = 'Unknown'

                            let percentage = value + '%';
                            return label + ": " + percentage;
                        }
                    }
                }
            }
            ]
        },
        options: {
            indexAxis: 'y',
            locale: 'pt-PT',
            responsive: true,
            maintainAspectRatio: false
        }
    });
}

window.nonNotifiedTotalByHourChart = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let horas = chartData.map(a => a.hora);
    let jan = chartData.map(a => a.jan);
    let fev = chartData.map(a => a.fev);
    let mar = chartData.map(a => a.mar);
    let abr = chartData.map(a => a.abr);
    let mai = chartData.map(a => a.mai);
    let jun = chartData.map(a => a.jun);
    let jul = chartData.map(a => a.jul);
    let ago = chartData.map(a => a.ago);
    let set = chartData.map(a => a.set);
    let out = chartData.map(a => a.out);
    let nov = chartData.map(a => a.nov);
    let dez = chartData.map(a => a.dez);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: horas,
            datasets: [{
                label: 'Jan',
                data: jan,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Fev',
                data: fev,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Mar',
                data: mar,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Abr',
                data: abr,
                backgroundColor: [
                    'rgba(204, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Mai',
                data: mai,
                backgroundColor: [
                    'rgba(204, 102, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 102, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Jun',
                data: jun,
                backgroundColor: [
                    'rgba(204, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Jul',
                data: jul,
                backgroundColor: [
                    'rgba(102, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Ago',
                data: ago,
                backgroundColor: [
                    'rgba(0, 204, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 204, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Set',
                data: set,
                backgroundColor: [
                    'rgba(0, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Out',
                data: out,
                backgroundColor: [
                    'rgba(102, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Nov',
                data: nov,
                backgroundColor: [
                    'rgba(204, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Dez',
                data: dez,
                backgroundColor: [
                    'rgba(96, 96, 96, 0.25)'
                ],
                borderColor: [
                    'rgba(96, 96, 96, 1)'
                ],
                borderWidth: 1,
                fill: false
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        filter: (legendItem, chartData) => (!chartData.datasets[legendItem.datasetIndex].data.every(item => item === 0))
                    }
                }
            }
        }
    });
}

window.nonNotifiedByWeekdayChart = (id, chartData) => {
    const ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }

    let diaSemana = chartData.map(a => a.diaSemana);
    let jan = chartData.map(a => a.jan);
    let fev = chartData.map(a => a.fev);
    let mar = chartData.map(a => a.mar);
    let abr = chartData.map(a => a.abr);
    let mai = chartData.map(a => a.mai);
    let jun = chartData.map(a => a.jun);
    let jul = chartData.map(a => a.jul);
    let ago = chartData.map(a => a.ago);
    let set = chartData.map(a => a.set);
    let out = chartData.map(a => a.out);
    let nov = chartData.map(a => a.nov);
    let dez = chartData.map(a => a.dez);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: diaSemana,
            datasets: [{
                label: 'Jan',
                data: jan,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Fev',
                data: fev,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.25)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Mar',
                data: mar,
                backgroundColor: [
                    'rgba(255, 205, 86, 0.25)'
                ],
                borderColor: [
                    'rgba(255, 205, 86, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Abr',
                data: abr,
                backgroundColor: [
                    'rgba(204, 0, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Mai',
                data: mai,
                backgroundColor: [
                    'rgba(204, 102, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 102, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Jun',
                data: jun,
                backgroundColor: [
                    'rgba(204, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Jul',
                data: jul,
                backgroundColor: [
                    'rgba(102, 204, 0, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 204, 0, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Ago',
                data: ago,
                backgroundColor: [
                    'rgba(0, 204, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 204, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Set',
                data: set,
                backgroundColor: [
                    'rgba(0, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(0, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Out',
                data: out,
                backgroundColor: [
                    'rgba(102, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(102, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Nov',
                data: nov,
                backgroundColor: [
                    'rgba(204, 0, 204, 0.25)'
                ],
                borderColor: [
                    'rgba(204, 0, 204, 1)'
                ],
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Dez',
                data: dez,
                backgroundColor: [
                    'rgba(96, 96, 96, 0.25)'
                ],
                borderColor: [
                    'rgba(96, 96, 96, 1)'
                ],
                borderWidth: 1,
                fill: false
            }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    labels: {
                        filter: (legendItem, chartData) => (!chartData.datasets[legendItem.datasetIndex].data.every(item => item === 0))
                    }
                }
            }
        }
    });
}
