const API = '/api/employees'

async function createEmployee(employee) {
    const response = await fetch(API,
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: employee
        });

    if (response.ok) {
        const employee = await response.json();
        _tBody.append(createRow(employee));
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
        getTr(employee.employeeId).replaceWith(createRow(employee));
    }
    else {
        console.error("something wrong with updateEmployee function");
    }
}

function saveEmployee() {
    const employee = JSON.stringify({
        employeeId: document.getElementById('idInput'),
        lastName: document.getElementById('lastName'),
        firstName: document.getElementById('firstName'),
        patronymic: document.getElementById('patronymic'),
        email: document.getElementById('email')
    })

    if (employee.employeeId === 0) {
        createEmployee(employee);
    }
    else {
        updateEmployee(employee);
    }

    reset();
}

function createRow(employee) {
    const tr = createTr(employee.employeeId);

    appendContent(tr, employee);
    appendButtons(tr, employee.employeeId);

    return tr;
}

function appendContent(tr, employee) {
    tr.append(createTd(employee.lastName));
    tr.append(createTd(employee.firstName));
    tr.append(createTd(employee.patronymic));
    tr.append(createTd(employee.email));
}

function appendButtons(tr, employeeId) {
    const changeButton = createButton("Change", async () => await getById(API, employeeId));
    const deleteButton = createButton("Delete", async () => await deleteById(API, employeeId));

    tr.append(createButtonTd(changeButton));
    tr.append(createButtonTd(deleteButton));
}

SAVE_BTN.addEventListener("click", saveEmployee);

getAll(API).forEach(employee => _tBody.append(createRow(employee)));