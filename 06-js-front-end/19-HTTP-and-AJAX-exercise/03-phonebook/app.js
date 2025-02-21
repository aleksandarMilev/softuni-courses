function solve() {
    let loadButtonElement = document.getElementById('btnLoad');
    let createButtonElement = document.getElementById('btnCreate');
    let personFieldInputElement = document.getElementById('person');
    let phoneFieldInputElement = document.getElementById('phone');
    let ulElement = document.getElementById('phonebook');

    let getAndPostReqUrl = 'http://localhost:3030/jsonstore/phonebook';
    let deleteRqUrl = 'http://localhost:3030/jsonstore/phonebook/';

    loadButtonElement.addEventListener('click', getPhonebooks);
    ulElement.addEventListener('click', deletePhonebook);
    createButtonElement.addEventListener('click', createPhonebook);

    let phoneBook = {};

    function renderPhonebook(data) {
        let liElement = document.createElement('li');
        liElement.textContent = `${data.person}: ${data.phone}`;

        let buttonElement = document.createElement('button');
        buttonElement.textContent = 'Delete';

        liElement.appendChild(buttonElement);

        ulElement.appendChild(liElement);

        phoneBook[data.person] = { person: data.person, phone: data.phone, id: data._id };
    }

    function getPhonebooks() {
        ulElement.innerHTML = '';

        fetch(getAndPostReqUrl)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`/${response.status}`);
        })
        .then(data => {
            Object.entries(data).map(d => d[1]).forEach(d => {
                renderPhonebook(d);
            })
        })
        .catch(err => console.error(err.message));
    }

    function createPhonebook() {
        let name = personFieldInputElement.value;
        let phone = phoneFieldInputElement.value;

        let phoneBook = 
        {
            person: name,
            phone,
        };

        let requestOptions = 
        {
            method: 'POST',
            headers: 
            {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(phoneBook),
        };

        fetch(getAndPostReqUrl, requestOptions)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`${response.status}`);
        })
        .then(data => {
            renderPhonebook(data);
        })
        .catch(err => console.error(err.message));

        personFieldInputElement.value = '';
        phoneFieldInputElement.value = '';
    }

    function deletePhonebook(e) {
        if(!e.target.tagName.toLowerCase() === 'button') {
            return;
        }

        let name = e.target.parentElement.textContent;
        let index = name.indexOf(':');
        name = name.substring(0, index);

        let id = phoneBook[name].id;

        if(!id) {
            return;
        }

        let requestOptions = 
        {
            method: 'DELETE',
        };

        fetch(deleteRqUrl + id, requestOptions)
        .then(response => {
            if(response.ok) {
                return response.json();
            }

            throw new Error(`${response.status}`)
        })
        .catch(err => console.error(err));
    }
}