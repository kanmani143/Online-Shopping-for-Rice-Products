// Button effects
$(function() {
    $(".navbar img").hover(
		function() { $(this).stop().fadeTo('fast', 0.8); },
		function() { $(this).stop().fadeTo('fast', 1); }
	);
});