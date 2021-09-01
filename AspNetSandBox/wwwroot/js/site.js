// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const BASE_URL = 'https://localhost:5001/WeatherForecastOpen';

const getWeather = async () => {
    try {
        const response = await axios.get(`${BASE_URL}`);

        const weather = response.data;

        console.log(`GET: Here's the weather`, weather);

        return weather;
    } catch (errors) {
        console.error(errors);
    }
};


function generateHTMLDailyWeatherForecasts(weather, index) {
    document.getElementById("timeFromNow" + index).textContent = weather.dailyForecasts[index].timeFromNow;
    document.getElementById("currentWeatherIcon" + index).setAttribute('src', 'https://openweathermap.org/img/wn/' + weather.dailyForecasts[index].dailyIconCode + '@2x.png');
    document.getElementById("currentDescription" + index).textContent = weather.dailyForecasts[index].dailyDescription;
    document.getElementById("speedWind" + index).textContent = weather.dailyForecasts[index].windSpeed + ' m/s';
    document.getElementById("currentTemperature" + index).textContent = weather.dailyForecasts[index].dailyTemperature + '°C';
}

const main = async () => {
    let weather = await getWeather();
    document.getElementById('currentWeatherIcon').setAttribute('src', 'https://openweathermap.org/img/wn/' + weather.currentIconCode + '@2x.png')
    document.getElementById('currentDescription').textContent = weather.currentDescription;
    document.getElementById('currentTemperature').textContent = weather.currentTemperature + '°C';

    // hours from now
    document.getElementById("timeFromNowHours").textContent = weather.dailyForecasts[0].timeFromNow;
    document.getElementById("currentWeatherIconHours").setAttribute('src', 'https://openweathermap.org/img/wn/' + weather.dailyForecasts[0].dailyIconCode + '@2x.png');
    document.getElementById("currentDescriptionHours").textContent = weather.dailyForecasts[0].dailyDescription;
    document.getElementById("speedWindHours").textContent = weather.dailyForecasts[0].windSpeed + ' m/s';
    document.getElementById("currentTemperatureHours").textContent = weather.dailyForecasts[0].dailyTemperature + '°C';

    console.log(weather.dailyForecasts.length)
    for (let i = 1 ; i < weather.dailyForecasts.length; i++) {
        generateHTMLDailyWeatherForecasts(weather, i);
    }

};

main();