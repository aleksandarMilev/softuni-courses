function solve() {
    let mainElement = document.getElementById('main');
    mainElement.innerHTML = '';

    let url = 'http://localhost:3030/jsonstore/advanced/profiles';

    let usersAdded = 1;

    fetch(url)
    .then(response => {
        if(response.ok) {
            return response.json();
        }

        throw new Error(`${response.states}`);
    })
    .then(data => {
        Object.entries(data).map(x => x[1]).forEach(user => {
            renderUser(user);
        })
    })
    .catch(err => console.error(err.message));

    function renderUser(user) {
        let {username, email, age} = user;
        
        let divElement = document.createElement('div');
        divElement.classList.add('profile');
        divElement.innerHTML = 
        `
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user${++usersAdded}Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user${usersAdded}Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user${usersAdded}Username" value="${username}" disabled readonly />
            <div class="user1Username hiddenInfo">
                <hr>
                <label>Email:</label>
                <input type="email" name="user${usersAdded}Email" value="${email}" disabled readonly />
                <label>Age:</label>
                <input type="text" name="user${usersAdded}Age" value="${age}" disabled readonly />
            </div>
            <button>Show more</button>
        `;

        mainElement.appendChild(divElement);
    }

    mainElement.addEventListener('click', toggleProfile);

    function toggleProfile(e) {
        if(e.target.tagName.toLowerCase() !== 'button') {
            return;
        }

        let buttonElement = e.target.parentElement.querySelector('button');
        let unlockAreaElement =  e.target.parentElement.querySelector('input[value="unlock"]');
        let hiddenDivElement = e.target.parentElement.querySelector('div:last-of-type');

        if(unlockAreaElement.checked) {
            if(buttonElement.textContent === 'Show more') {
                hiddenDivElement.classList.remove('hiddenInfo');
                buttonElement.textContent = 'Hide it';
            } else {
                hiddenDivElement.classList.add('hiddenInfo');
                buttonElement.textContent = 'Show more';
            }
        }
    }
}