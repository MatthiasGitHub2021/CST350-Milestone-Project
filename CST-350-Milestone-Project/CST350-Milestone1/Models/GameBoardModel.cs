namespace CST350_Milestone1.Models
{
    public class GameBoardModel
    {
        //int to hold GridSize param
        private int GridSize { get; set; }

        //Init a cell
        public CellModel Cell;

        //Init a grid of cells
        public CellModel[,] Grid { get; set; }

        public int bombCount = 0;

        //getter for private GridSize, used with Minesweeper.populateGrid()
        public int getGridSize()
        {
            return GridSize;
        }

        //Create game board with size param, nested loop to fill with CellModel objects
        public GameBoardModel(int gridSize)
        {
            //construct the board 
            this.Grid = new CellModel[gridSize, gridSize];
            this.GridSize = gridSize;
            this.Cell = new CellModel(0, 0, false, false, 0);

            //insert a new cell for each position
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new CellModel(i, j, false, false, 0);
                }
            }
        }

        //Set bombs in grid, utilize difficulty setting
        //Use random to select positions, increase number for difficulty setting
        public void setupLiveNeighbors(int difficultySetting)
        {
            //Size of grid to divide by for percentage of bombs
            int sizeOfGrid = GridSize * GridSize;

            //var for liveBomb selected
            int liveBomb = 0;

            Random random = new Random();

            //get amount of random cells and change to live
            switch (difficultySetting)
            {
                case 1:
                    //divide sizeOfGrid by certain difficulty setting and set 'Live' to true
                    //if size = 300 / 30 = 10 bombs (easy difficulty)
                    liveBomb = sizeOfGrid / 30;
                    //place amount of liveBombs in random positions of array
                    for (int i = 0; i <= liveBomb; i++)
                    {
                        Grid[random.Next(0, GridSize), random.Next(0, GridSize)].setLive();
                        bombCount = liveBomb;
                    }
                    break;
                case 2:
                    //if size = 300 / 20 = 15 bombs (medium difficulty)
                    liveBomb = sizeOfGrid / 20;
                    for (int i = 0; i <= liveBomb; i++)
                    {
                        Grid[random.Next(0, GridSize), random.Next(0, GridSize)].setLive();
                        bombCount = liveBomb;
                    }
                    break;
                case 3:
                    //if size = 300 / 10 = 30 bombs (hard difficulty)
                    liveBomb = sizeOfGrid / 10;
                    for (int i = 0; i <= liveBomb; i++)
                    {
                        Grid[random.Next(0, GridSize), random.Next(0, GridSize)].setLive();
                        bombCount = liveBomb;
                    }
                    break;
                case 4:
                    //to set up easy game winning condition for testing, sets 1 bomb at 0, 0
                    Grid[0, 0].setLive();
                    bombCount = 1;
                    break;
                default:
                    break;
            }
        }

        //A method to calculate the live neighbors for every cell on the grid. A cell should have between 0 and 8 live neighbors. 
        //If a cell itself is "live," then you can set the neighbor count to 9.
        public void calculateLiveNeighbors()
        {
            //loop through array, if live +1 to NumberOfLiveNeighbors
            foreach (CellModel cell in Grid)
            {
                //if cell is considered a bomb
                if (cell.getLive() == true)
                {
                    //add +1 to param foreach cell around it
                    if (isValid(cell.getRow() - 1, cell.getColumn()))
                    {
                        Grid[cell.getRow() - 1, cell.getColumn()].setNumberOfLiveNeighbors(1);        //top
                    }
                    if (isValid(cell.getRow(), cell.getColumn() - 1))
                    {
                        Grid[cell.getRow(), cell.getColumn() - 1].setNumberOfLiveNeighbors(1);        //left
                    }
                    if (isValid(cell.getRow(), cell.getColumn() + 1))
                    {
                        Grid[cell.getRow(), cell.getColumn() + 1].setNumberOfLiveNeighbors(1);         //right
                    }
                    if (isValid(cell.getRow() + 1, cell.getColumn()))
                    {
                        Grid[cell.getRow() + 1, cell.getColumn()].setNumberOfLiveNeighbors(1);        //bottom
                    }
                    if (isValid(cell.getRow() - 1, cell.getColumn() - 1))
                    {
                        Grid[cell.getRow() - 1, cell.getColumn() - 1].setNumberOfLiveNeighbors(1);    //top left
                    }
                    if (isValid(cell.getRow() - 1, cell.getColumn() + 1))
                    {
                        Grid[cell.getRow() - 1, cell.getColumn() + 1].setNumberOfLiveNeighbors(1);    //top right
                    }
                    if (isValid(cell.getRow() + 1, cell.getColumn() - 1))
                    {
                        Grid[cell.getRow() + 1, cell.getColumn() - 1].setNumberOfLiveNeighbors(1);    //bottom left
                    }
                    if (isValid(cell.getRow() + 1, cell.getColumn() + 1))
                    {
                        Grid[cell.getRow() + 1, cell.getColumn() + 1].setNumberOfLiveNeighbors(1);    //bottom right
                    }
                }
            }

            //loop again and set live cells to 9, if not, some bombs represent at 10+
            foreach (CellModel cell in Grid)
            {
                if (cell.getLive() == true)
                {
                    //set to 9 for consistency
                    cell.setAsBomb();
                }
            }
        }

        //check if cell is live
        public bool checkIfLive(int row, int col)
        {
            if (Grid[row, col].getLive() == true)
            {
                return true;
            }
            return false;
        }

        //Check if only bombs remain to end the game
        public bool endGame()
        {
            //int to hold bombcount
            int nonBombCells = GridSize * GridSize - bombCount;

            int visitedCells = 0;

            foreach (CellModel cell in Grid)
            {
                if (cell.getVisited() == true)
                {
                    visitedCells++;
                }
                //each time a cell is marked as visited, increase visited cells. If visited cells = nonbomb cells, game ends
                if (visitedCells == nonBombCells)
                {
                    return true;
                }
            }
            return false;
        }

        //Recursive function to check neighbors and set to visited
        public void floodFill(int row, int col)
        {
            if (isValid(row, col) && Grid[row, col].getNumberOfLiveNeighbors() == 0)
            {
                if (Grid[row, col].getVisited() == false)
                {
                    Grid[row, col].setVisited();
                    floodFill(row + 1, col);
                    floodFill(row, col + 1);
                    floodFill(row - 1, col);
                    floodFill(row, col - 1);
                    revealFloodFillNeighbors(row, col);
                }
            }
            //if selecting a cell that does not have a liveneighbor count of 0
            else if (isValid(row, col) == true)
            {
                Grid[row, col].setVisited();
            }
        }

        //Returns false if row/col are outside of Gridsize or < 0
        private bool isValid(int row, int col)
        {
            if (row >= 0 && row < GridSize && col >= 0 && col < GridSize)
            {
                return true;
            }
            return false;
        }

        //If cell neighbor is visited but not revealed, this reveals it. Used with floodFill()
        public void revealFloodFillNeighbors(int row, int col)
        {
            foreach (CellModel cell in Grid)
            {
                if (cell.getVisited() == true)
                {
                    if (isValid(row + 1, col) == true)
                    {
                        Grid[row + 1, col].setVisited();
                    }
                    if (isValid(row, col + 1) == true)
                    {
                        Grid[row, col + 1].setVisited();
                    }
                    if (isValid(row - 1, col) == true)
                    {
                        Grid[row - 1, col].setVisited();
                    }
                    if (isValid(row, col - 1) == true)
                    {
                        Grid[row, col - 1].setVisited();
                    }
                }
            }
        }

        //after clicking a button, update button array texts to display floodfill changes
        public void displaychanges()
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    if (Grid[x, y].getVisited() == true)
                    {
                        //Minesweeper.ChangeButtonText(x, y);
                    }
                }
            }
        }

        //Show cell neighbors, used with button array Minesweeper.cs to show cell values
        public int getCellRowAndColNeighborCount(int row, int col)
        {
            return Grid[row, col].getNumberOfLiveNeighbors();
        }

        //If game is lost, reveal bombs
        public void revealBombs()
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    if (Grid[x, y].getLive() == true)
                    {
                        //Minesweeper.ChangeButtonToBomb(x, y);
                    }
                }
            }
        }

        //If game is won, place flag on bombs
        public void revealFlags()
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    if (Grid[x, y].getLive() == true)
                    {
                        //Minesweeper.ChangeButtonToFlag(x, y);
                    }
                }
            }
        }

        //Makes sure all cells (minus bomb cells) are revealed before ending game 
        public bool isAllCellsRevealed()
        {
            int bombs = 0;
            int visitedCells = 0;

            foreach (CellModel cell in Grid)
            {
                if (cell.getVisited() == true)
                {
                    visitedCells++;
                }
                if (cell.getLive() == true)
                {
                    bombs++;
                }
                if (visitedCells == bombs)
                {
                    return true;
                }
            }
            return false;
        }

        //Used before setting pic of bomb else messagebox displays before revealing all
        public void revealAll()
        {
            foreach (CellModel cell in Grid)
            {
                cell.setVisited();
            }
        }
    }
}

