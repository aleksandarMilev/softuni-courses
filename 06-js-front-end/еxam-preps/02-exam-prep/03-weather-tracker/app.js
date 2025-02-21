window.addEventListener('load', solve);

function solve() {
    let url = 'http://localhost:3030/jsonstore/tasks';

    let elementsListDiv = document.getElementById('list');

    let formElement = document.querySelector('form');
        
    let locationFieldElement = document.getElementById('location');
    let temperatureFieldElement = document.getElementById('temperature');
    let dateFieldElement = document.getElementById('date');

    let loadHistoryButton = document.getElementById('load-history');
    let addWeatherButton = document.getElementById('add-weather');
    let editWeatherButton = document.getElementById('edit-weather');

    loadHistoryButton.addEventListener('click', loadHistory);
    loadHistoryButton.addEventListener('click', () => editWeatherButton.setAttribute('disabled', true));

    addWeatherButton.addEventListener('click', addWeather);

    editWeatherButton.addEventListener('click', editWeather);

    function loadHistory() {
        elementsListDiv.innerHTML = '';

        fetch(url)
        .then(res => res.json())
        .then(data => {
            renderPage(data);
        })
    }

    function renderPage(data) {
        Object
        .entries(data)
        .map(el => el[1])
        .forEach(el => {
            let divElement = document.createElement('div');
            divElement.className = 'container';

            let locationElement = document.createElement('h2');
            locationElement.textContent = el.location;

            let dateElement = document.createElement('h3');
            dateElement.textContent = el.date;
            
            let tempeartureElement = document.createElement('h3');
            tempeartureElement.id = 'celsius';
            tempeartureElement.textContent = el.temperature;

            divElement.appendChild(locationElement);
            divElement.appendChild(dateElement);
            divElement.appendChild(tempeartureElement);

            let buttonsDivElement = document.createElement('div');
            buttonsDivElement.className = 'buttons-container';

            let changeButton = document.createElement('button');
            changeButton.className = 'change-btn';
            changeButton.textContent = 'Change';
            changeButton.addEventListener('click', () => {
                locationFieldElement.value = el.location;
                temperatureFieldElement.value = el.temperature;
                dateFieldElement.value = el.date;

                editWeatherButton.removeAttribute('disabled');
                addWeatherButton.setAttribute('disabled', true);

                formElement.setAttribute('id', el._id);
            })

            let deleteButton = document.createElement('button');
            deleteButton.className = 'delete-btn';
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', () => {
                fetch(url + `/${el._id}`, {
                    method: 'DELETE',
                })
                .then(res => res.json())
                .then(() => {
                    elementsListDiv.innerHTML = '';
                    clearFields();
                    loadHistory();
                });
            });

            buttonsDivElement.appendChild(changeButton);
            buttonsDivElement.appendChild(deleteButton);

            divElement.appendChild(buttonsDivElement);

            elementsListDiv.appendChild(divElement);
        })
    }

    function addWeather(e) {
        e.preventDefault();

        let location = locationFieldElement.value;
        let temperature = temperatureFieldElement.value;
        let date = dateFieldElement.value;

        if(location === '' || temperature === '' || date === '') {
            return;
        }

        clearFields();

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ location, temperature, date }),
        })
        .then(res => res.json())
        .then(() => {
            elementsListDiv.innerHTML = '';
            loadHistory();
        });
    }

    function editWeather() {
        let location = locationFieldElement.value; 
        let temperature = temperatureFieldElement.value; 
        let date = dateFieldElement.value; 
        let id = formElement.getAttribute('id');

        if(location === '' || temperature === '' || date === '') {
            return;
        }

        fetch(url + `/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ location, temperature, date }),
        })
        .then(res => res.json())
        .then(() => {
            elementsListDiv.innerHTML = '';
            clearFields();
            loadHistory();
        })

        addWeatherButton.removeAttribute('disabled');
        editWeatherButton.setAttribute('disabled', true);
    }

    function clearFields() {
        locationFieldElement.value = '';
        temperatureFieldElement.value = '';
        dateFieldElement.value = '';
    }
}