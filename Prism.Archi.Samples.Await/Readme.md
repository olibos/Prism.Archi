# Scenario
You want to use await/async to run multiple process in parallel.What is the right way to do it.

## Description
Lot of people don't really understand the await/async and use it straightforward.
But, in most cases, they don't use it rhe right way :)

Here are two samples of code used to run 5 async method at the same time and get the most of the multithreading run.
* In the method "ThisDoesNotWorkInParallel"
  * Each task is directly awaited, which cause the main thread to stop and wait before running next one.
  * This is asynchronous, because the main thread may continue (i.e : a windows app won't freeze)
* In the method "ThisWorkInParallel"
  * All tasks are initiated without await, and they start directly.
  * When the result is required, the await is used to make the main thread wait for the result.
  
==> If you want to run code in // you have to start the task and, later, await the task ! There is no magic :)

## Program output
Look at the timers :)
```
ThisDoesNotWorkInParallel
===> This code does NOT work in //
10:56:56.805 - Call 1 started
10:56:58.796 - Call 2 started
10:57:00.461 - Call 3 started
10:57:01.537 - Call 4 started
10:57:02.587 - Call 5 started
10:57:02.588 - Call 1 done : 1236
10:57:02.588 - Call 2 done : 1976
10:57:02.588 - Call 3 done : 1645
10:57:02.588 - Call 4 done : 1060
10:57:02.588 - Call 5 done : 1040

ThisWorkInParallel
===> This code does work //
10:57:02.590 - Call 1 started
10:57:02.590 - Call 2 started
10:57:02.590 - Call 3 started
10:57:02.590 - Call 4 started
10:57:02.590 - Call 5 started
10:57:03.722 - Call 1 done : 1127
10:57:04.460 - Call 2 done : 1865
10:57:04.460 - Call 3 done : 1549
10:57:04.460 - Call 4 done : 1668
10:57:04.460 - Call 5 done : 1037
```
