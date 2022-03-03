using System;
using TechTalk.SpecFlow;

namespace TicTacSpecFlow.StepDefinitions
{
    [Binding]
    public class TicTacToeStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly TicTacToe.Board board = new();

        public TicTacToeStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"(.*) plays in (.*), (.*)")]
        public void GivenXPlaysIn(char c0, int p0, int p1)
        {
            board.placeMark(c0, p0, p1);
        }

        [Then(@"(.*) is found in cell (.*), (.*)")]
        public void ThenXIsFoundInCell(char c0, int p0, int p1)
        {
            context.Add("mark", board.getMark(p0, p1));
            context.Get<char>("mark").Should().Be(c0);
        }

        [When(@"checking for a winner")]
        public void WhenCheckingForAWinner()
        {
            //board.checkWinner();
            context.Add("winner", board.winner);
        }

        [Then(@"the winner of the game is (.*)")]
        public void ThereIsAWinner(char p0)
        {
            context.Get<char>("winner").Should().Be(p0);
        }

        [Then(@"there is no winner yet")]
        public void ThenTheWinnerOfTheGameIsNull()
        {
            context.Get<char>("winner").Should().Be('\0');
        }

        [When(@"asking whos turn is next")]
        public void WhenAskingWhosTurnIsNext()
        {
            context.Add("currentPlayerMark", board.getTurn());
            //TicTacToe.Board.Player current = board.getTurn();
        }

        [Then(@"player (.*) has the next turn")]
        public void ThenPlayerOHasTheNextTurn(char p0)
        {
            context.Get<char>("currentPlayerMark").Should().Be(p0);
        }


    }
}
