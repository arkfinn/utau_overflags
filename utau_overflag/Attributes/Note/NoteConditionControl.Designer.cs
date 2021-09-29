namespace utau_overflags.Attributes.Note
{
    partial class NoteConditionControl
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
            this.comboNote = new System.Windows.Forms.ComboBox();
            this.comboComparer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "音階が";
            // 
            // comboNote
            // 
            this.comboNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNote.FormattingEnabled = true;
            this.comboNote.Location = new System.Drawing.Point(58, 3);
            this.comboNote.Name = "comboNote";
            this.comboNote.Size = new System.Drawing.Size(64, 23);
            this.comboNote.TabIndex = 1;
            this.comboNote.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // comboComparer
            // 
            this.comboComparer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComparer.FormattingEnabled = true;
            this.comboComparer.Location = new System.Drawing.Point(128, 3);
            this.comboComparer.Name = "comboComparer";
            this.comboComparer.Size = new System.Drawing.Size(96, 23);
            this.comboComparer.TabIndex = 2;
            this.comboComparer.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "のとき";
            // 
            // NoteConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboComparer);
            this.Controls.Add(this.comboNote);
            this.Controls.Add(this.label1);
            this.Name = "NoteConditionControl";
            this.Size = new System.Drawing.Size(271, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboNote;
        private System.Windows.Forms.ComboBox comboComparer;
        private System.Windows.Forms.Label label2;
    }
}
