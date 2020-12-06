let rooms = [];
function addItem(value) {
    rooms.push(value);
    //gets the html element with the right id
    var div = document.getElementById("basket");
    var ul = document.createElement("ul")
    var li = document.createElement("li");
    var li2 = document.createElement("li");
    var btn = document.createElement("button");

    ul.className = "list-group ";
    li.className = "list-group justify-content-center";
    li2.className = "list-group justify-content-center";
    ul.id = value;

    ul.style = "list-style-type:none; margin:10px;";
    li.style = "display: inline-block; list-style-type: none;";
    li2.style = "padding:15px; display: inline-block; list-style-type: none;";

    btn.className = "btn btn-primary";
    btn.style = "border-radius:25%;";
    btn.innerHTML = '<img src="/images/Skrældespands-ikon.png" width="25" height="25"/>';
    btn.addEventListener("click", function () {
        rooms.pop(value);
        this.closest("ul").remove();
    });

    li.appendChild(document.createTextNode("Rum Nr:  " + value))
    li2.appendChild(btn);
    ul.appendChild(li);
    ul.appendChild(li2);
    div.appendChild(ul);
}


