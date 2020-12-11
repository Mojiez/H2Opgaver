function addItem(value) {
    //gets the html element with the right id
    var div = document.getElementById("basket");
    var ul = document.createElement("ul")
    var li = document.createElement("li");
    var btn = document.createElement("button");

    ul.className = "list-group ";
    li.className = "list-group justify-content-center";
    ul.id = value;

    ul.style = "list-style-type:none; margin:10px;";
    li.style = "display: inline-block; list-style-type: none;";

    btn.className = "btn btn-primary";
    btn.style = "border-radius:25%; margin:10px;";
    btn.innerHTML = '<img src="/images/Skrældespands-ikon.png" width="25" height="25"/>';
    btn.addEventListener("click", function () {
        
        this.closest("ul").remove();
    });

    li.appendChild(document.createTextNode("Rum Nr:  " + value))
    li.appendChild(btn);
    ul.appendChild(li);
    
    div.appendChild(ul);
};



