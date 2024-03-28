## Corona Mnagemaent System for HMO

**Description**
An easy to use system for managing patients in a Health Maintenance Organization (HMO), allowing you to:  

 - Add, manage and update information about patients and their corona infection and vaccination
 - View statistics regarding the number of patients and those receiving vaccinations
 
**Server side:**
 -  Developed in C# with a connection to SQL Server using Entity Framework.
 - Provides CRUD (Create, Read, Update, Delete) operations on data through an API.
 - Includes management of patient information, COVID-19 cases, and vaccinations.

 **Client side:**
-   Developed in React.
-   Displays all patients registered in the HMO.
- Show each patient their corona data
-   Shows COVID-19 details for each patient, including a picture.
-   Allows adding, updating, and deleting patients.
-   Presents a summary view of the COVID-19 situation.

**System Specification:**
-   The method of calling between the different API services and a schematic view of the information in the DATABASE are located in the README.md file.

**Technologies:**
-   Server side: C#, SQL Server, Entity Framework
-   Client side: React

**Installation and Running:**
**1. Clone the repository:**
```
git clone https://github.com/Rivi1473/ATIDA.git
```
**2. Run the server-side:**
-   Open the solution in Visual Studio 2022.
-   Run the application.

**3. Run the client-side:**

-   Open the project in Visual Studio Code.
-   Type  `npm i`  to install node_modules.
-   Type  `npm start`  to run the application.

  Make sure you have .NET Core SDK 6.0 installed.


**User instructions:**

  The main page of the website shows the personal details of the patients

  ![צילום מסך 2024-03-28 164531](https://github.com/Rivi1473/ATIDA/assets/144923864/08b0ed67-3d64-499a-80e8-cece09daee64)

By clicking on the corona button, the patient's corona information will be displayed
![צילום מסך 2024-03-28 164557](https://github.com/Rivi1473/ATIDA/assets/144923864/8366f521-74e7-4acb-aee6-c85419815a6d)

By clicking on the edit button, the patient's corona information will be displayed with an editing option.
Clicking the add button will open a page with an add with the option to upload a photo
![__לכידה](https://github.com/Rivi1473/ATIDA/assets/144923864/b70bc1e5-94d8-455a-a75d-2ac033570d10)


By clicking on the Corona Summary button, a page will open with a total display of the number of patients and the number of those vaccinated

![צילום מסך 2024-03-28 164545](https://github.com/Rivi1473/ATIDA/assets/144923864/fe07dbab-0fe4-428a-a2fa-cda302d03671)

