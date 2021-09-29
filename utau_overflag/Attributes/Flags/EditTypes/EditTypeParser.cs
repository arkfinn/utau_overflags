﻿using System;
using System.Collections.Generic;
using System.Text;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    class EditTypeParser : ChoiceSet
    {
        public EditType Parse(string method, string value)
        {
            switch (method)
            {
                case "Add":
                case "を追加":
                    return new FlagsAddition(value);
                case "OverWrite":
                case "で上書き":
                    return new FlagsOverWriter(value);
                case "Replace":
                case "で置換":
                    return new FlagsReplacer(value);
                case "Math":
                case "で計算":
                    return new FlagsCalculator(value);
            }
            throw new ArgumentException("invalid method:" + method);
        }

        private readonly string[] parsableWords = { "を追加", "で上書き", "で置換", "で計算" };
        public string[] Choices
        {
            get { return parsableWords; }
        }
    }
}
