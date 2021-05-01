using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine.Tokenizer
{
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
        static bool isString(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetter(currentCharacter);
        }
        public override Token tokenize(Tokenizer t)
        {

            Token token = new Token(t.input.Position, t.input.LineNumber,
                "string", t.input.loop(isString));

            return token;
        }
    }

    public class ColorTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            return currentCharacter =='#' ;
        }
        static bool isColor(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsLetterOrDigit(currentCharacter);
        }
        public override Token tokenize(Tokenizer t)
        {
            t.input.step();
            Token token = new Token(t.input.Position, t.input.LineNumber,
                "color", t.input.loop(isColor));
            if (token.Value.Length < 6)
                while (token.Value.Length < 6)
                    token.Value += "0";

            return token;
        }
    }


    public class NumberTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            return Char.IsDigit(currentCharacter) || currentCharacter == '-';
        }
        static bool isNumb(Input input)
        {
            char currentCharacter = input.peek();
            return Char.IsDigit(currentCharacter);
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token(t.input.Position, t.input.LineNumber,"number", "");
            token.Value += t.input.step().Character;
            token.Value += t.input.loop(isNumb);

            return token;
        }
    }
}
