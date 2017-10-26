using System;
using System.Collections;
/* test input
 * 
 * 
 * 
 * 
 */
namespace cssrandomizer
{
	class MainClass
	{
		public static int maxfontsize=30;
		public static bool colormodeoff= false;
		public static bool posmod = false;
		public static void Main (string[] args)
		{
			Console.WriteLine ("(C) Lucas Klein 2017 CSS RANDOMIZER");
			Console.WriteLine ("Gen flage code: -[maxfontsize only 2 digits] -[color mode off is 1 or color mode off 0] -[positionmod 1 is on 0 is off]");
			Console.WriteLine("example genflag code: -88 -0 -1");
			Console.WriteLine("flags can also be passed as args through command prompt");

			Console.WriteLine ("ENTER GEN FLAGS:");
			string genflags = Console.ReadLine() +"     ";

			if (genflags.IndexOf ('-') != -1 && args.Length == 0) {
				maxfontsize = int.Parse (genflags.Substring (genflags.IndexOf ("-") + 1, genflags.IndexOf ("-") + 3));

				genflags = genflags.Substring (genflags.IndexOf ("-") + 1);
				if (genflags.IndexOf ('-') != -1) {
					if (int.Parse (genflags.Substring (genflags.IndexOf ("-")+1, 1)) == 1) {
						colormodeoff = true;
					}
				}
				genflags = genflags.Substring (genflags.IndexOf ("-") + 2);
				if (genflags.IndexOf ('-') != -1) {
					if (int.Parse (genflags.Substring (genflags.IndexOf ("-")+1, 1)) == 1) {
						posmod = true;
					}
				}
			} else if (args.Length > 0) {
				//get flags from args

			}

			Console.WriteLine ("ENTER HTML CODE(MUST BE ONE LINE): ");
			string input = Console.ReadLine ();
			Console.WriteLine (input);
			Console.WriteLine("----------------OUTPUT---------------");
			for (int pos = 0; pos < input.Length - 3; pos++) {
				//p tag here
				if (input.Substring (pos, 3).Equals ("<p>")) {
					Console.WriteLine ("found p tag to randomize");
					string csscode = getcsscode ();

					input = input.Insert (pos + 2, " style='"+csscode +"'");

					Console.WriteLine (input.Substring (pos, 10));
					System.Threading.Thread.Sleep (50);
				}
			
					
			}


			Console.WriteLine (input);
		}

		public static string getcsscode(){
			Random rand = new Random ();
			string output ="";
			int randnum = rand.Next(10, maxfontsize);
			output+="font-size: "+randnum+"px;";
			if (!colormodeoff) {
				string color = "rgb(" + rand.Next (1, 255) + "," + rand.Next (1, 255) + "," + rand.Next (1, 255) + ")";
				output += " color:" + color + "; ";
			}
			if (posmod) {
				output+="position:absolute; top:"+rand.Next(-200,200)+"px;"+"left: "+ rand.Next(-200,200)+"px;";
			}











			return output;

		}
	}
}
