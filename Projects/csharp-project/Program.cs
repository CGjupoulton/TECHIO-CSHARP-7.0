// { autofold
using System;
using static System.Console;

namespace Sandbox
{
    class Program
    {
		public static void PrintMessage(string chan, string mess) => WriteLine($"TECHIO> message --channel \"{chan}\" \"{mess}\"");
		static Random rnd = new Random();

		class Point
		{
			private int X;
            private int Y;
			public Point(int x, int y) { X = x; Y = y; }

			public void Deconstruct(out int x, out int y) { 
                PrintMessage("DECONSTRUCTION", $"Deconstruct(...) have been called.");  
                x = X; y = Y; 
            }
            
            public void GetCoordinates(out int x, out int y) { x = X; y = Y; }
            // Without C#7.0, it would have thrown an: Unexpected symbol `throw' in class, struct, or interface member declaration
            public double Distance(Point other) => throw new NotImplementedException();

            public static Point GetPoint() => new Point(rnd.Next(100), rnd.Next(100));
		}
        
        /* 
            REF
        */                
        class RefTest {
            private int[] _data = {15, 24, 37, 41};
            public int Read(int number) => _data[number];
            public int Find(int number) => _data[number];           
            public ref int FindRef(int number) => ref _data[number];
        }
        /*
            SWITCH PATTERN
        */
        public static void PrintStarsSwitch(object o)
        {
            // The default clause is always evaluated last
            // If both 10 and 20 are true, only "There is more than 10 stars" will be print.
            // Because switch clause have now an top->bottom order.
            PrintMessage("SWITCH PATTERN", $"Process {o.GetType()}:{o}");
            switch (o)
            {
                default:
                    PrintMessage("SWITCH PATTERN", "Cloudy - no stars tonight!");
                    break;
                case double d when d > 10:
                    PrintMessage("SWITCH PATTERN", "There is more than 10 stars");
                    break;
                case double d when d > 20:
                    PrintMessage("SWITCH PATTERN", "There is more than 20 stars");
                    break;
            }
            PrintMessage("SWITCH PATTERN", String.Empty);
        }
// }
        static void Main(string[] args)
        {
            #region OUT_PARAMS
            /* OLD Syntax */
            int a, b;
            Point.GetPoint().GetCoordinates(out a, out b);
            PrintMessage("OUT PARAMS", $"My coordinates: ({a}, {b})");
            
            /* C# 7.0 (Inline statement & var keyword is available) */
            Point.GetPoint().GetCoordinates(out var x, out var y);
            PrintMessage("OUT PARAMS", $"My coordinates: ({x}, {y})");
            
            #endregion
    
            #region DECONSTRUCTION      // { autofold  
            (var myX, var myY) = Point.GetPoint();  // Will call Point.Deconstruct(...)
            // Other valid syntax
			// (var myX1, _) = Point.GetPoint();
			// (_, var myY2) = Point.GetPoint();		
            // var (myX3, myY3) = Point.GetPoint();			

			PrintMessage("DECONSTRUCTION", $"Syntax (var myX, var myY) : [{myX}, {myY}]");  
            #endregion // }
         
            #region REF                 // { autofold
            RefTest refExample = new RefTest();
            
			int copy = refExample.Find(3);copy++; // Here, we increment a local variable.
			PrintMessage("REF", $"Without ref: refExample.Read(3) = {refExample.Read(3)}");
			
			ref int reference = ref refExample.FindRef(3);reference++; // Here, we increment the ref.
			PrintMessage("REF", $"With ref   : refExample.Read(3) = {refExample.Read(3)}");
            #endregion // }

            #region SWITCH_PATTERN      // { autofold
            PrintStarsSwitch(42d);
            PrintStarsSwitch(42_000_000d);  // Digit separator is also a C#7.0 feature !
            PrintStarsSwitch(0b0010_1010); // Binary literals too !

            #endregion // }

            #region LOCAL_FUNCTION      // { autofold
            Fibonacci(7);

            int Fibonacci(int step)
            {
                PrintMessage("LOCAL FUNCTION", $"In Fibonacci, computing {step} steps.");
    
                if (step < 0) throw new ArgumentException("Less negativity please!", nameof(step));
                return Fib(step).current;
                
                // New tuples syntax
                (int current, int previous) Fib(int i)
                {
                    PrintMessage("LOCAL FUNCTION", $"In Fib, computing {new String(' ', step - i)} {i}");
                    if (i == 0) return (1, 0);
                    var (p, pp) = Fib(i - 1);
                    return (p + pp, p);
                }
            }
            #endregion // }

        }

// { autofold
    }
}
// }
