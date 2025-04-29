// Pie Chart: Applications Per Internship Role
// Mobile Menu Toggle Functionality
document.addEventListener('DOMContentLoaded', function () {
    const hamburger = document.querySelector('.hamburger-menu');
    const headerNav = document.querySelector('.header-nav');

    if (hamburger && headerNav) {
        hamburger.addEventListener('click', function () {
            headerNav.classList.toggle('mobile-open');
            this.setAttribute('aria-expanded',
                this.getAttribute('aria-expanded') === 'true' ? 'false' : 'true');
        });
    }
});

const roleCtx = document.getElementById('centerPieChart')?.getContext('2d');
if (roleCtx) {
    new Chart(roleCtx, {
        type: 'pie',
        data: {
            labels: ['Software Intern', 'Marketing Intern', 'Data Analyst', 'HR Intern', 'Business Analyst'],
            datasets: [{
                data: [45, 30, 60, 25, 55],
                backgroundColor: [
                    '#A2C5F4', '#FADADD ', '#FFE0B2', '#F7A99C', '#B8E0D2'
                ]
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Internship Applications by Role'
                },
                legend: {
                    position: 'top'
                }
            }
        }
    });
}


// Line Chart: Monthly Internship Applications
const lineCtx = document.getElementById('lineChart').getContext('2d');
new Chart(lineCtx, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'],
        datasets: [{
            label: 'Applications',
            data: [5, 10, 25, 40, 35, 20, 14, 26, 47, 35, 15, 5],
            borderColor: '#7C83FD',
            backgroundColor: '#E3E9FF',
            fill: true,
            tension: 0.4
        }]
    },
    options: {
        responsive: true,
        plugins: {
            title: { display: true, text: 'Monthly Internship Applications' }
        }
    }
});
// Bar Chart: Stipend vs Internship Duration by Field
const barCtx = document.getElementById('scatterChart')?.getContext('2d');
if (barCtx) {
    new Chart(barCtx, {
        type: 'bar',
        data: {
            labels: ['4 Months', '6 Months', '8 Months', '10 Months'],
            datasets: [
                {
                    label: 'IT',
                    data: [800, 950, 1200, null],
                    backgroundColor: '#E2D5F8'
                },
                {
                    label: 'Marketing',
                    data: [450, 600, 700, null],
                    backgroundColor: '#FFD8A9'
                },
                {
                    label: 'Finance',
                    data: [null, 1100, 1400, 1800],
                    backgroundColor: '#C7F0BD'
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Stipend vs Internship Duration by Field'
                },
                legend: {
                    position: 'top'
                }
            },
            scales: {
                y: {
                    title: {
                        display: true,
                        text: 'Monthly Stipend ($)'
                    },
                    beginAtZero: true
                },
                x: {
                    title: {
                        display: true,
                        text: 'Internship Duration'
                    }
                }
            }
        }
    });
}
