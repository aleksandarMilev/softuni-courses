function getInfo() {
    document.getElementById('submit').addEventListener('click', function() {

        let inputFieldElement = document.getElementById('stopId');
        let busId = inputFieldElement.value;

        fetch(`http://localhost:3030/jsonstore/bus/businfo/${busId}`)
            .then(response => {
                if(response.ok) {
                    return response.json();
                }

                throw new Error(`${response.status}`);
            })
            .then(stopData => {
                document.getElementById('stopName').textContent = stopData.name;

                let busList = stopData.buses;

                for (const bus in busList) {
                    let liElement = document.createElement('li'); 
                    liElement.textContent = `Bus ${bus} arrives in ${busList[bus]} minutes`;
                    document.getElementById('buses').appendChild(liElement);
                }
            })
            .catch(() => document.getElementById('stopName').textContent = 'ERROR');
    })
}