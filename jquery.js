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

});

