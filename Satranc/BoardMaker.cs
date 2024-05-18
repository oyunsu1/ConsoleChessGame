namespace Satranc
{
    public class BoardMaker
    {
        ChessPiece[,] chessboard = new ChessPiece[8, 8];
        public void BoardWriter(string[,] Board)
        {
            Console.Clear();
            char a = 'a';
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (chessboard[x,y].Color == "Black")
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(chessboard[x, y].Symbol);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (x == 7)
                        Console.Write($" {a++}\n");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 2 3 4 5 6 7 8");
            Console.ResetColor();
        }
        string[,] Pieceputter(string[,] chessboard, int x, int y)
        {

            if ((x == 0 || x == 7) && y == 0)
                this.chessboard[x, y] = new Rook("Black", x, y, "K");
            else if ((x == 0 || x == 7) && y == 7)
                this.chessboard[x, y] = new Rook("White", x, y, "K");
             else if ((x == 1 || x == 6) && y == 0)
                this.chessboard[x, y] = new Horse("Black", x, y, "A");
            else if ((x == 1 || x == 6) && y == 7)
                this.chessboard[x, y] = new Horse("White", x, y, "A");
            else if ((x == 2 || x == 5) && y == 0)
                this.chessboard[x, y] = new Archer("Black", x, y, "F");
            else if ((x == 2 || x == 5) && y == 7)
                this.chessboard[x, y] = new Archer("White", x, y, "F");
            else if (x == 3 && y == 0)
                this.chessboard[x, y] = new Queen("Black", x, y, "V");
            else if (x == 3 && y == 7)
                this.chessboard[x, y] = new Queen("White", x, y, "V");
            else if (x == 4 && y == 0)
                this.chessboard[x, y] = new King("Black", x, y, "Ş");
            else if (x == 4 && y == 7)
                this.chessboard[x, y] = new King("White", x, y, "Ş");
            else if (y == 1)
                this.chessboard[x, y] = new Pawn("Black", x, y, "P");
            else if (y == 6)
                this.chessboard[x, y] = new Pawn("White", x, y, "P");
            else
                this.chessboard[x, y] = new Empty("Empty", x, y, " ");
            return chessboard;
        }

        public string[,] Reset(string[,] Board)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board = Pieceputter(Board, x, y);
                }
            }
            return (Board);
        }
        public ChessPiece[,] GetChessBoard()
        {
            return chessboard;
        }
    }
}
