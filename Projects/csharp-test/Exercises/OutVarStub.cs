// { autofold
using System;
using static System.Console;

namespace Answer
{
	public class OutVarStub
	{
// }
public static string PrintStars(string starsValue)
{
    int startCount;
    if (int.TryParse(starsValue, out startCount))  // Fix this line to use the C# 7.0 syntax
        return new string('*', startCount);
    else
       return "Cloudy - no stars tonight!";
}
//{ autofold
	}
}
//}
