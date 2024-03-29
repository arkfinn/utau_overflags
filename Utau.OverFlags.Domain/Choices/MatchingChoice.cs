﻿using System;
using System.Collections.Generic;
using System.Text;
using Utau.OverFlags.Domain.Commands.WordLikes;

namespace Utau.OverFlags.Domain.Choices
{
    public class MatchingChoice : IChoicable
    {
        public Matching Parse(string method, string value)
        {
            switch (method)
            {
                case "All":
                case ExactMatching.MethodText:
                    return new ExactMatching(value);
                case "Partial":
                case PartialMatching.MethodText:
                    return new PartialMatching(value);
                case "Prefix":
                case ForwardMatching.MethodText:
                    return new ForwardMatching(value);
                case "Suffix":
                case BackwardMatching.MethodText:
                    return new BackwardMatching(value);
            }
            throw new ArgumentException("invalid wordlike:" + method);
        }

        private readonly string[] ParsableWords = {
            ExactMatching.MethodText,
            PartialMatching.MethodText,
            ForwardMatching.MethodText,
            BackwardMatching.MethodText};

        public string[] Choices
        {
            get { return ParsableWords; }
        }
    }
}
