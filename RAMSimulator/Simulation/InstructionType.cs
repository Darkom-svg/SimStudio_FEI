namespace FEI.RandomAccessMachine.Simulation {
	//Typ inštrukcie
	public enum InstructionType : byte
    {
        Read = 0,
        Write = 1,
        Load = 2,
        Store = 3,
        Add = 4,
        Subs = 5,
        Mult = 6,
        Div = 7,
        Jump = 8,
        JZero = 9,
        JGZero = 10,
        Halt = 11,
        Accept = 12,
        Reject = 13,
        While = 14,
        BlockBegin = 15,
        BlockEnd = 16,
        Push = 17,
        Pop = 18,
        Print = 19, // Vypise text
        ChangeIR = 20, // Zmeni reprezentaciu vstupu
        Do = 21,
        If = 22,
        IfBlockBegin = 23,
        IfBlockEnd = 24,
        WhileBlockBegin = 25,
        WhileBlockEnd = 26,
        DoWhileBlockBegin = 27,
        DoWhileBlockEnd = 28,
        Nop = 255
    }
}
