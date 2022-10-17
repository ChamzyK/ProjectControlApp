const API = '/api/projects'

function saveProject() {
    if (isNotValid()) {
        return;
    }

    const project = getJsonProject();

    if (ID.value == 0) {
        createProject(project);
    }
    else {
        updateProject(project);
    }

    reset();
}

function isNotValid() {
    return isEmpty(document.getElementById('name').value) ||
        isEmpty(document.getElementById('client').value) ||
        isEmpty(document.getElementById('executor').value) ||
        isNaN(document.getElementById('priority').value) ||
        document.getElementById('startDate').value == '' ||
        document.getElementById('endDate').value == '';
}

function getJsonProject() {
    return JSON.stringify({
        projectId: document.getElementById('idInput').value,
        name: document.getElementById('name').value,
        client: document.getElementById('client').value,
        executor: document.getElementById('executor').value,
        priority: document.getElementById('priority').value,
        startDate: document.getElementById('startDate').value,
        endDate: document.getElementById('endDate').value
    });
}
async function createProject(project) {
    const response = await fetch(API,
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: project
        });

    if (response.ok) {
        const project = await response.json();
        TBODY.append(createProjectTr(project));
    }
    else {
        console.error("something wrong with createProject function");
    }
}
async function updateProject(project) {
    const response = await fetch(API,
        {
            method: "PUT",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: project
        });

    if (response.ok) {
        const project = await response.json();
        getTr(project.projectId).replaceWith(createProjectTr(project));
    }
    else {
        console.error("something wrong with updateProject function");
    }
}

function createProjectTr(project) {
    const tr = createTr(project.projectId);

    appendProject(tr, project);
    appendButtons(tr, project.projectId);

    return tr;
}
function appendProject(tr, project) {
    tr.append(createTd(project.name));
    tr.append(createTd(project.client));
    tr.append(createTd(project.executor));
    tr.append(createTd(project.priority));

    const startDate = getSmallDate(project.startDate);
    tr.append(createTd(startDate));

    const endDate = getSmallDate(project.endDate);
    tr.append(createTd(endDate));
}
function appendButtons(tr, id) {
    const changeButton = createButton("Change", async () => await fillInputs(id));
    const deleteButton = createButton("Delete", async () => await deleteById(API, id));

    const changeBtnTd = createButtonTd(changeButton);
    const deleteBtnTd = createButtonTd(deleteButton);

    tr.append(changeBtnTd);
    tr.append(deleteBtnTd);
}

SAVE_BTN.addEventListener("click", saveProject);

async function fillInputs(id) {
    const project = await getById(API, id);

    document.getElementById('idInput').value = project.projectId;
    document.getElementById('name').value = project.name;
    document.getElementById('client').value = project.client;
    document.getElementById('executor').value = project.executor;
    document.getElementById('priority').value = project.priority;

    const startDate = new Date(project.startDate);
    document.getElementById('startDate').value = `${startDate.getFullYear()}-${(startDate.getMonth() + 1).toString().padStart(2, 0)}-${startDate.getDate().toString().padStart(2, 0) }`;

    const endDate = new Date(project.endDate);
    document.getElementById('endDate').value = `${endDate.getFullYear()}-${(endDate.getMonth() + 1).toString().padStart(2, 0)}-${endDate.getDate().toString().padStart(2, 0)}`;
}

async function fillProjectsTable() {
    const projects = await getAll(API);
    projects.forEach(project => TBODY.append(createProjectTr(project)));
}

fillProjectsTable();
