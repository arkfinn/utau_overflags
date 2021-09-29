namespace utau_overflags.Attributes.Lyric
{
    partial class LyricConditionControl
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
            this.textWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboWordLike = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "歌詞が";
            // 
            // textWord
            // 
            this.textWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWord.Location = new System.Drawing.Point(61, 6);
            this.textWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textWord.Name = "textWord";
            this.textWord.Size = new System.Drawing.Size(195, 22);
            this.textWord.TabIndex = 1;
            this.textWord.TextChanged += new System.EventHandler(this.formChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "と";
            // 
            // comboWordLike
            // 
            this.comboWordLike.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboWordLike.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWordLike.FormattingEnabled = true;
            this.comboWordLike.Location = new System.Drawing.Point(292, 5);
            this.comboWordLike.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboWordLike.Name = "comboWordLike";
            this.comboWordLike.Size = new System.Drawing.Size(106, 23);
            this.comboWordLike.TabIndex = 3;
            this.comboWordLike.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "のとき";
            // 
            // WordConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboWordLike);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textWord);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WordConditionControl";
            this.Size = new System.Drawing.Size(454, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboWordLike;
        private System.Windows.Forms.Label label3;
    }
}
