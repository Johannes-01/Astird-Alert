# Astird-Alert
This is a program desinged with Windows Forms on the .NET Core in C#.
It is desinged to set up alert messages. These messages will pop up in the windows tray icon bar.
It also has a client and server application. 
If a client sends a message to the server, the server will forward a broadcast to all other clients, except the one who send the message in the first place.

In order to make the program work. You have to:
1. change the ip in the method GetLocalIPAddress(). The ip has to look similar to this 192.168.188 (IPv4, with tree numbers).
2. You also have to change the ip address of the same method GetLocalIPAddress(), in the MainForm. Instead here the ip address can look like this 192.168. (only two numbers).
3. Start the Server, before running the AstridNotifier. 
4. Then Start AstridNotifier and type in the ip address of the Server.


With the Client you can test the connection to the Server and see your notifications send to other clients. 

Feel free to change this code, for your purposes.

