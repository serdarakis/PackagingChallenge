# Mobiquity Packer


Mobiquity Packer is a cross platform library that provides an optimized solution to packing items. Application helps user to find out most valuable package within limited package capacity.

## Introduction

Given a set of items, each with a weight and a value and index, Mobiquity Packer determines the items to include in a collection so that the total weight is less than or equal to a given limit and the total cost is as much as possible. Each thing you put inside the package has such parameters as index number, weight and cost. The package has a weight limit. Mobiquity Packer finds and optimum package with an optimized time.

Mobiquity Packer accepts a path to a file as its only argument. The input file may contain several lines. Each line is one test case. Each line should contain the weight that the package can take (before the colon) and the list of items you need to choose. Each item is enclosed in parentheses where the 1st number is an item’s index number, the 2nd its weight and the 3rd its cost. **E.g.**

> 81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)

> 8 : (1,15.3,€34)

> 75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52) (6,76.25,€75) (7,60.02,€74)

> 56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36) (6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)


Format of the file should be in UTF-8 format.  The pack method returns the solution as a string. Pack method throws an error/exception named APIException (com.mobiquity.packer.APIException where relevant) if any constraints are not met.

## Implementation
Application Reads the file and converts the information into the Package Model by parsing each line, calculates the items to pack using an efficient algorithm. Returns items indexes for each line in the input file. In case of any error library throws "APIException".

Package optimization is a known problem with Knapsack problem name. It has 3 different known algorithm when optimizing the items. These algorithms are Recursion solution and Dynamic Programming solution with Memoization and Tabulation methods.

Since optimization is close to Knapsack problem. Similar algorithm has been used to solve problem. However, since items weights are not integers, Memorization approach was the best solution.  However, small adjustment needs to be done because index is integer and capacity was fractional number.  Hash table has been used instead of a memory array.

        
## The Current Version
[Com.Mobiquity.Packer](https://www.nuget.org/packages/Com.Mobiquity.Packer/)

## Usage
Library developed with .Net Standard 2.1. Thus, application can be used in very varianted frameworks. You can see supported platforms belows:
 - .NET Core 3.0
 -   Mono 6.4
 -   Xamarin.iOS 12.16
 -   Xamarin.Mac 5.16
 -   Xamarin.Android 10
 -   An upcoming version Universal Windows Platform
 -   An upcoming version Unity


You can install latest version from Nuget Package Manager Console with a command below:

    Install-Package Com.Mobiquity.Packer -Version 1.0.2

To access `Packer` Class, you need to include namespace :

    using Com.Mobiquity.Packer;

Afterwards, you can use `Packer.Pack` function as shown. Don't forget to change `<File-Path>`  with your file name.

    Packer.Pack("<File-Path>");


## Building Source Code
-   Clone repository into a related folder.
-   Project has no dependency. It should be ready to build.
- You can use your favorite C# IDE to build solution or you can use script in `Scripts` folder.

**Scripts**

Scripts folder contains all necessary scripts for compilation, test execution and producing a nuget package. Remember that, you will need <b>dotnet CLI</b> to get it working.

 - <b>build.sh</b> will handle all operations. 
 - <b>test.sh</b> Runs all unit tests. 
 - <b>compile.sh</b> will clean solution restore and packs solution into a `Packages` folder.
 - <b>publish.sh</b> publishes nuget package. Replace  `<Api-Key>`  with your Api Key.
