const ID_QUALIFIED_NAME = 'data-rowid'

const INPUTS_DIV = document.getElementById('inputsDiv');
const ID = document.getElementById("idInput");
const TBODY = document.getElementById("tBody");
const SAVE_BTN = document.getElementById('saveButton');
const RESET_BTN = document.getElementById('resetButton');

async function getAll(api) {
    const response = await fetch(api,
        {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
    if (response.ok) {
        return await response.json();
    }
    else {
        console.error("Something wrong with getEntities function")
    }
}
async function getById(api, id) {
    const response = await fetch(`${api}/${id}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok) {
        return await response.json();
    }
    else {
        console.error("something wrong with get(id) function");
    }
}
async function deleteById(api, id) {
    const response = await fetch(`${api}/${id}`, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        getTr(id).remove();
    }
    else {
        console.error("something wrong with delete function");
    }
}

RESET_BTN.addEventListener('click', reset);
function reset() {
    const inputs = INPUTS_DIV.getElementsByTagName('input');

    for (let i = 0; i < inputs.length; i++) {
        inputs[i].value = '';
    }
    ID.value = 0;
}

function createButton(text, clickFunc) {
    const button = document.createElement("button");
    button.innerHTML = text;
    button.onclick = clickFunc;
    return button;
}
function createButtonTd(button) {
    const td = document.createElement('td');
    td.append(button);
    return td;
}

function createTr(id) {
    const tr = document.createElement("tr");
    tr.setAttribute(ID_QUALIFIED_NAME, id);

    return tr;
}
function getTr(id) {
    const selector = `tr[${ID_QUALIFIED_NAME}='${id}']`;
    return document.querySelector(selector);
}
function createTd(text) {
    const td = document.createElement("td");
    td.append(text);

    return td;
}

function getSmallDate(dateString) {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, 0);
    const month = (date.getMonth() + 1).toString().padStart(2, 0);
    const year = date.getFullYear();
    return `${day}.${month}.${year}`;
}

