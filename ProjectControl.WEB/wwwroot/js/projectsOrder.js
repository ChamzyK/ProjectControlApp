const STATE_DEFAULT = -1;
const NAME_ID = 0;
const CLIENT_ID = 1;
const EXECUTOR_ID = 2;
const PRIORITY_ID = 3;
const START_DATE_ID = 4;
const END_DATE_ID = 5;

let _orderState = STATE_DEFAULT;

function orderProjects(cellId, comparator) {
    let compareFn;
    if (_orderState === cellId) {
        compareFn = (a, b) => comparator(b.cells[cellId].innerHTML, a.cells[cellId].innerHTML);
        _orderState = STATE_DEFAULT;
    }
    else {
        compareFn = (a, b) => comparator(a.cells[cellId].innerHTML, b.cells[cellId].innerHTML);
        _orderState = cellId;
    }
    orderTable(compareFn);
}
function orderTable(compareFn) {
    const sortedRows = Array.from(projectsTable.rows)
        .slice(1)
        .sort(compareFn);

    projectsTable.tBodies[0].append(...sortedRows);
}

document.getElementById("nameTh").addEventListener('click', () => orderProjects(NAME_ID, stringComparator));
document.getElementById("clientTh").addEventListener('click', () => orderProjects(CLIENT_ID, stringComparator));
document.getElementById("executorTh").addEventListener('click', () => orderProjects(EXECUTOR_ID, stringComparator));
document.getElementById("priorityTh").addEventListener('click', () => orderProjects(PRIORITY_ID, numberComparator));
document.getElementById("startDateTh").addEventListener('click', () => orderProjects(START_DATE_ID, dateComparator));
document.getElementById("endDateTh").addEventListener('click', () => orderProjects(END_DATE_ID, dateComparator));

function stringComparator(a, b) {
    const nameA = a.toLowerCase();
    const nameB = b.toLowerCase();

    if (nameA < nameB) return -1;
    if (nameA > nameB) return 1;

    return 0;
}
function numberComparator(a, b) {
    return a - b;
}
function dateComparator(a, b) {
    const dateA = new Date(a);
    const dateB = new Date(b);

    return dateA - dateB;
}