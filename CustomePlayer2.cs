using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalah;

public class jxcPlayer2 : Player
{
    public jxcPlayer2(Position pos, int timeLimit) : base(pos, "jxcPlayer2", timeLimit) { }

    public override string gloat()
    {
        return "Victory is MINE hehehehe";
    }
    public override int chooseMove(Board b)
    {

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int timeLimit = 3500; // Limit to 4 seconds
        int depth = 5; // start with more than depth 1 to improve speed.

        moveResult result = new moveResult(0, 0); //base case

        // Iterate over increasing depths until time runs out
        while (stopwatch.ElapsedMilliseconds < timeLimit)
        {
            // Perform minimax search for the current depth
            result = minimax(b, depth, int.MinValue, int.MaxValue);

            // Increment depth for the next iteration
            depth++;

        }
        return result.getBestMove();

    }

    public override int evaluate(Board b)
    {
        int scoredif = b.stonesAt(13) - b.stonesAt(6);
        int totalStones = 0;
        int GoAgainPotential = 0;
        int CapturePotential = 0;
        int Target = 0;
        //int EmptySpot = 0;
        //int opponentStoneCount = 0; // Opponent's stones
        if (b.whoseMove() == Position.Top)
        {
            for (int i = 7; i < 13; i++)
            {
                totalStones += b.stonesAt(i);
                Target = (i + b.stonesAt(i)); // calculate the target
                if (b.stonesAt(i) == (13 - i))
                    GoAgainPotential++;
                // if target is within the top pit, origionally no stone in it, the opponent complementary pit has stone.
                if (Target < 13 && (b.stonesAt(Target) == 0 && b.stonesAt(12 - Target) > 0))
                    CapturePotential += (b.stonesAt(12 - Target));
                if (Target > 13)
                {
                    scoredif++;
                }
                //if (b.stonesAt(i) == 0) EmptySpot++;
                //for (int j = 0; j < 6; j++) { opponentStoneCount += b.stonesAt(j); }
            }
            //return scoredif * 5 + GoAgainPotential * 4 + CapturePotential * 3 + SumAtMySide - EmptySpot*2 - opponentStoneCount*2;
        }
        else
        {

            for (int i = 0; i < 6; i++)
            {
                totalStones -= b.stonesAt(i);
                Target = (i + b.stonesAt(i));
                if (b.stonesAt(i) == (13 - i))
                    GoAgainPotential--;
                if (Target < 13 && Target < 6 && b.stonesAt(Target) == 0 && b.stonesAt(12 - Target) > 0)
                    CapturePotential -= (b.stonesAt(12 - Target));
                if (Target > 13)
                {
                    scoredif--;
                }
                //if (b.stonesAt(i) == 0) EmptySpot--;
                //for (int j = 0; j < 6; j++) { opponentStoneCount += b.stonesAt(j); }

            }
        }
        return (2 * scoredif + GoAgainPotential + 2*CapturePotential + totalStones);

    }
    private moveResult minimax(Board b, int depth, int alpha, int beta)
    {
        if (depth == 0 || b.gameOver())
            return new moveResult(0, evaluate(b));

        int bestVal = int.MinValue;
        int bestMove = 0;
        if (b.whoseMove() == Position.Top)
        {
            for (int move = 7; move < 13 && alpha < beta; move++)
            {
                if (b.legalMove(move))
                {
                    Board b1 = new Board(b);
                    b1.makeMove(move, false);
                    moveResult val = minimax(b1, depth - 1, alpha, beta);
                    if (val.getBestScore() > bestVal)
                    {
                        bestVal = val.getBestScore();
                        bestMove = move;
                    }

                    if (bestVal > alpha)
                        alpha = bestVal;
                }
            }
        }
        else
        {
            bestVal = int.MaxValue;
            for (int move = 0; move < 6 && alpha < beta; move++)
            {
                if (b.legalMove(move))
                {
                    Board b1 = new Board(b);
                    b1.makeMove(move, false);
                    moveResult val = minimax(b1, depth - 1, alpha, beta);
                    if (val.getBestScore() < bestVal)
                    {
                        bestVal = val.getBestScore();
                        bestMove = move;
                    }

                    if (bestVal < beta)
                        beta = bestVal;
                }
            }

        }
        return new moveResult(bestMove, bestVal);
    }
    private class moveResult
    {
        public int move;
        public int score;

        public moveResult(int move, int score)
        {
            this.move = move;
            this.score = score;
        }
        public int getBestMove() { return move; }
        public int getBestScore() { return score; }
    }
}
