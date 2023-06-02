using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using utau_overflags;
using UtauPluginSet;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Lyric.WordLikes;
using utau_overflags.Attributes.Lyric.Connectors;
using utau_overflags.Attributes.Vibrato;
using utau_overflags.Attributes.Intensity;
using utau_overflags.Attributes.Comparers;
using utau_overflags.Attributes.Length;
using utau_overflags.Attributes.Moduration;
using utau_overflags.Attributes.Flags;
using utau_overflags.Attributes.Flags.EditTypes;

/*
 * 2011/6/25
 * 
 * useフラグを考慮すること
 * 
 * 
 * */

namespace utau_overflagstest
{
    public class FlagConditionTest
    {
       /* [Test]
        public void IsApplyConditionMathTest()
        {
            FlagCondition c = new FlagCondition();
            c.TargetNote = new Note(60);
            c.Operator = Operator.Equal;
            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Calculator("g+10Y%50h+10"));
            c.Version = FlagCondition.Version1500;
            c.UseFlagsEdit = true;

            UtauElement e60 = new UtauElement();
            e60.NoteNum = 60;
            e60["Flags"] = "g5Y100";

            c.ApplyCondition(e60);

            Assert.AreEqual(e60["Flags"], "g15Y50h10");
        }



        [Test]
        public void 無条件のときは常にIsApplyがtrue()
        {
            FlagCondition c = new FlagCondition();
            Assert.IsFalse(c.UseNoteCond);
            Assert.IsTrue(c.IsApply(new UtauElement()));
        }

        private UtauElement createElementByNoteNum(int i)
        {
            UtauElement e = new UtauElement();
            e.NoteNum = i;
            return e;
        }

        [Test]
        public void ノート番号が60のときIsApplyがtrue()
        {
            //バージョン1500でnotecondがfalseなら無条件okになることを確認
            FlagCondition c = new FlagCondition();
            c.Version = FlagCondition.Version1500;
            c.NoteCond = CreateNoteCondition(new EqualsComparer(60));
            c.UseNoteCond = true; 

            Assert.IsFalse(c.IsApply(createElementByNoteNum(59)));
            Assert.IsTrue(c.IsApply(createElementByNoteNum(60)));
            Assert.IsFalse(c.IsApply(createElementByNoteNum(61)));
        }

        private utau_overflags.Attributes.Note.NoteCondition CreateNoteCondition(Comparer c)
        {
           return new utau_overflags.Attributes.Note.NoteCondition(c);
        }

        [Test]
        public void IsApplyConditionReplaceTest()
        {
            //バージョン1500でNoteCondとFlagsEditがtrueなら動くことを確認
            FlagCondition c = new FlagCondition();
            c.NoteCond = CreateNoteCondition(new EqualsComparer(60));
            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Replacer("g10h10"));
            c.Version = FlagCondition.Version1500;
            c.UseNoteCond = true;
            c.UseFlagsEdit = true;

            UtauElement e60 = new UtauElement();
            e60.NoteNum = 60;
            e60["Flags"] = "g5Y100";

            c.ApplyCondition(e60);

            Assert.AreEqual(e60["Flags"], "g10Y100h10");
        }

        [Test]
        public void NoFlagsEditTest()
        {
            //UseFlagsEditをオフにすれば、例え設定があっても処理されないことを確認
            FlagCondition c = new FlagCondition();
            c.NoteCond = new utau_overflags.Attributes.Note.NoteCondition(new EqualsComparer(60));
            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Replacer("g10h10"));
            c.Version = FlagCondition.Version1500;
            c.UseNoteCond = true;
            c.UseFlagsEdit = false;

            c.IntensityEdit = new IntensityEdit(new UtauPluginSet.Calculators.Addition(25));
            c.UseIntensityEdit = false;

            c.VbrEdit = new VbrEdit("1,2,3");
            c.UseVbrEdit = false;

            UtauElement e60 = new UtauElement();
            e60.NoteNum = 60;
            e60["Flags"] = "g5Y100";
            e60.Intensity = 100;
            e60["Vbr"] = "4,5,6";

            //add

            c.ApplyCondition(e60);

            c.ApplyCondition(e60);

            Assert.AreEqual(e60["Flags"], "g5Y100");
            Assert.AreEqual(e60.Intensity, 100);
            Assert.AreEqual(e60["Vbr"], "4,5,6");
        }

        [Test]
        public void CondFalseNoEditTest()
        {
            //条件を満たしていないときに実行されないこと
            FlagCondition c = new FlagCondition();
            c.Version = FlagCondition.Version1500;
            c.NoteCond = new utau_overflags.Attributes.Note.NoteCondition(new EqualsComparer(61));
            c.UseNoteCond = true;

            c.UseFlagsEdit = true;
            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Replacer("g10h10"));
        
            c.IntensityEdit = new IntensityEdit(new UtauPluginSet.Calculators.Addition(25));
            c.UseIntensityEdit = true;

            c.VbrEdit = new VbrEdit("1,2,3");
            c.UseVbrEdit = true;

            UtauElement e60 = new UtauElement();
            e60.NoteNum = 60;
            e60["Flags"] = "g5Y100";
            e60.Intensity = 100;
            e60["Vbr"] = "4,5,6";

            c.ApplyCondition(e60);

            Assert.AreEqual(e60["Flags"], "g5Y100");
            Assert.AreEqual(e60.Intensity, 100);
            Assert.AreEqual(e60["Vbr"], "4,5,6");
        }


        [Test]
        public void ToStringTest()
        {
            FlagCondition c = new FlagCondition();
            c.Version = FlagCondition.Version1500;
            c.NoteCond = CreateNoteCondition(new EqualsComparer(60));
            c.UseNoteCond = false;

            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Replacer("g10h10"));
            c.UseFlagsEdit = false;
        
                    Assert.AreEqual("無条件で、何もしない",c.ToString());

            c.UseNoteCond = true;
            c.UseFlagsEdit = true;

            Assert.AreEqual("C4と同値の時、Flags「g10h10」で置換する",c.ToString());

            c.VbrEdit = new VbrEdit("1,2,3");
            c.UseVbrEdit = true;
 
            Assert.AreEqual("C4と同値の時、Flags「g10h10」で置換、VBRに「1,2,3」を設定する",c.ToString());

            c.WordCond = new LyricCondition(new PartialMatching("わ"));
            c.UseWordCond = true;
            Assert.AreEqual("C4と同値、「わ」と部分一致の時、Flags「g10h10」で置換、VBRに「1,2,3」を設定する", c.ToString());
            c.UseWordCond = false;
            c.UseVbrEdit = false;

            c.IntensityEdit = new IntensityEdit(new UtauPluginSet.Calculators.Addition(30));
            c.UseIntensityEdit = true;
            Assert.AreEqual("C4と同値の時、Flags「g10h10」で置換、音量を30加算する", c.ToString());

        }

        [Test]
        public void VbrEditTest()
        {
            FlagCondition c = new FlagCondition();
            c.Version = FlagCondition.Version1500;
            c.NoteCond = new utau_overflags.Attributes.Note.NoteCondition(new EqualsComparer(60));
            c.UseNoteCond = false;

            c.flagsEdit = new FlagsEdit(new utau_overflags.Attributes.Flags.EditTypes.Replacer("g10h10"));
            c.UseFlagsEdit = false;
        
            c.IntensityEdit = new IntensityEdit(new UtauPluginSet.Calculators.Addition(25)); 
            c.UseIntensityEdit = false;
            
            c.UseNoteCond = true;
            c.UseFlagsEdit = false;

            c.VbrEdit = new VbrEdit("1,2,3");
            c.UseVbrEdit = true;

            UtauElement e60 = new UtauElement();
            e60.NoteNum = 60;
            e60["Flags"] = "g5Y100";
            e60["VBR"] = "4,5,6";
            e60.Intensity = 100;

            c.ApplyCondition(e60);

            Assert.AreEqual(e60["Flags"], "g5Y100");
            Assert.AreEqual(e60["VBR"], "1,2,3");
            Assert.AreEqual(e60.Intensity, 100);
        }

        [Test]
        public void LengthCondTest()
        {
            FlagCondition c = new FlagCondition();
            c.lengthCond = new LengthCondition(new MoreThanEqualsComparer(240));
            c.Version = FlagCondition.Version1500;
            c.UseLengthCond = true;

            UtauElement l239 = new UtauElement();
            l239.Length = 239;

            UtauElement l240 = new UtauElement();
            l240.Length = 240;

            Assert.IsFalse(c.IsApply(l239));
            Assert.IsTrue(c.IsApply(l240));


        }

    

      
        class Word操作が設定されている時
        {
            [Test]
            public void _い_がセットされる()
            {
                //Word操作が設定されていれば動作することを確認
                UtauElement elm = ElementOf("あ");
                ConditionOf("い").ApplyCondition(elm);
                Assert.AreEqual("い", elm.Lyric);
            }

            private FlagCondition ConditionOf(string word)
            {
                FlagCondition c = new FlagCondition();
                c.Version = FlagCondition.Version1500;
                c.WordEdit = new LyricEdit(new ReplaceConnector(word));
                c.WordEdit.Enabled = true;
                return c;
            }

            private UtauElement ElementOf(string lyric)
            {
                UtauElement e = new UtauElement();
                e.Lyric = lyric;
                return e;
            }
        }

        class Moduration操作が設定されている時
        {
            [Test]
            public void _25がセットされる()
            {
                AppliedShouldEqual(25, ElementOf(100), ConditionOf(new Assignment(25)));
            }

            [Test]
            public void _25が加算される()
            {
                AppliedShouldEqual(125, ElementOf(100), ConditionOf(new UtauPluginSet.Calculators.Addition(25)));
            }

            [Test]
            public void _25が減算される()
            {
                AppliedShouldEqual(75, ElementOf(100), ConditionOf(new Subtraction(25)));
            }

            [Test]
            public void _25パーセントになる()
            {
                AppliedShouldEqual(30, ElementOf(120), ConditionOf(new Percent(25)));
            }

            private void AppliedShouldEqual(int expected, UtauElement elm, FlagCondition cond)
            {
                cond.ApplyCondition(elm);
                Assert.AreEqual(expected, elm.Moduration);

            }

            private FlagCondition ConditionOf(UtauPluginSet.Calculators.Calculator op)
            {
                FlagCondition c = new FlagCondition();
                c.Version = FlagCondition.Version1500;
                c.ModurationEdit = new ModurationEdit(op);
                c.UseModurationEdit = true;
                return c;
            }

            private UtauElement ElementOf(int mod)
            {
                UtauElement e = new UtauElement();
                e.Moduration = mod;
                return e;
            }
        
         }
        */
    }
}
