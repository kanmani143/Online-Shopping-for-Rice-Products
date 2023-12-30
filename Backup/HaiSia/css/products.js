// JSON products
var products = {
    'red_grouper': { 'eng': 'Red Grouper', 'chn': '绾㈡枒' },
    'barred_spanish_mackerel': { 'eng': 'Barred Spanish Mackerel', 'chn': '宸翠腹楸�' },
    'milk_fish': { 'eng': 'Milk Fish', 'chn': '鐗涘ザ楸�' },
    'threadfin': { 'eng': 'Threadfin', 'chn': '鍗堥奔' },
    'black_mullet': { 'eng': 'Black Mullet', 'chn': '涔岄奔' },
    'black_pomfret': { 'eng': 'Black Pomfret', 'chn': '榛戦渤' },
    'salmon': { 'eng': 'Salmon', 'chn': '涓夌汗楸�' },
    'flower_grouper': { 'eng': 'Flower Grouper', 'chn': '鑺辨枒' },
    'yellow_croaker': { 'eng': 'Yellow Croaker', 'chn': '榛勮姳楸�' },
    'season_fish': { 'eng': 'Season Fish', 'chn': '椴ラ奔' },
    'white_pomfret': { 'eng': 'White Pomfret', 'chn': '鐧介渤' },
    'threadfin': { 'eng': 'Threadfin', 'chn': '鐧藉崍' },
    'red_snapper': { 'eng': 'Red Snapper', 'chn': '绾㈤奔' },
    'silver_pomfret': { 'eng': 'Silver Pomfret', 'chn': '鏂楅渤' },
    'yellowtail': { 'eng': 'Yellowtail', 'chn': '榛勫熬楸�' },
    'tilapia': { 'eng': 'Tilapia', 'chn': '娉ョ綏绾�' },
    'file_fish': { 'eng': 'File Fish', 'chn': '楣夸粩楸�' },
    'golden_pomfret': { 'eng': 'Golden Pomfret', 'chn': '閲戦渤' },
    'sea_bream': { 'eng': 'Sea Bream', 'chn': '绾㈠摜閲�' },
    'snakehead_fish': { 'eng': 'Snakehead Fish', 'chn': '鐢熼奔' },
    'sea_bass': { 'eng': 'Sea Bass', 'chn': '閲戠洰椴�' },
    'spanish_mackeral': { 'eng': 'Spanish Mackeral', 'chn': '椹矝' },
    'cotton_fish': { 'eng': 'Cotton Fish', 'chn': '妫夎姳楸�' },
    'ribbon_fish': { 'eng': 'Ribbon Fish', 'chn': '甯﹂奔' },
    'stingray': { 'eng': 'Stingray', 'chn': '鏂归奔' },
    'ikan_parang': { 'eng': 'Ikan Parang', 'chn': '瑗垮垁楸�' },
    'grouper': { 'eng': 'Grouper', 'chn': '鐭虫枒' },
    'sole_fish': { 'eng': 'Sole Fish', 'chn': '鎵侀奔' },
    'green_wrasse': { 'eng': 'Green Wrasse', 'chn': '闈掕。' },
    'flower_crab': { 'eng': 'Flower Crab', 'chn': '鑺辫煿' },
    'crab': { 'eng': 'Crab', 'chn': '铻冭煿' },
    'lobster': { 'eng': 'Lobster', 'chn': '榫欒櫨' },
    'prawns': { 'eng': 'Prawns', 'chn': '铏� ' },
    'softshell_cuttlefish': { 'eng': 'Softshell Cuttlefish', 'chn': '闈掔洰' },
    'cuttlefish': { 'eng': 'Cuttlefish', 'chn': '澧ㄦ枟' },
    'chilean_seabass': { 'eng': 'Chilean Seabass', 'chn': '闆奔' },
    'crayfish': { 'eng': 'Crayfish', 'chn': '铏惧﹩' },
    'baby_squid': { 'eng': 'Baby Squid', 'chn': '椴滈笨浠�' },
    'assorted_shellfish': { 'eng': 'Assorted Shellfish', 'chn': '璐濈被' },
    'squid': { 'eng': 'Squid', 'chn': '椴滈笨' }
}

// Preload product images and bind hover listeners
$(document).ready(function() {
$('<img />').attr('src', 'Images/loading.gif');
    $('#fish span').hoverIntent(
		function() { swap($(this).attr('class')); },
		function() { }
	);
    $.each(products, function(key, value) {
        products[key].img = $('<img />')
			.load(function() { products[key].loaded = true; })
			.error(function() { products[key].loaded = false; })
			.attr('id', 'center_graphic')
			.attr('src', 'Images/OurProduct/' + key + '.jpg')
		;
    });
});

// Swap product image
function swap(img) {
    var path;
    if (img == "default")
        path = "Images/center-graphic.jpg";
    else if (products[img].loaded)
        path = "Images/OurProduct/" + img + ".jpg";
    else
        path = "Images/loading.gif";

    $('#product_img').stop().fadeOut('fast', function() {
        $(this).attr('src', path).fadeIn('slow');
    });
}