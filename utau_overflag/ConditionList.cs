using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;
using utau_overflags.OldSetting;
using System.Diagnostics;
using System.Xml;

namespace utau_overflags
{
    public class ConditionList : BindingList<FlagCondition>
    {


        public void Output(string fn)

        {
            var preset = new PresetController();
            preset.Write<ConditionList>(fn, this);
        }

        static public ConditionList _FromFile(string path)
        {
            OldConditionList res = null;
            if (!File.Exists(path))
                return null;

            XmlSerializer serializer = new XmlSerializer(typeof(OldConditionList));
            //ファイルを開く
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                //XMLファイルから読み込み、逆シリアル化する
                res = (OldConditionList)serializer.Deserialize(fs);
            }

            ConditionList list = new ConditionList();
            foreach (OldFlagCondition item in res.FlagCondition)
            {
                list.Add(item.toFlagCondition());
            }
            return list;
        }

        static public ConditionList FromFile(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            
            // タイトル表示
            nodeList = root.SelectNodes("FlagCondition");
            if(nodeList.Count ==0)
            {
            //    return FromFileNewStyle(path);
            }
            OldConditionList res = new OldConditionList();
            //Change the price on the books.
            foreach (XmlNode nd in nodeList)
            {
                OldFlagCondition cond = OldFlagCondition.from(nd);
                res.FlagCondition.Add(cond);
            }
            return res.toConditionList();
        }

        static public ContractList FromFileNewStyle(string path)
        {
            return ContractList.FromFile(path);
        }
    }
}
