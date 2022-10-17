const LAST_NAME_ID = 0;
const FIRST_NAME_ID = 1;
const PATRONYMIC_ID = 2;
const EMAIL_ID = 3;

document.getElementById("lastNameTh").addEventListener('click', () => orderProjects(LAST_NAME_ID, stringComparator));
document.getElementById("firstNameTh").addEventListener('click', () => orderProjects(FIRST_NAME_ID, stringComparator));
document.getElementById("patronymicTh").addEventListener('click', () => orderProjects(PATRONYMIC_ID, stringComparator));
document.getElementById("emailTh").addEventListener('click', () => orderProjects(EMAIL_ID, stringComparator));