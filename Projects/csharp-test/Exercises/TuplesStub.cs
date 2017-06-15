// { autofold
using System;
using System.Linq;
using System.Collections.Generic;

namespace Answer
{
	public class TuplesStub
	{
// }

private static readonly List<(int Id, string, string)> DB = new List<(int, string, string)>()
{
    (1, "John", "Doe"),
    (2, "A", "B"),
    (3, "Jane", "Doe")
};

public static (int Id, string FirstName, string LastName) LookupName(int id)
{
    // You can use Linq to retrieve info from DB and then return the first correct tuple.
	return (1, "John", "Doe");
}
//{ autofold
	}
}
//}
