function loadRepos() {
	document
		.getElementsByTagName('button')[0]
		.addEventListener('click', makeRequest);

	function makeRequest() {
		let reposListElement = document.querySelector('#repos');
		reposListElement.innerHTML = '';
		let username = document.querySelector('input').value;

		let url = `https://api.github.com/users/${username}/repos`;

		fetch(url)
			.then(response => {
				if(response.ok) {
					return response.json();
				}

				throw new Error('User not found!');
			})
			.then(data => {
				data.forEach(repo => {
					let listItemElement = document.createElement('li');
					let linkElement = document.createElement('a');

					linkElement.href = repo.html_url;
					linkElement.textContent = repo.full_name;

					listItemElement.appendChild(linkElement);
					reposListElement.appendChild(listItemElement);
				});
			})
			.catch(error => {
				let listItemElement = document.createElement('li');
				listItemElement.textContent = error.message;
				reposListElement.appendChild(listItemElement);
			});
	} 
}