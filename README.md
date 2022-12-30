## CODING CHALLENGE
This is a simple web api app that allows the CRUD management of devices. This is part of a coding challenge and so the details will only focus on the requirements and no info is revelead regarding the company itself. 

The coding requirements are:
* A rest service that supports the management of a device database
    * Device entity composed of (Name, Brand and Creation Date)
    * Supported Ops (Add, GetById, List, UpdateFull, UpdatePatch, ListByBrand, Delete)
* Should expose an API
* Deliverd in GIT
* Included Readme
* Respecting REST Pattern
* Clean and efficient code
* Unit Tests with good coverage

As an extra step besides all that was mentioned previsouly, docker support has also been added.

## Docker Commands
For docker to run it must be installed and running linux (Windows with WSL also can be an option).
Both commands should run in the root of the repo.

```
docker build -f DevicesProject.API/Dockerfile -t {replaceWithNameOfImage} .
```

```
docker run -p 8080:80 -d {replaceWithNameOfImage}
```

After this localhost:8080/swagger/index.html should reveal the swagger spec