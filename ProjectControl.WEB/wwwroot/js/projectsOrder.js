const NAME_ID = 0;
const CLIENT_ID = 1;
const EXECUTOR_ID = 2;
const PRIORITY_ID = 3;
const START_DATE_ID = 4;
const END_DATE_ID = 5;

document.getElementById("nameTh").addEventListener('click', () => orderProjects(NAME_ID, stringComparator));
document.getElementById("clientTh").addEventListener('click', () => orderProjects(CLIENT_ID, stringComparator));
document.getElementById("executorTh").addEventListener('click', () => orderProjects(EXECUTOR_ID, stringComparator));
document.getElementById("priorityTh").addEventListener('click', () => orderProjects(PRIORITY_ID, numberComparator));
document.getElementById("startDateTh").addEventListener('click', () => orderProjects(START_DATE_ID, dateComparator));
document.getElementById("endDateTh").addEventListener('click', () => orderProjects(END_DATE_ID, dateComparator));