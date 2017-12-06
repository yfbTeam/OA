namespace xyoa.SchTable.Xueji.ZaijiSheng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZaijiSheng_dr : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlInputFile fileExcel;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.fileExcel.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.fileExcel.PostedFile.FileName));
                if ((extension != ".xls") && (extension != ".XLS"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传xls文件');</script>");
                }
                else
                {
                    str3 = "b1_" + this.Number.Text + "";
                    this.fileExcel.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string str6 = str + "b1_" + this.Number.Text + "" + extension + "";
                    string sql = "Select * INTO b1_" + this.Number.Text + " FROM  OpenDataSource( 'Microsoft.Jet.OLEDB.4.0','Data Source=" + str6 + ";User ID=Admin;Password=;Extended properties=Excel 5.0')...Sheet1$";
                    this.List.ExeSql(sql);
                    string str8 = "select * from b1_" + this.Number.Text + "";
                    SqlDataReader list = this.List.GetList(str8);
                    while (list.Read())
                    {
                        if (this.pulicss.GetFormatStr(list["学生姓名"].ToString()).Trim() != "")
                        {
                            string str9 = "否";
                            string str10 = "否";
                            string str11 = "否";
                            string str12 = "否";
                            string str13 = "否";
                            string str14 = "是";
                            string str15 = "否";
                            string str16 = "是";
                            string str17 = "男";
                            if (this.pulicss.GetFormatStr(list["留守儿童"].ToString()).Trim() != "")
                            {
                                str9 = list["留守儿童"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["农民工子女"].ToString()).Trim() != "")
                            {
                                str10 = list["农民工子女"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["军人子女"].ToString()).Trim() != "")
                            {
                                str11 = list["军人子女"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["教师子女"].ToString()).Trim() != "")
                            {
                                str12 = list["教师子女"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["单亲家庭"].ToString()).Trim() != "")
                            {
                                str13 = list["单亲家庭"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["独生子女"].ToString()).Trim() != "")
                            {
                                str14 = list["独生子女"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["贫困生"].ToString()).Trim() != "")
                            {
                                str15 = list["贫困生"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["是否住校"].ToString()).Trim() != "")
                            {
                                str16 = list["是否住校"].ToString();
                            }
                            if (this.pulicss.GetFormatStr(list["性别"].ToString()).Trim() != "")
                            {
                                str17 = list["性别"].ToString();
                            }
                            string str18 = string.Concat(new object[] { 
                                "insert into qp_sch_Xuesheng   (Zhuxiao,Sushe,Xueqi,Xueduan,BanJi,Xuejihao,Xuehao,Kaohao,Xingming,Xingbie,Chusheng,Mingzhu,Jiguan,Chushengdi,RuxiaoShijian,RuxiaoChengji,Zhaopian,Zhengzhimianmhao,Laiyuanxiao,XuejiZhuangtai,Zhiwu,Shengfenzheng,Jiangkan,Shengyuan,Dianhua,Dizhi,Youbian,Tongxin,Youxiang,HukouLeixing,HukouXingzhi,Sancan,LiushouErtong,Nongminggao,Junrenzinv,Jiaoshizinv,Danqinjiating,Dushengzinv,Pingkunsheng,Username,Realname,Nowtimes) values ('", str16, "','0','", this.divsch.GetXueqi(), "','", this.divsch.GetXueduan(), "','", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", this.pulicss.GetFormatStr(list["学籍号"].ToString()), "','", this.pulicss.GetFormatStr(list["学号"].ToString()), "','", this.pulicss.GetFormatStr(list["考号"].ToString()), "','", this.pulicss.GetFormatStr(list["学生姓名"].ToString()), 
                                "','", str17, "','", this.pulicss.GetFormatStr(list["出生日期"].ToString()), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["民族"].ToString())), "','", this.pulicss.GetFormatStr(list["籍贯"].ToString()), "','", this.pulicss.GetFormatStr(list["出生地"].ToString()), "','", this.pulicss.GetFormatStr(list["入校时间"].ToString()), "','", this.pulicss.GetFormatStr(list["入学成绩"].ToString()), "','/SchTable/Xueji/file/0.jpg','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["政治面貌"].ToString())), 
                                "','", this.pulicss.GetFormatStr(list["来源校(园)"].ToString()), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", "在校"), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["职务"].ToString())), "','", this.pulicss.GetFormatStr(list["身份证号"].ToString()), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["健康状况"].ToString())), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["生源类别"].ToString())), "','", this.pulicss.GetFormatStr(list["联系电话"].ToString()), "','", this.pulicss.GetFormatStr(list["家庭住址"].ToString()), 
                                "','", this.pulicss.GetFormatStr(list["邮编"].ToString()), "','", this.pulicss.GetFormatStr(list["通信地址"].ToString()), "','", this.pulicss.GetFormatStr(list["电子邮箱"].ToString()), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["户口类型"].ToString())), "','", this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["户口性质"].ToString())), "','", this.pulicss.GetFormatStr(list["三残"].ToString()), "','", str9, "','", str10, 
                                "','", str11, "','", str12, "','", str13, "','", str14, "','", str15, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                                "')"
                             });
                            this.List.ExeSql(str18);
                            string str19 = "select top 1 id  from qp_sch_Xuesheng  where Xingming='" + this.pulicss.GetFormatStr(list["学生姓名"].ToString()) + "' order by id desc ";
                            SqlDataReader reader2 = this.List.GetList(str19);
                            if (reader2.Read())
                            {
                                string str20 = "insert into [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.divsch.GetXueqi() + "','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + reader2["id"].ToString() + "','" + this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", this.pulicss.GetFormatStr(list["职务"].ToString())) + "','" + this.divsch.TypeCodeDr("Name", "qp_sch_DataFile", "在校") + "')";
                                this.List.ExeSql(str20);
                            }
                            reader2.Close();
                        }
                    }
                    list.Close();
                    string str21 = "drop table b1_" + this.Number.Text + "";
                    this.List.ExeSql(str21);
                    File.Delete(base.Server.MapPath("//file//b1_" + this.Number.Text + "" + extension + ""));
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ZaijiSheng_dr.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('导入文件不能为空！');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                        Random random = new Random();
                        string str = random.Next(0x2710).ToString();
                        this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + str + "";
                        this.Label2.Text = this.Label2.Text + "" + this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", base.Request.QueryString["id"].ToString()) + "";
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
                this.BindAttribute();
            }
        }
    }
}

