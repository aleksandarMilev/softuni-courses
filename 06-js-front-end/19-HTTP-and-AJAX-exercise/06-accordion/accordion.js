function solve() {
    let mainElement = document.getElementById('main');
    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let posts = {};

    fetch(url)
    .then(response => {
        if(response.ok) {
            return response.json();
        }

        throw new Error(`${response.status}`);
    })
    .then(data => {
        data.forEach(post => {
            posts[post._id] = post.title;

            renderPost(post);
        });
    })
    .catch(err => console.error(err.message));

    function renderPost(post) {
        let divElement = document.createElement('div');
        divElement.classList.add('accordion');
        divElement.innerHTML = 
        `
            <div class="head">
            <span>${post.title}</span>
            <button class="button" id="${post._id}">More</button>
            </div>
            <div class="extra">
                <p></p>
            </div>
        `;

        mainElement.appendChild(divElement);
    }

    mainElement.addEventListener('click', toggleDescriptions);

    function toggleDescriptions(e) {
        
        if(e.target.tagName.toLowerCase() !== 'button') {
            return;
        }

        fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${e.target.id}`)
        .then(response => {
            if(response.ok) {
                return response.json();
            }
    
            throw new Error(`${response.status}`);
        })
        .then(post => {
            renderHiddenText(post);
        })
        .catch(err => console.error(err.message));

        function renderHiddenText(post) {
            let paragrpahElement = document.createElement('p');
            paragrpahElement.textContent = post.content;
            currentPostHiddenElement.appendChild(paragrpahElement);
        }

        let currentPostHiddenElement = e.target.parentElement.parentElement.querySelector('.extra');
        currentPostHiddenElement.innerHTML = '';
        
        if(e.target.textContent === 'More') {
            currentPostHiddenElement.style.display = 'block';
            e.target.textContent = 'Less';
        } else {
            currentPostHiddenElement.style.display = 'none';
            e.target.textContent = 'More';
        }
    }
}