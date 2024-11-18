let charts = {};

window.destroyChart = function(chartId) {
    if (charts[chartId]) {
        charts[chartId].destroy();
        delete charts[chartId];
    }
}

window.renderDepartmentChart = function(labels, data) {
    var ctx = document.getElementById('departmentChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Employees per Department',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.6)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

window.renderEmployeeFlowChart = function(labels, currentYearJoinData, currentYearLeaveData,
                                          lastYearJoinData, lastYearLeaveData, lastYear, currentYear) {
    var ctx = document.getElementById('employeeFlowChart').getContext('2d');

    charts['employeeFlowChart'] = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: `Joins ${currentYear}`,
                    data: currentYearJoinData,
                    borderColor: '#4CAF50',
                    backgroundColor: 'rgba(76, 175, 80, 0.1)',
                    tension: 0.4
                },
                {
                    label: `Leaves ${currentYear}`,
                    data: currentYearLeaveData,
                    borderColor: '#f44336',
                    backgroundColor: 'rgba(244, 67, 54, 0.1)',
                    tension: 0.4
                },
                {
                    label: `Joins ${lastYear}`,
                    data: lastYearJoinData,
                    borderColor: '#2196F3',
                    backgroundColor: 'rgba(33, 150, 243, 0.1)',
                    tension: 0.4,
                    borderDash: [5, 5]
                },
                {
                    label: `Leaves ${lastYear}`,
                    data: lastYearLeaveData,
                    borderColor: '#FF9800',
                    backgroundColor: 'rgba(255, 152, 0, 0.1)',
                    tension: 0.4,
                    borderDash: [5, 5]
                }
            ]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Number of Employees'
                    }
                }
            },
            plugins: {
                title: {
                    display: true,
                    text: 'Employee Join/Leave Trends'
                }
            }
        }
    });
}