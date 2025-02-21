function solve() {
    let firstNameFieldElement = document.querySelector('input[name="firstName"]');
    let lastNameFieldElement = document.querySelector('input[name="lastName"]');
    let facultyNumberFieldElement = document.querySelector('input[name="facultyNumber"]');
    let gradeFieldElement = document.querySelector('input[name="grade"]');
    let submitButtonElement = document.getElementById('submit');
    let tbodyElement = document.querySelector('tbody');

    let url = 'http://localhost:3030/jsonstore/collections/students';

    submitButtonElement.addEventListener('click', addStudent);

    function addStudent() {
        let { firstName, lastName, facultyNumber, grade } = takeValues();

        cleanInputFields();

        let student = {firstName, lastName, facultyNumber, grade};

        let requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(student),
        };

        fetch(url, requestOptions)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`${response.status}`);
        })
        .then(st => {
            renderStudent(st);
        })
        .catch(err => console.error(err.message));

        function takeValues() {
            let firstName = firstNameFieldElement.value;
            let lastName = lastNameFieldElement.value;
            let facultyNumber = facultyNumberFieldElement.value;
            let grade = gradeFieldElement.value;
            return { firstName, lastName, facultyNumber, grade };
        }

        function cleanInputFields() {
            firstNameFieldElement.value = '';
            lastNameFieldElement.value = '';
            facultyNumberFieldElement.value = '';
            gradeFieldElement.value = '';
        }

        function renderStudent(student) {
            let {firstName, lastName, facultyNumber, grade} = student;
    
            let tr = document.createElement('tr');
            tr.innerHTML = `
            <td>${firstName}</td>
            <td>${lastName}</td>
            <td>${facultyNumber}</td>
            <td>${grade}</td>
            `;
    
            tbodyElement.appendChild(tr);
        }
    }
}