using System.Collections.Generic;

namespace Game_Programming_Patterns.Bytecode
{
    public class VM
    {
        private readonly Stack<int> stack = new Stack<int>();

        private void Push(int value)
        {
            stack.Push(value);
        }

        private int Pop()
        {
            return stack.Pop();
        }

        public void Interpret(char[] bytecode)
        {
            for (int index = 0; index < bytecode.Length; index++)
            {
                Instruction instruction = (Instruction)bytecode[index];
                switch (instruction)
                {
                    case Instruction.SET_HEALTH:
                        int amount = Pop();
                        int wizard = Pop();
                        break;

                    case Instruction.SET_WISDOM:
                        break;

                    case Instruction.SET_AGILITY:
                        break;

                    case Instruction.PLAY_SOUND:
                        int sound = Pop();
                        break;

                    case Instruction.SPAWN_PARTICLES:
                        int particles = Pop();
                        break;

                    case Instruction.INT_LITERAL:
                        // Read the next byte from the bytecode.
                        int value = bytecode[index++];
                        Push(value);
                        break;

                    case Instruction.GET_HEALTH:
                        Push(Pop()); // instead, use pop value to access some wizard's health
                        break;

                    case Instruction.GET_WISDOM:
                        // same as get_health
                        break;

                    case Instruction.GET_AGILITY:
                        // same as get_health
                        break;

                    case Instruction.ADD:
                        Push(Pop() + Pop());
                        break;

                    case Instruction.DIVIDE:
                        Push(Pop() / Pop());
                        break;

                    case Instruction.JUMP:
                        index += Pop(); // pray to the gods that stack isn't overflowed
                        break; // this feature is literal spaghetti code
                }
            }
        }
    }
}
