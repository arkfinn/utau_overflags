namespace utau_overflags.Attributes.Length
{
    partial class LengthEditControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            numLength = new System.Windows.Forms.NumericUpDown();
            comboCalculator = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "音長を";
            // 
            // numLength
            // 
            numLength.Location = new System.Drawing.Point(57, 3);
            numLength.Name = "numLength";
            numLength.Size = new System.Drawing.Size(61, 22);
            numLength.TabIndex = 1;
            numLength.Maximum = 200;
            numLength.Minimum = 0;
            numLength.ValueChanged += formChanged;
            // 
            // comboCalculator
            // 
            comboCalculator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboCalculator.FormattingEnabled = true;
            comboCalculator.Location = new System.Drawing.Point(124, 2);
            comboCalculator.Name = "comboCalculator";
            comboCalculator.Size = new System.Drawing.Size(85, 23);
            comboCalculator.TabIndex = 2;
            comboCalculator.SelectedIndexChanged += formChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(215, 5);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "する";
            // 
            // LengthEditControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(comboCalculator);
            Controls.Add(numLength);
            Controls.Add(label1);
            Name = "LengthEditControl";
            Size = new System.Drawing.Size(277, 36);
            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.ComboBox comboCalculator;
        private System.Windows.Forms.Label label2;
    }
}
