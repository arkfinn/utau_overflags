using System;
using System.IO;

namespace Utau.Domain.Scores
{
    public interface IScoreReader
    {
        void Read(Action<StreamReader> callback);
    }
}