# InterviewExercise

.NET 8.0 Web API project
I Used: 
  - Cosmos DB Local Emulator: version 2.14.18
    - EF Cosmos Provider for DbContext (UnitOfWork)
  - DI
  - DDD
  - CQRS pattern

## How to use

Update the CosmosDBSettings in the appsettings.Development.json file with you EndpointUri and PrimaryKey.
Run the application in Debug Mode
The application will check on startup if the containers reflecting the domain model are already created if not it will create the needed containers.
Swagger will start and you should be able to: 
  - get customers
  - create customers
  - update customerContactMethods
  - get invoices
  - create invoices with invoiceLines
  - update invoices


## Note

  - Tests are not present due to lack of time, however i would have created validator tests and handling tests
  - My Experience with Cosmos DB is limited and I suspect the data should probably have been embedded in the main domain entities (Invoice, Customer) more, I added containers for each domain entity in this exercise (which is more relational...)

