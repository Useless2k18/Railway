using BusinessLogicWPF.Model;

namespace BusinessLogicWPF.Helper
{
    public static class DataHelper
    {
        private static Train _train;
        private static bool _statusForEnable;

        public static Train Train
        {
            get => _train;
            set
            {
                if (value == null || _train == value) return;
                _train = value;
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
