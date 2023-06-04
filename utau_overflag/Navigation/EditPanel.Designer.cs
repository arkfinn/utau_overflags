namespace utau_overflags.Forms
{
    partial class EditPanel
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            button8 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button9);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(426, 455);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // button8
            // 
            button8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button8.Image = Properties.Resources.Condition_Note;
            button8.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button8.Location = new System.Drawing.Point(7, 21);
            button8.Margin = new System.Windows.Forms.Padding(4);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(412, 40);
            button8.TabIndex = 6;
            button8.Text = "　音程(Note)";
            button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button7.Image = Properties.Resources.Condition_Others;
            button7.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button7.Location = new System.Drawing.Point(6, 357);
            button7.Margin = new System.Windows.Forms.Padding(4);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(412, 40);
            button7.TabIndex = 5;
            button7.Text = "　自由指定(Others)";
            button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button6.Image = Properties.Resources.Condition_Vibrato;
            button6.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button6.Location = new System.Drawing.Point(6, 309);
            button6.Margin = new System.Windows.Forms.Padding(4);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(412, 40);
            button6.TabIndex = 4;
            button6.Text = "　ビブラート(VBR)";
            button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button5.Image = Properties.Resources.Condition_Lyric;
            button5.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button5.Location = new System.Drawing.Point(4, 213);
            button5.Margin = new System.Windows.Forms.Padding(4);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(412, 40);
            button5.TabIndex = 3;
            button5.Text = "　歌詞(Lyric)";
            button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button4.Image = Properties.Resources.Condition_Moduration;
            button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button4.Location = new System.Drawing.Point(6, 261);
            button4.Margin = new System.Windows.Forms.Padding(4);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(412, 40);
            button4.TabIndex = 2;
            button4.Text = "　モジュレーション(Moduration)";
            button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button3.Image = Properties.Resources.Condition_Intensity;
            button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button3.Location = new System.Drawing.Point(6, 117);
            button3.Margin = new System.Windows.Forms.Padding(4);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(412, 40);
            button3.TabIndex = 1;
            button3.Text = "　音量(Intensity)";
            button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button2.Image = Properties.Resources.Condition_Flags;
            button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button2.Location = new System.Drawing.Point(7, 69);
            button2.Margin = new System.Windows.Forms.Padding(4);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(412, 40);
            button2.TabIndex = 0;
            button2.Text = "　フラグ(Flags)";
            button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 410);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(426, 45);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            button1.Location = new System.Drawing.Point(4, 9);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(88, 29);
            button1.TabIndex = 0;
            button1.Text = "キャンセル";
            button1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button9.Image = Properties.Resources.Condition_Length;
            button9.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            button9.Location = new System.Drawing.Point(7, 165);
            button9.Margin = new System.Windows.Forms.Padding(4);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(412, 40);
            button9.TabIndex = 3;
            button9.Text = "　音の長さ(Length)";
            button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // EditPanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "EditPanel";
            Size = new System.Drawing.Size(426, 455);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}
