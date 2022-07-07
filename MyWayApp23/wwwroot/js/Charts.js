window.setup = (id, config) => {
    var ctx = document.getElementById(id).getContext('2d');
    let chartStatus = Chart.getChart(id);
    if (chartStatus != undefined) {
        chartStatus.destroy();
    }
    new Chart(ctx, config);
}