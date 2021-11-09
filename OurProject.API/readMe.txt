at the moment our api isnt working 
We type dotnet run in terminal and get an error code we couldn't yet resolve in time

So in summary we have:
- a controllers folder with the read, create dto's and the main controller where gets and sets are specified for each of the user/event items
- a models folder which contains a main Models file for both event and user
- a ports folder chich contains a context, the database, a mock database and the Sql database
- a profiles map which we made to be able to use autoMapper

todo:
- fix the bug that comes when 'dotnet run' in terminal
- if that bug is the only thing that keeps us from starting the api then we'll have to fast check everything in postman see if the mock database is
working fine and the api is working as if it was with a real database
- if that bug isnt the only thing that keeps us from starting the api then we'll have a problem and lots of work to do

the error codes:

"error CS0579: Duplicate 'global::System.Runtime.Versioning.TargetFrameworkAttribute' attribute"
"error CS0579: Duplicate 'System.Reflection.AssemblyCompanyAttribute' attribute"
"error CS0579: Duplicate 'System.Reflection.AssemblyProductAttribute' attribute"
"error CS0579: Duplicate 'System.Reflection.AssemblyTitleAttribute' attribute"
"error CS0579: Duplicate 'System.Reflection.AssemblyVersionAttribute' attribute"