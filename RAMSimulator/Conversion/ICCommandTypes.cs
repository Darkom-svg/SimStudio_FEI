namespace DusanRodina.RandomAccessMachine.Conversion {
	//Typy príkazov
	public enum ICCommandTypes
    {
        Assignment = 0,

        If = 1, 
        Else = 2, 
        EndIf = 3,

        For = 4, 
        EndFor = 5,

        While = 6, 
        EndWhile = 7,

        Print = 8,
        Goto = 9,
    }
}
