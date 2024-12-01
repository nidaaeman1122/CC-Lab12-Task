namespace lexicalAnalyzerV2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox tfInput;
        private System.Windows.Forms.TextBox tfTokens;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.TextBox symbolTable;

        private void InitializeComponent()
        {
            this.tfInput = new System.Windows.Forms.TextBox();
            this.tfTokens = new System.Windows.Forms.TextBox();
            this.btn_Input = new System.Windows.Forms.Button();
            this.symbolTable = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // tfInput
            this.tfInput.Location = new System.Drawing.Point(12, 12);
            this.tfInput.Multiline = true;
            this.tfInput.Name = "tfInput";
            this.tfInput.Size = new System.Drawing.Size(300, 100);
            this.tfInput.TabIndex = 0;

            // tfTokens
            this.tfTokens.Location = new System.Drawing.Point(12, 150);
            this.tfTokens.Multiline = true;
            this.tfTokens.Name = "tfTokens";
            this.tfTokens.ReadOnly = true;
            this.tfTokens.Size = new System.Drawing.Size(300, 100);
            this.tfTokens.TabIndex = 1;

            // symbolTable
            this.symbolTable.Location = new System.Drawing.Point(320, 12);
            this.symbolTable.Multiline = true;
            this.symbolTable.Name = "symbolTable";
            this.symbolTable.ReadOnly = true;
            this.symbolTable.Size = new System.Drawing.Size(300, 200);
            this.symbolTable.TabIndex = 2;

            // btn_Input
            this.btn_Input.Location = new System.Drawing.Point(12, 120);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(75, 23);
            this.btn_Input.TabIndex = 3;
            this.btn_Input.Text = "Analyze";
            this.btn_Input.UseVisualStyleBackColor = true;
            this.btn_Input.Click += new System.EventHandler(this.btn_Input_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(640, 260);
            this.Controls.Add(this.btn_Input);
            this.Controls.Add(this.symbolTable);
            this.Controls.Add(this.tfTokens);
            this.Controls.Add(this.tfInput);
            this.Name = "Form1";
            this.Text = "Lexical Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
