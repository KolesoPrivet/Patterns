using System;

namespace Interpreter
{
    class Program
    {
        static void Main()
        {
            Context context = new Context {Vocabulary = 'a', Source = "aaa"};

            var expression = new NonTerminalExpression();
            expression.Interpret(context);

            Console.WriteLine(context.Result    );
        }
    }

    class Context
    {
        // Контекст распознающей граматики языка;

        public string Source { get; set; }
        public char Vocabulary { get; set; }
        public bool Result { get; set; }
        public int Position { get; set; }
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            context.Result = 
                context.Source[context.Position] == context.Vocabulary;
        }
    }

    class NonTerminalExpression : AbstractExpression
    {
        private AbstractExpression nonTerminalExpression;
        private AbstractExpression terminalExpression;

        public override void Interpret(Context context)
        {
            if (context.Position < context.Source.Length)
            {
                terminalExpression = new TerminalExpression();
                terminalExpression.Interpret(context);
                context.Position++;

                if (context.Result)
                {
                    nonTerminalExpression = new NonTerminalExpression();
                    nonTerminalExpression.Interpret(context);
                }
            }
        }
    }
}
