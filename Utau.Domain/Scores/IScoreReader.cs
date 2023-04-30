using System;
using Utau.Elements;

namespace Utau.Domain.Scores
{
    public interface IScoreReader
    {
        void Read(Action<UtauElement> callback);
    }
}