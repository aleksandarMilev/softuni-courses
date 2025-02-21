function attachEventsListeners() {
    let inputFieldElement = document.getElementById('inputDistance');
    let outputFieldElement = document.getElementById('outputDistance');

    let inputUnitsElement = document.getElementById('inputUnits');
    let outputUnitsElement = document.getElementById('outputUnits');

    let convertButtonElement = document.getElementById('convert');
    convertButtonElement.addEventListener('click', convertRate);

    function convertRate() {
        let convertRates = {
            'km': 1000,
            'm': 1,
            'cm': 0.01,
            'mm': 0.001,
            'mi': 1609.34,
            'yrd': 0.9144,
            'ft': 0.3048,
            'in': 0.0254,
        };

        let inputValue = inputFieldElement.value;
        let inputUnit = inputUnitsElement.value;
        let outputUnit = outputUnitsElement.value;

        let result = inputValue * convertRates[inputUnit] / convertRates[outputUnit];
        outputFieldElement.value = result;
    }
}