using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_to_arduino
{
    class calculator
    {
        private int _commandcase = 0;

        public int Commandcase
        {
            get
            {
                return _commandcase;
            }
        }

        public void Calc(ref double number, ref string tempnumber, ref string display, char i)
        {
            try
            {
                switch (Commandcase)
                {
                    case 0:
                        number = Convert.ToDouble(tempnumber);
                        display += string.Format("{0:0.##}", tempnumber) + " ";
                        tempnumber = "";
                        StoreCommand(i);
                        break;
                    case 1:
                        number += Convert.ToDouble(tempnumber);
                        display += "+ " + string.Format("{0:0.##}", tempnumber) + " ";
                        tempnumber = "";
                        StoreCommand(i);
                        break;
                    case 2:
                        number -= Convert.ToDouble(tempnumber);
                        display += "- " + string.Format("{0:0.##}", tempnumber) + " ";
                        tempnumber = "";
                        StoreCommand(i);
                        break;
                    case 3:
                        number *= Convert.ToDouble(tempnumber);
                        display += "* " + string.Format("{0:0.##}", tempnumber) + " ";
                        tempnumber = "";
                        StoreCommand(i);
                        break;
                    case 4:
                        number /= Convert.ToDouble(tempnumber);
                        display += "/ " + string.Format("{0:0.##}", tempnumber) + " ";
                        tempnumber = "";
                        StoreCommand(i);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                _commandcase = 6;
            }

        }

        public void StoreCommand(char i)
        {
            if (i == '+')
            {
                _commandcase = 1;
            }
            else if (i == '-')
            {
                _commandcase = 2;
            }
            else if (i == '*')
            {
                _commandcase = 3;
            }
            else if (i == '/')
            {
                _commandcase = 4;
            }
            else if (i == '=')
            {
                _commandcase = 5;
            }
        }
    }
}
