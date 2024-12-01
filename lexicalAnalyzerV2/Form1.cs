using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace lexicalAnalyzerV2
{
    public partial class Form1 : Form
    {
        // Declare necessary variables
        List<List<string>> SymbolTable = new List<List<string>>(); // Symbol table to store variables
        List<string> finalArray = new List<string>();
        Regex variable_Reg;
        Regex constants_Reg;
        Regex operators_Reg;
        Regex specialCharacters_Reg;
        List<string> keywordList;

        public Form1()
        {
            InitializeComponent();

            // Initialize variables
            keywordList = new List<string> { "int", "float", "while", "main", "if", "else", "new" };
            variable_Reg = new Regex(@"^[A-Za-z_][A-Za-z0-9_]*$");
            constants_Reg = new Regex(@"^[0-9]+(\.[0-9]+)?([eE][+-]?[0-9]+)?$");
            operators_Reg = new Regex(@"[+\-*/=;(){}]");
            specialCharacters_Reg = new Regex(@"[.,'\[\]{}();:?]");

        }

        // Button click event to start lexical analysis
        private void btn_Input_Click(object sender, EventArgs e)
        {
            string userInput = tfInput.Text; // Get input from the text box
            List<string> finalArrayc = new List<string>();
            List<string> tempArray = new List<string>();

            char[] charinput = userInput.ToCharArray(); // Convert input to char array

            // Processing the input character by character
            foreach (char ch in charinput)
            {
                Match matchVariable = variable_Reg.Match(ch.ToString());
                Match matchConstant = constants_Reg.Match(ch.ToString());
                Match matchOperator = operators_Reg.Match(ch.ToString());
                Match matchSpecial = specialCharacters_Reg.Match(ch.ToString());

                // If the character is a valid token, add it to tempArray
                if (matchVariable.Success || matchConstant.Success || matchOperator.Success || matchSpecial.Success || ch == ' ')
                {
                    tempArray.Add(ch.ToString());
                }

                // If it's a newline or end of input, process tokens and reset tempArray
                if (ch == '\n' || ch == ' ' || ch == '\r')
                {
                    if (tempArray.Count > 0)
                    {
                        finalArrayc.Add(string.Join("", tempArray));
                        tempArray.Clear();
                    }
                }
            }

            // Process any remaining tokens after the loop
            if (tempArray.Count > 0)
            {
                finalArrayc.Add(string.Join("", tempArray));
                tempArray.Clear();
            }

            // Token processing and symbol table creation
            tfTokens.Clear(); // Clear previous tokens
            SymbolTable.Clear(); // Clear the symbol table

            int row = 1; // Row index for symbol table
            int count = 1; // Count for token identification

            foreach (string token in finalArrayc)
            {
                Match matchOperator = operators_Reg.Match(token);
                Match matchVariable = variable_Reg.Match(token);
                Match matchConstant = constants_Reg.Match(token);
                Match matchSpecial = specialCharacters_Reg.Match(token);

                // Process operator tokens
                if (matchOperator.Success)
                {
                    tfTokens.AppendText("<op, " + token + "> ");
                }
                // Process constant tokens
                else if (matchConstant.Success)
                {
                    tfTokens.AppendText("<digit, " + token + "> ");
                }
                // Process special character tokens
                else if (matchSpecial.Success)
                {
                    tfTokens.AppendText("<punc, " + token + "> ");
                }
                // Process variables (excluding keywords)
                else if (matchVariable.Success && !keywordList.Contains(token))
                {
                    SymbolTable.Add(new List<string> { row.ToString(), token, "var", "", "line" + row });
                    tfTokens.AppendText("<var" + count + ", " + token + "> ");
                    row++;
                    count++;
                }
                // Process keywords
                else if (matchVariable.Success && keywordList.Contains(token))
                {
                    tfTokens.AppendText("<keyword, " + token + "> ");
                }
            }

            // Display the symbol table
            DisplaySymbolTable();
        }

        // Method to display the symbol table in the UI
        private void DisplaySymbolTable()
        {
            symbolTable.Clear();
            foreach (var row in SymbolTable)
            {
                symbolTable.AppendText(string.Join("\t", row) + "\n");
            }
        }
    }
}
