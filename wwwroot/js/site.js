function JSAlert() {
    alert("Hello");
}


<script>
	$('.mask-phone').mask('+7 (999) 999-99-99');
</script>

function getCookie(name) {
	var matches = document.cookie.match(new RegExp("(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"));
	return matches ? decodeURIComponent(matches[1]) : undefined;
}