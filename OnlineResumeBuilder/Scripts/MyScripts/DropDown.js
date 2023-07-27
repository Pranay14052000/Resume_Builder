$(document).ready(function () {
    // Event bindings for the country dropdown
    $('#Country').on('change', function () {
        populateStates();
    });

    // Event bindings for the state dropdown
    $('#State').on('change', function () {
        populateCities();
    });
});


function populateStates() {
 
    var country = document.getElementById("Country").value;

    var states = [];

    if (country === "India") {
        states = ["Goa", "Kerala", "Maharashtra"]; 
    }
   

    var stateDropdown = document.getElementById("State");
    stateDropdown.options.length = 0; 

    for (var i = 0; i < states.length; i++) {
        var option = new Option(states[i], states[i]);
        stateDropdown.options.add(option);
    }

  
    populateCities();
}

function populateCities() {
    var state = document.getElementById("State").value;
    var cities = [];

    if (state === "Goa") {
        cities = ["Panaji", "Ponda", "Margao", "Vasco", "Mapusa"];
    }
    else if (state === "Kerala") {
        cities = ["Kochi", "Trivendrum", "Kozhikode", "Alleppey"];
    }
    else if (state === "Maharashtra") {
        cities = ["Mumbai", "Pune", "Nagpur"];
    }

    var cityDropdown = document.getElementById("City");
    cityDropdown.options.length = 0;

    for (var i = 0; i < cities.length; i++) {
        var option = new Option(cities[i], cities[i]);
        cityDropdown.options.add(option);
    }
}


function populateCountryBasedCities() {
    var country = document.getElementById("Countryone").value;
    var cities = [];


    if (country === "India") {
        cities = ["Mumbai", "Bangalore", "Chennai", "Kolkata", "Chennai","Kochi"];
    }
    else if (country === "USA") {
        cities = ["New York", "Los Angeles", "Chicago", "San Francisco"];
    }
 
    var cityDropdown = document.getElementById("Cityone");
    cityDropdown.options.length = 0;

    for (var i = 0; i < cities.length; i++) {
        var option = new Option(cities[i], cities[i]);
        cityDropdown.options.add(option);
    }
}


function populateCountryBasedCitiesSecond() {
    var country = document.getElementById("Countrytwo").value;
    var cities = [];


    if (country === "India") {
        cities = ["Mumbai", "Bangalore", "Chennai", "Kolkata", "Chennai", "Kochi"];
    }
    else if (country === "USA") {
        cities = ["New York", "Los Angeles", "Chicago", "San Francisco"];
    }

    var cityDropdown = document.getElementById("Citytwo");
    cityDropdown.options.length = 0;

    for (var i = 0; i < cities.length; i++) {
        var option = new Option(cities[i], cities[i]);
        cityDropdown.options.add(option);
    }
}