# VehicleTrackingSystem

Processes to Run
1. One solution with Two Projects.
   - One is the web api
   - Another one is the web application
2. Open the solution in your microsoft visual studio.
3. Need to change the Database Query String.
   - appsettings.json file inside the VehicleTrackingSystem project
   - I use two Database. Vehicle Tracking System and Auth.
   - I use seperate database for the authentication and suthorization.
 4. Run the Add-Migration code in the PM console.
 5. Update-Database code.
 6. Run the VehicleTrackingSystem project by using IIS express or IIS.
 7. Get the all API information in the browser. 
 8. Need Postman software to check the Web Api. 
 9. Register the user by using the following link in postman.
     /api/Authenticate/register
     
     json input will be: 
       {
        "username": "string",
        "email": "user@example.com",
        "password": "string"
      }
 10. Try to get the device in     
 
 
 Features:
 1. AES encryption uses to protect the data from the MITM attach.
 2. N-Tier Architecture. Plannig to use clean Architecture for large project.
 3. Latest Technology uses like as dot net core.
 4. Data validation.
 5. Hash algorithm uses to store the password.
 6. Added one IoT code which one send the data to the server. I write the code by using lua language.
 7. SQL Server databases.
 8. Uses interfaces to secure the data.
