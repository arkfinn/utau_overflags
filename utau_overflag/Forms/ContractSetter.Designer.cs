namespace utau_overflags.Forms
{
    partial class ContractSetter
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listConditions = new utau_overflags.Forms.SortableListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listEdits = new utau_overflags.Forms.SortableListBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(383, 351);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listConditions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // listConditions
            // 
            this.listConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listConditions.Location = new System.Drawing.Point(3, 15);
            this.listConditions.MinimumCount = 0;
            this.listConditions.Name = "listConditions";
            this.listConditions.SelectedItem = null;
            this.listConditions.Size = new System.Drawing.Size(377, 154);
            this.listConditions.TabIndex = 0;
            this.listConditions.OnRemoved += new System.EventHandler(this.OnListChanged);
            this.listConditions.OnMoved += new System.EventHandler(this.OnListChanged);
            this.listConditions.OnAddRequest += new System.EventHandler(this.listConditions_OnAddRequest);
            this.listConditions.OnListDoubleClicked += new System.EventHandler(this.listConditions_OnListDoubleClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listEdits);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 175);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // listEdits
            // 
            this.listEdits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEdits.Location = new System.Drawing.Point(3, 15);
            this.listEdits.MinimumCount = 0;
            this.listEdits.Name = "listEdits";
            this.listEdits.SelectedItem = null;
            this.listEdits.Size = new System.Drawing.Size(377, 157);
            this.listEdits.TabIndex = 0;
            this.listEdits.OnRemoved += new System.EventHandler(this.OnListChanged);
            this.listEdits.OnMoved += new System.EventHandler(this.OnListChanged);
            this.listEdits.OnAddRequest += new System.EventHandler(this.listEdits_OnAddRequest);
            this.listEdits.OnListDoubleClicked += new System.EventHandler(this.listEdits_OnListDoubleClicked);
            // 
            // ContractSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ContractSetter";
            this.Size = new System.Drawing.Size(383, 351);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SortableListBox listConditions;
        private SortableListBox listEdits;
    }
}
