using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Utau.OverFlags.Domain.Contracts
{
    [Serializable()]
    public class ContractList
    {
        private ContractList() { }
        public ContractList(List<Contract> list)
        {
            Items = list;
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

        public static ContractList FromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContractList));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (ContractList)serializer.Deserialize(fs);
            }
        }

    }
}
