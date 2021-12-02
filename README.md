# Introduction.
This is an API ASP.net API based application which maintains the records of Experts and their friendship. 

## How to Run

1- Clone the code at your local machine
2- Run the code using your preffered IDE (This source is created using the Visual Studio)
3- A Swagger based page will appear containing all the API and their related informatin.

## A bit Intorduction of API

### Add Expert

Use `AddExpert` API to add the expert in the system. Expert Name and the Web URL are the mandatory parameters.

### Get Expert

Use `GetExepert` API to get the expert information (Id, Name, Web URL, List of friends). Id is the Mandatory parameter which was provided on the Addition of Expert.

### Add Relation

To Add the relation between two experts use the `AddRelation` API. ID of both experts are mandatory to create the relation.

#### Find Path 

To find the chain of experts between two experts use the `GetRelation` API. Id of the both experts are mandatory to call this API.


