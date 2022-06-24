using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class BoardRowCol
    {
        public int Row { get; set; }
        public int Column { get; set; }

        private readonly StringBuilder _output;

        public BoardRowCol(int row, int column)
        {
            Row = row;
            Column = column;
            _output = new StringBuilder();
        } 


        public override string ToString()
        {
            switch (Column)
            {
                case 0:
                    _output.Append("A");
                    break;
                case 1:
                    _output.Append("B");
                    break;
                case 2:
                    _output.Append("C");
                    break;
                case 3:
                    _output.Append("D");
                    break;
                case 4:
                    _output.Append("E");
                    break;
                case 5:
                    _output.Append("F");
                    break;
                case 6:
                    _output.Append("G");
                    break;
                case 7:
                    _output.Append("H");
                    break;
            }

            switch (Row)
            {
                case 1:
                    _output.Append("8");
                    break;
                case 2:
                    _output.Append("7");
                    break;
                case 3:
                    _output.Append("6");
                    break;
                case 4:
                    _output.Append("5");
                    break;
                case 5:
                    _output.Append("4");
                    break;
                case 6:
                    _output.Append("3");
                    break;
                case 7:
                    _output.Append("2");
                    break;
                case 8:
                    _output.Append("1");
                    break;
            }

            return _output.ToString();
        }
    }
}
