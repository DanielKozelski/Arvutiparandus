$(document).ready(function () {
	$('#TeenusedNimekiri').on('change', function () {
		if (this.value != "null") {
			if ($('#Teenused').html().indexOf(this.value) == -1) {
				$('#Teenused').append(this.value + "\n");
			}
		}
	});
});