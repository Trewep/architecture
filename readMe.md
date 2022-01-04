## This is THE API
Our API consists of 2 endpoints (users and events), where multiple actions are available
### Endpoints:
1. **User-side**
- Get all users in the database **(getAllUser)**
- Get a user in the database based on a certain id **(getUserById)**
- Remove a user in the database based on a certain id **(removeUserById)**
- Put a user in the database, add an user or edit an user arleady on database **(addEditUser)**

2. **Event-side**
- Get all events in the database **(getAllEvents)**
- Get an event in the database based on a certain id **(getEventById)**
- Remove an event in the database based on a certain id **(removeEventById)**
- Put an event in the database, add an event or edit an event arleady on database **(addEditEvent)**

## How To Run our API:
1. Copy/clone git the main or download the code via the green button on github
    1. **Clone:**: open vscode and open a terminal and type `git clone https://github.com/Trewep/architecture.git`
    2. **Copy/download**: open vscode, locate the downloaded folder and open the folder 'OurProject.API' (trust author etc. etc.)
2. Open terminal and navigate to folder 'OurProject.API'
    `cd OurProject.API`
3. Update Sqlite server
    `dotnet ef database update`
4. Run the API (don't worry, this is going to build and open a browser so you can use the api with Swagger)
    `dotnet watch run`
5. Close the api in terminal
    - windows:`ctrl + c`
    - mac:`ctrl + c`

## How To Run our API-tests:
1. Open terminal and navigate to folder OurProject.test
    `cd OurProject.test` or first `cd..` to go back a folder
2. Run the tests (entirely in terminal)
    `dotnet test`

## Our Api Contains:
- A controllers folder with the read, create dto's and the controllers for users and events
- A domains folder which contains separate files for both event and user
- An infra folder with Sql database and the database context
- A migrations folder so our database can run correctly with dotnet watch run
- A ports folder chich contains a the database interface

## Thanks to:
- Dylan Herman (https://github.com/DwowlaN)
- Arthur De Lophem (https://github.com/r0808)
- Fluppe Van Meerbeeck (https://github.com/Trewep)
- Our teacher for the support Raf Ceuls (https://github.com/rceuls)