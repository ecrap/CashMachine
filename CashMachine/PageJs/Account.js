$(function () {
    $("#Account_cardNumber").bind('keypress paste', function () {
        this.value = this.value.replace(/[^0-9-]/g, '');
        if (this.value.length % 5 === 0) {
        }
    });
});

function textFill(numb) {
    var x = $("#Account_cardNumber").val();
    if (x.length < 19) {
        if ((x.length + 1) % 5 === 0) {
            $("#Account_cardNumber").val(x +"-" +numb);
        }else{
            $("#Account_cardNumber").val(x + numb);
        }
    }
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
