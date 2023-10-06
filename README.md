# SeturAssessment
 Backend (.NET) Assessment (https://github.com/setur/assessment-backend-net/tree/master)

### Project Structure:

Assesment consist of two main microservices. These are:
ContactApplication and ReportApplication

ContactApplication works like main microservice. It is responsible for Creating person, creating person's contact information (can be multiple), retrieving these information. Also, it is responsible for consuming rabbitmq messaging queue to create report details which is creating excel report and change the report's status to completed.

ReportApplication is simply creating report and publishes message to rabbitmq queue to ContactApplication to create report details.


### Database Structure:

Person  |
------------- |
GUID (PK) | GUID (PK)
Name  | PersonId (FK)
Surname |
CompanyName |

ContactInformation |
------------- |
GUID (PK) |
PersonId (FK) |
PhoneNuımber|
Email |
Locatin | 

Report |
------------- |
GUID (PK) |
RequestDateTime |
Status| 

ReportDetails |
------------- |
GUID (PK) |
ReportId (FK) |
ReportByte |

### Technologies Used:
- .NET Core (.NET 7)
- Entity Framework
- RabbitMQ
- PostgreSql

### Requirements To Work:
- Install Erlang to work with RabbitMQ from (https://www.erlang.org/downloads)
- Intall RabbitMQ from (https://www.rabbitmq.com/install-windows.html#downloads)
- Install PostgreSql from (https://www.postgresql.org/download/windows/)
- IIS Expres

For Postgres: "User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=postgres;"

For RabbitMQ:   "RabbitMQHost": "localhost","RabbitMQPort": "5672"

These values are in solutions' appsettings.json. If you want to work with different ports or different passwords or other setting you should change these values.

My aim was prepare the containers to work in docker and then publish the solution. Unfortunately, I couldn't have enough time for it.

### Requests and Endpoints:
For Contact Service:

- (POST) https://localhost:44396/api/contact/CreatePerson
Json sample to use in postman or another app (Post Request)
```javascript
{
    "Name": "Kubert",
    "Surname": "Tester",
    "CompanyName": "Setur"
}
```
- (GET) https://localhost:44396/api/contact/DeletePerson/Guid personId
- (GET) https://localhost:44396/api/contact/GetAllPerson
- (GET) https://localhost:44396/api/contact/GetPersonById/Guid personId
- (POST) https://localhost:44396/api/contact/AddContactInformation/Guid personId

Json sample
```javascript
{
    "PhoneNumber": "123",
    "Email": "Test",
    "Location": "Istanbul"
}
```
- (GET) https://localhost:44396/api/contact/DeleteContactInformation/Guid personId/Guid contactId

For Report Service:
- (POST) https://localhost:44313/api/report/CreateReport
- (GET) https://localhost:44313/api/report/GetCompletedReports
- (GET) https://localhost:44313/api/report/GetReport/Guid reportId

GetReport call does not work in postman or any other app since this request returns an excel report. Using through a web browser starts responding report.


