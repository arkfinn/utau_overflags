﻿namespace utau_overflags.Attributes.Length
{
    partial class LengthConditionControl
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
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.comboComparer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "音長が";
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(58, 3);
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(76, 22);
            this.numLength.TabIndex = 1;
            this.numLength.Maximum = decimal.MaxValue;
            this.numLength.Minimum = 0;
            this.numLength.ValueChanged += new System.EventHandler(this.formChanged);
            // 
            // comboComparer
            // 
            this.comboComparer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComparer.FormattingEnabled = true;
            this.comboComparer.Location = new System.Drawing.Point(141, 3);
            this.comboComparer.Name = "comboComparer";
            this.comboComparer.Size = new System.Drawing.Size(88, 23);
            this.comboComparer.TabIndex = 2;
            this.comboComparer.SelectedIndexChanged += new System.EventHandler(this.formChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "のとき";
            // 
            // LengthConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboComparer);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.label1);
            this.Name = "LengthConditionControl";
            this.Size = new System.Drawing.Size(342, 30);
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.ComboBox comboComparer;
        private System.Windows.Forms.Label label2;
    }
}
