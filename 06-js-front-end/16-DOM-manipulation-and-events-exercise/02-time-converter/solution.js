function attachEventsListeners() {
    let conversionRates = {
        days: 86400,
        hours: 3600,
        minutes: 60,
        seconds: 1
    };

    document.querySelectorAll('input[type="button"]').forEach(button => {
        button.addEventListener('click', convertTime);
    });

    function convertTime() {
        let unit = this.id.replace('Btn', '');
        let field = document.querySelector(`#${unit}`);
        let value = Number(field.value);

        let seconds = value * conversionRates[unit];

        for (let [unit, rate] of Object.entries(conversionRates)) {
            document.querySelector(`#${unit}`).value = seconds / rate;
        }
    }
}
