﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace utau_overflags.Attributes.Others
{
    class OthersEditTest
    {
        [TestCase("VBR", "50")]
        [TestCase("$direct", "True")]
        public void ToStringが入力値通りの値を返す(string text, string text2)
        {
            var edit = new OthersEdit(text, text2);
            Assert.That(edit.ToString(), Is.EqualTo(text + "に「" + text2 + "」を設定"));
        }
    }
}
