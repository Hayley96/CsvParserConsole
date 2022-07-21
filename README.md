# :page_with_curl: CsvParserConsole
An .NET 6 Console app designed to Parse a file, query the file data, and return records.

![](https://github.com/Hayley96/CsvParserConsole/blob/main/GIF/CsvParserConsoleApp.gif)

## :link: Table of contents
1. [Introduction](#introduction)
2. [Application Overview](#applicationOverview)
   1. [Technologies Used](#technologiesUsed)
   2. [Query References](#QueryReference)

## Introduction :wave: <a name="introduction"></a>
An .NET 6 Console app designed to parse a CSV file and return records from different queries based on a pre-established set of criteria. 

## :computer: Application Overview <a name="applicationOverview"></a>

The application consists of the following main components:

* CSV Parser
* Data Query

### ⚒️ Technologies Used <a name="technologiesUsed"></a>

<div>
<img align="left" alt="C#" title="C-Sharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img align="left" alt=".NET 6" title=".NET 6" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
</div>
</br></br>

### 🔄 Query References <a name="QueryReference"></a>

#### Get all people

| Query                                   | ReturnType     | Description                                                              |
| :-------------------------------------  | :--------------| :------------------------------------------------------------------------|
| `Get people with 'Esq' in Company Name` | `List<Person>` | Returns a list of people who have the string 'Esq' in their company name |

#### Get all people whose Company Name contains string 'Esq'

| Query                           | ReturnType     | Description                                                       |
| :------------------------------ | :--------------| :-----------------------------------------------------------------|
| `Get people from Derbyshire`    | `List<Person>` | returns a list of people who live in county Derbyshire            |

#### Get all people where house number is three digits

| Query                                               | ReturnType    | Description                                                       |
| :---------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose house number is exactly 3 digits` | `List<Person>`| returns a list of people whose house number is exactly 3 digits   |

#### Get all people whose web URL has more than 35 characters

| Action                                                              | ReturnType    | Description                                                       |
| :-------------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose website URL length is greater than 35 characters` | `List<Person>`| returns a list of people whose URL length > 35                    |

#### Get all people whose postcode contains only one digit after the city code, example SE2

| Action                                                        | ReturnType    | Description                                                       |
| :-------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people who live in a postcode with a single digit value` | `List<Person>`| returns list of people whose postcode contains one digit          |
