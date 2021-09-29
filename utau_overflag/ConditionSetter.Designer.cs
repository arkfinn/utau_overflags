namespace utau_overflags
{
    partial class ConditionSetter
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_use_lengthcond = new System.Windows.Forms.CheckBox();
            this.cbx_use_inscond = new System.Windows.Forms.CheckBox();
            this.cb_WordCond = new System.Windows.Forms.CheckBox();
            this.cb_condNote = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_useModuration = new System.Windows.Forms.CheckBox();
            this.wordedit_use = new System.Windows.Forms.CheckBox();
            this.cb_useInsensity = new System.Windows.Forms.CheckBox();
            this.cb_useVbrEdit = new System.Windows.Forms.CheckBox();
            this.cb_UseFlagsEdit = new System.Windows.Forms.CheckBox();
            this.modurationEditControl1 = new utau_overflags.Attributes.Moduration.ModurationEditControl();
            this.intensityEditControl1 = new utau_overflags.Attributes.Intensity.IntensityEditControl();
            this.wordEditControl1 = new utau_overflags.Attributes.Lyric.LyricEditControl();
            this.vbrEditControl1 = new utau_overflags.Attributes.Vibrato.VbrEditControl();
            this.lengthConditionControl1 = new utau_overflags.Attributes.Length.LengthConditionControl();
            this.noteConditionControl1 = new utau_overflags.Attributes.Note.NoteConditionControl();
            this.intensityConditionControl1 = new utau_overflags.Attributes.Intensity.IntensityConditionControl();
            this.wordConditionControl1 = new utau_overflags.Attributes.Lyric.LyricConditionControl();
            this.flagsEditControl1 = new utau_overflags.Attributes.Flags.FlagsEditControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(214, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 21);
            this.button1.TabIndex = 9;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Enabled = false;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(236, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 21);
            this.button2.TabIndex = 10;
            this.button2.Text = "元に戻す";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lengthConditionControl1);
            this.groupBox1.Controls.Add(this.noteConditionControl1);
            this.groupBox1.Controls.Add(this.intensityConditionControl1);
            this.groupBox1.Controls.Add(this.wordConditionControl1);
            this.groupBox1.Controls.Add(this.cb_use_lengthcond);
            this.groupBox1.Controls.Add(this.cbx_use_inscond);
            this.groupBox1.Controls.Add(this.cb_WordCond);
            this.groupBox1.Controls.Add(this.cb_condNote);
            this.groupBox1.Location = new System.Drawing.Point(7, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 126);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // cb_use_lengthcond
            // 
            this.cb_use_lengthcond.AutoSize = true;
            this.cb_use_lengthcond.Location = new System.Drawing.Point(6, 92);
            this.cb_use_lengthcond.Name = "cb_use_lengthcond";
            this.cb_use_lengthcond.Size = new System.Drawing.Size(15, 14);
            this.cb_use_lengthcond.TabIndex = 23;
            this.cb_use_lengthcond.UseVisualStyleBackColor = true;
            this.cb_use_lengthcond.CheckedChanged += new System.EventHandler(this.cb_LengthCond_CheckedChanged);
            // 
            // cbx_use_inscond
            // 
            this.cbx_use_inscond.AutoSize = true;
            this.cbx_use_inscond.Location = new System.Drawing.Point(6, 67);
            this.cbx_use_inscond.Name = "cbx_use_inscond";
            this.cbx_use_inscond.Size = new System.Drawing.Size(15, 14);
            this.cbx_use_inscond.TabIndex = 17;
            this.cbx_use_inscond.UseVisualStyleBackColor = true;
            this.cbx_use_inscond.CheckedChanged += new System.EventHandler(this.cb_IntensityCond_CheckedChanged);
            // 
            // cb_WordCond
            // 
            this.cb_WordCond.AutoSize = true;
            this.cb_WordCond.Location = new System.Drawing.Point(6, 43);
            this.cb_WordCond.Name = "cb_WordCond";
            this.cb_WordCond.Size = new System.Drawing.Size(15, 14);
            this.cb_WordCond.TabIndex = 5;
            this.cb_WordCond.UseVisualStyleBackColor = true;
            this.cb_WordCond.CheckedChanged += new System.EventHandler(this.cb_WordCond_CheckedChanged);
            // 
            // cb_condNote
            // 
            this.cb_condNote.AutoSize = true;
            this.cb_condNote.Checked = true;
            this.cb_condNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_condNote.Enabled = false;
            this.cb_condNote.Location = new System.Drawing.Point(6, 18);
            this.cb_condNote.Name = "cb_condNote";
            this.cb_condNote.Size = new System.Drawing.Size(15, 14);
            this.cb_condNote.TabIndex = 4;
            this.cb_condNote.UseVisualStyleBackColor = true;
            this.cb_condNote.CheckedChanged += new System.EventHandler(this.cb_NoteCond_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flagsEditControl1);
            this.groupBox2.Controls.Add(this.modurationEditControl1);
            this.groupBox2.Controls.Add(this.intensityEditControl1);
            this.groupBox2.Controls.Add(this.wordEditControl1);
            this.groupBox2.Controls.Add(this.vbrEditControl1);
            this.groupBox2.Controls.Add(this.cb_useModuration);
            this.groupBox2.Controls.Add(this.wordedit_use);
            this.groupBox2.Controls.Add(this.cb_useInsensity);
            this.groupBox2.Controls.Add(this.cb_useVbrEdit);
            this.groupBox2.Controls.Add(this.cb_UseFlagsEdit);
            this.groupBox2.Location = new System.Drawing.Point(7, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 154);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // cb_useModuration
            // 
            this.cb_useModuration.AutoSize = true;
            this.cb_useModuration.Location = new System.Drawing.Point(6, 132);
            this.cb_useModuration.Name = "cb_useModuration";
            this.cb_useModuration.Size = new System.Drawing.Size(15, 14);
            this.cb_useModuration.TabIndex = 26;
            this.cb_useModuration.UseVisualStyleBackColor = true;
            this.cb_useModuration.CheckedChanged += new System.EventHandler(this.cb_ModurationEdit_CheckedChanged);
            // 
            // wordedit_use
            // 
            this.wordedit_use.AutoSize = true;
            this.wordedit_use.Location = new System.Drawing.Point(6, 63);
            this.wordedit_use.Name = "wordedit_use";
            this.wordedit_use.Size = new System.Drawing.Size(15, 14);
            this.wordedit_use.TabIndex = 20;
            this.wordedit_use.UseVisualStyleBackColor = true;
            this.wordedit_use.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // cb_useInsensity
            // 
            this.cb_useInsensity.AutoSize = true;
            this.cb_useInsensity.Location = new System.Drawing.Point(6, 86);
            this.cb_useInsensity.Name = "cb_useInsensity";
            this.cb_useInsensity.Size = new System.Drawing.Size(15, 14);
            this.cb_useInsensity.TabIndex = 13;
            this.cb_useInsensity.UseVisualStyleBackColor = true;
            this.cb_useInsensity.CheckedChanged += new System.EventHandler(this.cb_IntensityEdit_CheckedChanged);
            // 
            // cb_useVbrEdit
            // 
            this.cb_useVbrEdit.AutoSize = true;
            this.cb_useVbrEdit.Location = new System.Drawing.Point(6, 109);
            this.cb_useVbrEdit.Name = "cb_useVbrEdit";
            this.cb_useVbrEdit.Size = new System.Drawing.Size(15, 14);
            this.cb_useVbrEdit.TabIndex = 10;
            this.cb_useVbrEdit.UseVisualStyleBackColor = true;
            this.cb_useVbrEdit.CheckedChanged += new System.EventHandler(this.cb_useVbrEdit_CheckedChanged);
            // 
            // cb_UseFlagsEdit
            // 
            this.cb_UseFlagsEdit.AutoSize = true;
            this.cb_UseFlagsEdit.Location = new System.Drawing.Point(6, 15);
            this.cb_UseFlagsEdit.Name = "cb_UseFlagsEdit";
            this.cb_UseFlagsEdit.Size = new System.Drawing.Size(15, 14);
            this.cb_UseFlagsEdit.TabIndex = 9;
            this.cb_UseFlagsEdit.UseVisualStyleBackColor = true;
            this.cb_UseFlagsEdit.CheckedChanged += new System.EventHandler(this.cb_UseFlagsEdit_CheckedChanged);
            // 
            // modurationEditControl1
            // 
            this.modurationEditControl1.Location = new System.Drawing.Point(19, 128);
            this.modurationEditControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.modurationEditControl1.Name = "modurationEditControl1";
            this.modurationEditControl1.Size = new System.Drawing.Size(261, 22);
            this.modurationEditControl1.TabIndex = 32;
            // 
            // intensityEditControl1
            // 
            this.intensityEditControl1.Location = new System.Drawing.Point(19, 82);
            this.intensityEditControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.intensityEditControl1.Name = "intensityEditControl1";
            this.intensityEditControl1.Size = new System.Drawing.Size(245, 21);
            this.intensityEditControl1.TabIndex = 13;
            // 
            // wordEditControl1
            // 
            this.wordEditControl1.Location = new System.Drawing.Point(19, 61);
            this.wordEditControl1.Name = "wordEditControl1";
            this.wordEditControl1.Size = new System.Drawing.Size(261, 22);
            this.wordEditControl1.TabIndex = 31;
            // 
            // vbrEditControl1
            // 
            this.vbrEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vbrEditControl1.Location = new System.Drawing.Point(19, 106);
            this.vbrEditControl1.Margin = new System.Windows.Forms.Padding(4);
            this.vbrEditControl1.Name = "vbrEditControl1";
            this.vbrEditControl1.Size = new System.Drawing.Size(261, 23);
            this.vbrEditControl1.TabIndex = 30;
            // 
            // lengthConditionControl1
            // 
            this.lengthConditionControl1.Location = new System.Drawing.Point(19, 92);
            this.lengthConditionControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lengthConditionControl1.Name = "lengthConditionControl1";
            this.lengthConditionControl1.Size = new System.Drawing.Size(256, 24);
            this.lengthConditionControl1.TabIndex = 29;
            // 
            // noteConditionControl1
            // 
            this.noteConditionControl1.Location = new System.Drawing.Point(21, 15);
            this.noteConditionControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.noteConditionControl1.Name = "noteConditionControl1";
            this.noteConditionControl1.Size = new System.Drawing.Size(203, 22);
            this.noteConditionControl1.TabIndex = 28;
            // 
            // intensityConditionControl1
            // 
            this.intensityConditionControl1.Location = new System.Drawing.Point(21, 67);
            this.intensityConditionControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.intensityConditionControl1.Name = "intensityConditionControl1";
            this.intensityConditionControl1.Size = new System.Drawing.Size(195, 25);
            this.intensityConditionControl1.TabIndex = 27;
            // 
            // wordConditionControl1
            // 
            this.wordConditionControl1.Location = new System.Drawing.Point(21, 38);
            this.wordConditionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.wordConditionControl1.Name = "wordConditionControl1";
            this.wordConditionControl1.Size = new System.Drawing.Size(265, 26);
            this.wordConditionControl1.TabIndex = 26;
            // 
            // flagsEditControl1
            // 
            this.flagsEditControl1.Location = new System.Drawing.Point(19, 8);
            this.flagsEditControl1.Name = "flagsEditControl1";
            this.flagsEditControl1.Size = new System.Drawing.Size(261, 32);
            this.flagsEditControl1.TabIndex = 33;
            // 
            // ConditionSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ConditionSetter";
            this.Size = new System.Drawing.Size(301, 346);
            this.Load += new System.EventHandler(this.ConditionSetter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_condNote;
        private System.Windows.Forms.CheckBox cb_UseFlagsEdit;
        private System.Windows.Forms.CheckBox cb_useVbrEdit;
        private System.Windows.Forms.CheckBox cb_WordCond;
        private System.Windows.Forms.CheckBox cb_useInsensity;
        private System.Windows.Forms.CheckBox cbx_use_inscond;
        private System.Windows.Forms.CheckBox cb_useModuration;
        private System.Windows.Forms.CheckBox cb_use_lengthcond;
        private Attributes.Vibrato.VbrEditControl vbrEditControl1;
        private Attributes.Lyric.LyricConditionControl wordConditionControl1;
        private Attributes.Lyric.LyricEditControl wordEditControl1;
        private System.Windows.Forms.CheckBox wordedit_use;
        private Attributes.Intensity.IntensityConditionControl intensityConditionControl1;
        private Attributes.Intensity.IntensityEditControl intensityEditControl1;
        private Attributes.Note.NoteConditionControl noteConditionControl1;
        private Attributes.Length.LengthConditionControl lengthConditionControl1;
        private Attributes.Moduration.ModurationEditControl modurationEditControl1;
        private Attributes.Flags.FlagsEditControl flagsEditControl1;

    }
}
