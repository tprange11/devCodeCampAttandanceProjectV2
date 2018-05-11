var x = document.getElementById("demo");
var y = document.getElementById("myBtn");
    
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError, { maximumAge: 600000, timeout: 5000, enableHighAccuracy: true });
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function isInRange() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(inRange, showError, { maximumAge: 600000, timeout: 5000, enableHighAccuracy: true });
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
        x.innerHTML = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
}

function inRange(position) {

    if (Math.abs(position.coords.latitude - 43.044110) <= .015 && Math.abs(position.coords.longitude - -87.912006) <= .015) {
        //x.innerHTML = "Click Button to sign in.";
        y.style.visibility = "visable";
    } else {
        x.innerHTML = "You can not login at this time. You are not at DevCodeCamp.";
        y.style.visibility = "hidden";
    }
    
}
    
function showError(error) {
    switch(error.code) {
        case error.PERMISSION_DENIED:
            x.innerHTML = "User denied the request for Geolocation.";
        break;
    case error.POSITION_UNAVAILABLE:
            x.innerHTML = "Location information is unavailable.";
        break;
    case error.TIMEOUT:
            x.innerHTML = "The request to get user location timed out.";
        break;
    case error.UNKNOWN_ERROR:
            x.innerHTML = "An unknown error occurred.";
        break;
}
}
