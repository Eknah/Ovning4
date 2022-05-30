// Övning 4
// --------
//
// Frågor:
//
// Teori och Fakta:
//
// 1)	När data lagras i stacken så läggs det i en "hög" så att det först lagrade objektet ligger längst ner
//		och det senast lagrade objektet läggs högst upp. Så för att komma åt ett objekt så måste alla ovanliggande
//		objekt plockas bort först.
//		När objekt lagras på heapen istället så är alla objekt tillgängliga samtidigt hela tiden, bara man vet vad
//		vad man letar efter.
//		Fördelen med data som lagras på stacken är att datan raderar sig självt när den har använts färdigt, till
//		skillnad mot heapen där lagrad data ligger kvar efter att den har använts.
//		Skiss på dom två olika strukturerna finns under Questions/StackAndHeap.png".
//
// 2)	Value types lagras på antingen stacken eller på heapen, beroende på var dom deklareras och
//		lagrar alltid det direkta värdet i minnet.
//		Reference types lagras alltid på heapen och lagrar istället adressen till värdet i minnet.
//		Exempel: Value types som skickas som parametrar till en funktion, skickas, som default,
//		som en kopia av värdet,
//		medan reference types som skickas som parametrar skickar en kopia av referensen, som pekar på samma instans
//		som originalvariablen, med andra ord så ändrar man då det faktiska värdet i fallen för reference types.
//
// 3)	Eftersom int är en value type så gäller att när y sätts till "=x" så kopieras värdet
//		av x till minnespositionen för y, x och y pekar då alltså på olika positioner i minnet men som
//		för stunden har samma värde. När y sedan sätts till "=4" så ändras bara variablen y och inte x, så
//		det som returneras är det utsprungliga värdet på x som är satt till 3.
//
//		I fallet för MyInt så gäller att MyInt måste vara en class som är en reference type. Därmed så lagrar
//		x minnesadressen till en instans av MyInt. När y sätts till "=x" så kopieras samma minnesadress från
//		x till y och dom båda pekar då på samma objekt. När sedan y.MyValue sätts till "=4" så sätts värdet
//		MyValue på det MyInt-objekt som både x och y pekar på, och det är detta som sedan returneras.
//
// Övning 1: ExamineList()
//
// 2)	Listans kapacitet ökas när Count överskrider Capacity.
//
// 3)	Kapaciteten fördubblas.
//
// 4)	Eftersom storleken på den underliggande arrayen inte kan ändra dynamiskt under runtime så måste en
//		ny array skapas varje gång storleken ska ändras, för att sedan kopiera över alla dom tidigare värdena.
//		Därför är det i regel mer effektivt att öka listans kapacitet med flera element åt gången.
//
// 5)	Nej listans kapacitet minskar inte när element tas bort.
//
// 6)	När man på förhand kan veta relativt noga hur många element som ska lagras i strukturen.
//
// Övning 3: ExamineStack()
//
// 1)	Därför att i en riktig kö i exempelvis en butik så är det personen/objektet som ställdes i kön först som
//		också först lämnar kön, mao. FIFO (First In First Out). I en stack är det istället personen/objektet som tillades till
//		stacken sist som först lämnar kön, mao. FILO (First In Last Out). En ICA-kö modelleras därför bäst
//		med en Queue och inte en Stack.

using System;


namespace SkalProj_Datastrukturer_Minne
{


	class Program
	{

		/// <summary>
		/// The main method, vill handle the menues for the program
		/// </summary>
		/// <param name="args"></param>
		static void Main()
		{
			while (true)
			{
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
					+ "\n1. Examine a List"
					+ "\n2. Examine a Queue"
					+ "\n3. Examine a Stack"
					+ "\n4. CheckParanthesis"
					+ "\n0. Exit the application");
				char input = ' '; //Creates the character input to be used with the switch-case below.
				try
				{
					input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
				}
				catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
				{
					Console.Clear();
					Console.WriteLine("Please enter some input!");
				}
				switch (input)
				{
					case '1':
						ExamineList();
						break;
					case '2':
						ExamineQueue();
						break;
					case '3':
						ExamineStack();
						break;
					case '4':
						CheckParanthesis();
						break;
					/*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
					case '0':
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
						break;
				}
			}
		}

		/// <summary>
		/// Examines the datastructure List
		/// </summary>
		static void ExamineList()
		{
			/*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

			//List<string> theList = new List<string>();
			//string input = Console.ReadLine();
			//char nav = input[0];
			//string value = input.substring(1);

			//switch(nav){...}

			Console.WriteLine("Examine a List: \n"
				+ "\n+Value"
				+ "\n-Value"
				+ "\n0 - Return to Main Menu");

			List<string> theList = new List<string>(); // The list to store content and to be examined
			bool returnToMainMenu = false;

			while (!returnToMainMenu) // Work with the list until user wants to return to main menu
			{
				// Print contents of the list each loop
				Console.WriteLine($"Current List Count: {theList.Count}");
				Console.WriteLine($"Current List Capacity: {theList.Capacity}");
				Console.Write($"Current contents:");
				foreach (var entry in theList)
					Console.Write($" '{entry}'");
				Console.WriteLine();

				string? input = Console.ReadLine();
				if (input != null)
				{

					char? nav = input[0]; // Get first char in input string
					string value = input.Substring(1); // Get the remaining part of the input string

					switch (nav)
					{
						case '+': // Add
							theList.Add(value);
							break;
						case '-': // Remove
							theList.Remove(value);
							break;
						case '0': // Return to main menu
							returnToMainMenu = true;
							break;
						default: // Invalid input command
							Console.WriteLine("Please enter either +Value or -Value");
							break;
					}
				}
			}
		}

		/// <summary>
		/// Examines the datastructure Queue
		/// </summary>
		static void ExamineQueue()
		{
			/*
			 * Loop this method untill the user inputs something to exit to main menue.
			 * Create a switch with cases to enqueue items or dequeue items
			 * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
			*/

			Console.WriteLine("Examine a Queue: \n"
					+ "\nt - Test"
					+ "\n0 - Return to Main Menu");

			Queue<string> theQueue = new Queue<string>();
			List<string>? queueOperations = null;

			string? input = Console.ReadLine();
			if (input != null)
			{

				char? nav = input[0]; // Get first character in input string
				string value = input.Substring(1); // Get remaining part of input string

				switch (nav)
				{
					case 't': // Test queue
						queueOperations = TestQueue();
						break;
					case '0': // return to main menu
						return;
					default: // Invalid input
						Console.WriteLine("Please enter a valid input.");
						break;
				}
			}

			if (queueOperations != null) // Check if the test queue data has been obtained from the ICA queue simulation
			{
				foreach (string operation in queueOperations)
				{
					switch (operation) // Each entry is either a name to be enqueued or a dequeue-command
					{
						case "Dequeue": // Deqeueu
							theQueue.Dequeue();
							break;
						default: // Enqueue, entry is a name
							theQueue.Enqueue(operation);
							break;
					}

					// Print contents after each queue operation
					Console.WriteLine($"Current Queue Count: {theQueue.Count}");
					Console.Write($"Current contents:");
					foreach (var entry in theQueue)
						Console.Write($" '{entry}'");
					Console.WriteLine();
				}
			}
		}

		/// <summary>
		/// Provides queue operations, simulating a queue in a ICA store
		/// </summary>
		/// <returns>Simulated queue actions</returns>
		static List<string> TestQueue()
		{
			var queueOperations = new List<string>(); // Contains simulated queue actions

			queueOperations.Add("Kalle");
			queueOperations.Add("Greta");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Stina");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Olle");
			queueOperations.Add("Pelle");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Adam");
			queueOperations.Add("Dequeue");
			queueOperations.Add("Dequeue");

			return queueOperations;
		}

