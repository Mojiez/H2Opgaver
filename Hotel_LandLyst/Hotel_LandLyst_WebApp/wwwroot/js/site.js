﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    })
};

function changeColor  () {
    document.getElementById("indexbody").style.backgroundColor = "brown";
    document.getElementById("indexheader").style.backgroundColor = "orange";
    document.getElementById("indexfooter").style.backgroundColor = "orange";
};

function nextpicture(e) {
    $('.carousel').carousel('next');
}