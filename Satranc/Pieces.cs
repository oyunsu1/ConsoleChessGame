namespace Satranc
{
    public abstract class ChessPiece
    {
        public string Color { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Symbol { get; set; }

        public ChessPiece(string color, int xPosition, int yPosition, string symbol)
        {
            Color = color;
            XPosition = xPosition;
            YPosition = yPosition;
            Symbol = symbol;
        }

        public abstract bool IsValidMove(int newX, int newY);
    }
    public class King : ChessPiece
    {
        public King(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }

        public override bool IsValidMove(int newX, int newY)
        {
            int deltaX = Math.Abs(newX - XPosition);
            int deltaY = Math.Abs(newY - YPosition);
            return deltaX <= 1 && deltaY <= 1;
        }
    }
    public class Queen : ChessPiece
    {
        public Queen(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }

        public override bool IsValidMove(int newX, int newY)
        {
            return newX == XPosition || newY == YPosition || Math.Abs(newX - XPosition) == Math.Abs(newY - YPosition);
        }
    }
    public class Rook : ChessPiece
    {
        public Rook(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }
        public override bool IsValidMove(int newX, int newY)
        {
            return newX == XPosition || newY == YPosition;
        }
    }
    public class Horse : ChessPiece
    {
        public Horse(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }
        public override bool IsValidMove(int newX, int newY)
        {
            return XPosition + 2 == newX && YPosition + 1 == newY || XPosition + 2 == newX && YPosition - 1 == newY ||
                    XPosition - 2 == newX && YPosition + 1 == newY || XPosition - 2 == newX && YPosition - 1 == newY ||
                    XPosition - 1 == newX && YPosition + 2 == newY || XPosition + 1 == newX && YPosition + 2 == newY ||
                    XPosition - 1 == newX && YPosition - 2 == newY || XPosition + 1 == newX && YPosition - 2 == newY;
        }
    }
    public class Archer : ChessPiece
    {
        public Archer(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }
        public override bool IsValidMove(int newX, int newY)
        {
            return Math.Abs(newX - XPosition) == Math.Abs(newY - YPosition);
        }
    }
    public class Pawn : ChessPiece
    {
        public Pawn(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }
        public override bool IsValidMove(int newX, int newY)
        {
            int deltaY = Math.Abs(newY - YPosition);
            if ((YPosition == 6 || YPosition == 1) && XPosition == newX)
                return deltaY <= 2;
            return deltaY <= 1;
        }
    }
    public class Empty : ChessPiece
    {
        public Empty(string color, int xPosition, int yPosition, string symbol) : base(color, xPosition, yPosition, symbol)
        {
        }
        public override bool IsValidMove(int newX, int newY)
        {
            return false;
        }
    }
}
