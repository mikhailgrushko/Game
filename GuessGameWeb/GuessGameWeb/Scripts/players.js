$(document).ready(function () {

	$("#addPlayer").click(function () {
		var newName = $("#newname").val();
		var newType = $("#newType").val();

		var html = '<tr>'+
						'<td>'+newName+'</td>'
						'<td>' + newType + '</td>'
						'<td>'+
							'<a href="/Home/Delete">Delete</a>'
						'</td>'
						'</tr>';
					$(html).appendTo($("#playersTbl"))
	})
	console.log("here");

})