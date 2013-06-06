jQuery(function($){
	$.fn.dp_calendar.regional[''] = {
		closeText: 'Cerrar',
		prevText: '&#x3c;Ant',
		nextText: 'Sig&#x3e;',
		currentText: 'Hoy',
		monthNames: ['TH1','TH2','TH3','TH4','TH5','TH6',
		'TH7','TH8','TH9','TH10','TH11','TH12'],
		monthNamesShort: ['TH1', 'TH2', 'TH3', 'TH4', 'TH5', 'TH6',
		'TH7', 'TH8', 'TH9', 'TH10', 'TH11', 'TH12'],
		dayNames: ['Chủ nhật','Thứ 2','Thứ 3','Thứ 4','Thứ 5','Thứ 6','Thứ 7'],
		dayNamesShort: ['CN','T2','T3','T4','T5','T6','T7'],
		dayNamesMin: ['CN', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7'],
		DP_LBL_NO_ROWS: 'Không còn giờ trống trong ngày này',
		DP_LBL_SORT_BY: '',
		DP_LBL_TIME: '',
		DP_LBL_TITLE: '',
		DP_LBL_PRIORITY: ''};
	$.datepicker.regional[''] = $.fn.dp_calendar.regional[''];
});