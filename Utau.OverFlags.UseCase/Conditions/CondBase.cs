using Utau.Elements;

namespace utau_overflags.Conditions
{
    abstract public class CondBase
    {
        //TODO: Enabledは削除し、CondBaseは使うものをリスト管理としたい。
        private bool _Enabled = true;

        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        public bool IsApply(UtauElement elm)
        {
            if (Enabled)
            {
                return DecideApply(elm);
            }
            //使用しない場合は常に条件ｏｋとする
            return true;
        }

        abstract protected bool DecideApply(UtauElement elm);
    }
}