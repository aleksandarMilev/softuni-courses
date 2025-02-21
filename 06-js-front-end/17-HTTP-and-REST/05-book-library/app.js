 function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/collections/books';

    let titleInputElement = document.querySelector('input[name="title"]');
    let authorInputElement = document.querySelector('input[name="author"]');

    //GET ALL (GET)
    document
        .querySelector('button')
        .addEventListener('click', makeGetRequest); 
    
    //SUBMIT (POST)
    document
        .getElementById('submit-button')
        .addEventListener('click', makePostRequest);

    document
        .querySelector('tbody')
        .addEventListener('click', function(event) {
            event.target.textContent === 'Edit'
                ? makePutRequest(event.target) //EDIT (PUT)
                : makeDeleteRequest(event.target); //DELETE (DELETE)
        });

    function createBookItemElement(book) {
        let bookTableRowElement = document.createElement('tr');

        bookTableRowElement.innerHTML = `
            <td>${book.title}</td>
            <td>${book.author}</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        `

        return bookTableRowElement;
    }

    function makeGetRequest() {
        let tableBodyElement = document.querySelector('tbody');
        tableBodyElement.innerHTML = '';

        fetch(url)
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`Bad response: ${response.status}`);
            })
            .then(data => {
                let books = Object.values(data);

                books
                    .map(book => createBookItemElement(book))
                    .forEach(bookItemElement => tableBodyElement.appendChild(bookItemElement));
            })
            .catch(err => console.error(err.message));
    }

    function makePostRequest() {
        let outputParagraphElement = document.createElement('p');
        outputParagraphElement.style.textAlign = 'center';

        let title = titleInputElement.value;
        let author = authorInputElement.value;

        if(title === '' || author === '') {
            outputParagraphElement.textContent = 'Invalid author/title name!';
            outputParagraphElement.style.color = 'red';

            document.body.appendChild(outputParagraphElement);

            titleInputElement.value = '';
            authorInputElement.value = '';
            return;
        }

        let book = 
        {
            "author": author,
            "title": title,
        };

        let requestOptions = 
        {
            method: 'POST',
            headers: 
            {
                'Content-type': 'application/JSON'
            },
            body: JSON.stringify(book),
        };

        fetch(url, requestOptions)
            .then(response => {
                if(!response.ok) {
                    throw new Error(`${response.status}`);
                } 

                outputParagraphElement.textContent = `You successfully added "${title}" by ${author}`;
                outputParagraphElement.style.color = 'green';

                document
                    .querySelector('tbody')
                        .appendChild(createBookItemElement(book));
                    
            })
            .catch(err => {
                outputParagraphElement.textContent = `An error occured- ${err.message}! Please try again!`;
                outputParagraphElement.style.color = 'red';
            });
            
        document.body.appendChild(outputParagraphElement);

        titleInputElement.value = '';
        authorInputElement.value = '';
    }

    function makePutRequest(eventTarget) {

    }

    function makeDeleteRequest(eventTarget) {
        
    }
}