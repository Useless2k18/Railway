using BusinessLogicWPF.Domain;

namespace BusinessLogicWPF.Helper
{
    public static class DataHelper
    {
        private static SelectableViewModel _data;
        private static bool _statusForEnable;

        public static SelectableViewModel Data
        {
            get => _data;
            set
            {
                if (value == null || _data == value) return;
                _data = value;
            }
        }

        public static bool StatusForEnable
        {
            get => _statusForEnable;
            set
            {
                if (_statusForEnable.Equals(value)) return;
                _statusForEnable = value;
            }
        }
    }
}
