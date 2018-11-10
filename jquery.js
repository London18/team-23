$(document).ready(function () {


    $("#save").click(function () {
        console.log("pressed it");
        var question = $('textarea#new_q').val();
        var answer = $('textarea#new_a').val();
        var tags = $("#tagsid").val();

        console.log("The question is: " + question);
        console.log(answer);
        console.log(tags);
        

        $.post("Handler.ashx", { action: "saveNewQuestion" , question: question, answer:answer, tags:tags}, function (data) {
           
        });

    });

    $("#myBtn").click(function () {

        $("#myModal").modal();
    });

    
});

function filter(column=0) {
    // Declare variables 
    var input, filter, table, tr, td, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[column];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function getSearchMethod() {
    var i = $('input[name=searchmethod]:checked').val();
    return i;
}

