function solve() {
    let nameFieldElement = document.querySelector('input[name="author"]');
    let messageFieldElement = document.querySelector('input[name="content"]');
    let textFieldElement = document.getElementById('messages');
    let sendElement = document.getElementById('submit');
    let refreshElement = document.getElementById('refresh');

    let url = 'http://localhost:3030/jsonstore/messenger';

    sendElement.addEventListener('click', sendMessage);
    refreshElement.addEventListener('click', renderMessages);

    function sendMessage() {
        let messageObj = 
        {
            author: nameFieldElement.value,
            content: messageFieldElement.value,
        };

        nameFieldElement.value = '';
        messageFieldElement.value = '';

        let requestOptions = 
        {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(messageObj),
        };

        fetch(url, requestOptions)
            .then(response => {
                if(!response.ok) {
                    throw new Error(`${response.status}`);
                }
            })
            .catch(err => console.error(err.message));
    }

    function renderMessages() {
        textFieldElement.textContent = '';

        fetch(url)
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`${response.status}`);
            })
            .then(data => {
                let result = '';

                Object.entries(data)
                .map(mes => mes[1])
                .forEach(mes => {
                    result += `${mes.author}: ${mes.content}\n`;
                })

                let lastIndex = result.lastIndexOf('\n');
                result = result.slice(0, lastIndex) + result.slice(lastIndex + 1);

                textFieldElement.textContent = result;
            })
            .catch(err => console.error(err.message));
    }   
}