$(function () {
    $("#Movement_ammount").bind('keyup paste', function () {
        this.value = this.value.replace(/[^0-9.]/g, '');
	});
});

function textFill(numb) {
    var x = $("#Movement_ammount").val();
    $("#Movement_ammount").val(x + numb);
}

function Clear() {
    $("#Movement_ammount").val("");
    $("#errorText").text("");
}
