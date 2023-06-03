using System;
using System.Windows.Forms;
using Utau.OverFlags.Domain.Attributes.Flags;
using Utau.OverFlags.Domain.Attributes.Intensity;
using Utau.OverFlags.Domain.Attributes.Length;
using Utau.OverFlags.Domain.Attributes.Lyric;
using Utau.OverFlags.Domain.Attributes.Moduration;
using Utau.OverFlags.Domain.Attributes.Note;
using Utau.OverFlags.Domain.Attributes.Vibrato;
using utau_overflags.Attributes.Vibrato;

namespace utau_overflags
{
    public partial class ConditionSetter : UserControl
    {
        public ConditionSetter()
        {
            InitializeComponent();
        }

        //TODO: 各cond,editのChanged時の処理がない。
        //別ウィンドウで編集させたいので、その際考慮する

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public event EventHandler ConditionSaved;

        protected void OnConditionSaved()
        {
            if (ConditionSaved != null)
            {
                ConditionSaved(this, EventArgs.Empty);
            }
        }

        private bool _isChanged;

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
            private set
            {
                _isChanged = value;
                button1.Enabled = value;
                button2.Enabled = value;
            }
        }

        private FlagCondition _targetCondition;

        public FlagCondition TargetCondition
        {
            get { return _targetCondition; }
            set
            {
                _targetCondition = value;
                Reset();
            }
        }

        public void Reset()
        {
            if (TargetCondition == null)
            {
                SetEnabled(false);
                IsChanged = false;
                return;
            }

            ResetNoteCond(TargetCondition);
            ResetFlagsEdit(TargetCondition);
            if (TargetCondition.Version < FlagCondition.Version1500)
            {
                cb_condNote.Checked = true;
                cb_UseFlagsEdit.Checked = true;
            }
            ResetVbrEdit(TargetCondition);
            ResetWordCond(TargetCondition);
            ResetIntensityEdit(TargetCondition);
            ResetIntensityCond(TargetCondition);
            ResetWordEdit(TargetCondition);
            ResetModurationEdit(TargetCondition);

            SetEnabled(true);

            IsChanged = false;
        }

        public void SaveCondition()
        {
            SaveNoteCond(TargetCondition);
            SaveFlagsEdit(TargetCondition);
            SaveVbrEdit(TargetCondition);
            SaveWordCond(TargetCondition);
            SaveIntensityEdit(TargetCondition);
            SaveIntensityCond(TargetCondition);
            SaveLengthCond(TargetCondition);
            SaveWordEdit(TargetCondition);
            SaveModurationEdit(TargetCondition);

            TargetCondition.Version = FlagCondition.NowVersion;
            IsChanged = false;
            OnConditionSaved();
        }

        private void ConditionSetter_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private bool _my_enabled = true;

        public void SetEnabled(bool b)
        {
            _my_enabled = b;

            SetNoteCondEnabled(b);
            SetFlagsEditEnabled(b);
            SetVbrEditEnabled(b);
            SetWordCondEnabled(b);
            SetIntensityCondEnabled(b);
            SetIntensityEditEnabled(b);
            SetWordEditEnabled(b);
            SetModurationEditEnabled(b);
            SetLengthCondEnabled(b);

            button1.Enabled = b;
            button2.Enabled = b;
        }

        #region NoteCond

        private void SetNoteCondEnabled(bool b)
        {
            cb_condNote.Enabled = b;
            cb_NoteCond_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_NoteCond_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            noteConditionControl1.Enabled = cb_condNote.Checked && _my_enabled;
        }

        private void SaveNoteCond(FlagCondition saveto)
        {
            saveto.UseNoteCond = cb_condNote.Checked;
            var cond = noteConditionControl1.Export();
            cond.Enabled = noteConditionControl1.Enabled;
            saveto.NoteCond = (NoteCondition)cond;
        }

        private void ResetNoteCond(FlagCondition loadfrom)
        {
            NoteCondition cond = loadfrom.NoteCond;
            noteConditionControl1.Import(cond);
            cb_condNote.Checked = loadfrom.UseNoteCond;
        }

        #endregion NoteCond

        #region WordCond

        private void SetWordCondEnabled(bool b)
        {
            cb_WordCond.Enabled = b;
            cb_WordCond_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_WordCond_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            wordConditionControl1.Enabled = cb_useVbrEdit.Checked && _my_enabled;
        }

        private void SaveWordCond(FlagCondition saveto)
        {
            saveto.UseWordCond = cb_WordCond.Checked;
            LyricCondition cond = (LyricCondition)wordConditionControl1.Export();
            cond.Enabled = wordConditionControl1.Enabled;
            saveto.WordCond = cond;
        }

        private void ResetWordCond(FlagCondition loadfrom)
        {
            LyricCondition cond = loadfrom.WordCond;
            wordConditionControl1.Import(cond);
            cb_WordCond.Checked = loadfrom.UseWordCond;
        }

        #endregion WordCond

        #region WordEdit

        private void SetWordEditEnabled(bool b)
        {
            wordedit_use.Enabled = b;
            checkBox1_CheckedChanged_1(this, EventArgs.Empty);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            IsChanged = true;
            wordEditControl1.Enabled = wordedit_use.Checked && _my_enabled;
        }

        private void SaveWordEdit(FlagCondition saveto)
        {
            saveto.UseWordEdit = wordedit_use.Checked;
            var edit = wordEditControl1.Export();
            edit.Enabled = wordEditControl1.Enabled;
            saveto.WordEdit = (LyricEdit)edit;
        }

        private void ResetWordEdit(FlagCondition loadfrom)
        {
            LyricEdit edit = loadfrom.WordEdit;
            wordEditControl1.Import(edit);
            wordedit_use.Checked = loadfrom.UseWordEdit;
        }

