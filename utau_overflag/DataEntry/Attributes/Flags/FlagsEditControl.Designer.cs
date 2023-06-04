namespace utau_overflags.Attributes.Flags
{
    partial class FlagsEditControl
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
            this.textFlags = new System.Windows.Forms.TextBox();
            this.comboEditType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flags";
            // 
            // textFlags
            // 
            this.textFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFlags.Location = new System.Drawing.Point(42, 3);
            this.textFlags.Name = "textFlags";
            this.textFlags.Size = new System.Drawing.Size(100, 19);
            this.textFlags.TabIndex = 1;
            this.textFlags.TextChanged += new System.EventHandler(this.formChanged);
            // 
            // comboEditType
            // 
            this.comboEditType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEditType.FormattingEnabled = true;
            this.comboEditType.Location = new System.Drawing.Point(150, 3);
            this.comboEditType.Name = "comboEditType";
            this.comboEditType.Size = new System.Drawing.Size(78, 20);
            this.comboEditType.TabIndex = 2;
            this.comboEditType.SelectedValueChanged += new System.EventHandler(this.formChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "する";
            // 
            // FlagsConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboEditType);
            this.Controls.Add(this.textFlags);
            this.Controls.Add(this.label1);
            this.Name = "FlagsConditionControl";
            this.Size = new System.Drawing.Size(261, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFlags;
        private System.Windows.Forms.ComboBox comboEditType;
        private System.Windows.Forms.Label label2;
    }
}
