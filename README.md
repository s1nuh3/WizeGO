Hello !

This small Rest API has 2 endpoints:

/sayhi : Returns a simple JSON with a message "Hello World" greeting !
/jokes : This endpoint calls this fun API https://github.com/15Dkatz/official_joke_api
         Can be call it without passing a path category returning programming category by default, or receive a category
         like: /jokes/general, returnig a fun joke when the category is valid.

The project also has it's Xunit tests project, that runs against /jokes endpoint. 

To run this project you need a machine with .net5.0 sdk and/or Docker installed. Being familiar with the command-line interface and/or VS Code. It should be easy to run as I've dockerized it. As a CI/CD feature, this docker image will not complete if the unit tests fails.

To run the Rest API, move to the root path of the solution and execute this commands :

    docker build -t wizego:latest .
    docker run --rm -it -p 5000:80 wizego:latest

API endpoints will be available to be tested/used on the a web browser or any client like Postman, curl, etc., at localhost:

http://localhost:5000/sayhi
http://localhost:5000/jokes

To just run the Xunit tests, terminate the previous execution if is still running, and then:

    docker build --target testrunner -t wizego:latest .
    docker run wizego:latest

The unit tests will run and show the resulsts on the command-line.

Alternately:

This web API and can be compiled locally on any machine with this sdk installed using net cli or VS Code.

Navigate to the root folder /WizeGO and run this commands:

    dotnet restore
    dotnet build

To run the API:

    dotnet ./WizeGo.APi/bin/Debug/net5.0/WizeGO.APi.dll

To run the test:

    dotnet test ./WizeGo.UnitTests/bin/Debug/net5.0/WizeGO.UnitTests.dll

Thats it!!

Happy Coding