namespace utau_overflags.Attributes.Others
{
    partial class OthersEditControl
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
            this.textValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboKey = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "に";
            // 
            // textValue
            // 
            this.textValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textValue.Location = new System.Drawing.Point(118, 0);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(89, 19);
            this.textValue.TabIndex = 1;
            this.textValue.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "を設定する";
            // 
            // comboKey
            // 
            this.comboKey.FormattingEnabled = true;
            this.comboKey.Items.AddRange(new object[] {
            "$direct",
            "$patch"});
            this.comboKey.Location = new System.Drawing.Point(3, 0);
            this.comboKey.Name = "comboKey";
            this.comboKey.Size = new System.Drawing.Size(89, 20);
            this.comboKey.TabIndex = 3;
            this.comboKey.SelectedIndexChanged += new System.EventHandler(this.comboKey_SelectedIndexChanged);
            // 
            // OthersEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.label2);
            this.Name = "OthersEditControl";
            this.Size = new System.Drawing.Size(282, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboKey;
    }
}
