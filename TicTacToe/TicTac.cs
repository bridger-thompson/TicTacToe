namespace TicTacToe
{

    public class Board
    {
        public class Player
        {
            public bool turn { get; set; }
            public char mark { get; set; }  

            public Player(char mark, bool turn)
            {
                this.mark = mark;
                this.turn = turn;
            }

        }

        private char[,] board = new char[3, 3];
        public char winner { get; set; }
        private Player playerX = new('x', true);
        private Player playerO = new('O', false);

        public void placeMark(char mark, int x, int y)
        {
            //place mark on the board
            board[x, y] = mark;
            //change whos turn it is
            if (playerX.mark == mark)
            {
                playerX.turn = false;
                playerO.turn = true;
            }
            else if (playerO.mark == mark)
            {
                playerX.turn = true;
                playerO.turn = false;
            }
            //winner?
            checkWinner();
        }

        public char getMark(int x, int y)
        {
            return board[x, y];
        }

        public void checkWinner()
        {
            //check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    winner = board[0, i];
            }
            //check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    winner = board[i, 0];
            }
            //check crosses
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                winner = board[0, 0];
            else if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
                winner = board[2, 0];

        }

        public char getTurn()
        {
            //return the mark of the current player
            if (playerX.turn)
                return playerX.mark;
            else
                return playerO.mark;
        }
    }
}