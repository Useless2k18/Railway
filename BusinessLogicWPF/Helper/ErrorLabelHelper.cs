namespace BusinessLogicWPF.Helper
{
    public class ErrorLabelHelper
    {
        private static int _counter;

        public static bool Check()
        {
            _counter++;
            return _counter > 2;
        }

        public static void Reset()
        {
            _counter = 0;
        }
    }
}
