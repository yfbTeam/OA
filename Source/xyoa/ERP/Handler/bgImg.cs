namespace ERP.Handler
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Services;
    using System.Web.SessionState;

    [WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1), WebService(Namespace="http://tempuri.org/")]
    public class bgImg : IHttpHandler, IRequiresSessionState
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        public void ProcessRequest(HttpContext context)
        {
            string str = null;
            string sql = "select * from qp_oa_Bg where  Username='" + context.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Url"].ToString();
            }
            else
            {
                str = "/Images/skin1/bg/blue_glow.jpg";
            }
            list.Close();
            context.Response.ContentType = "image/Jpeg";
            if ((context.Request["h"] == null) || (context.Request["h"] == ""))
            {
                context.Response.WriteFile(HttpContext.Current.Server.MapPath("~/Images/borderImg.gif"));
                context.Response.End();
            }
            else if ((context.Request["w"] == null) || (context.Request["w"] == ""))
            {
                context.Response.WriteFile(HttpContext.Current.Server.MapPath("~/Images/borderImg.gif"));
                context.Response.End();
            }
            else
            {
                int thumbWidth = 0;
                int thumbHeight = 0;
                Regex regex = new Regex(@"^\d+$");
                string input = context.Request["h"];
                if (regex.Match(input).Success)
                {
                    thumbHeight = int.Parse(input);
                }
                else
                {
                    context.Response.WriteFile(HttpContext.Current.Server.MapPath("~/Images/borderImg.gif"));
                    context.Response.End();
                    return;
                }
                string str4 = context.Request["w"];
                if (regex.Match(str4).Success)
                {
                    thumbWidth = int.Parse(str4);
                }
                else
                {
                    context.Response.WriteFile(HttpContext.Current.Server.MapPath("~/Images/borderImg.gif"));
                    context.Response.End();
                    return;
                }
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath("" + str + ""));
                Image image2 = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppRgb);
                Graphics graphics = Graphics.FromImage(image2);
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                graphics.Dispose();
                Image image3 = image2.GetThumbnailImage(thumbWidth, thumbHeight, null, IntPtr.Zero);
                MemoryStream stream = new MemoryStream();
                image3.Save(stream, ImageFormat.Jpeg);
                image.Dispose();
                image2.Dispose();
                image3.Dispose();
                context.Response.ClearContent();
                context.Response.ContentType = "image/Jpeg";
                context.Response.BinaryWrite(stream.ToArray());
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

