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
		Random r = new Random();

		void Debug(string message) {
			Console.WriteLine(message);
		}
		int DieRoll() {
			var Roll = r.Next(1, 7);
			Debug($"The value of the Roll is {Roll}.");
			return Roll;
		}
		int NewHighScore(int CurrentScore) {
			if (CurrentScore > HighScore) {
				HighScore = CurrentScore;
				Debug($"You set a new HighScore of {HighScore} points.");				
			}
			else {
				Debug($"You scored {CurrentScore} points, the HighScore remains at {HighScore} points.");
			}
			return HighScore;
		}
		static void Main(string[] args) {
			new Program().Run();
		}

		void PlayAgain() {
			//Debug("Now running PlayAgain.");
			Console.WriteLine("Would you like to play again? Please type 'yes' or 'no.'");
				string YesNo = Console.ReadLine();
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
