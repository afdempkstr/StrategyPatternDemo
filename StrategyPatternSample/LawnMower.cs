using System;

namespace StrategyPatternSample
{
    class StrategicLawnMower
    {
        public static void Demo()
        {
            var frontYard = new Lawn();
            var backYard = new Lawn();

            frontYard.SelectLawnMower(new Mower1());
            frontYard.Mow();

            backYard.SelectLawnMower(new Mower2());
            backYard.Mow();

            frontYard.SelectLawnMower(new Mower1());
            frontYard.Mow();
            Console.Read();
        }
    }

    class Lawn
    {
        // false = needs mowing, true = already mowed
        public bool[,] Area { get; } = new bool[10, 5];

        private LawnMower _lawnMower;

        //public LawnMower LawnMower { get => _lawnMower; set => _lawnMower = value; }

        public void SelectLawnMower(LawnMower mower)
        {
            _lawnMower = mower;
        }

        public void Mow()
        {
            Console.WriteLine($"Mowing the grass using a {_lawnMower.GetType().Name}");
            _lawnMower.Mow(Area);
        }
    }

    abstract class LawnMower
    {
        public abstract void Mow(bool[,] area);
    }

    class Mower1 : LawnMower
    {
        public override void Mow(bool[,] area)
        {
            var rows = area.GetLength(0);
            var columns = area.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    area[row, column] = true;
                }
            }
        }
    }

    class Mower2 : LawnMower
    {
        public override void Mow(bool[,] area)
        {
            var rows = area.GetLength(0);
            var columns = area.GetLength(1);

            // TODO: do this with a single nested loop
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (var column = 0; column < columns; column++)
                    {
                        area[row, column] = true;
                    }
                }
                else
                {
                    for (var column = columns - 1; column >= 0; column--)
                    {
                        area[row, column] = true;
                    }
                }
            }
        }
    }

    // TODO : Create a LawnMower that moves in a spiral

}
