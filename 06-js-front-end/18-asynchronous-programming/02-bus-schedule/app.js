function solve() {
    let departButtonElement = document.getElementById('depart');
    let arriveButtonElement = document.getElementById('arrive');
    let infoBoxElement = document.querySelector('div span');

    const firstStopId = 'depot';
    let nextStopId = firstStopId;

    departButtonElement.addEventListener('click', function() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`)
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`${response.status}`);
            })
            .then(stopData => {
                infoBoxElement.textContent = `Next stop ${stopData.name}`;
                nextStopId = stopData.next;

                departButtonElement.disabled = true;
                arriveButtonElement.disabled = false;

            })
            .catch(() => {
                infoBoxElement.textContent = 'Error';

                departButtonElement.disabled = true;
                arriveButtonElement.disabled = true;
            })
    })

    document.getElementById('arrive').addEventListener('click', function() {
        infoBoxElement.textContent = infoBoxElement.textContent.replace('Next stop', 'Arriving at');

        departButtonElement.disabled = false;
        arriveButtonElement.disabled = true;
    });
}