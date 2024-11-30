# Freelancer API Documentation

This document provides the details of the Freelancer API that allows you to manage freelancers, their skillsets, and hobbies.

## Table of Contents

1. [Overview](#overview)
2. [API Endpoints](#api-endpoints)
    - [POST /api/Freelancers](#post-apifreelancers)
    - [GET /api/Freelancers/{id}](#get-apifreelancersid)
    - [GET /api/Freelancers/search](#get-apifreelancerssearch)
    - [PUT /api/Freelancers/archive/{id}](#put-apifreelancersarchiveid)
    - [PUT /api/Freelancers/unarchive/{id}](#put-apifreelancersunarchiveid)
3. [Models](#models)
    - [FreelancerRegisterRequest](#freelancerregisterrequest)
    - [FreelancerModel](#freelancermodel)
    - [FreelancerSkillsetModel](#freelancerskillsetmodel)
    - [FreelancerHobbyModel](#freelancerhobbymodel)
4. [Error Handling](#error-handling)

## Overview

The Freelancer API allows you to register freelancers with their personal details (username, email, phone number), skillsets, and hobbies. It provides endpoints to register new freelancers, retrieve freelancer details, search for freelancers, and archive or unarchive freelancer records.

## API Endpoints

### POST /api/Freelancers

#### Description
Registers a new freelancer with their personal details, skillsets, and hobbies.

#### Request Body
```json
{
  "Username": "JohnDoe",
  "Email": "john.doe@example.com",
  "PhoneNumber": "123-456-7890",
  "Skillsets": ["Web Development", "Python"],
  "Hobbies": ["Photography", "Cycling"]
}
Username: The username of the freelancer.
Email: The email address of the freelancer.
PhoneNumber: The phone number of the freelancer.
Skillsets: A list of skillset names the freelancer has.
Hobbies: A list of hobbies the freelancer has.
Response
Returns a 201 Created status with the created freelancer object.

json
Copy code
{
  "id": 1,
  "Username": "JohnDoe",
  "Email": "john.doe@example.com",
  "PhoneNumber": "123-456-7890",
  "IsArchived": false
}
GET /api/Freelancers/{id}
Description
Retrieves the details of a freelancer by their ID, including associated skillsets and hobbies.

Response
Returns a 200 OK status with the freelancer's details.

json
Copy code
{
  "id": 1,
  "Username": "JohnDoe",
  "Email": "john.doe@example.com",
  "PhoneNumber": "123-456-7890",
  "IsArchived": false,
  "Skillsets": [
    {
      "SkillName": "Web Development",
      "FreelancerId": 1
    },
    {
      "SkillName": "Python",
      "FreelancerId": 1
    }
  ],
  "Hobbies": [
    {
      "HobbyName": "Photography",
      "FreelancerId": 1
    },
    {
      "HobbyName": "Cycling",
      "FreelancerId": 1
    }
  ]
}
GET /api/Freelancers/search
Description
Searches for freelancers by their username or email. Returns a list of freelancers that match the search term.

Query Parameters
searchTerm: A string to search for in the freelancer's username or email.
Response
Returns a list of freelancers that match the search term.

json
Copy code
[
  {
    "id": 1,
    "Username": "JohnDoe",
    "Email": "john.doe@example.com",
    "PhoneNumber": "123-456-7890",
    "IsArchived": false
  }
]
PUT /api/Freelancers/archive/{id}
Description
Archives a freelancer by their ID. Sets the freelancer's IsArchived status to true.

Response
Returns a 200 OK status with a success message.

json
Copy code
{
  "message": "Freelancer archived successfully"
}
PUT /api/Freelancers/unarchive/{id}
Description
Unarchives a freelancer by their ID. Sets the freelancer's IsArchived status to false.

Response
Returns a 200 OK status with a success message.

json
Copy code
{
  "message": "Freelancer unarchived successfully"
}
Models
FreelancerRegisterRequest
This model represents the request body for registering a new freelancer.

csharp
Copy code
public class FreelancerRegisterRequest
{
    public string Username { get; set; }  
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Skillsets { get; set; }
    public List<string> Hobbies { get; set; }
}
Username: The username of the freelancer.
Email: The email address of the freelancer.
PhoneNumber: The phone number of the freelancer.
Skillsets: A list of strings representing the freelancer's skills.
Hobbies: A list of strings representing the freelancer's hobbies.
FreelancerModel
This model represents the freelancer data stored in the database.

csharp
Copy code
public class FreelancerModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsArchived { get; set; }
    public List<FreelancerSkillsetModel> Skillsets { get; set; }
    public List<FreelancerHobbyModel> Hobbies { get; set; }
}
Id: The unique identifier of the freelancer.
Username: The freelancer's username.
Email: The freelancer's email.
PhoneNumber: The freelancer's phone number.
IsArchived: A flag indicating whether the freelancer is archived.
Skillsets: A list of FreelancerSkillsetModel objects.
Hobbies: A list of FreelancerHobbyModel objects.
FreelancerSkillsetModel
This model represents a freelancer's skillset.

csharp
Copy code
public class FreelancerSkillsetModel
{
    public int FreelancerId { get; set; }
    public string SkillName { get; set; }
}
FreelancerId: The ID of the freelancer.
SkillName: The name of the skill.
FreelancerHobbyModel
This model represents a freelancer's hobby.

csharp
Copy code
public class FreelancerHobbyModel
{
    public int FreelancerId { get; set; }
    public string HobbyName { get; set; }
}
FreelancerId: The ID of the freelancer.
HobbyName: The name of the hobby.
Error Handling
The API will return the following status codes in case of errors:

404 Not Found: The requested resource could not be found.
400 Bad Request: The request is invalid (e.g., missing required fields or invalid data).
500 Internal Server Error: A generic error indicating that something went wrong on the server side.
For example:

json
Copy code
{
  "message": "Freelancer not found"
}
Conclusion
This API provides CRUD operations for managing freelancers, including their skillsets and hobbies, with the ability to archive and unarchive freelancer records.