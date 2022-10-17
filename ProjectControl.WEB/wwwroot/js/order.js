const STATE_DEFAULT = -1;

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
    const sortedRows = Array.from(mainTable.rows)
        .slice(1)
        .sort(compareFn);

    mainTable.tBodies[0].append(...sortedRows);
}


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
    const splittedA = a.split('.')
    const splittedB = b.split('.')

    const dateA = new Date(splittedA[2], splittedA[1], splittedA[0]);
    const dateB = new Date(splittedB[2], splittedB[1], splittedB[0]);

    return dateA - dateB;
}