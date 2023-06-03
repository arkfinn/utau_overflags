using NUnit.Framework;

namespace utau_overflags
{
    class ConditionListTest
    {
        [Test]
        public void ToStringの内容を確認()
        {
            /*
             * メモ
             * 専用のネームスペース作る
             * FlagConditionの旧形式を用意して読み込み可能にする
             * 読み込んだあと新形式に変換する
             */

            ConditionList list = ConditionList.FromFile("TestFiles/ろにテト！.xml");
            Assert.That(list.Count, Is.EqualTo(7));
            Assert.That(list[0].ToString(), Is.EqualTo("G5以上の時、Flags「Y0g-15H20L4」で上書きする"));
            Assert.That(list[1].ToString(), Is.EqualTo("D#5以上の時、Flags「Y0g-10H20L4」で上書きする"));
            Assert.That(list[2].ToString(), Is.EqualTo("C#5以上の時、Flags「Y0g-8H15L2」で上書きする"));
            Assert.That(list[3].ToString(), Is.EqualTo("D#4以上の時、Flags「g-3」を追加する"));
            Assert.That(list[4].ToString(), Is.EqualTo("C4以上の時、Flags「」を追加する"));
            Assert.That(list[5].ToString(), Is.EqualTo("G3以下の時、Flags「Y0g8」で上書きする"));
            Assert.That(list[6].ToString(), Is.EqualTo("A3以下の時、Flags「Y0g5」で上書きする"));
        }

        //[Test]
        //public void 次にやること()
        //{
        //    Assert.Fail("次にやること");
        //    /*
        //      * FlagConditionを消す
        //     * 
        //     * 保存確認ボタンをまとめたい（「保存しないで実行」みたいな）
        //     * 
        //     * メインウィンドウはChangedのときは実行ボタンを押せない
        //     * リセットを用意
        //     * 保存確認ダイアログは作り直す
        //     * 保存して実行・保存しないで実行・実行しない
        //     * 
        //     */
        //}
    }
}
