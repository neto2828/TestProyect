function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 20.13799499383488, lng: -98.81076724748546 },
        zoom: 17,
    });

    const drawingManager = new google.maps.drawing.DrawingManager({
        // drawingMode: google.maps.drawing.OverlayType.POLYGON,
        drawingControl: true,
        drawingControlOptions: {
            position: google.maps.ControlPosition.TOP_CENTER,
            drawingModes: [
                google.maps.drawing.OverlayType.POLYGON,
                google.maps.drawing.OverlayType.POLYLINE,
            ],
        },
        markerOptions: {
            icon: "https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png",
        },
    });

    let data = {
        paths: [
            {
                
                "lat": 20.139183596331733,
            "lng": -98.8121512673652
            },
            {

                "lat": 20.139022430421395,
                "lng": -98.81086380701196
            },
            {
    
                "lat": 20.137894264394117,
            "lng": -98.81104619722865
            },
{

   
                "lat": 20.13806550440478,
    "lng": -98.81240875943584
            }
        ],
        editable: true,
        draggable: true,
    };

    const polygons = new google.maps.Polygon(data);

    polygons.setMap(map);

    google.maps.event.addListener(polygons, 'dragend', function (event) {
        console.log(event);
    });

    google.maps.event.addListener(polygons.getPath(), 'insert_at', function (event) {
        console.log(event);
    });

    drawingManager.setMap(map);
}