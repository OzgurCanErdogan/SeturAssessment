# SeturAssessment
 Backend (.NET) Assessment (https://github.com/setur/assessment-backend-net/tree/master)

Project Structure:

Assesment consist of two main microservices. These are:
ContactApplication and ReportApplication

ContactApplication works like main microservice. It is responsible for Creating person, creating person's contact information (can be multiple), retrieving these information. Also, it is responsible for consuming rabbitmq messaging queue to create report details which is creating excel report and change the report's status to completed.

ReportApplication is simply creating report and publishes message to rabbitmq queue to ContactApplication to create report details.
 
