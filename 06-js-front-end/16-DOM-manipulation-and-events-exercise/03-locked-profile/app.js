function lockedProfile() {
    let showMoreButtonElements = document.getElementsByTagName('button');

    for (const button of showMoreButtonElements) {
        button.addEventListener('click', showOrHideDetails);
    }

    function showOrHideDetails() {
        let unlockButton = this.parentElement.querySelector('input[value="unlock"]');
        let hiddenDiv = this.parentElement.querySelector('div');

        if(unlockButton.checked) {

            if(this.textContent === 'Show more') {
                hiddenDiv.style.display = 'block';
                this.textContent = 'Hide it';
            } else {
                hiddenDiv.style.display = 'none';
                this.textContent = 'Show more';
            }
        }
    }
}