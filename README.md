# BakeryNET
This is a small bakery website developed with angular as frontend and .NET / ef core as backend. The database used in postgresql

It is implemented following the TDD mantra of "red => green => refactoring", as such I commited often to demonstrate my work process. Create a new failing test, implement the feature so the test passes, refactor to improve current code and find any bug.
The solution consists of 52 tests for both failing and passing cases.

The only requirements to get started is having a recent version of Node installed. Download here: https://nodejs.org/en/download/, and a working .NET environment

Once you have the requirements:

 1. Clone the repo:
	```shell
	$ git clone https://github.com/AlessandroRossi-unige/skinet.git
 2. If you want to use docker to get a working version of postgres you need to compose the containers, if you don't connect to any db by changing the connection string in appsettings:
 `$ docker-compose up -d`
 3. Run the backend witht the following command:
`$ dotnet watch run -p .\API\`
 5. cd into the client and run:
 `$ npm install`
 `$ ng serve`
The server should be running at https://localhost:4200/

The bakery has two admins, Luana and Maria. You can access the admin features of the site by logging with these credentials:
`email: luana@bakerynet.com password: Pa$$w0rdL`
`email: maria@bakerynet.com password: Pa$$w0rdM`

For any questions you can send me an email at alessandro0024@gmail.com
