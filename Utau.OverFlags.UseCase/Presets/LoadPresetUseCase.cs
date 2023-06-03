using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utau.OverFlags.Domain.Contracts;
using utau_overflags.OldSetting;

namespace Utau.OverFlags.Application.Presets
{
    public class LoadPresetUseCase
    {
        private readonly string FilePath;

        public LoadPresetUseCase(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public ContractList Execute()
        {
            if (!File.Exists(FilePath))
                return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            // タイトル表示
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes("FlagCondition");
            if (nodeList.Count == 0)
            {
                return ContractList.FromFile(FilePath);
            }

            OldConditionList res = new OldConditionList();
            foreach (XmlNode nd in nodeList)
            {
                OldFlagCondition cond = OldFlagCondition.from(nd);
                res.FlagCondition.Add(cond);
            }
            return res.toContractList();
        }

    }
}
