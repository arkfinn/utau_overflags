using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Utau.OverFlags.Domain.Contracts;

namespace utau_overflags.OldSetting
{
    [System.Xml.Serialization.XmlRoot("ArrayOfFlagCondition")]
    public class OldConditionList
    {
        public List<OldFlagCondition> FlagCondition = new List<OldFlagCondition>();
       
        public ConditionList toConditionList()
        {
            ConditionList list = new ConditionList();
            foreach (OldFlagCondition item in FlagCondition)
            {
                list.Add(item.toFlagCondition());
            }
            return list;
        }

        internal ContractList toContractList()
        {
            List<Contract> list = new List<Contract>();
            foreach (OldFlagCondition item in FlagCondition)
            {
                list.Add(item.toContract());
            }
            return new ContractList(list);
        }
    }
}
