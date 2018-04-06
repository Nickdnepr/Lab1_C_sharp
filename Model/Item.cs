namespace ConsoleApplication1.Model
{
    public class Item
    {
        private int numOfFoxes;
        private int x;
        private int y;
        private MapCode code;
        private bool shoted;

        public Item(int numOfFoxes, int x, int y, MapCode code)
        {
            this.numOfFoxes = numOfFoxes;
            this.x = x;
            this.y = y;
            this.code = code;
            shoted = false;
        }

        public Item(int x, int y, MapCode code)
        {
            this.x = x;
            this.y = y;
            this.code = code;
            shoted = false;
        }

        public Item(int x, int y)
        {
            this.x = x;
            this.y = y;
            shoted = false;
        }

        public void addFox()
        {
            numOfFoxes++;
        }

        public int getNumOfFoxes()
        {
            return numOfFoxes;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setNumOfFoxes(int numOfFoxes)
        {
            this.numOfFoxes = numOfFoxes;
        }

        public bool getShooted()
        {
            return shoted;
        }

        public MapCode getCode()
        {
            return code;
        }

        public void shoot()
        {
            numOfFoxes = 0;
            shoted = true;
        }
    }
}