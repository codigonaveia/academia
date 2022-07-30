$('#Alunos').click(function () {
    debugger;
    $("#NameMenu").text("ALUNOS");
    $("#NameMenu")
        .addClass("text text-danger alert alert-info").addClass("active")
        .removeClass("text text-warning")
        .removeClass("text text-primary")
        .removeClass("text text-danger");


});

$('#Professores').click(function () {

    $("#NameMenu").text("PROFESSORES");
    $("#NameMenu").addClass("text text-warning alert alert-info").addClass("active")
        .removeClass("text text-danger")
        .removeClass("text text-primary")
        .removeClass("text text-danger");

});
$('#Equipamentos').click(function () {

    $("#NameMenu").text("EQUIPAMENTOS");
    $("#NameMenu").addClass("text text-primary alert alert-info").addClass("active")
        .removeClass("text text-danger")
        .removeClass("text text-warning")
        .removeClass("text text-danger");

});
$('#Financeiro').click(function () {

    $("#NameMenu").text("FINANCEIRO");
    $("#NameMenu").addClass("text text-danger alert alert-info").addClass("active")
        .removeClass("text text-danger")
        .removeClass("text-warning")
        .removeClass("text text-primary");

});