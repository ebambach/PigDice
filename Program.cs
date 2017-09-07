using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceProject {
	class Program {
		int CurrentScore = 0;
		int HighScore = 0; //Stores the highest number of points score during the running of the program.
		int NewRoll;
		int RollCounter = 0;
		int Twos = 0;
		int Threes = 0;
		int Fours = 0;
		int Fives = 0;
		int Sixes = 0;

		Random r = new Random();

		void Debug(string message) {
			Console.WriteLine(message);
		}
		int DieRoll() {
			RollCounter++;
			var Roll = r.Next(1, 7);
			//Debug($"The value of the Roll is {Roll}.");
			switch (Roll){
				case 2:
					Twos++;
					break;
				case 3:
					Threes++;
					break;
				case 4:
					Fours++;
					break;
				case 5:
					Fives++;
					break;
				case 6:
					Sixes++;
					break;
			}
			return Roll;
		}
		int NewHighScore(int CurrentScore) {
			Console.Clear();
			if (CurrentScore > HighScore) {
				HighScore = CurrentScore;
				Debug($"The number of rolls was {RollCounter}, and you set a new high score of {HighScore} points.");				
			}
			else {
				Debug($"The number of rolls was {RollCounter}, you scored {CurrentScore} points, the high score remains at");
				Debug($"{HighScore} points.");
			}
			Debug("");
			Debug("                       You rolled:");
			Debug("");
			Debug($"             {Twos}      {Threes}      {Fours}      {Fives}      {Sixes}.");
			Debug("           -----  -----  -----  -----  -----");
			Debug("           |o  |  |o  |  |o o|  |o o|  |o o|");
			Debug("           |   |  | o |  |   |  | o |  |o o|");
			Debug("           |  o|  |  o|  |o o|  |o o|  |o o|");
			Debug("           -----  -----  -----  -----  -----");
			//Dice art is from https://codegolf.stackexchange.com/questions/2602/draw-dice-results-in-ascii
			Reset();
			return HighScore;
		}
		static void Main(string[] args) {
			new Program().Run();
		}

		void PlayAgain() {
			//Debug("Now running PlayAgain.");
			Console.WriteLine("Would you like to play again? Please type 'yes' or 'no.'");
				string YesNo = Console.ReadLine();
				//If the user holds down the enter/return key, YesNo defaults to "yes."
				if (YesNo == "") {
					YesNo = "yes";
				}
			YesNo = YesNo.ToLower();
			if (YesNo == "yes" || YesNo == "y") {
				YesNo = "yes";
				NewRoll = 0;
				CurrentScore = 0;
				Run();
			}
			if (YesNo == "no" || YesNo == "n") {
				YesNo = "no";
				Console.WriteLine("Thank you for playing!");
			}
			if (YesNo != "yes" && YesNo != "no") {
				Console.WriteLine($"Your response '{YesNo}' was not recognized as a valid response.");
				PlayAgain();
			}
		}
		void Reset() {
			RollCounter = 0;
			Twos = 0;
			Threes = 0;
			Fours = 0;
			Fives = 0;
			Sixes = 0;
		}
		void Run() {
				do {
					NewRoll = DieRoll();
					if (NewRoll == 1) {
						NewHighScore(CurrentScore);
						PlayAgain();
					}
					else {
						CurrentScore = CurrentScore + NewRoll;
					}
				}
				while (NewRoll != 1);
		}		
	}
}
