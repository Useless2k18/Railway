using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BussinessLogic
{
    public sealed partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();

            PlayStore.Image = Properties.Resources.Play_Store;
            AppleStore.Image = Properties.Resources.app_store_apple;
            WindowsStore.Image = Properties.Resources.Windows_logo;
        }

        private void _MinButton_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void _CloseButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            var bmp = new Bitmap(image.Width, image.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                var matrix = new ColorMatrix { Matrix33 = opacity };
                var attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private void ButtonLoginRegister_Click(object sender, System.EventArgs e)
        {
            using (var loginAndRegistrationForm = new LoginAndRegistrationForm())
            {
                Hide();
                loginAndRegistrationForm.ShowDialog();
                Show();
            }
        }
    }
}
