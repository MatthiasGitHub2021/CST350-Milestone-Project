namespace CST350_Milestone1.Models
{
    /* CellModel is used to fill GameBoardModel.
     * 
     */
    public class CellModel
    {
        private int Row { get; set; }
        private int Column { get; set; }
        private bool Visited;
        private bool Live;
        private int NumberOfLiveNeighbors { get; set; }

        //Constructor with 5 params
        public CellModel(int row, int column, bool visited, bool live, int numOfLiveNeighbors)
        {
            this.Row = row;
            this.Column = column;
            this.Visited = visited;
            this.Live = live;
            this.NumberOfLiveNeighbors = numOfLiveNeighbors;
        }

        public CellModel()
        {
            Row = -1;
            Column = -1;
            Visited = false;
            Live = false;
            NumberOfLiveNeighbors = 0;
        }

        public void setLive()
        {
            Live = true;
        }

        public bool getLive()
        {
            return this.Live;
        }

        public int getRow()
        {
            return this.Row;
        }

        public int getColumn()
        {
            return this.Column;
        }

        public bool getVisited()
        {
            return this.Visited;
        }

        public void setVisited()
        {
            this.Visited = true;
        }

        public void setVisited(int row, int col)
        {
            this.Row = row;
            this.Column = col;
            this.Visited = true;
        }

        //use to change live cells to have NumberOfLiveNeighbors count of 9
        public int setAsBomb()
        {
            NumberOfLiveNeighbors = 9;
            return this.NumberOfLiveNeighbors;
        }

        public int getNumberOfLiveNeighbors()
        {
            return this.NumberOfLiveNeighbors;
        }

        //used to increase NumberOfLiveNeighbors when setting up board 
        public int setNumberOfLiveNeighbors(int num)
        {
            return this.NumberOfLiveNeighbors += num;
        }

    }
}