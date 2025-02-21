function loadRepos() {
    document
        .getElementsByTagName('button')[0]
        .addEventListener('click', makeRequest);

    function makeRequest() {
        let url = 'https://api.github.com/users/testnakov/reps';

        fetch(url)
            .then(response => {
                if(response.ok) {
                    return response.text();
                }

                throw new Error('Bad response');
            })
            .then(text => {
                document.getElementById('res').textContent = text;
            })
            .catch(err => console.error(err));
    }
}