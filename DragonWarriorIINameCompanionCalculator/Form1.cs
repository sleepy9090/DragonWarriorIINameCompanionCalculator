/**
 *  @file           DragonWarriorIINameCompanionCalculator.cs
 *  @brief          Defines the logic for calculating the companion names from the entered heroes name.
 *  
 *  @copyright      2019 Shawn M. Crawford [sleepy]
 *  @date           10/17/2019
 *
 *  @remark Author  Shawn M. Crawford [sleepy]
 *
 *  @note           N/A
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragonWarriorIINameCompanionCalculator
{
    public partial class Form1 : Form
    {

        private static readonly string[] _PRINCE_NAMES =
            { "Bran", "Glynn", "Talint", "Numor", "Lars", "Orfeo", "Artho", "Esgar" };

        private static readonly string[] _PRINCESS_NAMES =
            { "Varia", "Elani", "Ollisa", "Roz", "Kailin", "Peta", "Illyth", "Gwen" };

        private static readonly int _MAGIC_NUMBER_1 = 0x180;

        private static readonly int _MAGIC_NUMBER_2 = 0x7;

        private static readonly int _MAGIC_NUMBER_3 = 0x38;

        private static readonly int _MAGIC_NUMBER_4 = 0x8;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string heroName = textBoxName.Text;
            string hexValue;
            string hexValue2;
            string hexValue3;
            string hexValue4;
            string totalHexValue;
            string tempHexValue;
            int value;
            int value2;
            int value3;
            int value4;
            int totalValue;
            int tempValue;
            int finalValue1;
            int finalValue2;

            if (heroName.Length != 0)
            {
                hexValue = GetCharHexValue(heroName[0]);

                if (heroName.Length >= 2)
                {
                    hexValue2 = GetCharHexValue(heroName[1]);
                }
                else
                {
                    hexValue2 = "00";
                }

                if (heroName.Length >= 3)
                {
                    hexValue3 = GetCharHexValue(heroName[2]);
                }
                else
                {
                    hexValue3 = "00";
                }

                if (heroName.Length >= 4)
                {
                    hexValue4 = GetCharHexValue(heroName[3]);
                }
                else
                {
                    hexValue4 = "00";
                }


                if (hexValue == "??" || hexValue2 == "??" || hexValue3 == "??" || hexValue4 == "??")
                {
                    MessageBox.Show(@"Invalid character in name.", @"Name Companion Calc", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    
                }
                else
                {
                    value = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
                    value2 = int.Parse(hexValue2, System.Globalization.NumberStyles.HexNumber);
                    value3 = int.Parse(hexValue3, System.Globalization.NumberStyles.HexNumber);
                    value4 = int.Parse(hexValue4, System.Globalization.NumberStyles.HexNumber);

                    totalValue = value + value2 + value3 + value4 + _MAGIC_NUMBER_1;
                    totalHexValue = totalValue.ToString("X");

                    tempValue = int.Parse(totalHexValue[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                    totalValue = totalValue + tempValue;

                    tempHexValue = totalHexValue[0].ToString() + "00";
                    tempValue = int.Parse(tempHexValue, System.Globalization.NumberStyles.HexNumber);
                    totalValue = totalValue - tempValue;

                    // Prince
                    finalValue1 = totalValue & _MAGIC_NUMBER_2;

                    totalValue = totalValue & _MAGIC_NUMBER_3;

                    // Princess
                    finalValue2 = totalValue / _MAGIC_NUMBER_4;

                    if (finalValue1 >= 0 && finalValue1 <= 7)
                    {
                        textBoxPrinceOfCannock.Text = _PRINCE_NAMES[finalValue1];
                    }
                    else
                    {
                        textBoxPrinceOfCannock.Text = @"Error";
                    }

                    if (finalValue2 >= 0 && finalValue2 <= 7)
                    {
                        textBoxPrincessOfMoonbrooke.Text = _PRINCESS_NAMES[finalValue2];
                    }
                    else
                    {
                        textBoxPrincessOfMoonbrooke.Text = @"Error";
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Please enter a name for the hero.", @"Name Companion Calc", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            

        }

        private string GetCharHexValue(char c)
        {
            string hexValue;

            switch (c)
            {
                case 'A':
                    hexValue = "24";
                    break;
                case 'B':
                    hexValue = "25";
                    break;
                case 'C':
                    hexValue = "26";
                    break;
                case 'D':
                    hexValue = "27";
                    break;
                case 'E':
                    hexValue = "28";
                    break;
                case 'F':
                    hexValue = "29";
                    break;
                case 'G':
                    hexValue = "2A";
                    break;
                case 'H':
                    hexValue = "2B";
                    break;
                case 'I':
                    hexValue = "2C";
                    break;
                case 'J':
                    hexValue = "2D";
                    break;
                case 'K':
                    hexValue = "2E";
                    break;
                case 'L':
                    hexValue = "2F";
                    break;
                case 'M':
                    hexValue = "30";
                    break;
                case 'N':
                    hexValue = "31";
                    break;
                case 'O':
                    hexValue = "32";
                    break;
                case 'P':
                    hexValue = "33";
                    break;
                case 'Q':
                    hexValue = "34";
                    break;
                case 'R':
                    hexValue = "35";
                    break;
                case 'S':
                    hexValue = "36";
                    break;
                case 'T':
                    hexValue = "37";
                    break;
                case 'U':
                    hexValue = "38";
                    break;
                case 'V':
                    hexValue = "39";
                    break;
                case 'W':
                    hexValue = "3A";
                    break;
                case 'X':
                    hexValue = "3B";
                    break;
                case 'Y':
                    hexValue = "3C";
                    break;
                case 'Z':
                    hexValue = "3D";
                    break;
                case '\'':
                    hexValue = "5F";
                    break;
                case ',':
                    hexValue = "69";
                    break;
                case '.':
                    hexValue = "6B";
                    break;
                case ';':
                    hexValue = "70";
                    break;
                case '~':
                    hexValue = "75";
                    break;
                case '>':
                    hexValue = "63";
                    break;
                case ' ':
                    hexValue = "60";
                    break;
                case 'a':
                    hexValue = "0A";
                    break;
                case 'b':
                    hexValue = "0B";
                    break;
                case 'c':
                    hexValue = "0C";
                    break;
                case 'd':
                    hexValue = "0D";
                    break;
                case 'e':
                    hexValue = "0E";
                    break;
                case 'f':
                    hexValue = "0F";
                    break;
                case 'g':
                    hexValue = "10";
                    break;
                case 'h':
                    hexValue = "11";
                    break;
                case 'i':
                    hexValue = "12";
                    break;
                case 'j':
                    hexValue = "13";
                    break;
                case 'k':
                    hexValue = "14";
                    break;
                case 'l':
                    hexValue = "15";
                    break;
                case 'm':
                    hexValue = "16";
                    break;
                case 'n':
                    hexValue = "17";
                    break;
                case 'o':
                    hexValue = "18";
                    break;
                case 'p':
                    hexValue = "19";
                    break;
                case 'q':
                    hexValue = "1A";
                    break;
                case 'r':
                    hexValue = "1B";
                    break;
                case 's':
                    hexValue = "1C";
                    break;
                case 't':
                    hexValue = "1D";
                    break;
                case 'u':
                    hexValue = "1E";
                    break;
                case 'v':
                    hexValue = "1F";
                    break;
                case 'w':
                    hexValue = "20";
                    break;
                case 'x':
                    hexValue = "21";
                    break;
                case 'y':
                    hexValue = "22";
                    break;
                case 'z':
                    hexValue = "23";
                    break;
                case '!':
                    hexValue = "6F";
                    break;
                case '?':
                    hexValue = "6E";
                    break;
                default:
                    hexValue = "??";
                    break;
            }

            return hexValue;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
