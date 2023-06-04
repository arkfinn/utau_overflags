namespace utau_overflags.Attributes.Intensity
{
    partial class IntensityEditControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.numIntensity = new System.Windows.Forms.NumericUpDown();
            this.comboCalculator = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numIntensity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "音量を";
            // 
            // numIntensity
            // 
            this.numIntensity.Location = new System.Drawing.Point(57, 3);
            this.numIntensity.Name = "numIntensity";
            this.numIntensity.Size = new System.Drawing.Size(61, 22);
            this.numIntensity.TabIndex = 1;
            this.numIntensity.Maximum = 200;
            this.numIntensity.Minimum = 0;
            this.numIntensity.ValueChanged += new System.EventHandler(this.formChanged);
            // 
            // comboCalculator
            // 
            this.comboCalculator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCalculator.FormattingEnabled = true;
            this.comboCalculator.Location = new System.Drawing.Point(124, 2);
            this.comboCalculator.Name = "comboCalculator";
            this.comboCalculator.Size = new System.Drawing.Size(85, 23);
            this.comboCalculator.TabIndex = 2;
            this.comboCalculator.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "する";
            // 
            // IntensityEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCalculator);
            this.Controls.Add(this.numIntensity);
            this.Controls.Add(this.label1);
            this.Name = "IntensityEditControl";
            this.Size = new System.Drawing.Size(277, 36);
            ((System.ComponentModel.ISupportInitialize)(this.numIntensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numIntensity;
        private System.Windows.Forms.ComboBox comboCalculator;
        private System.Windows.Forms.Label label2;
    }
}
