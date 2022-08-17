using System;
class CheckString
{
	public static char[] copyOfRange(char[] symbol, int start,int end)
	{
			int length = end - start;
			char[] newchar = new char[length];
			Array.Copy(symbol, start, newchar, 0, length);
			return newchar;
	}

	static char EndSymbol(char symbol)
	{
		if (symbol == '(')
        {
			return ')';
		}	
		if (symbol == '{')
        {
			return '}';
		}
		if (symbol == '[')
        {
			return ']';
		}
			
		return char.MinValue;
	}

	static bool checkOrder(char[] symbols,int n)
	{
		if (n == 0)
			return true;
		if (n == 1)
			return false;
		if (symbols[0] == ')' ||symbols[0] == '}' ||symbols[0] == ']')
			return false;

		char end = EndSymbol(symbols[0]);

		int i, count = 0;
		for (i = 1; i < n; i++)
		{
			if (symbols[i] == symbols[0])
				count++;
			if (symbols[i] == end)
			{
				if (count == 0)
					break;
				count--;
			}
		}
		if (i == n)
			return false;
		if (i == 1)
			return checkOrder(copyOfRange(symbols,i + 1, n),n - 2);
		return checkOrder(copyOfRange(symbols, 1, n),i - 1) && checkOrder(copyOfRange(symbols, (i + 1),n), n - i - 1);
	}

	public static void Main(String[] args)
	{

		Console.Write("Enter the symbol: ");
        string userInput = Console.ReadLine();
		char[] symbol = userInput.ToCharArray();
		int n = symbol.Length;
		char[] symbol1 = new char[n-2]; ;
		if (symbol[0] == '"' && symbol[n-1] == '"')
        {
			for(int i = 1; i < n - 1; i++)
            {
				symbol1[i - 1] = symbol[i];
            }
			Console.WriteLine(checkOrder(symbol1, n-2));
		}
        else
        {
			Console.WriteLine(checkOrder(symbol, n));
		}
		
	}
}