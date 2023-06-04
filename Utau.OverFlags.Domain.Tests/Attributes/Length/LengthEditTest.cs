using NUnit.Framework;
using Utau.Elements;
using Utau.OverFlags.Domain.Commands.Calculations;

namespace Utau.OverFlags.Domain.Attributes.Length
{
    class LengthEditTest
    {
        [Test]
        public void DefaultValueTest()
        {
            var edit = new LengthEdit();
            Assert.That(edit.Calculator.Value, Is.EqualTo(0));
        }

        [Test]
        public void EditTest()
        {
            var elm = new UtauElement
            {
                Length = 100
            };
            var edit = new LengthEdit(new AdditionCommand(20));

            var result = edit.Edit(elm);

            Assert.That(result, Is.True);
            Assert.That(elm.Length, Is.EqualTo(120));
        }

        [Test]
        public void ToStringTest()
        {
            var edit = new LengthEdit(new AdditionCommand(20));
            Assert.That(edit.ToString(), Is.EqualTo($"音長を20加算"));
        }
    }
}
