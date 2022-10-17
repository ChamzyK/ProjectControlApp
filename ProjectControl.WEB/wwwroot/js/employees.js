const API = '/api/employees'

function saveEmployee() {
    const employee = getJsonEmployee();

    if (ID.value == 0) {
        createEmployee(employee);
    }
    else {
        updateEmployee(employee);
    }

    reset();
}
function getJsonEmployee() {
    return JSON.stringify({
        employeeId: document.getElementById('idInput').value,
        lastName: document.getElementById('lastName').value,
        firstName: document.getElementById('firstName').value,
        patronymic: document.getElementById('patronymic').value,
        email: document.getElementById('email').value
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
        TBODY.append(createEmployeeTr(employee));
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
function appendButtons(tr, id) {
    const changeButton = createButton("Change", async () => await fillInputs(id));
    const deleteButton = createButton("Delete", async () => await deleteById(API, id));

    const changeBtnTd = createButtonTd(changeButton);
    const deleteBtnTd = createButtonTd(deleteButton);

    tr.append(changeBtnTd);
    tr.append(deleteBtnTd);
}

SAVE_BTN.addEventListener("click", saveEmployee);

async function fillInputs(id) {
    const employee = await getById(API, id);

    document.getElementById('idInput').value = employee.employeeId;
    document.getElementById('lastName').value = employee.lastName;
    document.getElementById('firstName').value = employee.firstName;
    document.getElementById('patronymic').value = employee.patronymic;
    document.getElementById('email').value = employee.email;
}

async function fillEmployeesTable() {
    const employees = await getAll(API);
    employees.forEach(employee => TBODY.append(createEmployeeTr(employee)));
}

fillEmployeesTable();