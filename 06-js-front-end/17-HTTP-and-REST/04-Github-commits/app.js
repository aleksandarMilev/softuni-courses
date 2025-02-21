function loadCommits() {
    document.querySelector('button').addEventListener('click', makeRequest);

    function makeRequest() {
        let ul = document.getElementById('commits');
        let usernameElement = document.getElementById('username');
        let repositoryElement = document.getElementById('repo');

        let url = `https://api.github.com/repos/${usernameElement.value}/${repositoryElement.value}/commits`;

        fetch(url)
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`Error: ${response.status}`);
            })
            .then(data => {
                data.forEach(commit => {
                    let author = commit.commit.author.name;
                    let message = commit.commit.message;

                    let li = document.createElement('li');
                    li.textContent = `${author}: ${message}`;

                    ul.appendChild(li);
                });
            })
            .catch(error => {
                let li = document.createElement('li');
                li.textContent = error.message;

                ul.appendChild(li);
            })

        ul.innerHTML = '';
        usernameElement.value = '';
        repositoryElement.value = '';
    }
}