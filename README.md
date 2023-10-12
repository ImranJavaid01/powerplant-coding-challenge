# Power Plant Coding Challenge


## CC Overview
I have implemtnted the coding challenge with respect to given document. I have test it with given request object and get the appropriate response.


## Things covered in Coding challenge

- Coding using Solid Principle
- Add Docker file(After running the application to docker you can access it at http://localhost:8888/swagger/index.html)
- Unit Test(Unable to go for 100% code coverage because of shortage of time)
- Swagger

## Tools Used

- Dotnet 6 (WebAPI)
- Visual Studio 2022
- Docker

## Installation

- you can run it locally and test it using Swagger
- Or you can run it on docker container and access it on port 8888. 

## Request Object

- When you will pass the request payload then you dont need to add units in fuel object i.e  
```Request payload
{
  "load": 910,
  "fuels":
  {
    "gas": 13.4,
    "kerosine": 50.8,
    "co2": 20,
    "wind": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredbig2",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    {
      "name": "gasfiredsomewhatsmaller",
      "type": "gasfired",
      "efficiency": 0.37,
      "pmin": 40,
      "pmax": 210
    },
    {
      "name": "tj1",
      "type": "turbojet",
      "efficiency": 0.3,
      "pmin": 0,
      "pmax": 16
    },
    {
      "name": "windpark1",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 150
    },
    {
      "name": "windpark2",
      "type": "windturbine",
      "efficiency": 1,
      "pmin": 0,
      "pmax": 36
    }
  ]
}
```

## Code Structure
		
		
- server (folder)
  	- Dockerfile
  	- README.md
  	- EngieTestCC(API)
	- EngieTestCC.TEST(Unit Test)

## Running application on Docker

- cd API directory where the docker file is placed
- docker build -t engieimage .
- docker run --rm -p 8888:8888 -p 80:80 -e ASPNETCORE_HTTP_PORT=https://+:8888 -e ASPNETCORE_URLS=http://+:8888 engieimage

