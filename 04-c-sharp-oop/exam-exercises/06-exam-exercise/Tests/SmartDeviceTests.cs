using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class Board : IBoard
    {
        private Enums.Symbol[,] board;

        public Board()
            :this(3, 3)
        {
        }

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            board = new Enums.Symbol[rows, cols];
        }

        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Enums.Symbol[,] BoardState
            => board; 

        public bool isFull()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Enums.Symbol.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaceSymbol(Index index, Enums.Symbol symbol)
        {
            if (index.Row < 0 || index.Row >= Rows 
                || index.Col < 0 || index.Col >= Cols)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            board[index.Row, index.Col] = symbol;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            ICollection<Index> emptyPositions = new List<Index>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == Enums.Symbol.Empty)
                    {
                        emptyPositions.Add(new Index(row, col));
                    }
                }
            }

            return emptyPositions;
        }

        public Symbol GetRowSymbol(int row)
        {
            throw new NotImplementedException();
        }

        public Symbol GetColSymbol(int col)
        {
            throw new NotImplementedException();
        }

        public Symbol GetDiagonalTRBLSymbol()
        {
            throw new NotImplementedException();
        }

        public Symbol GetDiagonalTLBRSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
