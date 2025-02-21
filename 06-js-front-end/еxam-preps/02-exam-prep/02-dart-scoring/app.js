window.addEventListener('load', solve);

function solve() {
    let playerNameFieldElement = document.querySelector('#player');
    let scoreFieldElement = document.querySelector('#score');
    let roundFieldElement = document.querySelector('#round');
    let addButtonElement = document.querySelector('#add-btn');
    let clearButtonElement = document.querySelector('.clear');
    let ulSureElement = document.querySelector('#sure-list');
    let ulScoreboardElement = document.querySelector('#scoreboard-list');

    addButtonElement.addEventListener('click', e => {
        e.preventDefault();
        renderInformation();
        addButtonElement.setAttribute('disabled', true);
    })

    clearButtonElement.addEventListener('click', () => {
        window.location.reload();
    })

    function renderInformation() {
        let name = playerNameFieldElement.value;
        let score = scoreFieldElement.value;
        let round = roundFieldElement.value;

        clearFields();

        let liELement = document.createElement('li');
        liELement.classList.add('dart-item');

        let articleElement = document.createElement('article');

        let nameParagraphElement = document.createElement('p');
        nameParagraphElement.textContent = name;

        let scoreParagraphElement = document.createElement('p');
        scoreParagraphElement.textContent = `Score: ${score}`;

        let roundParagraphElement = document.createElement('p');
        roundParagraphElement.textContent = `Round: ${round}`;

        let editButtonElement = document.createElement('button');
        editButtonElement.classList.add('btn');
        editButtonElement.classList.add('edit');
        editButtonElement.textContent = 'edit';
        editButtonElement.addEventListener('click', () => {
           playerNameFieldElement.value = name;
           scoreFieldElement.value = score
           roundFieldElement.value = round;

           liELement.remove();

           addButtonElement.removeAttribute('disabled');
        });

        let okButtonElement = document.createElement('button');
        okButtonElement.classList.add('btn');
        okButtonElement.classList.add('ok');
        okButtonElement.textContent = 'ok';
        okButtonElement.addEventListener('click', e => {
            e.preventDefault();

            let liELement = document.createElement('li');
            liELement.classList.add('dart-item');
    
            let articleElement = document.createElement('article');
    
            let nameParagraphElement = document.createElement('p');
            nameParagraphElement.textContent = name;
    
            let scoreParagraphElement = document.createElement('p');
            scoreParagraphElement.textContent = `Score: ${score}`;
    
            let roundParagraphElement = document.createElement('p');
            roundParagraphElement.textContent = `Round: ${round}`;

            articleElement.appendChild(nameParagraphElement);
            articleElement.appendChild(scoreParagraphElement);
            articleElement.appendChild(roundParagraphElement);
    
            liELement.appendChild(articleElement);
    
            ulScoreboardElement.appendChild(liELement);

            ulSureElement.innerHTML = '';

           addButtonElement.removeAttribute('disabled');
        });

        articleElement.appendChild(nameParagraphElement);
        articleElement.appendChild(scoreParagraphElement);
        articleElement.appendChild(roundParagraphElement);

        liELement.appendChild(articleElement);
        liELement.appendChild(editButtonElement);
        liELement.appendChild(okButtonElement);

        ulSureElement.appendChild(liELement);
    }

    function clearFields() {
        playerNameFieldElement.value = '';
        scoreFieldElement.value = '';
        roundFieldElement.value = '';
    }
}