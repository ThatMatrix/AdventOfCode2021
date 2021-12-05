namespace Day5
{
    public class Line
    {
        public int beginX;
        public int beginY;

        public int endX;
        public int endY;

        public Line(int beginX, int beginY, int endX, int endY)
        {
            this.beginX = beginX;
            this.beginY = beginY;
            this.endX = endX;
            this.endY = endY;
        }

        void AddToField(Field field)
        {
            if (beginX == endX)
            {
                for (int i = beginY; i < endY; i++)
                {
                    field.table[beginX][i] += 1;
                }
            }
            else if (beginY == endY)
            {
                for (int i = beginX; i < beginY; i++)
                {
                    field.table[i][beginY] += 1;
                }
            }
        }
    }
}