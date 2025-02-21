function solve() {
    let url = 'http://localhost:3030/jsonstore/tasks';

    let divListElement = document.getElementById('list');

    let formElement = document.querySelector('#form form');

    let nameInputFieldElement = document.getElementById('name');
    let daysInputFieldElement = document.getElementById('num-days');
    let dateInputFieldElement = document.getElementById('from-date');

    let loadButtonElement = document.getElementById('load-vacations');
    let editButtonElement = document.getElementById('edit-vacation');
    let addButtonElement = document.getElementById('add-vacation');

    loadButtonElement.addEventListener('click', loadVacations);

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let name = nameInputFieldElement.value;
        let days = daysInputFieldElement.value;
        let date = dateInputFieldElement.value;
    
        let vacation = { name, days, date };

        let requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(vacation),
        };
    
        fetch(url, requestOptions)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`${response.status}`);
        })
        .then(() => {
            loadVacations();
            clearFields();
        })
        .catch(err => console.error('Bad response: ' + err.message));
    })

    editButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let id = formElement.getAttribute('vacation-id');

        let name = nameInputFieldElement.value;
        let days = daysInputFieldElement.value;
        let date = dateInputFieldElement.value;
        
        let vacation = { name, days, date };

        let requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(vacation),
        };

        fetch(url + `/${id}`, requestOptions)
        .then(response => {
            if(!response.ok) {
                throw new Error(`${response.status}`);
            }
        })
        .then(() => {
            loadVacations();
            clearFields();
        })
        .then(() => {
            addButtonElement.removeAttribute('disabled');
            editButtonElement.setAttribute('disabled', true);
            
            formElement.removeAttribute('vacation-id');
        })
        .catch(err => console.error('Bad response: ' + err.message));
    })

    function loadVacations() {
        divListElement.innerHTML = '';

        fetch(url)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`${response.status}`);
        })
        .then(data => {
            Object
            .entries(data)
            .forEach(va => {
                renderVacation(va);
            });
        })
        .catch(err => console.error('Bad response: ' + err.message));
    }

    function renderVacation(vacation) {
        let vacationId = vacation[0];
        let vacationData = vacation[1];

        let divElement = document.createElement('div');
        divElement.classList.add('container');

        let nameElement = document.createElement('h2');
        nameElement.textContent = vacationData.name;

        let dateElement = document.createElement('h3');
        dateElement.textContent = vacationData.date;

        let daysElement = document.createElement('h3');
        daysElement.textContent = vacationData.days;

        let changeButtonElement = document.createElement('button');
        changeButtonElement.textContent = 'Change';
        changeButtonElement.classList.add('change-btn');
        changeButtonElement.addEventListener('click', (e) => {
            nameInputFieldElement.value = nameElement.textContent;
            daysInputFieldElement.value = daysElement.textContent;
            dateInputFieldElement.value = dateElement.textContent;

            divElement.remove();

            editButtonElement.removeAttribute('disabled');
            addButtonElement.setAttribute('disabled', true);

            formElement.setAttribute('vacation-id', vacationId);
        });

        let doneButtonElement = document.createElement('button');
        doneButtonElement.textContent = 'Done';
        doneButtonElement.classList.add('done-btn');
        doneButtonElement.addEventListener('click', (e) => {
            deleteVacation(vacationId)
            .then(() => {
                divElement.remove();
                loadVacations();
            })
            .catch(err => console.error(err.message));
        });

        divElement.appendChild(nameElement);
        divElement.appendChild(dateElement);
        divElement.appendChild(daysElement);
        divElement.appendChild(changeButtonElement);
        divElement.appendChild(doneButtonElement);

        divListElement.appendChild(divElement);
    }

    function clearFields() {
        nameInputFieldElement.value = '';
        daysInputFieldElement.value = '';
        dateInputFieldElement.value = '';
    }

    function deleteVacation(vacationId) {
        let requestOptions = {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
        };

        return fetch(url + `/${vacationId}`, requestOptions)
                .then(response => {
                    if(!response.ok) {
                        throw new Error(`${response.status}`);
                    }
                })
    }
}