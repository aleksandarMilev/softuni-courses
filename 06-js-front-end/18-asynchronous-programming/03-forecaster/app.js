function solve() {
  let inputFieldElement = document.getElementById("location");
  let hiddenDivElement = document.getElementById("forecast");

  document.getElementById("submit").addEventListener("click", getCityName);

  function getCityName() {
    hiddenDivElement.style.display = "block";

    fetch("http://localhost:3030/jsonstore/forecaster/locations")
    .then((response) => {
        if (response.ok) {
          return response.json();
        }

        throw new Error(`${response.status}`);
      })
      .then((data) => {
        data.forEach((cityInfo) => {
          let { code, name } = cityInfo;

          if (name.toLowerCase() === inputFieldElement.value.toLowerCase()) {
            getTodayForecast(code);
            getThreeDayForecast(code);
          }
        });
      })
      .catch(err => console.error(err.message));
  }

  function getTodayForecast(cityCode) {
    let todayForecastDivWrapper = document.querySelector('#current');
    todayForecastDivWrapper.innerHTML = '';

    fetch(`http://localhost:3030/jsonstore/forecaster/today/${cityCode}`)
      .then((response) => {
        if (response.ok) {
          return response.json();
        }

        throw new Error(`${response.status}`);
      })
      .then((data) => {
        let todayForecastDivElement = document.createElement('div');
        todayForecastDivElement.classList.add('forecasts');

        todayForecastDivElement.innerHTML = `
          <span class="condition symbol">${getIconCode(data.forecast.condition)}</span>
          <span class="condition">
              <span class="forecast-data">${data.name}</span>
              <span class="forecast-data">${data.forecast.low}/${data.forecast.high}</span>
              <span class="forecast-data">${data.forecast.condition}</span>
          </span>
        `;

        todayForecastDivWrapper.appendChild(todayForecastDivElement);
      })
      .catch(err => console.error(err.message));
  }

  function getThreeDayForecast(cityCode) {
    let upomingDivElement = document.getElementById('upcoming');
    upomingDivElement.innerHTML = '';

    let threeDayForecastDivElement = document.createElement('div');
    threeDayForecastDivElement.classList.add('forecast-info');

    fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`)
      .then(response => {
        if (response.ok) {
          return response.json();
        } 

        throw new Error(`${response.status}`);
      })
      .then((data) => {
        data.forecast.forEach(day => {
          let spanElement = document.createElement('span'); 
          spanElement.classList.add('upcoming');

          let{condition, high, low} = day;

          spanElement.innerHTML = `
            <span class="symbol">${getIconCode(condition)}</span>
            <span class="forecast-data">${low}/${high}</span>
            <span class="forecast-data">${condition}</span>
          `;
          
          threeDayForecastDivElement.appendChild(spanElement);
        });
      })
      .catch(err => console.error(err.message));

      upomingDivElement.appendChild(threeDayForecastDivElement);
  }

  function getIconCode(icon) {
    switch (icon) {
      case "Sunny":
        return "&#x2600";
      case "Partly sunny":
        return "&#x26C5";
      case "Overcast":
        return "&#x2601";
      case "Rain":
        return "&#x2614";
      case "Degrees":
        return "&#176";
    }
  }
}