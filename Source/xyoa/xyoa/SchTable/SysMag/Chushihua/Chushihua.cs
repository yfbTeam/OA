namespace xyoa.SchTable.SysMag.Chushihua
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chushihua : Page
    {
        protected Button Button1;
        protected TextBox ById;
        protected CheckBox CheckBox1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox YsXueduan;
        protected TextBox YsXueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str14;
            if (this.CheckBox1.Checked)
            {
                string str3;
                SqlDataReader list;
                string str4;
                string str11;
                SqlDataReader reader4;
                if (this.Xueqi.SelectedValue != this.divsch.GetXueqi())
                {
                    string s = this.divsch.GetXueqi().Substring(2, 2);
                    int num = int.Parse(this.Xueqi.SelectedValue.Substring(2, 2)) - int.Parse(s);
                    str3 = "select A.*,B.[Mingcheng] as BanJiName,B.Nianji,C.RuxueBiye,D.Num,D.Xueduan as DXueduan from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] inner join [qp_sch_Nianji] as [C] on [B].[Nianji] = [C].[NianjiMc] inner join [qp_sch_SetSclClass] as [D] on [B].[Nianji] = [D].[Name] order by A.id asc";
                    list = this.List.GetList(str3);
                    while (list.Read())
                    {
                        if (list["RuxueBiye"].ToString() == "毕业")
                        {
                            str4 = string.Concat(new object[] { "insert into qp_sch_Biangeng_Rz   (XsId,Xueqi,Xueduan,QZhuangtai,HZhuangtai,Username,Realname,Nowtimes) values ('", list["XsId"].ToString(), "','", this.YsXueqi.Text, "','", this.YsXueduan.Text, "','", this.divsch.TypeCode("Name", "qp_sch_DataFile", list["XuejiZhuangtai"].ToString()), "','毕业','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                            this.List.ExeSql(str4);
                            string sql = "Update [stu_table_" + this.YsXueqi.Text + "_" + this.YsXueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "]     Set XuejiZhuangtai='" + this.ById.Text + "' where   XsId='" + list["XsId"].ToString() + "'";
                            this.List.ExeSql(sql);
                        }
                        else if (num > 0)
                        {
                            string str6 = list["BanJiName"].ToString();
                            string str7 = "0";
                            string str8 = string.Concat(new object[] { "select * from qp_sch_SetSclClass where Num=", list["Num"].ToString(), "+", num, "" });
                            SqlDataReader reader2 = this.List.GetList(str8);
                            if (reader2.Read() && (reader2["Xueduan"].ToString() == list["DXueduan"].ToString()))
                            {
                                str7 = reader2["Name"].ToString();
                            }
                            reader2.Close();
                            if (str7 != "0")
                            {
                                string str9 = str7.Substring(0, 2);
                                int num2 = int.Parse(str6.Substring(2, str6.Length - 3)) + num;
                                string str10 = string.Concat(new object[] { "select id from qp_sch_Banji where Xueqi='", this.Xueqi.SelectedValue, "' and Mingcheng='", str9, "", num2, "班'" });
                                SqlDataReader reader3 = this.List.GetList(str10);
                                if (reader3.Read())
                                {
                                    str11 = "select id from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] where XsId='" + list["XsId"].ToString() + "'";
                                    reader4 = this.List.GetList(str11);
                                    if (!reader4.Read())
                                    {
                                        str4 = "insert into [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.Xueqi.SelectedValue + "','" + reader3["id"].ToString() + "','" + list["XsId"].ToString() + "','" + list["Zhiwu"].ToString() + "','" + list["XuejiZhuangtai"].ToString() + "')";
                                        this.List.ExeSql(str4);
                                    }
                                    reader4.Close();
                                }
                                else
                                {
                                    string str12 = string.Concat(new object[] { "insert into qp_sch_Banji  (Xueqi,Nianji,Mingcheng,Shangkedidian,BzUsername,BzRealname,RkUsername,RkRealname,XldUsername,XldRealname) values ('", this.pulicss.GetFormatStr(this.Xueqi.SelectedValue), "','", str9, "年级','", str9, "", num2, "班'','','','','','','','')" });
                                    this.List.ExeSql(str12);
                                    string str13 = string.Concat(new object[] { "select id from qp_sch_Banji where Xueqi='", this.Xueqi.SelectedValue, "' and Mingcheng='", str9, "", num2, "班'" });
                                    SqlDataReader reader5 = this.List.GetList(str13);
                                    if (reader5.Read())
                                    {
                                        str11 = "select id from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] where XsId='" + list["XsId"].ToString() + "'";
                                        reader4 = this.List.GetList(str11);
                                        if (!reader4.Read())
                                        {
                                            str4 = "insert into [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.Xueqi.SelectedValue + "','" + reader5["id"].ToString() + "','" + list["XsId"].ToString() + "','" + list["Zhiwu"].ToString() + "','" + list["XuejiZhuangtai"].ToString() + "')";
                                            this.List.ExeSql(str4);
                                        }
                                        reader4.Close();
                                    }
                                    reader5.Close();
                                }
                                reader3.Close();
                            }
                        }
                    }
                    list.Close();
                    str14 = "Update qp_sch_Chushihua  Set Xueqi='" + this.Xueqi.SelectedValue + "',Xueduan='" + this.Xueduan.SelectedValue + "'";
                    this.List.ExeSql(str14);
                }
                else if ((this.Xueqi.SelectedValue == this.divsch.GetXueqi()) && (this.Xueduan.SelectedValue != this.divsch.GetXueduan()))
                {
                    str3 = "select * from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] order by id asc";
                    list = this.List.GetList(str3);
                    while (list.Read())
                    {
                        str11 = "select id from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] where XsId='" + list["XsId"].ToString() + "'";
                        reader4 = this.List.GetList(str11);
                        if (!reader4.Read())
                        {
                            str4 = "insert into [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.Xueqi.SelectedValue + "','" + list["BanJi"].ToString() + "','" + list["XsId"].ToString() + "','" + list["Zhiwu"].ToString() + "','" + list["XuejiZhuangtai"].ToString() + "')";
                            this.List.ExeSql(str4);
                        }
                        reader4.Close();
                    }
                    list.Close();
                    str14 = "Update qp_sch_Chushihua  Set Xueqi='" + this.Xueqi.SelectedValue + "',Xueduan='" + this.Xueduan.SelectedValue + "'";
                    this.List.ExeSql(str14);
                }
            }
            else
            {
                str14 = "Update qp_sch_Chushihua  Set Xueqi='" + this.Xueqi.SelectedValue + "',Xueduan='" + this.Xueduan.SelectedValue + "'";
                this.List.ExeSql(str14);
            }
            this.pulicss.InsertLog("修改当前学期设置", "当前学期设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Chushihua.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Chushihua";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                }
                list.Close();
                this.ById.Text = this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "毕业", "20");
                this.YsXueqi.Text = this.divsch.GetXueqi();
                this.YsXueduan.Text = this.divsch.GetXueduan();
                this.BindAttribute();
            }
        }
    }
}

