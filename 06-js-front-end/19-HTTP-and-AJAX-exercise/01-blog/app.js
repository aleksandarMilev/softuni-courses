function solve() {
    let loadPostsButtonElement = document.getElementById('btnLoadPosts');
    let viewPostButtonElement = document.getElementById('btnViewPost');
    let postTitleElement = document.getElementById('post-title');
    let postBodyElement = document.getElementById('post-body');
    let commentsULElement = document.getElementById('post-comments');
    let selectElement = document.getElementById('posts');

    let baseUrl = 'http://localhost:3030/jsonstore/blog/';

    let posts = {};

    loadPostsButtonElement.addEventListener('click', loadPosts);
    viewPostButtonElement.addEventListener('click', viewPost);

    function loadPosts() {
        fetch(baseUrl + 'posts')
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`${response.status}`);
            })
            .then(data => {
                Object.entries(data).forEach(post => {
                    posts[post[1].title] = post[1];

                    createOption(post);
                })

            })
            .catch(err => console.error(err.message));
    }

    function createOption(post) {
        let optionElement = document.createElement('option');
        optionElement.value = post[1].id;
        optionElement.textContent = post[1].title;

        selectElement.appendChild(optionElement);
    }

    function viewPost() {
        fetch(baseUrl + 'comments')
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`${response.status}`);
            })
            .then(data => {
                renderPost(data);
            })
            .catch(err => console.error(err.message))
    }

    function renderPost(data) {
        commentsULElement.innerHTML = '';

        let selectedOptionText = selectElement.options[selectElement.selectedIndex].textContent;
        let selectedOptionValue = selectElement.value;

        let currentPost = posts[selectedOptionText];

        let comments =  
            Object.entries(data)
            .filter(postData => postData[1].postId === selectedOptionValue)
            .map(postData => postData[1].text);
        
        postTitleElement.textContent = currentPost.title;
        postBodyElement.textContent = currentPost.body;

        comments.forEach(comment => {
            let listItemElement = document.createElement('li');
            listItemElement.textContent = comment;

            commentsULElement.appendChild(listItemElement);
        })
    }
}