namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class _ : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox TextBox3;
        protected TextBox TextBox4;
        protected TextBox TextBox5;
        protected TextBox TextBox6;

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str2 = null;
            str2 = "" + this.TextBox4.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { '\n' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string sql = "insert into qp_sch_DataFile (Name,type,ifdel) values ('" + strArray[i].Trim() + "','" + this.TextBox5.Text + "','0')";
                this.List.ExeSql(sql);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Write("" + this.TextBox6.Text.Length + "<br>");
            base.Response.Write("" + this.TextBox6.Text.LastIndexOf("班") + "<br>");
            base.Response.Write("" + this.TextBox6.Text.Substring(2, this.TextBox6.Text.Length - 3) + "<br>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

