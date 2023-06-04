using NUnit.Framework;

namespace Utau.OverFlags.Domain.Attributes.Vibrato
{
    class VbrEditTest
    {
        [TestCase("50")]
        [TestCase("12,34")]
        public void ToStringが入力値通りの値を返す(string text)
        {
            VbrEdit edit = new VbrEdit(text);
            Assert.That(edit.ToString(), Is.EqualTo("VBRに「" + text + "」を設定"));
        }
    }
}
