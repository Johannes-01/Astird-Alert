# Astird-Alert
This is a program desinged with Windows Forms on the .NET Core in C#.
It is desinged to set up alert messages. These messages will pop up in the windows tray icon bar.
It also has a client and server application. 
If a client sends a message to the server, the server will forward a broadcast to all other clients, except the one who send the message in the first place.

In order to make the program work. You have to:
1. change the ip address to your own ip address in the "client" file.
2. and in the MainForm.
3. Then start the server.
4. After that you can start the main file AstridNotifier.
5. Type in the ip address of the server to connect to it.


