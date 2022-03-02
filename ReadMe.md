# Read Me
Each task is under its own folder. All services are written with .NET 6. There for you must have .NET SDK version 6.0.100 installed to build and run repo. Additionally VSCode or Visual Studio 2022 is required for debugging the code. 

___
## Task 1

### **Problem:**
You are given an array of n unique integers a = a[0], a[1], ... , a[n - 1] and an integer value k. Find and print the number of pairs (a[i], a[j]) where i < j and a[i] + a[j] = k.

### **How to Run:**
* Open a termianl window with ```Task 1\CountPairs``` as the working directory.
* Run the following command to build and execute the application
    * ```dotnet run -c Release```
* To run the benchmarks use the following command
    * ```dotnet run -c Release -- --b```

### **Solution Approach:**
There are 3 possible ways to find the number of pairs matching the criteria.
1. **Using Brute-Force** - The time complexity of the above solution is O(n2) and doesn’t require any extra space
2. **Using Sorting** - The time complexity of the above solution is O(n.log(n)) and doesn’t require any extra space.
3. **Using Hashing** - The time complexity of the above solution is O(n) and requires O(n) extra space, where n is the size of the input.

To find the most efficient approach a benchmark was written. The results of the benchamrk is as follows:
|                 Method | Element Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD | Allocated |
|----------------------- |-------------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|----------:|
| CountPairsByBruteForce |            10 |         34.51 ns |       0.267 ns |       0.209 ns |         34.46 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |            10 |         34.42 ns |       0.116 ns |       0.103 ns |         34.39 ns |  1.00 |    0.01 |         - |
|    CountPairsByHashing |            10 |        108.04 ns |       1.018 ns |       0.850 ns |        108.16 ns |  3.13 |    0.03 |     336 B |

|                 Method | Element Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD | Allocated |
|----------------------- |-------------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|----------:|
| CountPairsByBruteForce |           100 |      4,571.04 ns |     114.538 ns |     337.719 ns |      4,692.30 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |           100 |        280.63 ns |       1.731 ns |       1.534 ns |        280.40 ns |  0.06 |    0.00 |         - |
|    CountPairsByHashing |           100 |        969.82 ns |       4.888 ns |       4.082 ns |        969.08 ns |  0.22 |    0.01 |   2,792 B |

|                 Method | Element Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD | Allocated |
|----------------------- |-------------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|----------:|
| CountPairsByBruteForce |          1000 |    348,834.33 ns |   6,956.287 ns |  14,209.852 ns |    342,107.42 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |          1000 |      3,801.19 ns |      39.288 ns |      36.750 ns |      3,803.49 ns |  0.01 |    0.00 |         - |
|    CountPairsByHashing |          1000 |      9,649.95 ns |     191.715 ns |     528.039 ns |      9,399.78 ns |  0.03 |    0.00 |  27,712 B |

|                 Method | Element Count |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD | Allocated |
|----------------------- |-------------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|----------:|
| CountPairsByBruteForce |         10000 | 33,530,000.55 ns | 146,040.218 ns | 121,950.196 ns | 33,514,842.86 ns | 1.000 |    0.00 |      34 B |
|    CountPairsBySorting |         10000 |     45,601.13 ns |     803.596 ns |     751.685 ns |     45,526.81 ns | 0.001 |    0.00 |         - |
|    CountPairsByHashing |         10000 |    191,875.87 ns |   1,095.898 ns |     915.124 ns |    191,560.35 ns | 0.006 |    0.00 | 258,275 B |

Based on these results **Sorting** approach was selected as it was efficient for wide range of element counts.

___
## Task 2

### **Problem:**
Create a program that evaluates arithmetic expressions written in Polish notation. Expressions can contain double-precision floating point numbers and the following operations: addition, subtraction, division and multiplication.

### **How to Run:**
* Open a termianl window with ```Task 2\PolishNotation``` as the working directory.
* Run the following command to build and execute the application
    * ```dotnet run -c Release```

___
## Task 3

### **Problem:**
Implement a REST API for the solution to task 2 that evaluates expressions that are supplied in the requests.

### **How to Run:**
* Open a termianl window with ```Task 3\PolishNotation.API``` as the working directory.
* Run the following command to build and execute the application
    * ```dotnet run -c Release```
* Navigate to [https://localhost:7070/swagger/index.html](https://localhost:7070/swagger/index.html) to open the Swagger UI.

**Alternatively you can also run this Web API as a docker container**
* Open a termianl window with ```Task 3``` as the working directory.
* Run the following command to build the container image.
    * ```docker build -t polish-notation.api -f .\Dockerfile .```
* Once the build is completed run the following to start the container.
    * ```docker run --name polish-notation.api -p 7070:80 -d polish-notation.api```
* Navigate to [https://localhost:7070/swagger/index.html](https://localhost:7070/swagger/index.html) to open the Swagger UI.
