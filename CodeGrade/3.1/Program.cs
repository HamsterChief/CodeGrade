IStack<char> stk = new Solution.Stack<char>(1);
stk.Push('a');
stk.Push('b');
char[] actual = new char[4];
actual[0] = stk.Pop();
stk.Push('c');
actual[1] = stk.Pop();
actual[2] = stk.Pop();
actual[3] = stk.Pop();
System.Console.WriteLine();