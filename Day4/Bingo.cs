namespace Day4
{
    public class Bingo
    {
        private (int, bool)[][] table;

        public Bingo(int[] input)
        {
            int indexInput = 0;
            
            table = new (int, bool)[5][];
            for (int i = 0; i < 5; i++)
            {
                table[i] = new (int, bool)[5];
                for (int j = 0; j < 5; j++)
                {
                    table[i][j] = (input[indexInput], false);
                }
            }
        }

        public (int, bool)[][] GetTable()
        {
            return table;
        }

        public bool DrawingNumber(int number)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (table[i][j].Item1 == number)
                    {
                        if (CheckWin(i, j))
                            return true;
                    }
                }
            }

            return false;
        }

        bool CheckWin(int i, int j)
        {
            bool horCheck = true;
            bool vertCheck = true;

            int k = 0;
            while (horCheck && k < 5)
            {
                horCheck = table[i][k].Item2;
                k++;
            }

            if (horCheck)
            {
                return true;
            }

            k = 0;
            while (vertCheck && k < 5)
            {
                vertCheck = table[k][j].Item2;
                k++;
            }

            if (vertCheck)
            {
                return true;
            }

            return false;
        }
    }
}