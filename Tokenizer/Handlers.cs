using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine.Tokenizer
{
/*    class Handlers
    {
    }*/
    public class WhiteSpaceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return Char.IsWhiteSpace(t.input.peek());
        }
        static bool isWhiteSpace(Input input)
        {
            return Char.IsWhiteSpace(input.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            return new Token(t.input.Position, t.input.LineNumber,
                "whitespace", t.input.loop(isWhiteSpace));
        }
    }
    public class CommaTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.peek() == ',';
        }

        public override Token tokenize(Tokenizer t)
        {

            t.input.step();
            return new Token(t.input.Position, t.input.LineNumber,
                "comma", ",");
        }
    }

    public class StringTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            return Char.IsLetter(currentCharacter);
        }
        static bool isId(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }
        public override Token tokenize(Tokenizer t)
        {

            Token token = new Token(t.input.Position, t.input.LineNumber,
                "string", t.input.loop(isId));

            return token;
        }
    }


    public class NumberTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            return Char.IsDigit(currentCharacter);
        }
        static bool isNumb(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsDigit(currentCharacter);
        }
        public override Token tokenize(Tokenizer t)
        {

            Token token = new Token(t.input.Position, t.input.LineNumber,
                "number", t.input.loop(isNumb));

            return token;
        }
    }
}
