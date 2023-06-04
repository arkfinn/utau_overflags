namespace utau_overflags.Attributes.Note
{
    partial class NoteEditControl
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
            comboNote = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "音階を";
            // 
            // comboNote
            // 
            comboNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboNote.FormattingEnabled = true;
            comboNote.Location = new System.Drawing.Point(49, 2);
            comboNote.Name = "comboNote";
            comboNote.Size = new System.Drawing.Size(81, 23);
            comboNote.TabIndex = 2;
            comboNote.SelectedIndexChanged += formChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(136, 5);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "に変更";
            // 
            // NoteEditControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(comboNote);
            Controls.Add(label1);
            Name = "NoteEditControl";
            Size = new System.Drawing.Size(366, 35);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboNote;
        private System.Windows.Forms.Label label2;
    }
}
