namespace CurrencyConverterMVP.Views
{
    partial class SumView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ValueLeftBox = new System.Windows.Forms.TextBox();
            this.ValueRightBox = new System.Windows.Forms.TextBox();
            this.SumLabel = new System.Windows.Forms.Label();
            this.SumValuteLabel = new System.Windows.Forms.Label();
            this.ValuteLeftComboBox = new System.Windows.Forms.ComboBox();
            this.ValuteRightComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ValueLeftBox
            // 
            this.ValueLeftBox.Location = new System.Drawing.Point(225, 0);
            this.ValueLeftBox.Name = "ValueLeftBox";
            this.ValueLeftBox.Size = new System.Drawing.Size(220, 20);
            this.ValueLeftBox.TabIndex = 0;
            // 
            // ValueRightBox
            // 
            this.ValueRightBox.Location = new System.Drawing.Point(-1, 0);
            this.ValueRightBox.Name = "ValueRightBox";
            this.ValueRightBox.Size = new System.Drawing.Size(220, 20);
            this.ValueRightBox.TabIndex = 0;
            // 
            // SumLabel
            // 
            this.SumLabel.Location = new System.Drawing.Point(451, 0);
            this.SumLabel.Name = "SumLabel";
            this.SumLabel.Size = new System.Drawing.Size(100, 20);
            this.SumLabel.TabIndex = 1;
            this.SumLabel.Text = "SumLabel";
            // 
            // SumValuteLabel
            // 
            this.SumValuteLabel.Location = new System.Drawing.Point(451, 22);
            this.SumValuteLabel.Name = "SumValuteLabel";
            this.SumValuteLabel.Size = new System.Drawing.Size(324, 21);
            this.SumValuteLabel.TabIndex = 1;
            this.SumValuteLabel.Text = "SumValuteLabel";
            // 
            // ValuteLeftComboBox
            // 
            this.ValuteLeftComboBox.FormattingEnabled = true;
            this.ValuteLeftComboBox.Location = new System.Drawing.Point(225, 22);
            this.ValuteLeftComboBox.Name = "ValuteLeftComboBox";
            this.ValuteLeftComboBox.Size = new System.Drawing.Size(220, 21);
            this.ValuteLeftComboBox.TabIndex = 2;
            // 
            // ValuteRightComboBox
            // 
            this.ValuteRightComboBox.FormattingEnabled = true;
            this.ValuteRightComboBox.Location = new System.Drawing.Point(-1, 22);
            this.ValuteRightComboBox.Name = "ValuteRightComboBox";
            this.ValuteRightComboBox.Size = new System.Drawing.Size(220, 21);
            this.ValuteRightComboBox.TabIndex = 2;
            // 
            // SumView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 45);
            this.Controls.Add(this.ValuteRightComboBox);
            this.Controls.Add(this.ValuteLeftComboBox);
            this.Controls.Add(this.SumValuteLabel);
            this.Controls.Add(this.SumLabel);
            this.Controls.Add(this.ValueRightBox);
            this.Controls.Add(this.ValueLeftBox);
            this.Name = "SumView";
            this.Text = "SumView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ValueLeftBox;
        private System.Windows.Forms.TextBox ValueRightBox;
        private System.Windows.Forms.Label SumLabel;
        private System.Windows.Forms.Label SumValuteLabel;
        private System.Windows.Forms.ComboBox ValuteLeftComboBox;
        private System.Windows.Forms.ComboBox ValuteRightComboBox;
    }
}