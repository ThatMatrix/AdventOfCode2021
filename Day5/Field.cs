namespace Day5
{
    public class Field
    {
        public int[][] table;
        public int width;
        public int height;

        public Field(int width, int height)
        {
            this.width = width;
            this.height = height;
            
            table = new int[width][];
            for (int i = 0; i < width; i++)
            {
                table[i] = new int[height];
                for (int j = 0; j < height; j++)
                {
                    table[i][j] = 0;
                }
            }
        }

        public int numberDangerousZones()
        {
            int tt = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (table[i][j] > 1)
                    {
                        tt += 1;
                    }
                }
            }

            return tt;
        }
    }
}