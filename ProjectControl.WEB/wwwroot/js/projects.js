const API = '/api/projects'

function saveProject() {
    const project = getJsonProject();

    if (project.projectId === 0) {
        createProject(project);
    }
    else {
        updateProject(project);
    }

    reset();
}
function getJsonProject() {
    return JSON.stringify({
        projectId: document.getElementById('idInput'),
        name: document.getElementById('name'),
        client: document.getElementById('client'),
        executor: document.getElementById('executor'),
        priority: document.getElementById('priority'),
        startDate: document.getElementById('startDate'),
        endDate: document.getElementById('endDate')
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
        _tBody.append(createProjectTr(project));
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

SAVE_BTN.addEventListener("click", saveProject);

getAll(API).forEach(project => _tBody.append(createProjectTr(project)));
