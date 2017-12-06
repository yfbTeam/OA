namespace xyoa.WorkFlow
{
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class MyWorkFlow_dc : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + list["FormNumber"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        StateBag bag = ViewState;
                        object obj2 = bag["url"];
                        (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "try{window.L", reader2["Number"], ".location.href='http://", base.Request.Url.Authority, "/WorkFlow/AddWorkFlow_spyj_dc.aspx?Number=", list["Number"].ToString(), "&Buzhou=", reader2["sqlstr"], "&key=1';}catch(err){}" });
                    }
                    reader2.Close();
                    Random random = new Random();
                    string str3 = random.Next(0x2710).ToString();
                    string str4 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str3 + "";
                    MemoryStream outStream = new MemoryStream();
                    byte[] buffer = null;
                    StreamWriter writer = File.CreateText(base.Server.MapPath("/WorkFlow/file/" + str4 + ".html"));
                    string str6 = string.Concat(new object[] { "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\" /></head><body  onload=\"geturl()\">", this.showform.FormatKjStrZh(list["FileContent"].ToString().Replace("/seal/", "http://" + base.Request.Url.Authority + "/seal/")), "</body><script>function geturl(){", this.ViewState["url"], "}</script></html>" });
                    writer.WriteLine(str6);
                    writer.Close();
                    using (ZipFile file = ZipFile.Create(outStream))
                    {
                        file.BeginUpdate();
                        file.NameTransform = new MyNameTransfom();
                        string str7 = "select  * from qp_oa_fileupload where KeyField='" + list["Number"].ToString() + "' order by id desc";
                        SqlDataReader reader3 = this.List.GetList(str7);
                        while (reader3.Read())
                        {
                            file.Add(base.Server.MapPath("/" + reader3["NewName"].ToString() + ""));
                        }
                        reader3.Close();
                        file.Add(base.Server.MapPath("/WorkFlow/file/" + str4 + ".html"));
                        file.CommitUpdate();
                        buffer = new byte[outStream.Length];
                        outStream.Position = 0L;
                        outStream.Read(buffer, 0, buffer.Length);
                    }
                    base.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("" + list["Name"].ToString() + ".zip", Encoding.UTF8) + "");
                    base.Response.BinaryWrite(buffer);
                    base.Response.Flush();
                    base.Response.End();
                    File.Delete("/WorkFlow/file/" + str4 + ".html");
                }
                list.Close();
            }
        }

        public class MyNameTransfom : INameTransform
        {
            public string TransformDirectory(string name)
            {
                return null;
            }

            public string TransformFile(string name)
            {
                return Path.GetFileName(name);
            }
        }
    }
}

