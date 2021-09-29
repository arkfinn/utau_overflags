using System;

namespace Utau.Domain.Notes
{
    public class NoteName
    {
        public readonly string Value;

        public NoteName(int noteNumber)
        {
            Value = fetchNoteName(noteNumber);
        }

        private string fetchNoteName(int noteNumber)
        {
            switch (noteNumber % 12)
            {
                case 0:
                    return "C";

                case 1:
                    return "C#";

                case 2:
                    return "D";

                case 3:
                    return "D#";

                case 4:
                    return "E";

                case 5:
                    return "F";

                case 6:
                    return "F#";

                case 7:
                    return "G";

                case 8:
                    return "G#";

                case 9:
                    return "A";

                case 10:
                    return "A#";

                case 11:
                    return "B";

                default:
                    // noteNumberが0未満の場合は例外とする。
                    throw new ArgumentException("NoteName Error: " + noteNumber);
            }
        }
    }
}