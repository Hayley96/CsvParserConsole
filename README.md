# :page_with_curl: CsvParserConsole
A Console app designed to parse a file, query the file data, and return records.

![](https://github.com/Hayley96/CsvParserConsole/blob/main/GIF/CsvParserConsoleApp.gif)

## :link: Table of contents
1. [Introduction](#introduction)
2. [Application Overview](#applicationOverview)
   1. [Technologies Used](#technologiesUsed)
   2. [Query References](#QueryReference)
3. [Pre-requisites](#prerequisites)
4. [Getting Started](#gettingStarted)
   1. [Application Setup](#applicationsetup)
   2. [Restore Dependencies](#restoredependencies)
   3. [Running Tests](#runningtests)
   4. [Main Entry Point](#mainentrypoint)

## Introduction :wave: <a name="introduction"></a>
A .NET Console application designed to parse a CSV file and return records from different queries based on a pre-established set of criteria. The console window will display a list of options in a menu format. The options can be navigated using the Arrow Up 🔼 or Arrow Down 🔽 keys. To select a query, navigate to the menu option and hit `Enter`.

## :computer: Application Overview <a name="applicationOverview"></a>

The application consists of the following main components:

* CSV Parser
* Data Query
* View

### ⚒️ Technologies Used <a name="technologiesUsed"></a>

<div>
<img align="left" alt="C#" title="C-Sharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img align="left" alt=".NET 6" title=".NET 6" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
</div>
</br></br>

### ❓ Query References <a name="QueryReference"></a>

#### Get all people

| Query                                   | ReturnType     | Description                                                              |
| :-------------------------------------  | :--------------| :------------------------------------------------------------------------|
| `Get people with 'Esq' in Company Name` | `List<Person>` | Returns a list of people who have the string 'Esq' in their company name |

#### Get all people whose Company Name contains string 'Esq'

| Query                           | ReturnType     | Description                                                       |
| :------------------------------ | :--------------| :-----------------------------------------------------------------|
| `Get people from Derbyshire`    | `List<Person>` | Returns a list of people who live in county Derbyshire            |

#### Get all people where house number is three digits

| Query                                               | ReturnType    | Description                                                       |
| :---------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose house number is exactly 3 digits` | `List<Person>`| Returns a list of people whose house number is exactly 3 digits   |

#### Get all people whose web URL has more than 35 characters

| Action                                                              | ReturnType    | Description                                                       |
| :-------------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people whose website URL length is greater than 35 characters` | `List<Person>`| Returns a list of people whose URL length > 35                    |

#### Get all people whose postcode contains only one digit after the city code, example SE2

| Action                                                        | ReturnType    | Description                                                       |
| :-------------------------------------------------------------| :-------------| :-----------------------------------------------------------------|
| `Get people who live in a postcode with a single digit value` | `List<Person>`| Returns list of people whose postcode contains one digit          |


## ⭐ Pre-requisites <a name="prerequisites"></a>

* C# / .NET 6
* NuGet

## 🔀 Getting Started <a name="gettingStarted"></a>

### Application Setup <a name="applicationsetup"></a>

Fork this repo to your Github and then clone the forked version of this repo.

- Setup:
	- Open up project in Visual Studio
	- This application requires a path pointing to a csv file. By default the path is set using the 'Visual Studio Default Working Directory' and returning its great grand-parent directory. This now defaults to: [.\CsvParserConsoleApp\Data](./CsvParserConsoleApp/Data)
	 - If your 'Default Working Directory' is not set to application root '\bin\Debug\net6.0', then you will need to specify a new file path:
       - To change the filepath in the appliation, you will need to modify the path in the following file:
	      * [Program.cs](https://github.com/Hayley96/CsvParserConsole/blob/main/CsvParserConsoleApp/Program.cs)
	      * ![ProgramFilePath](https://github.com/Hayley96/CsvParserConsole/blob/main/GIF/FilePathMethodProgram.png)

### Restore Dependencies <a name="restoredependencies"></a>

- Open up a terminal and navigate to the root folder of the main application directory [CsvParserConsoleApp](./CsvParserConsoleApp):
 - run: `dotnet restore`

### Running the Unit Tests <a name="runningtests"></a>

- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory [CsvParserConsole](../../):
 - run: `dotnet test`


### Main Entry Point <a name="mainentrypoint"></a>
- The Main Entry Point for the application is: [Program.cs](https://github.com/Hayley96/CsvParserConsole/blob/main/CsvParserConsoleApp/Program.cs)


## Thank you!! 👋
