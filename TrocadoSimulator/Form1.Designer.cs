namespace TrocadoSimulator {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UxBtnSubmit = new System.Windows.Forms.Button();
            this.UxLblProductAmount = new System.Windows.Forms.Label();
            this.UxLblPaidAmount = new System.Windows.Forms.Label();
            this.UxLblChangeAmount = new System.Windows.Forms.Label();
            this.UxTxtProductAmount = new System.Windows.Forms.TextBox();
            this.UxTxtPaidAmount = new System.Windows.Forms.TextBox();
            this.UxTxtChangeAmount = new System.Windows.Forms.TextBox();
            this.UxTxtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UxBtnSubmit
            // 
            this.UxBtnSubmit.Location = new System.Drawing.Point(219, 173);
            this.UxBtnSubmit.Name = "UxBtnSubmit";
            this.UxBtnSubmit.Size = new System.Drawing.Size(85, 29);
            this.UxBtnSubmit.TabIndex = 0;
            this.UxBtnSubmit.Text = "Submit";
            this.UxBtnSubmit.UseVisualStyleBackColor = true;
            this.UxBtnSubmit.Click += new System.EventHandler(this.UxBtnSubmit_Click);
            // 
            // UxLblProductAmount
            // 
            this.UxLblProductAmount.AutoSize = true;
            this.UxLblProductAmount.Location = new System.Drawing.Point(38, 51);
            this.UxLblProductAmount.Name = "UxLblProductAmount";
            this.UxLblProductAmount.Size = new System.Drawing.Size(124, 20);
            this.UxLblProductAmount.TabIndex = 1;
            this.UxLblProductAmount.Text = "Product Amount";
            // 
            // UxLblPaidAmount
            // 
            this.UxLblPaidAmount.AutoSize = true;
            this.UxLblPaidAmount.Location = new System.Drawing.Point(38, 91);
            this.UxLblPaidAmount.Name = "UxLblPaidAmount";
            this.UxLblPaidAmount.Size = new System.Drawing.Size(100, 20);
            this.UxLblPaidAmount.TabIndex = 2;
            this.UxLblPaidAmount.Text = "Paid Amount";
            // 
            // UxLblChangeAmount
            // 
            this.UxLblChangeAmount.AutoSize = true;
            this.UxLblChangeAmount.Location = new System.Drawing.Point(38, 130);
            this.UxLblChangeAmount.Name = "UxLblChangeAmount";
            this.UxLblChangeAmount.Size = new System.Drawing.Size(125, 20);
            this.UxLblChangeAmount.TabIndex = 3;
            this.UxLblChangeAmount.Text = "Change Amount";
            // 
            // UxTxtProductAmount
            // 
            this.UxTxtProductAmount.Location = new System.Drawing.Point(204, 45);
            this.UxTxtProductAmount.Name = "UxTxtProductAmount";
            this.UxTxtProductAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtProductAmount.TabIndex = 4;
            // 
            // UxTxtPaidAmount
            // 
            this.UxTxtPaidAmount.Location = new System.Drawing.Point(204, 85);
            this.UxTxtPaidAmount.Name = "UxTxtPaidAmount";
            this.UxTxtPaidAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtPaidAmount.TabIndex = 5;
            // 
            // UxTxtChangeAmount
            // 
            this.UxTxtChangeAmount.Enabled = false;
            this.UxTxtChangeAmount.Location = new System.Drawing.Point(204, 124);
            this.UxTxtChangeAmount.Name = "UxTxtChangeAmount";
            this.UxTxtChangeAmount.Size = new System.Drawing.Size(100, 26);
            this.UxTxtChangeAmount.TabIndex = 6;
            // 
            // UxTxtOutput
            // 
            this.UxTxtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UxTxtOutput.Location = new System.Drawing.Point(42, 208);
            this.UxTxtOutput.Multiline = true;
            this.UxTxtOutput.Name = "UxTxtOutput";
            this.UxTxtOutput.Size = new System.Drawing.Size(262, 149);
            this.UxTxtOutput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 369);
            this.Controls.Add(this.UxTxtOutput);
            this.Controls.Add(this.UxTxtChangeAmount);
            this.Controls.Add(this.UxTxtPaidAmount);
            this.Controls.Add(this.UxTxtProductAmount);
            this.Controls.Add(this.UxLblChangeAmount);
            this.Controls.Add(this.UxLblPaidAmount);
            this.Controls.Add(this.UxLblProductAmount);
            this.Controls.Add(this.UxBtnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UxBtnSubmit;
        private System.Windows.Forms.Label UxLblProductAmount;
        private System.Windows.Forms.Label UxLblPaidAmount;
        private System.Windows.Forms.Label UxLblChangeAmount;
        private System.Windows.Forms.TextBox UxTxtProductAmount;
        private System.Windows.Forms.TextBox UxTxtPaidAmount;
        private System.Windows.Forms.TextBox UxTxtChangeAmount;
        private System.Windows.Forms.TextBox UxTxtOutput;
    }
}

