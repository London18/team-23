<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
    <link rel="stylesheet" href="style.css" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://bootstrap-tagsinput.github.io/bootstrap-tagsinput/dist/bootstrap-tagsinput.css" />

    <script src="http://bootstrap-tagsinput.github.io/bootstrap-tagsinput/dist/bootstrap-tagsinput.min.js"></script>
    <script type="text/javascript" src="jquery.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <!-- seach for questions button -->
        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Search for answers</button>

        <!--Modal to search for questions -->
        <div class="container">
            <!-- Modal -->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class='modal-content'>
                        <div class='modal-header'>
                            <button type='button' class='close' data-dismiss='modal'>&times;</button>
                            <h4 class='modal-title'>
                                <input type="text" id="myInput" onkeyup="filter(getSearchMethod())" placeholder="Search for questions.." />
                                <label class="radio-inline">
                                    <input type="radio" name="searchmethod" checked value="0">Question
                                </label>
                                <label class="radio-inline">
                                    <input type="radio" name="searchmethod" value="1">Answer
                                </label>
                                <label class="radio-inline">
                                    <input type="radio" name="searchmethod" value="2">Keyword
                                </label>
                            </h4>
                        </div>
                        <div class='modal-body'>
                            <p>

                                <div id="myTable" runat="server" clientidmode="static"></div>


                            </p>
                        </div>
                        <div class='modal-footer'>
                            <button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>
                        </div>
                    </div>

                </div>
            </div>

        </div>

        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addQuestionModal">Add a new question</button>

        <!-- Modal to add question-->
        <div class="container">
            <!-- Modal -->
            <div class="modal fade" id="addQuestionModal" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class='modal-content'>
                        <div class='modal-header'>
                            <button type='button' class='close' data-dismiss='modal'>&times;</button>
                            <h4 class='modal-title'>Add a new Question</h4>
                        </div>
                        <div class='modal-body'>
                            <p>

                                <div class="form-group">
                                    <label for="new_question">Add a new question below:</label>
                                    <textarea id='new_q' class="form-control" rows="5" id="question"></textarea>
                                </div>
                                <div class="form-group">
                                    <label for="new_answer">Add the answer to the question above:</label>
                                    <textarea id='new_a' class="form-control" rows="5" id="answer"></textarea>
                                </div>

                                <div class="form-group">
                                    <label for="tags">Add tags:</label>
                                    <input id='tagsid' type="text" value="" data-role="tagsinput" />
                                </div>


                            </p>
                        </div>
                        <div class='modal-footer'>
                            <button type='button' class='btn btn-default' data-dismiss='modal'>Cancel</button>
                            <button id='save' type='button' class='btn btn-default' data-dismiss='modal'>Add</button>
                        </div>
                    </div>

                </div>
            </div>

        </div>



    </form>
</body>
</html>
