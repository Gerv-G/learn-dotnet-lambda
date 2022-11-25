# learn-dotnet-lambda

A personal learning project intended to achieve the following learning outcomes:
- [x] Refresh on how to create a .NET core Web API from scratch via CLI
- [x] Understand the basics of configuring an app host and dependency injection from scratch
- [x] Create an integration test (controller-level) running against an in-memory [TestServer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.testhost.testserver?view=aspnetcore-6.0)
- [ ] Create a Docker app from scratch
- [ ] Deploy the containerized app to AWS Lambda
- [ ] Create a CI/CD (TBD: GitHub actions or AWS CodeBuild)

While I am already able to work on projects with these technologies, I have not tried writing one from scratch.
I wanted to understand the nuances in creating one. Who knows I might be taking some things for granted.

## Build and Run
### Prerequisites
- .NET 6.0
- Docker (future)

### Build
```shell
dotnet build
```

### Run tests
```shell
dotnet test
```

### Running locally
To run the .NET project on you machine
```shell
dotnet run --project GreetingApi
```

