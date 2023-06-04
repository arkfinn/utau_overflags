using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utau.OverFlags.Domain.Contracts;
using utau_overflags;

namespace Utau.OverFlags.Application.Presets
{
    class LoadPresetUseCaseTest
    {

        [Test]
        public void ContractListの読み込み()
        {
            ContractList list = new LoadPresetUseCase("TestFiles/contract_list.xml").Execute();
            Assert.That(list, Is.Not.Null);
            Assert.That(list.Items.Count, Is.EqualTo(5));
            Assert.That(list.Items[0].ToString(), Is.EqualTo("「あ」と完全一致、「い」と部分一致、「う」と前方一致、「え」と後方一致の時、歌詞に「か」をセット、歌詞に「き」を前に追加、歌詞に「く」を後に追加する"));
            Assert.That(list.Items[1].ToString(), Is.EqualTo("音量が11と同値、音量が12以下、音量が13以上の時、音量を1加算、音量を2に設定、音量を3%に変更、音量を4減算する"));
            Assert.That(list.Items[2].ToString(), Is.EqualTo("A0と同値、A#0以下、B0以上の時、モジュレーションを31加算、モジュレーションを32に設定、モジュレーションを33%に変更、モジュレーションを34減算する"));
            Assert.That(list.Items[3].ToString(), Is.EqualTo("音長が21と同値、音長が22以下、音長が23以上の時、VBRに「あ」を設定する"));
            Assert.That(list.Items[4].ToString(), Is.EqualTo("無条件で、Flags「Y1」を追加、Flags「Y2」で計算、Flags「Y3」で上書き、Flags「Y4」で置換する"));
        }

        [Test]
        public void 旧ファイルの読み込み()
        {
            ContractList list = new LoadPresetUseCase("TestFiles/ろにテト！.xml").Execute();
            Assert.That(list.Items.Count, Is.EqualTo(7));
            Assert.That(list[0].ToString(), Is.EqualTo("G5以上の時、Flags「Y0g-15H20L4」で上書きする"));
            Assert.That(list[1].ToString(), Is.EqualTo("D#5以上の時、Flags「Y0g-10H20L4」で上書きする"));
            Assert.That(list[2].ToString(), Is.EqualTo("C#5以上の時、Flags「Y0g-8H15L2」で上書きする"));
            Assert.That(list[3].ToString(), Is.EqualTo("D#4以上の時、Flags「g-3」を追加する"));
            Assert.That(list[4].ToString(), Is.EqualTo("C4以上の時、Flags「」を追加する"));
            Assert.That(list[5].ToString(), Is.EqualTo("G3以下の時、Flags「Y0g8」で上書きする"));
            Assert.That(list[6].ToString(), Is.EqualTo("A3以下の時、Flags「Y0g5」で上書きする"));

        }
    }
}
