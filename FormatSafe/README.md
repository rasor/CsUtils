# FormatSafe

FormatSafe enables doing string.Format() with too few and too many parameters.  

Using FormatSafe15():  

```csharp
static void Main(string[] args)
{
    var body = "here is 0: {0}, 1: {1}, 2: {2} and 14: {14}";
    Console.WriteLine("body: " + body);
    Console.WriteLine();

    Console.WriteLine("Too few parameters. All elems are in body, but body expects also {14}");
    var res = FormatSafe15(body, "a", "b", "c");
    Console.WriteLine(res);

    Console.WriteLine("'d' is not in body");
    res = FormatSafe15(body, "a", "b", "c", "d");
    Console.WriteLine(res);

    Console.WriteLine("Too many parameters. '16' is more than FormatSafe15 will handle. It will be ignored");
    res = FormatSafe15(body, "a1", "b1", "c1", "d1", "e1", "a2", "b2", "c2", "d2", "e2", "a3", "b3", "c3", "d3", "e3", "16");
    Console.WriteLine(res);

    Console.WriteLine("-------------");

    body = "here is 0: {0}, 1: {1}, 2: {2} and 9: {9}";
    Console.WriteLine("body: " + body);
    Console.WriteLine();

    Console.WriteLine("Too many parameters. body don't include 'a3'");
    res = FormatSafe15(body, "a1", "b1", "c1", "d1", "e1", "a2", "b2", "c2", "d2", "e2", "a3");
    Console.WriteLine(res);
}
```

Output:

```bash
$ dotnet run
# body: here is 0: {0}, 1: {1}, 2: {2} and 14: {14}

# Too few parameters. All elems are in body, but body expects also {14}
# here is 0: a, 1: b, 2: c and 14:
# 'd' is not in body
# here is 0: a, 1: b, 2: c and 14: 
# Too many parameters. '16' is more than FormatSafe15 will handle. It will be ignored
# here is 0: a1, 1: b1, 2: c1 and 14: e3
# -------------
# body: here is 0: {0}, 1: {1}, 2: {2} and 9: {9}

# Too many parameters. body don't include 'a3'
# here is 0: a1, 1: b1, 2: c1 and 9: e2
```

The End
