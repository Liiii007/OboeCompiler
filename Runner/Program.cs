using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Antlr4.Runtime;
using OboeCompiler;
using OboeCompiler.Calc;

namespace Runner
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            string input = "$bind.a=1;if($bind.a==2){$bind.a=sin(cos(1)+sin(2));}else{$bind.b=5;}";
            var    root  = GetRootProgramAST(input);

            OboeBackend      compiler = new OboeBackend();
            OboeStructLinker linker   = new OboeStructLinker();
            Instruction[]    instrs;
            ExecuteContext   context;

            BindTest.LinkId(linker);
            compiler.SetLinker(linker);
            compiler.AppendProgram(root);
            instrs  = compiler.Instructions.ToArray();
            context = ExecuteContext.GetExecuteContext(compiler);

            BindTest[] test   = new BindTest[100];
            var        handle = GCHandle.Alloc(test, GCHandleType.Pinned);

            OboeVM.InitExecutors();
            OboeVM.LinkContext(instrs, context);

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < 100; i++)
            {
                var ptr = (BindTest*)handle.AddrOfPinnedObject() + i;
                BindTest.BindValue(ptr, linker);

                //每次执行前都重新绑定一次外部变量，内部变量不需要重新绑定
                OboeVM.LinkExternal(instrs, linker);
                OboeVM.Execute(instrs, OboeBackend.functions);
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        private static CalcParser.ProgContext GetRootProgramAST(string input)
        {
            AntlrInputStream       inputStream = new AntlrInputStream(input);
            CalcLexer              lexer       = new CalcLexer(inputStream);
            CommonTokenStream      tokens      = new CommonTokenStream(lexer);
            CalcParser             parser      = new CalcParser(tokens);
            CalcParser.ProgContext root        = parser.prog();
            return root;
        }
    }
}