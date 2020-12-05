let rooms = [];
function addItem(value) {
    rooms.push(value);
    var ul = document.getElementById("dynamic-list");

    var li = document.createElement("li");
    li.setAttribute('id', value);
    li.appendChild(document.createTextNode(value));
    ul.appendChild(li);
}

function removeItem(value) {
    rooms.pop(value);
    var ul = document.getElementById("dynamic-list");
    var item = document.getElementById(value);
    ul.removeChild(item);
}