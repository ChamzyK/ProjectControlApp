async function getEmployees() {
    const response = await fetch("/api/employees",
        {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
    if (response.ok === true) {
        const employees = await response.json();
        const rows = document.querySelector("tbody");
        employees.forEach(employee => rows.append(row(employee)));
    }
    else {
        alert("Something wrong");
    }
}

async function getEmployee(id) {
    const response = await fetch(`/api/employees/${id}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        const employee = await response.json();

        document.getElementById("employeeId").value = employee.employeeId;
        document.getElementById("firstName").value = employee.firstName;
        document.getElementById("lastName").value = employee.lastName;
        document.getElementById("patronymic").value = employee.patronymic;
        document.getElementById("email").value = employee.email;
    }
    else {
        alert("Something wrong");
    }
}

async function createEmployee(lastName, firstName, patronymic, email) {
    const response = await fetch("/api/employees",
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                lastName,
                firstName,
                patronymic,
                email
            })
        });

    if (response.ok) {
        const employee = await response.json();
        document.querySelector("tbody").append(row(employee));
    }
    else {
        alert("Something wrong");
    }
}

async function updateEmployee(employeeId, lastName, firstName, patronymic, email) {
    const response = await fetch("/api/employees",
        {
            method: "PUT",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify(
                {
                    employeeId,
                    lastName,
                    firstName,
                    patronymic,
                    email
                })
        });

    if (response.ok) {
        const employee = await response.json();
        document.querySelector(`tr[data-rowid='${employee.employeeId}']`).replaceWith(row(employee))
    }
    else {
        alert("Something wrong");
    }
}

async function deleteEmployee(id) {
    const response = await fetch(`/api/employees/${id}`, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok) {
        const employee = await response.json();
        document.querySelector(`tr[data-rowid='${employee.employeeId}']`).remove();
    }
    else {
        alert("Something wrong");
    }
}

function reset() {
    document.getElementById("employeeId").value = "";
    document.getElementById("firstName").value = "";
    document.getElementById("lastName").value = "";
    document.getElementById("patronymic").value = "";
    document.getElementById("email").value = "";
}

async function save() {
    const employeeId = document.getElementById("employeeId").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const patronymic = document.getElementById("patronymic").value;
    const email = document.getElementById("email").value;

    if (employeeId === "") {
        await createEmployee(lastName, firstName, patronymic, email);
    }
    else {
        await updateEmployee(employeeId, lastName, firstName, patronymic, email);
    }
    reset();
}

function row(employee) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", employee.employeeId);

    const lastNameTd = document.createElement("td");
    lastNameTd.append(employee.lastName);
    tr.append(lastNameTd);

    const firstNameTd = document.createElement("td");
    firstNameTd.append(employee.firstName);
    tr.append(firstNameTd);

    const patronymicTd = document.createElement("td");
    patronymicTd.append(employee.patronymic);
    tr.append(patronymicTd);

    const emailTd = document.createElement("td");
    emailTd.append(employee.email);
    tr.append(emailTd);

    const projectsTd = document.createElement("td");
    projectsTd.append(employee.projects);
    tr.append(projectsTd);

    const buttonsTd = document.createElement("td");

    const updateButton = document.createElement("button");
    updateButton.append("Change");
    updateButton.addEventListener("click", async () => await getEmployee(employee.employeeId));
    buttonsTd.append(updateButton);

    const deleteButton = document.createElement("button");
    deleteButton.append("Delete");
    deleteButton.addEventListener("click", async () => await deleteEmployee(employee.employeeId));

    buttonsTd.append(deleteButton);
    tr.appendChild(buttonsTd);

    return tr;
}

document.getElementById("resetButton").addEventListener("click", () => reset());

document.getElementById("saveButton").addEventListener("click", () => save());

getEmployees();