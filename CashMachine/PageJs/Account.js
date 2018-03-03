$(function () {
    $("#Account_cardNumber").bind('keyup paste', function () {
        this.value = this.value.replace(/[^0-9-]/g, '');
	});
});

function textFill(numb) {
    var x = $("#Account_cardNumber").val();
    $("#Account_cardNumber").val(x + numb);
}

function pinFill(numb) {
    var x = $("#Account_pin").val();
    $("#Account_pin").val(x + numb);
}

function Clear() {
    $("#Account_cardNumber").val("");
    $("#errorText").text("");
}

function ClearPin() {
    $("#Account_pin").val("");
    $("#errorText").text("");
}
