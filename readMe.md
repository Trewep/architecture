## This is THE API 
Our API consists of 2 endpoints (users and events), where multiple actions are available
### Endpoints:
1. **User-side**
- get all users in the database **(getAllUser)**
- get a user in the database based on a certain id **(getUserById)**
- remove a user in the database based on a certain id **(removeUserById)**
- put a user in the database, add an user or edit an user arleady on database **(addEditUser)**

2. **Event-side**
- get all events in the database **(getAllEvents)**
- get an event in the database based on a certain id **(getEventById)**
- remove an event in the database based on a certain id **(removeEventById)**
- put an event in the database, add an event or edit an event arleady on database **(addEditEvent)**

## How To Run:
1. Copy/clone git the main (or download the code via the green button on github)
    1. **Clone:** open vscode and open a terminal and type `$ git clone https://github.com/Trewep/architecture.git`
    2. **Copy/download**: open vscode and open folder OurProject.API (trust author etc. etc.) 
2. Open terminal and navigate to folder OurProject.API
    `cd OurProject.API`
3. Update Sqlite server 
    `dotnet ef database update`
4. run the API (don't worry, this is going to build and open a browser so you can use the api)
    `dotnet watch run`

## Our Api Contains:
- a controllers folder with the read, create dto's and the controllers for users and events
- a domains folder which contains separate files for both event and user
- an infra folder with Sql database and the database context
- a migrations folder so our database can run correctly with dotnet watch run
- a ports folder chich contains a the database interface

## todo:
- thorough check of the API on it's consistancy and links to be sure it remains runable without any (unexpected) problems