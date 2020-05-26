// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($) {

    function getCoords(e) {

        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 29.4399, lng: -98.4816 },
            zoom: 12,
            mapTypeId: 'roadmap'
        });
        var input = document.getElementById('pac-input');
        var searchBox = new google.maps.places.SearchBox(input);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
        map.addListener('bounds_changed', function () {
            searchBox.setBounds(map.getBounds());
        });

        var markers = [];
        searchBox.addListener('places_changed', function () {
            var places = searchBox.getPlaces();
            if (places.length == 0) {
                return;
            }
            markers.forEach(function (marker) {
                marker.setMap(null);
            });

            markers = [];
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                if (!place.geometry) {
                    console.log("Returned place contains no geometry");
                    return;
                }
                var icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25)
                };
                markers.push(new google.maps.Marker({
                    map: map,
                    icon: icon,
                    title: place.name,
                    position: place.geometry.location
                }));

                if (place.geometry.viewport) {
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });

            map.fitBounds(bounds);
        });

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            url: 'http://localhost:44312/foodtrucktracker/home',
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            success: function (data, textStatus, jQxhr) {
                console.log("it worked!");

                var infowindow = new google.maps.InfoWindow({
                    content: ''
                });

                for (let i = 0; i < data.length; i++) {
                    var marker = new google.maps.Marker({
                        map: map,
                        title: data[i].company,
                        position: new google.maps.LatLng(data[i].lat, data[i].long)
                    });

                }
                function bindInfoWindow(marker, map, infowindow, html) {
                    google.maps.event.addListener(marker, 'click', function () {
                        infowindow.setContent(html);
                        infowindow.open(map, marker);
                    });

                }
                google.maps.event.addDomListener(window, 'load', initialize);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
                console.log("Try again.");
            }
        });

        e.preventDefault();
    }
    window.onload = getCoords;
})(jQuery);