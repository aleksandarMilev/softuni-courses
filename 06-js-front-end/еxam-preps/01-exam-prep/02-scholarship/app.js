window.addEventListener('load', solve)

function solve() {
    let nextButtonElement = document.getElementById('next-btn');

    let nameFieldElement = document.getElementById('student');
    let univeristyFieldElement = document.getElementById('university');
    let scoreFieldElement = document.getElementById('score');

    let previewULElement = document.getElementById('preview-list');
    let candidatesListULElement = document.getElementById('candidates-list');

    nextButtonElement.addEventListener('click', renderStudent);
    previewULElement.addEventListener('click', processInformation);

    function renderStudent(e) {
        if(!nameFieldElement.value || !univeristyFieldElement.value || !scoreFieldElement.value) {
            return;
        }

        previewULElement.innerHTML = '';
        candidatesListULElement.innerHTML = '';

        e.target.disabled = true;

        let liElement = document.createElement('li');
        liElement.innerHTML =
        `
            <li class="application">
            <article>
                <h4>${nameFieldElement.value}</h4>
                <p>University: ${univeristyFieldElement.value}</p>
                <p>Score: ${scoreFieldElement.value}</p>
            </article>
            <button class="action-btn edit">edit</button>
            <button class="action-btn apply">apply</button>
            </li>
        `;

        nameFieldElement.value = '';
        univeristyFieldElement.value = '';
        scoreFieldElement.value = '';
    
        previewULElement.appendChild(liElement);
    }

    function processInformation(e) {
        if(e.target.textContent === 'edit') {
            editStudent();
        }else if(e.target.textContent === 'apply') {
            applyStudent();
        }
    }

    function editStudent() {
        let nameElement = document.querySelector('.application h4');
        let universityElement = document.querySelector('.application p');
        let scoreElement = document.querySelector('.application p:last-of-type');

        nameFieldElement.value = nameElement.textContent;
        univeristyFieldElement.value = universityElement.textContent.split(': ')[1];
        scoreFieldElement.value = scoreElement.textContent.split(': ')[1];

        previewULElement.innerHTML = '';

        nextButtonElement.disabled = false;
    }

    function applyStudent() {
        let studentData = previewULElement.querySelector('li article');

        let liElement = document.createElement('li');
        liElement.classList.add('application');
        liElement.appendChild(studentData);

        candidatesListULElement.appendChild(liElement);

        previewULElement.innerHTML = '';

        nextButtonElement.disabled = false;
    }
}