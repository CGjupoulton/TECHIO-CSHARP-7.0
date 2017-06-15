// { autofold
using System;
using static System.Console;

namespace Answer
{
	public class IsExpressionStub
	{
// }
public static string PrintStars(object o)
{
    if (o is int i || (o is string s && int.TryParse(s, out i)))
        return new string('*', i);
    else
       return "Cloudy - no stars tonight!";
}
//{ autofold
	}
}
//}
