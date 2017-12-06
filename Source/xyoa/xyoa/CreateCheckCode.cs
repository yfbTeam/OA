namespace xyoa
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class CreateCheckCode : Page
    {
        protected HtmlForm form1;

        private string CreateCheckCodeString()
        {
            char[] chArray = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string str = "";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                str = str + chArray[random.Next(chArray.Length)];
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int num3;
            Point point;
            Point point2;
            this.Session["codenum"] = this.CreateCheckCodeString();
            int width = 0x2d;
            int height = 0x12;
            Font font = new Font("Arial", 12f, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.FromArgb(0xff, 100, 100), 0f);
            Pen pen2 = new Pen(Color.FromArgb(0xff, 100, 100), 0f);
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(ColorTranslator.FromHtml("#F0F0F0"));
            RectangleF layoutRectangle = new RectangleF(5f, 2f, (float) width, (float) height);
            Random random = new Random();
            for (num3 = 0; num3 < 2; num3++)
            {
                point = new Point(0, random.Next(height));
                point2 = new Point(width, random.Next(height));
                graphics.DrawLine(pen, point, point2);
            }
            for (num3 = 0; num3 < 2; num3++)
            {
                point = new Point(random.Next(width), 0);
                point2 = new Point(random.Next(width), height);
                graphics.DrawLine(pen2, point, point2);
            }
            graphics.DrawString(this.CreateCheckCodeString(), font, brush, layoutRectangle);
            image.Save(base.Response.OutputStream, ImageFormat.Gif);
            graphics.Dispose();
            image.Dispose();
        }
    }
}

