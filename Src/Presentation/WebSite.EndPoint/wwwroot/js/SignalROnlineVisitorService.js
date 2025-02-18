var connection = new signalR.HubConnectionBuilder()
    .withUrl("/Chathub")
    .build();

connection.start();