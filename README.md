# Conway's Game of Life
Exercise for Cohort Juniper (10)



## Instructions

1. Create a unit tests project within this solution
2. Write some tests for your implementation of Conways Game Of Life:
  1. Create a test file in the test project
  2. Create a ConwaysGameOfLife class in the ConwaysGameOfLife project that implements the Board interface
  3. Write tests for all the rules and implement them
  
In order to visualize your particular class, change the class that is being initialized on the first line of the MainWindow constructor 

I suggest that your implementation's constructor take an argument that sets up the initial board state.

## Game Rules
1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
2. Any live cell with two or three live neighbours lives on to the next generation.
3. Any live cell with more than three live neighbours dies, as if by overcrowding.
4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
