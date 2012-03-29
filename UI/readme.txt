﻿In order to use the Intranet template, you'll need to enable Windows authentication
and disable Anonymous authentication.

For detailed instructions (including instructions for IIS 6.0), please visit
http://go.microsoft.com/fwlink/?LinkID=213745

IIS 7 & IIS 8
1. Open IIS Manager and navigate to your website.
2. In Features View, double-click Authentication.
3. On the Authentication page, select Windows authentication. If Windows
   authentication is not an option, you'll need to make sure Windows authentication
   is installed on the server.

      To enable Windows authentication on Windows:
      a) In Control Panel open "Programs and Features".
      b) Select "Turn Windows features on or off".
      c) Navigate to Internet Information Services > World Wide Web Services > Security
         and make sure the Windows authentication node is checked.

      To enable Windows authentication on Windows Server:
      a) In Server Manager, select Web Server (IIS) and click Add Role Services
      b) Navigate to Web Server > Security
         and make sure the Windows authentication node is checked.

4. In the Actions pane, click Enable to use Windows authentication.
5. On the Authentication page, select Anonymous authentication.
6. In the Actions pane, click Disable to disable anonymous authentication.

IIS Express
1. Right click on the project in Visual Studio and select Use IIS Express.
2. Click on your project in the Solution Explorer to select the project.
3. If the Properties pane is not open, open it (F4).
4. In the Properties pane for your project:
 a) Set "Anonymous Authentication" to "Disabled".
 b) Set "Windows Authentication" to "Enabled".

You can install IIS Express using the Microsoft Web Platform Installer:
    For Visual Studio: http://go.microsoft.com/fwlink/?LinkID=214802
    For Visual Web Developer: http://go.microsoft.com/fwlink/?LinkID=214800
