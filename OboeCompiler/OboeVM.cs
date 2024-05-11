using System;
using System.Runtime.CompilerServices;
using OboeCompiler.Calc;

namespace OboeCompiler
{
    public unsafe static class OboeVM
    {
        private static delegate* managed<Instruction, ref int, void>[] executorPtrs =
            new delegate* managed<Instruction, ref int, void>[128];

        private static Action<Instruction>[] executors = new Action<Instruction>[128];
        private static Func<float, float>[]  functions;

        #region Ops

        public static void AddOp(Instruction instruction, ref int pc)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);
            StoreMemPos(instruction.Dst.Ptr, src0 + src1);
        }

        public static void SubOp(Instruction instruction, ref int pc)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);
            StoreMemPos(instruction.Dst.Ptr, src0 - src1);
        }

        public static void MulOp(Instruction instruction, ref int pc)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);
            StoreMemPos(instruction.Dst.Ptr, src0 * src1);
        }

        public static void DivOp(Instruction instruction, ref int pc)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);
            StoreMemPos(instruction.Dst.Ptr, src0 / src1);
        }

        public static void CallOp(Instruction instruction, ref int pc)
        {
            float src1       = LoadMemPos(instruction.Src1.Ptr);
            var   callResult = GetCallResult(functions, instruction.Src0.Index, src1);
            StoreMemPos(instruction.Dst.Ptr, callResult);
        }

        public static void StoreOp(Instruction instruction, ref int pc)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            StoreMemPos(instruction.Dst.Ptr, src0);
        }

        public static void TrueAndJumpOp(Instruction instruction, ref int pc)
        {
            float boolValue = LoadMemPos(instruction.Dst.Ptr);

            if (boolValue != 0)
            {
                pc = instruction.Src0.Index - 1;
            }
            else
            {
                pc = instruction.Src1.Index - 1;
            }
        }

        public static void LargerOp(Instruction instruction, ref int _)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);

            StoreMemPos(instruction.Dst.Ptr, src0 > src1 ? 1 : 0);
        }

        public static void LargerEqualOp(Instruction instruction, ref int _)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);

            StoreMemPos(instruction.Dst.Ptr, src0 >= src1 ? 1 : 0);
        }

        public static void EqualOp(Instruction instruction, ref int _)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);

            StoreMemPos(instruction.Dst.Ptr, Math.Abs(src0 - src1) < 10e-6 ? 1 : 0);
        }

        public static void NotEqualOp(Instruction instruction, ref int _)
        {
            float src0 = LoadMemPos(instruction.Src0.Ptr);
            float src1 = LoadMemPos(instruction.Src1.Ptr);

            StoreMemPos(instruction.Dst.Ptr, Math.Abs(src0 - src1) >= 10e-6 ? 1 : 0);
        }

        public static void InitExecutors()
        {
            executorPtrs[(int)InstructionType.Add]         = &AddOp;
            executorPtrs[(int)InstructionType.Sub]         = &SubOp;
            executorPtrs[(int)InstructionType.Mul]         = &MulOp;
            executorPtrs[(int)InstructionType.Div]         = &DivOp;
            executorPtrs[(int)InstructionType.Store]       = &StoreOp;
            executorPtrs[(int)InstructionType.Call]        = &CallOp;
            executorPtrs[(int)InstructionType.TrueAndJump] = &TrueAndJumpOp;
            executorPtrs[(int)InstructionType.Larger]      = &LargerOp;
            executorPtrs[(int)InstructionType.LargerEqual] = &LargerEqualOp;
            executorPtrs[(int)InstructionType.Equal]       = &EqualOp;
            executorPtrs[(int)InstructionType.NotEqual]    = &NotEqualOp;
        }

        #endregion

        public static void Execute(Instruction[] instructions, Func<float, float>[] func)
        {
            functions = func;
            int pcRegister = 0;

            while (pcRegister < instructions.Length)
            {
                Execute(instructions[pcRegister], functions, ref pcRegister);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Execute(Instruction instruction, Func<float, float>[] functions, ref int pcRegister)
        {
            executorPtrs[(int)instruction.Type](instruction, ref pcRegister);
            pcRegister++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float GetCallResult(Func<float, float>[] functions, int index, float src)
        {
            return functions[index](src);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LoadMemPos(IntPtr memPos)
        {
            float* ptr = (float*)memPos;
            return *ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void StoreMemPos(IntPtr memPos, float value)
        {
            float* ptr = (float*)memPos;
            *ptr = value;
        }

        #region Bind

        public static void LinkExternal(Instruction[] generatorInstructions, OboeStructLinker linker)
        {
            for (int i = 0; i < generatorInstructions.Length; i++)
            {
                var ins = generatorInstructions[i];

                if (ins.Src0.Type == MemPos.MemType.External) ins.Src0.Ptr = linker.IndexToPtr[ins.Src0.Index];
                if (ins.Src1.Type == MemPos.MemType.External) ins.Src1.Ptr = linker.IndexToPtr[ins.Src1.Index];
                if (ins.Dst.Type  == MemPos.MemType.External) ins.Dst.Ptr  = linker.IndexToPtr[ins.Dst.Index];

                generatorInstructions[i] = ins;
            }
        }

        public static void LinkContext(Instruction[] generatorInstructions, ExecuteContext context)
        {
            for (int i = 0; i < generatorInstructions.Length; i++)
            {
                var ins = generatorInstructions[i];

                if (context.IsValueType(ins.Src0)) ins.Src0.Ptr = context.GetPtr(ins.Src0);
                if (context.IsValueType(ins.Src1)) ins.Src1.Ptr = context.GetPtr(ins.Src1);
                if (context.IsValueType(ins.Dst)) ins.Dst.Ptr   = context.GetPtr(ins.Dst);

                generatorInstructions[i] = ins;
            }
        }

        #endregion
    }
}