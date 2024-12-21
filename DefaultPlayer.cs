using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankalah;

public class defaultPlayer : Player
{
	public defaultPlayer(Position pos, int timeLimit) : base(pos, "defaultPlayer", timeLimit) { }

	public override string gloat()
	{
		return "Victory is MINE hehehehe";
	}
	public override int chooseMove(Board b)
	{
		//int bestMove = -1;
		//int bestScore = int.MinValue;

		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();

		int timeLimit = 4000; // Limit to 4 seconds
		int depth = 5; // start with more than depth 1 to improve speed.

		moveResult result = new moveResult(0, 0); //base case

		// Iterate over increasing depths until time runs out
		while (stopwatch.ElapsedMilliseconds < timeLimit)
		{
			// Perform minimax search for the current depth
			result = minimax(b, depth, int.MinValue, int.MaxValue, stopwatch, timeLimit);

			// Increment depth for the next iteration
			depth++;

		}
		return result.getBestMove();

		stopwatch.Stop();
	}

	public override int evaluate(Board b)
	{
		return b.stonesAt(13) - b.stonesAt(6);

	}
	private moveResult minimax(Board b, int depth, int alpha, int beta, Stopwatch stopwatch, int timeLimit)
	{
		if (depth == 0 || b.gameOver() || stopwatch.ElapsedMilliseconds >= timeLimit)
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
					moveResult val = minimax(b1, depth - 1, alpha, beta, stopwatch, timeLimit);
					if (val.getBestScore() > bestVal)
					{
						bestVal = val.getBestScore();
						bestMove = move;
					}
					if (stopwatch.ElapsedMilliseconds >= timeLimit)
					{
						break;
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
					moveResult val = minimax(b1, depth - 1, alpha, beta, stopwatch, timeLimit);
					if (val.getBestScore() < bestVal)
					{
						bestVal = val.getBestScore();
						bestMove = move;
					}
					if (stopwatch.ElapsedMilliseconds >= timeLimit)
					{
						break;
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
