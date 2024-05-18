using Satranc;

BoardMaker boardMaker = new BoardMaker();
ChessPiece[,] chessboard = boardMaker.GetChessBoard();
bool WhiteTurn = true;
string[,] Board = new string[8, 8];
Board = boardMaker.Reset(Board);
boardMaker.BoardWriter(Board);
int x, y, Newx, Newy;
while (true)
{
    Console.WriteLine($"{(WhiteTurn == true ? "White's" : "Black's")} turn.");
    string? Movement = Console.ReadLine();
    if (Movement == "Game Over")
        break;
    if (Movement == null || Movement.Length != 4){
        Console.WriteLine("Invalid Move!"); continue;
    }
    x = Convert.ToInt32(Movement[0]) - 'a';
    y = Convert.ToInt32(Movement[1]) - '1';
    Newx = Convert.ToInt32(Movement[2]) - 'a';
    Newy = Convert.ToInt32(Movement[3] - '1');
    if (!(x >= 0 && x <= 8 && y >= 0 && y <= 8 && Newx >= 0 && x <= 8 && Newy >= 0 && Newy <= 8)) {
        Console.WriteLine("Invalid Move!\n");  continue;
    }
    else if (WhiteTurn == true)
    {
        if (chessboard[y, x].IsValidMove(Newy, Newx) && chessboard[y,x].Color != chessboard[Newy, Newx].Color && chessboard[y,x].Color == "White" && Corridor(x,y,Newx,Newy))
            Movemento("White");
        else
        {
            Console.Write("Invalid Move\n");
            continue;
        }
    }
    else if (!WhiteTurn)
    {
        if (chessboard[y, x].IsValidMove(Newy, Newx) && chessboard[y, x].Color != chessboard[Newy, Newx].Color && chessboard[y, x].Color == "Black" && Corridor(x, y, Newx, Newy))
            Movemento("Black");
        else
        {
            Console.Write("Invalid Move\n");
            continue;
        }
    }
}
void Movemento(string Color)
{
    chessboard[Newy, Newx] = chessboard[y, x];
    if (chessboard[y,x].Symbol == "P")
        chessboard[Newy, Newx] = new Pawn(Color, Newy, Newx, "P");
    else if (chessboard[y, x].Symbol == "K")
        chessboard[Newy, Newx] = new Rook(Color, Newy, Newx, "K");
    else if (chessboard[y, x].Symbol == "A")
        chessboard[Newy, Newx] = new Horse(Color, Newy, Newx, "A");
    else if (chessboard[y, x].Symbol == "F")
        chessboard[Newy, Newx] = new Archer(Color, Newy, Newx, "F");
    else if (chessboard[y, x].Symbol == "V")
        chessboard[Newy, Newx] = new Queen(Color, Newy, Newx, "V");
    else if (chessboard[y, x].Symbol == "Ş")
        chessboard[Newy, Newx] = new King(Color, Newy, Newx, "Ş");
    chessboard[y, x] = new Empty("Empty", y, x, " ");
    boardMaker.BoardWriter(Board);
    WhiteTurn = !WhiteTurn;
}
bool Corridor(int x, int y, int Newx, int Newy)
{
    int i = 1;
    int j = 1;
    if (chessboard[y, x].Symbol == "P" && (Newy != y && chessboard[Newy,Newx].Symbol == " "))
        return false;
    if (chessboard[y, x].Symbol == "P" && ((Newx != x && Newy == y) && chessboard[Newy, Newx].Symbol != " "))
        return false;
    else if (chessboard[y, x].Symbol == "P" && ((y - 1) == Newy || (y + 1) == Newy) && chessboard[Newy, Newx].Symbol != " " && chessboard[Newy, Newx].Color != chessboard[y, x].Color)
        return true;
    if (chessboard[y, x].Symbol == "A")
        return true;
    if (y == Newy)
    {
        if (x > Newx)
            i *= -1;
        while (x < Newx || x > Newx)
        {
            x += i;
            if (chessboard[y, x].Symbol != " " && x != Newx)
                return false;
        }
    }
    else if (x == Newx)
    {
        if (y > Newy)
            i *= -1;
        while (y < Newy || y > Newy)
        {
            y += i;
            if (chessboard[y, x].Symbol != " " && y != Newy)
                return false;
        }
    }
    else
    {
        if (y > Newy)
            i *= -1;
        if (x > Newx)
            j *= -1;
        while ((x < Newx || x > Newx) && (y < Newy || y > Newy))
        {
            x += j;
            y += i;
            if (chessboard[y, x].Symbol != " " && y != Newy && x != Newx)
                return false;
        }
    }
    return true;
}