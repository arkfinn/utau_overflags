using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using utau_overflags.Attributes.Lyric;
using utau_overflags.Attributes.Lyric.Connectors;
using utau_overflags.Attributes.Lyric.WordLikes;
using utau_overflags.Conditions;
using utau_overflags.Edits;

namespace utau_overflags.Forms
{
    class ContractSetterTest
    {
        [Test]
        public void  条件をセットすると反映されるテスト()
        {
            var control = new ContractSetter();
            control.LoadContract(CreateContract());
            Assert.That(control.ToContract().ToString(), Is.EqualTo(CreateContract().ToString()));
        }

        private Contract CreateContract()
        {
              List<EditBase> edits = new List<EditBase>();
            edits.Add(new LyricEdit(new ReplaceConnector("か")));

             List<CondBase> conditions = new List<CondBase>();
            conditions.Add(new LyricCondition(new ExactMatching("あ")));
           return  new Contract(conditions,edits);
        }
    }
}
