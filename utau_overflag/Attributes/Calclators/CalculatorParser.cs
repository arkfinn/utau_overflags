﻿using System;
using Utau.OverFlags.Domain.CalculateCommands;
using utau_overflags.Attributes;

namespace UtauPluginSet.Attributes.Calculators
{
    public class CalculatorParser : ChoiceSet
    {
        public CalculateCommand Parse(string method, int value)
        {
            switch (method)
            {
                case "に設定":
                    return new AssignmentCommand(value);

                case "加算":
                    return new AdditionCommand(value);

                case "減算":
                    return new SubtractionCommand(value);

                case "%に変更":
                    return new PercentCommand(value);
            }
            throw new ArgumentException("invalid method:" + method);
        }

        private readonly string[] parsableWords = { "に設定", "加算", "減算", "%に変更" };

        public string[] Choices
        {
            get { return parsableWords; }
        }
    }
}