		/// <summary>
		/// Examines the datastructure Stack
		/// </summary>
		static void ExamineStack()
		{
			/*
			 * Loop this method until the user inputs something to exit to main menue.
			 * Create a switch with cases to push or pop items
			 * Make sure to look at the stack after pushing and and poping to see how it behaves
			*/


			Console.WriteLine("Examine a Queue: \n"
					+ "\nr - Reverse Text"
					+ "\n0 - Return to Main Menu");

			string? input = Console.ReadLine(); // Get user action

			if (input != null)
			{
				char? nav = input[0]; // Get first char in input string
				string value = input.Substring(1); // Get remaining part of input string

				switch (nav)
				{
					case 'r': // Reverse
						Console.WriteLine("Input string to reverse: ");
						var text = Console.ReadLine();
						var reversed = ReverseText(text);
						Console.WriteLine($"Reversed: {reversed}");
						break;
					case '0': // Return to main menu
						return;
					default: // Invalid input
						Console.WriteLine("Please enter a valid input.");
						break;
				}
			}
		}

		/// <summary>
		/// Reverses the passed text string
		/// </summary>
		/// <param name="text">Text string to be reversed</param>
		/// <returns>The reversed text strings</returns>
		static string ReverseText(string text)
		{
			Stack<char> chars = new Stack<char>(); // Stores input string as a Stack of letters

			foreach (var c in text) // Fill the stack
				chars.Push(c);

			string result = String.Empty; // Will store the reversed string result

			for (var i = 0; i < text.Length; i++)
				result += (chars.Pop()); // Pop the letters from the stack, will be in reversed order

			return result;
		}

		static void CheckParanthesis()
		{
			/*
			 * Use this method to check if the paranthesis in a string is Correct or incorrect.
			 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
			 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
			 */

			Console.WriteLine("Check Paranthesis: \n"
					+ "\nc - Check String"
					+ "\n0 - Return to Main Menu");

			string? input = Console.ReadLine(); // Get user action
			if (input != null)
			{
				char? nav = input[0];

				switch (nav)
				{
					case 'c': // Check for paranthesis
						Console.WriteLine("Input string to check: ");
						var text = Console.ReadLine();
						var result = CheckStringForParanthesis(text);
						Console.WriteLine($"Format is correct: {result}");
						break;
					case '0': // Return to main menu
						return;
					default: // Invalid input
						Console.WriteLine("Please enter a valid input.");
						break;
				}
			}

		}

		/// <summary>
		/// Checks if the passed input string has a valid paranthesis format.
		/// </summary>
		/// <param name="text">Text string to be checked.</param>
		/// <returns>True on valid paranthesis format, otherwise false.</returns>
		private static bool CheckStringForParanthesis(string? text)
		{
			char[] openings = { '(', '[', '{', '<' };
			char[] closings = { ')', ']', '}', '>' };

			var openingChars = new Stack<char>(); // Will store all found opening paranthesises

			if (text != null)
			{
				foreach (char c in text) // Iterate through all letters
				{
					if (openings.Contains(c)) // Found an opening paranthesis
					{ 
						openingChars.Push(c); // Push to stack
					}
					else if (closings.Contains(c)) // Found a closing paranthesis
					{
						if (Array.IndexOf(openings, openingChars.Peek()) // Check if the last pushed opening is of the same type
						== Array.IndexOf(closings, c))					 // as the currently found closing paranthesis
						{
							openingChars.Pop(); // Then pop the last found opening
						}
					}

				}
			}

			if (openingChars.Count == 0) // No remaining unclosed paranthesis openings exist
				return true; // Check succeeded
			else
				return false; // Check failed
		}
	}
}

