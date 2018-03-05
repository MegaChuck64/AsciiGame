using System.Drawing;

namespace Tools
{
    public class Structures
    {
        struct Ascii
        {
            public char symbol;

            public Brush color;

            public Ascii(char sym, Brush col)
            {
                symbol = sym;
                color = col;
            }
        }
    }
}
