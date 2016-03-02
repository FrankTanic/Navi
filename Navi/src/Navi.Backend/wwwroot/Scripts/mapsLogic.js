var geocoder = new google.maps.Geocoder();
var latLng = new google.maps.LatLng(51.871784, 4.546146);
var lastLocation = localStorage.getItem("lastLocation");

function initialize() {
    var map = new google.maps.Map(document.getElementById('mapCanvas'), {
        zoom: 18,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var locationMarker = new google.maps.Marker({
        position: latLng,
        title: 'The BLiS HQ',
        map: map,
        draggable: true
    });

    // Update current position info.
    updateMarkerPosition(latLng);
    geocodePosition(latLng);

    // Add event listeners.
    google.maps.event.addListener(locationMarker, 'dragstart', function () {
        updateMarkerAddress('Dragging...');
    });

    google.maps.event.addListener(locationMarker, 'drag', function () {
        updateMarkerStatus('Dragging...');
        updateMarkerPosition(locationMarker.getPosition());
    });

    google.maps.event.addListener(locationMarker, 'dragend', function () {
        updateMarkerStatus('Drag ended');
        geocodePosition(locationMarker.getPosition());
    });

    google.maps.event.addListener(circle, 'radius_changed', function () {
        localStorage.setItem("circleRadius", circle.getRadius());
    });

    if (typeof(lastLocation) !== 'undefined' && lastLocation) {
        var circle = new google.maps.Circle({
            map: map,
            radius: 50,
            fillColor: '#AA0000',
            center: locationMarker.getPosition(),
            setEditable: true
        });
        circle.bindTo('center', locationMarker, 'position');
        document.getElementById('info').style.display = "none";
    }
}

function geocodePosition(pos) {
    geocoder.geocode({
        latLng: pos
    }, function (responses) {
        if (responses && responses.length > 0) {
            updateMarkerAddress(responses[0].formatted_address);
        } else {
            updateMarkerAddress('Cannot determine address at this location.');
        }
    });
}

function updateMarkerStatus(str) {
    document.getElementById('markerStatus').innerHTML = str;
}

function updateMarkerPosition(latLng) {
    document.getElementById('info').innerHTML = [
      latLng.lat(),
      latLng.lng()
    ].join(', ');
}

function updateMarkerAddress(str) {
    document.getElementById('address').innerHTML = str;
}
function saveLocation() {
    latLng = document.getElementById('info').innerHTML;
    localStorage.setItem("lastLocation", JSON.stringify(latLng));
}

function radiusCheck(latLng, latLngMob)
{
    var distance = google.maps.geometry.spherical.computeDistanceBetween(latLng, latLngMob);
    alert(distance);
}