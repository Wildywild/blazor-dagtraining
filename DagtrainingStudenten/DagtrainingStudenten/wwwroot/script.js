

function getSimpleString(text) {
	return 'bla ' + text;
}


function doeGeolocation() {
	return new Promise((resolve, reject) => {
		navigator.geolocation.getCurrentPosition(
			pos => {
				resolve({
					Latitude: pos.coords.latitude,
					Longitude: pos.coords.longitude,
					Accuracy: pos.coords.accuracy
				});
			},
			err => reject(err)
		);
	});
}
