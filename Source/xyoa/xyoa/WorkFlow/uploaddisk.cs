namespace xyoa.WorkFlow
{
    using System;
    using System.Web;
    using System.Web.UI;

    public class uploaddisk : Page
    {
        public void doFormUploadDisk()
        {
            string str = base.Server.MapPath("/");
            HttpFileCollection files = base.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (files.GetKey(i).ToUpper() == "EDITFILE")
                {
                    file.SaveAs(str + @"\" + file.FileName.Substring(file.FileName.LastIndexOf('\\') + 1));
                    base.Response.Write("文件保存成功<br>");
                    base.Response.Write("文件大小: " + file.ContentLength.ToString() + "\tbytes<br>");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.doFormUploadDisk();
        }
    }
}

