
function setupChart(id, config) {
    // JS - Destroy exiting Chart Instance to reuse <canvas> element
    //let chartStatus = Chart.getChart(id); // <canvas> id
    //if (chartStatus != undefined) {
    //    chartStatus.destroy();
    //    //(or)
    //    // chartStatus.clear();
    //}
//-- End of chart destroy   
    const ctx = document.getElementById(id).getContext('2d');
    var id = new Chart(ctx, config);
}