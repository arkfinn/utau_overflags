namespace utau_overflags
{
    partial class Form1
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            sortableListBox1 = new DataDisplay.SortableListBox();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            contractSetter1 = new Forms.ContractSetter();
            comboBox1 = new System.Windows.Forms.ComboBox();
            button5 = new System.Windows.Forms.Button();
            buttonRun = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            splitContainer1.Location = new System.Drawing.Point(1, 28);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(sortableListBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(contractSetter1);
            splitContainer1.Size = new System.Drawing.Size(735, 445);
            splitContainer1.SplitterDistance = 241;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // sortableListBox1
            // 
            sortableListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            sortableListBox1.Location = new System.Drawing.Point(0, 0);
            sortableListBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            sortableListBox1.MinimumCount = 1;
            sortableListBox1.Name = "sortableListBox1";
            sortableListBox1.SelectedIndex = -1;
            sortableListBox1.SelectedItem = null;
            sortableListBox1.Size = new System.Drawing.Size(237, 441);
            sortableListBox1.TabIndex = 5;
            sortableListBox1.OnAddRequest += sortableListBox1_OnAddRequest;
            sortableListBox1.OnSelectedIndexChanged += sortableListBox1_OnSelectedIndexChanged;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button2.BackColor = System.Drawing.Color.Red;
            button2.Enabled = false;
            button2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(4, 407);
            button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(70, 25);
            button2.TabIndex = 2;
            button2.Text = "リセット";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Enabled = false;
            button1.Location = new System.Drawing.Point(394, 407);
            button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(88, 29);
            button1.TabIndex = 1;
            button1.Text = "確定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += conditionSetter1_ConditionSaved;
            // 
            // contractSetter1
            // 
            contractSetter1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            contractSetter1.Enabled = false;
            contractSetter1.Location = new System.Drawing.Point(4, 4);
            contractSetter1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            contractSetter1.Name = "contractSetter1";
            contractSetter1.Size = new System.Drawing.Size(478, 400);
            contractSetter1.TabIndex = 0;
            contractSetter1.OnChanged += contractSetter1_OnChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(7, 1);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(148, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Image = (System.Drawing.Image)resources.GetObject("button5.Image");
            button5.Location = new System.Drawing.Point(162, 2);
            button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(20, 21);
            button5.TabIndex = 2;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // buttonRun
            // 
            buttonRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonRun.Location = new System.Drawing.Point(574, 479);
            buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new System.Drawing.Size(159, 29);
            buttonRun.TabIndex = 3;
            buttonRun.Text = "この設定で処理実行";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // toolTip1
            // 
            toolTip1.IsBalloon = true;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(241, 485);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(280, 15);
            label1.TabIndex = 4;
            label1.Text = "確定されていない修正があります。修正を完了して下さい。";
            label1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(735, 510);
            Controls.Add(label1);
            Controls.Add(buttonRun);
            Controls.Add(button5);
            Controls.Add(comboBox1);
            Controls.Add(splitContainer1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "OverFlags";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private Forms.ContractSetter contractSetter1;
        private DataDisplay.SortableListBox sortableListBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

