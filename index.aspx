<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ToDoApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="content/site.css" rel="stylesheet" />
    <script
  src="https://code.jquery.com/jquery-3.6.0.js"
  integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk="
  crossorigin="anonymous"></script>
    <title></title>
</head>
<body>
    <input id="txtMessage" type="text" />

    <div id="myDIV" class="header">
        <h2 style="margin: 5px">My To Do List</h2>
        <input type="text" id="myInput" placeholder="Title..." />
        <span onclick="newElement()" class="addBtn">Add</span>
    </div>

    <ul id="myUL">
        <li>Hit the gym</li>
        <li class="checked">Pay bills</li>
        <li>Meet George</li>
        <li>Buy eggs</li>
        <li>Read a book</li>
        <li>Organize office</li>
    </ul>


    <script>
// Create a "close" button and append it to each list item
var myNodelist = document.getElementsByTagName("LI");
var i;
for (i = 0; i < myNodelist.length; i++) {
  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  myNodelist[i].appendChild(span);
}

// Click on a close button to hide the current list item
var close = document.getElementsByClassName("close");
var i;
for (i = 0; i < close.length; i++) {
  close[i].onclick = function() {
    var div = this.parentElement;
    div.style.display = "none";
  }
}

// Add a "checked" symbol when clicking on a list item
var list = document.querySelector('ul');
list.addEventListener('click', function(ev) {
  if (ev.target.tagName === 'LI') {
    ev.target.classList.toggle('checked');
  }
}, false);

// Create a new list item when clicking on the "Add" button
function newElement() {
  var li = document.createElement("li");
  var inputValue = document.getElementById("myInput").value;
  var t = document.createTextNode(inputValue);
  li.appendChild(t);
  if (inputValue === '') {
    alert("You must write something!");
  } else {
    document.getElementById("myUL").appendChild(li);
  }
  document.getElementById("myInput").value = "";

  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  li.appendChild(span);

  for (i = 0; i < close.length; i++) {
    close[i].onclick = function() {
      var div = this.parentElement;
      div.style.display = "none";
    }
   }

    var data = new Object();
    data.Message = inputValue;
    data.isSaved = 1;
    var jobj = JSON.stringify(data);
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        url: "index.aspx/SaveToDo",
        data: "{'obj': '" + jobj + "'}",
        success: function (response) {
            $('#txtMessage').val(inputValue);
            console.log(response);
        }
    });
}
</script>
</body>
</html>
