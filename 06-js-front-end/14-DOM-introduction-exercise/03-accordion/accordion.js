function toggle() {
    const buttonElement = document.getElementsByClassName('button')[0];
    const hiddenElement = document.getElementById('extra');

    if(hiddenElement.style.display === 'none' || hiddenElement.style.display === '') {
        hiddenElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        hiddenElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}
