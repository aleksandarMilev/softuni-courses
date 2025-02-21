function create(words) {
    let contentElement = document.getElementById('content');

    for (const word of words) {
        let paragraphElement = document.createElement('p');
        paragraphElement.textContent = word;
        paragraphElement.style.display = 'none';

        let divElement = document.createElement('div');
        divElement.addEventListener('click', showParagraphInAnElement);
        divElement.appendChild(paragraphElement);

        contentElement.appendChild(divElement);        
    }

    function showParagraphInAnElement() {
        let paragraph = this.getElementsByTagName('p')[0];
        paragraph.style.display = 'block';
    }
}