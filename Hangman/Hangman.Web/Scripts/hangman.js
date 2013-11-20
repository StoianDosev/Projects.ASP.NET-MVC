
var canvas = document.getElementById("canvasElement");
var context = canvas.getContext("2d");



(function fun() {


    context.fillStyle = "#fff";
    context.fillRect(0, 0, context.canvas.width, context.canvas.height)
    context.beginPath();
    context.strokeStyle = "black";
    context.lineWidth = 5;

    //drawing the gallow
    context.moveTo(10, 400);
    context.lineTo(100, 400);
    context.moveTo(55, 400);
    context.lineTo(55, 50);
    context.lineTo(250, 50);
    context.lineTo(250, 100);
    context.stroke();

}());

function drawHead() {
    //drawing the hangman
    context.lineWidth = 2;
    context.beginPath();
    context.fillStyle = "#FF96B9";
    //head
    context.arc(250, 125, 25, 0, 2 * Math.PI, false);
    context.fill();
    context.stroke();

    //eyes
    context.beginPath();
    context.arc(250 - 10, 125 - 10, 2, 0, 2 * Math.PI, false);
    context.moveTo(250 + 10, 125 - 10);
    context.arc(250 + 10, 125 - 10, 2, 0, 2 * Math.PI, false);
    context.stroke();

    //nose
    context.moveTo(250, 115);
    context.lineTo(245, 130);
    context.lineTo(255, 130);
    context.stroke();

    //neck
    context.moveTo(250, 150);
    context.lineTo(250, 170);
    context.stroke();
    context.beginPath();
}


function drawBody() {
    context.arc(250, 215, 55, 0, 2 * Math.PI, false);
    context.fill();
    context.stroke();
}

function drawHands() {
    context.moveTo(250 - 47, 215 - 30);
    context.lineTo(150, 170);
    context.moveTo(250 + 47, 215 - 30);
    context.lineTo(350, 170);
    context.stroke();
}

function drawLegs() {

    context.moveTo(250 - 25, 215 + 50);
    context.lineTo(250 - 40, 320);
    context.moveTo(250 + 25, 215 + 50);
    context.lineTo(250 + 40, 320);
    context.stroke();
}

function drawMouth() {

    context.beginPath();
    context.arc(250, 140, 5, 0, 2 * Math.PI, false);
    context.stroke();
}
