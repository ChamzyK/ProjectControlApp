const API = '/api/projects'

async function createProject(project) {
    const response = await fetch(API,
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: project
        });

    if (response.ok) {
        const project = await response.json();
        _tBody.append(createRow(project));
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
        getTr(project.projectId).replaceWith(createRow(project));
    }
    else {
        console.error("something wrong with updateProject function");
    }
}

function save() {
    const project = JSON.stringify({
        projectId: document.getElementById('idInput'),
        name: document.getElementById('name'),
        client: document.getElementById('client'),
        executor: document.getElementById('executor'),
        priority: document.getElementById('priority'),
        startDate: document.getElementById('startDate'),
        endDate: document.getElementById('endDate')
    })

    if (project.projectId === 0) {
        createProject(project);
    }
    else {
        updateProject(project);
    }

    reset();
}

function createRow(project) {
    const tr = createTr(project.projectId);

    appendContent(tr, project);
    appendButtons(tr, project.projectId);

    return tr;
}

function appendContent(tr, project) {
    tr.append(createTd(project.name));
    tr.append(createTd(project.client));
    tr.append(createTd(project.executor));
    tr.append(createTd(project.priority));

    const startDate = getSmallDate(project.startDate);
    tr.append(createTd(startDate));

    const endDate = getSmallDate(project.endDate);
    tr.append(createTd(endDate));
}

function appendButtons(tr, projectId) {
    const changeButton = createButton("Change", async () => await getById(API, projectId));
    const deleteButton = createButton("Delete", async () => await deleteById(API, projectId));

    tr.append(createButtonTd(changeButton));
    tr.append(createButtonTd(deleteButton));
}

SAVE_BTN.addEventListener("click", save);

getAll(API).forEach(project => _tBody.append(createRow(project)));