        #endregion WordEdit

        #region IntensityCond

        private void SetIntensityCondEnabled(bool b)
        {
            cbx_use_inscond.Enabled = b;
            cb_IntensityCond_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_IntensityCond_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            intensityConditionControl1.Enabled = cbx_use_inscond.Checked && _my_enabled;
        }

        private void SaveIntensityCond(FlagCondition saveto)
        {
            saveto.UseIntensityCond = cbx_use_inscond.Checked;
            var cond = intensityConditionControl1.Export();
            cond.Enabled = intensityConditionControl1.Enabled;
            saveto.IntensityCond = (IntensityCondition)cond;
        }

        private void ResetIntensityCond(FlagCondition loadfrom)
        {
            IntensityCondition cond = loadfrom.IntensityCond;
            intensityConditionControl1.Import(cond);
            cbx_use_inscond.Checked = loadfrom.UseIntensityCond;
        }

        #endregion IntensityCond

        #region IntensityEdit

        private void SetIntensityEditEnabled(bool b)
        {
            cb_useInsensity.Enabled = b;
            cb_IntensityEdit_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_IntensityEdit_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            intensityEditControl1.Enabled = cb_useInsensity.Checked && _my_enabled;
        }

        private void SaveIntensityEdit(FlagCondition saveto)
        {
            saveto.UseIntensityEdit = cb_useInsensity.Checked;
            IntensityEdit edit = (IntensityEdit)intensityEditControl1.Export();
            edit.Enabled = intensityEditControl1.Enabled;
            saveto.IntensityEdit = edit;
        }

        private void ResetIntensityEdit(FlagCondition loadfrom)
        {
            intensityEditControl1.Import(loadfrom.IntensityEdit);
            cb_useInsensity.Checked = loadfrom.UseIntensityEdit;
        }

        #endregion IntensityEdit

        #region LengthCond

        private void SetLengthCondEnabled(bool b)
        {
            cb_use_lengthcond.Enabled = b;
            cb_LengthCond_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_LengthCond_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            lengthConditionControl1.Enabled = cb_use_lengthcond.Checked && _my_enabled;
        }

        private void SaveLengthCond(FlagCondition saveto)
        {
            saveto.UseIntensityCond = cb_use_lengthcond.Checked;
            var cond = lengthConditionControl1.Export();
            cond.Enabled = lengthConditionControl1.Enabled;
            saveto.lengthCond = (LengthCondition)cond;
        }

        private void ResetLengthCond(FlagCondition loadfrom)
        {
            LengthCondition cond = loadfrom.lengthCond;
            lengthConditionControl1.Import(cond);
            cb_use_lengthcond.Checked = loadfrom.UseLengthCond;
        }

        #endregion LengthCond

        #region Vbr

        private void SetVbrEditEnabled(bool enabled)
        {
            cb_useVbrEdit.Enabled = enabled;
            cb_useVbrEdit_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_useVbrEdit_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            vbrEditControl1.Enabled = cb_useVbrEdit.Checked && _my_enabled;
        }

        private void SaveVbrEdit(FlagCondition saveto)
        {
            saveto.UseVbrEdit = cb_useVbrEdit.Checked;

            VbrEdit vbr = (VbrEdit)vbrEditControl1.Export();
            vbr.Enabled = vbrEditControl1.Enabled;
            saveto.VbrEdit = vbr;
        }

        private void ResetVbrEdit(FlagCondition loadfrom)
        {
            VbrEdit vbr = loadfrom.VbrEdit;
            vbrEditControl1.Import(vbr);
            cb_useVbrEdit.Checked = loadfrom.UseVbrEdit;
        }

        #endregion Vbr

        #region FlagsEdit

        private void SetFlagsEditEnabled(bool b)
        {
            cb_UseFlagsEdit.Enabled = b;
            cb_UseFlagsEdit_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_UseFlagsEdit_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            flagsEditControl1.Enabled = cb_UseFlagsEdit.Checked && _my_enabled;
        }

        private void SaveFlagsEdit(FlagCondition saveto)
        {
            FlagsEdit edit = (FlagsEdit)flagsEditControl1.Export();
            edit.Enabled = wordEditControl1.Enabled;
            saveto.flagsEdit = edit;
        }

        private void ResetFlagsEdit(FlagCondition loadfrom)
        {
            FlagsEdit edit = loadfrom.flagsEdit;
            flagsEditControl1.Import(edit);
            cb_UseFlagsEdit.Checked = loadfrom.UseWordEdit;
        }

        #endregion FlagsEdit

        #region ModurationEdit

        private void SetModurationEditEnabled(bool b)
        {
            cb_useModuration.Enabled = b;
            cb_ModurationEdit_CheckedChanged(this, EventArgs.Empty);
        }

        private void cb_ModurationEdit_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            modurationEditControl1.Enabled = cb_useModuration.Checked && _my_enabled;
        }

        private void SaveModurationEdit(FlagCondition saveto)
        {
            saveto.UseModurationEdit = cb_useModuration.Checked;
            var edit = modurationEditControl1.Export();
            edit.Enabled = modurationEditControl1.Enabled;
            saveto.ModurationEdit = (ModurationEdit)edit;
        }

        private void ResetModurationEdit(FlagCondition loadfrom)
        {
            modurationEditControl1.Import(loadfrom.ModurationEdit);
            cb_useModuration.Checked = loadfrom.UseModurationEdit;
        }

        #endregion ModurationEdit

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void comboBoxOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void comboBoxWT_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCondition();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            IsChanged = true;
        }
    }
}