using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using utau_overflags.OldSetting;

namespace utau_overflags
{
    [Serializable()]
    public class ContractList
    {
        private ContractList() { }
        public ContractList(List<Contract> list)
        {
            this.Items = list;
        }

        public List<Contract> Items;
        public IEnumerator<Contract> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public Contract this[int index]
        {
            get { return Items[index]; }
        }
        
        static public ContractList FromFile(string path)
        {
            if (!File.Exists(path))
                return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // タイトル表示
            XmlNodeList  nodeList = doc.DocumentElement.SelectNodes("FlagCondition");
            if (nodeList.Count == 0)
            {
                return FromNewFile(path);
            }

            OldConditionList res = new OldConditionList();
            foreach (XmlNode nd in nodeList)
            {
                OldFlagCondition cond = OldFlagCondition.from(nd);
                res.FlagCondition.Add(cond);
            }
            return res.toContractList();
        }

        private static ContractList FromNewFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContractList));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (ContractList)serializer.Deserialize(fs);
            }
        }

    }
}
