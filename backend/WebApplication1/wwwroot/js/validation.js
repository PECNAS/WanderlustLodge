window.days_count = 0;

function validateForm() {
    name = document.getElementById('Name').value.trim();
    phoneNumber = document.getElementById('PhoneNumber').value.trim();
    inDateStr = document.getElementById('InDate').value;
    outDateStr = document.getElementById('OutDate').value;

    nameRegex = /^[А-ЯЁ][а-яё]+\s[А-ЯЁ][а-яё]+(?:\s[А-ЯЁ][а-яё]+)?$/;
    if (!nameRegex.test(name)) {
        //alert('Имя должно состоять из 2 или 3 слов на русском языке, каждое слово с заглавной буквы');
        return false;
    }

    phoneRegex = /^\+7\d{10}$/;
    if (!phoneRegex.test(phoneNumber)) {
        //alert('Номер телефона должен начинаться с +7 и содержать 11 цифр');
        return false;
    }

    today = new Date();
    today.setHours(0, 0, 0, 0);

    inDate = new Date(inDateStr);
    if (inDate < today || inDateStr == '') {
        //alert('Дата заезда не может быть раньше сегодняшнего дня');
        return false;
    }

    outDate = new Date(outDateStr);
    minOutDate = new Date(inDate);

    if (outDate < minOutDate || outDateStr == '') {
        //alert('Дата выезда должна быть как минимум на 1 день позже даты заезда');
        return false;
    }

    return true;
}

function check() {
    if (validateForm() == true) {
        document.querySelector("#SendBtn").removeAttribute("disabled");
    } else {
        document.querySelector("#SendBtn").setAttribute("disabled", "");
    }

    inDateStr = new Date(document.getElementById('InDate').value);
    outDateStr = new Date(document.getElementById('OutDate').value);

    var res = (outDateStr - inDateStr) / (1000 * 60 * 60 * 24);
    if (res > 0 && res != NaN) {
        console.log("A");
        window.days_count = res;
        document.getElementById("DaysCount").innerHTML = window.days_count;
        document.getElementById("FullPrice").innerHTML = window.days_count * window.room_price + " руб.";
    }
}

document.querySelector("#SendBtn").addEventListener("click", check);

var inputs = [document.getElementById('Name'),
document.getElementById('PhoneNumber'),
document.getElementById('InDate'),
document.getElementById('OutDate')]

inputs.forEach((el) => {
    el.addEventListener("keyup", check)
});