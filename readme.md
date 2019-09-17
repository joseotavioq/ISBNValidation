# Problem Description

The ISBN standard is used to define a unique identification code for a book that encodes information such as language, book genre, publisher etc.

Each ISBN is of the general form **X-XXX-XXXXX-X** where the final *X* is a checksum digit to validate that the ISBN format is correct.

An example of a valid ISBN is: **0-306-40615-2**. 

## ISBN Rules

1. The first 9 digits are used to represent varies fields and the 10th digit is a checksum to ensure that the ISBN is a valid one. 
The formula for calculating the ISBN checksum is defined as:

![equation](http://latex.codecogs.com/gif.latex?x_%7B10%7D%20%3D%20%281x_1%20&plus;%202x_2%20&plus;%203x_3%20&plus;%204x_4%20&plus;%205x_5%20&plus;%206x_6%20&plus;%207x_7%20&plus;%208x_8%20&plus;%209x_9%29%7Emod%7E11)

In the ISBN above

![equation](http://latex.codecogs.com/gif.latex?1*0%20&plus;%202*3%20&plus;%203*0%20&plus;%204*6%20&plus;%205*4%20&plus;%206*0%20&plus;%207*6%20&plus;%208*1%20&plus;%209*5%20%3D%20145%7Emod%7E11%20%3D%202)

The following gives exactly the same result as the formula above.

![equation](http://latex.codecogs.com/gif.latex?x_%7B10%7D%20%3D%20%5Csum%5Climits_%7Bi%3D1%7D%5E%7B9%7D%20ix_i%7Emod%7E11)

2. Where the checksum comes to an exact value of 10, then an �X� or �x� is used to represent that in the ISBN code.
	Example: 030-000-009-X is ok.

3.  There can only be 0 or 3 '-' in the ISBN.
	Example: 0-30640615-2 is invalid

4.  There cannot be be a '-' at the start of the ISBN or at the end.
	Example: -0306-40615-2 is invalid

5. The '-' may not be consecutive.
	Example: 0�30640615-2 is invalid

## Results

On the first time, I developed the algorithm located on "ValidatorBaseline.cs" file.

From this baseline, I increased the performance of it creating the "ValidatorFirstTry.cs" file and after that the "ValidatorSecondTry.cs" file.

As a result, I added the BenchmarkDotNet nuget package to this project, to measure the performance and memory allocation, as follows:

| Method | Mean | Error | StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--|--|--|--|--|--|--|--|--|
| Baseline | 8,322.05 ns | 165.754 ns | 258.059 ns | 1.000 | 0.4120 | - | - | 1731 B |
| ValidatorFirstTry | 548.61 ns | 12.893 ns | 38.016 ns | 0.065 | 0.0410 | - | - | 172 B |
| ValidatorSecondTry | 47.46 ns | 1.069 ns | 3.135 ns | 0.006 | 0.0153 | - | - | 64 B |

**Legends**

*Mean*: Arithmetic mean of all measurements

*Error*: Half of 99.9% confidence interval

*StdDev*: Standard deviation of all measurements

*Ratio*: Mean of the ratio distribution ([Current]/[Baseline])

*Gen 0*: GC Generation 0 collects per 1000 operations

*Gen 1*: GC Generation 1 collects per 1000 operations

*Gen 2*: GC Generation 2 collects per 1000 operations

*Allocated*: Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

*1 ns*: 1 Nanosecond (0.000000001 sec)

More information about the results is available at: [BenchmarkDotNet Results](https://benchmarkdotnet.org/articles/overview.html#benchmark-results)