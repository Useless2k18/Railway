using BusinessLogicWPF.Domain;

namespace BusinessLogicWPF.Helper
{
    public static class DataHelper
    {
        private static SelectableViewModel _data;

        public static SelectableViewModel Data
        {
            get => _data;
            set
            {
                if (value == null || _data == value) return;
                _data = value;
            }
        }
    }
}
