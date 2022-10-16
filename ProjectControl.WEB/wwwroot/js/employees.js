const API = '/api/employees'

function saveEmployee() {
    const employee = getJsonEmployee();

    if (employee.employeeId === 0) {
        createEmployee(employee);
    }
    else {
        updateEmployee(employee);
    }

    reset();
}
function getJsonEmployee() {
    return JSON.stringify({
        employeeId: document.getElementById('idInput'),
        lastName: document.getElementById('lastName'),
        firstName: document.getElementById('firstName'),
        patronymic: document.getElementById('patronymic'),
        email: document.getElementById('email')
    });
}
async function createEmployee(employee) {
    const response = await fetch(API,
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: employee
        });

    if (response.ok) {
        const employee = await response.json();
        _tBody.append(createEmployeeTr(employee));
    }
    else {
        console.error("something wrong with createEmployee function");
    }
}
async function updateEmployee(employee) {
    const response = await fetch(API,
        {
            method: "PUT",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: employee
        });

    if (response.ok) {
        const employee = await response.json();
        getTr(employee.employeeId).replaceWith(createEmployeeTr(employee));
    }
    else {
        console.error("something wrong with updateEmployee function");
    }
}

function createEmployeeTr(employee) {
    const tr = createTr(employee.employeeId);

    appendEmployee(tr, employee);
    appendButtons(tr, employee.employeeId);

    return tr;
}
function appendEmployee(tr, employee) {
    tr.append(createTd(employee.lastName));
    tr.append(createTd(employee.firstName));
    tr.append(createTd(employee.patronymic));
    tr.append(createTd(employee.email));
}

SAVE_BTN.addEventListener("click", saveEmployee);

getAll(API).forEach(employee => _tBody.append(createEmployeeTr(employee)));