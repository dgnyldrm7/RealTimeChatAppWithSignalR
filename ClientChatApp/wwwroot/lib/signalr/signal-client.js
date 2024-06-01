$(document).ready(function () {

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7119/chatapp")
        .build();

    function Start()
    {
        connection.start().then(function () {
            console.log("Hub Connected");
        });
    }
    try {
        Start();
    }
    catch {
        setTimeout(() => {
            Start();
        },3000)
    }

    //connection.on("ReceiveSendAllMessage", (message) => {
    //    console.log(message);
    //})


    connection.on("ReceiveSendAllMessage", (message) => {

        let value = document.querySelector("#chat-box");

        const newDiv = document.createElement("div");
        newDiv.className = "icerigim";

        newDiv.style.border = "1px solid black";
        newDiv.style.borderRadius = "5px";
        newDiv.style.padding = "5px";
        newDiv.style.margin = "50px";

        let newList = document.createElement("ul");
        newList.className = "listem";

        let newLi = document.createElement("li");
        newLi.style.marginTop = "5px";

    
        newList.appendChild(newLi);
        newDiv.appendChild(newList);
        value.appendChild(newDiv);

        newLi.style.listStyle = "none";

        newLi.textContent = message;

  

    })

    $("#allmessage").click(function ()
    {
        const message = "asdasasddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd";

        connection.invoke("HerkeseMesagge", message).catch(function (error) {
            console.log("Hata", error);
        })
    });




});