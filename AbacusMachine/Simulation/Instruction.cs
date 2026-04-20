namespace FEI.AbacusMachine.Simulation {
	public struct Instruction
    {
        public AMOperation operation;
        public int register;

        public Instruction(AMOperation operation, int register)
        {
            this.operation = operation;
            this.register = register;
        }
    }

}
