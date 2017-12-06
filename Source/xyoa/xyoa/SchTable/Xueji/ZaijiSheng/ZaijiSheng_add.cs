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

    public class ZaijiSheng_add : Page
    {
        protected Label BanJi;
        protected Button Button1;
        protected TextBox Chusheng;
        protected TextBox Chushengdi;
        protected RadioButtonList Danqinjiating;
        protected TextBox Dianhua;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Dizhi;
        protected RadioButtonList Dushengzinv;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList HukouLeixing;
        protected DropDownList HukouXingzhi;
        protected DropDownList Jiangkan;
        protected RadioButtonList Jiaoshizinv;
        protected TextBox Jiguan;
        protected RadioButtonList Junrenzinv;
        protected TextBox Kaohao;
        protected Label Label1;
        protected TextBox Laiyuanxiao;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected RadioButtonList LiushouErtong;
        protected DropDownList Mingzhu;
        protected TextBox NianjiName;
        protected RadioButtonList Nongminggao;
        protected Panel Panel1;
        protected Panel Panel2;
        protected RadioButtonList Pingkunsheng;
        private publics pulicss = new publics();
        protected TextBox RuxiaoChengji;
        protected TextBox RuxiaoShijian;
        protected CheckBoxList Sancan;
        protected TextBox Shengfenzheng;
        protected DropDownList Shengyuan1;
        protected DropDownList Shengyuan2;
        protected DropDownList Shengyuan3;
        protected TextBox Tongxin;
        protected HtmlInputFile uploadFile;
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected TextBox Xuehao;
        protected TextBox Xuejihao;
        protected DropDownList XuejiZhuangtai;
        protected TextBox Youbian;
        protected TextBox Youxiang;
        protected DropDownList Zhengzhimianmhao;
        protected DropDownList Zhiwu;
        protected RadioButtonList Zhuxiao;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str9;
            string selectedValue = "";
            if (this.NianjiName.Text == "小学")
            {
                selectedValue = this.Shengyuan1.SelectedValue;
            }
            if (this.NianjiName.Text == "初中")
            {
                selectedValue = this.Shengyuan2.SelectedValue;
            }
            if (this.NianjiName.Text == "高中")
            {
                selectedValue = this.Shengyuan3.SelectedValue;
            }
            string str2 = base.Server.MapPath("/SchTable/Xueji/file/");
            string str3 = string.Empty;
            string str4 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str8 = random.Next(0x2710).ToString();
                str4 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                this.uploadFile.PostedFile.SaveAs(str2 + str4 + extension);
                str3 = str4 + extension;
                str9 = string.Concat(new object[] { 
                    "insert into qp_sch_Xuesheng   (Zhuxiao,Sushe,Xueqi,Xueduan,BanJi,Xuejihao,Xuehao,Kaohao,Xingming,Xingbie,Chusheng,Mingzhu,Jiguan,Chushengdi,RuxiaoShijian,RuxiaoChengji,Zhaopian,Zhengzhimianmhao,Laiyuanxiao,XuejiZhuangtai,Zhiwu,Shengfenzheng,Jiangkan,Shengyuan,Dianhua,Dizhi,Youbian,Tongxin,Youxiang,HukouLeixing,HukouXingzhi,Sancan,LiushouErtong,Nongminggao,Junrenzinv,Jiaoshizinv,Danqinjiating,Dushengzinv,Pingkunsheng,Username,Realname,Nowtimes) values ('", this.Zhuxiao.SelectedValue, "','0','", this.divsch.GetXueqi(), "','", this.divsch.GetXueduan(), "','", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", this.pulicss.GetFormatStr(this.Xuejihao.Text), "','", this.pulicss.GetFormatStr(this.Xuehao.Text), "','", this.pulicss.GetFormatStr(this.Kaohao.Text), "','", this.pulicss.GetFormatStr(this.Xingming.Text), 
                    "','", this.Xingbie.SelectedValue, "','", this.pulicss.GetFormatStr(this.Chusheng.Text), "','", this.Mingzhu.SelectedValue, "','", this.pulicss.GetFormatStr(this.Jiguan.Text), "','", this.pulicss.GetFormatStr(this.Chushengdi.Text), "','", this.pulicss.GetFormatStr(this.RuxiaoShijian.Text), "','", this.pulicss.GetFormatStr(this.RuxiaoChengji.Text), "','/SchTable/Xueji/file/", str3, 
                    "','", this.Zhengzhimianmhao.SelectedValue, "','", this.pulicss.GetFormatStr(this.Laiyuanxiao.Text), "','", this.pulicss.GetFormatStr(this.XuejiZhuangtai.SelectedValue), "','", this.pulicss.GetFormatStr(this.Zhiwu.SelectedValue), "','", this.pulicss.GetFormatStr(this.Shengfenzheng.Text), "','", this.pulicss.GetFormatStr(this.Jiangkan.SelectedValue), "','", selectedValue, "','", this.pulicss.GetFormatStr(this.Dianhua.Text), 
                    "','", this.pulicss.GetFormatStr(this.Dizhi.Text), "','", this.pulicss.GetFormatStr(this.Youbian.Text), "','", this.pulicss.GetFormatStr(this.Tongxin.Text), "','", this.pulicss.GetFormatStr(this.Youxiang.Text), "','", this.HukouLeixing.SelectedValue, "','", this.HukouXingzhi.SelectedValue, "','", this.pulicss.GetChecked(this.Sancan), "','", this.LiushouErtong.SelectedValue, 
                    "','", this.Nongminggao.SelectedValue, "','", this.Junrenzinv.SelectedValue, "','", this.Jiaoshizinv.SelectedValue, "','", this.Danqinjiating.SelectedValue, "','", this.Dushengzinv.SelectedValue, "','", this.Pingkunsheng.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { 
                    "insert into qp_sch_Xuesheng   (Zhuxiao,Sushe,Xueqi,Xueduan,BanJi,Xuejihao,Xuehao,Kaohao,Xingming,Xingbie,Chusheng,Mingzhu,Jiguan,Chushengdi,RuxiaoShijian,RuxiaoChengji,Zhaopian,Zhengzhimianmhao,Laiyuanxiao,XuejiZhuangtai,Zhiwu,Shengfenzheng,Jiangkan,Shengyuan,Dianhua,Dizhi,Youbian,Tongxin,Youxiang,HukouLeixing,HukouXingzhi,Sancan,LiushouErtong,Nongminggao,Junrenzinv,Jiaoshizinv,Danqinjiating,Dushengzinv,Pingkunsheng,Username,Realname,Nowtimes) values ('", this.Zhuxiao.SelectedValue, "','0','", this.divsch.GetXueqi(), "','", this.divsch.GetXueduan(), "','", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", this.pulicss.GetFormatStr(this.Xuejihao.Text), "','", this.pulicss.GetFormatStr(this.Xuehao.Text), "','", this.pulicss.GetFormatStr(this.Kaohao.Text), "','", this.pulicss.GetFormatStr(this.Xingming.Text), 
                    "','", this.Xingbie.SelectedValue, "','", this.pulicss.GetFormatStr(this.Chusheng.Text), "','", this.Mingzhu.SelectedValue, "','", this.pulicss.GetFormatStr(this.Jiguan.Text), "','", this.pulicss.GetFormatStr(this.Chushengdi.Text), "','", this.pulicss.GetFormatStr(this.RuxiaoShijian.Text), "','", this.pulicss.GetFormatStr(this.RuxiaoChengji.Text), "','/SchTable/Xueji/file/0.jpg','", this.Zhengzhimianmhao.SelectedValue, 
                    "','", this.pulicss.GetFormatStr(this.Laiyuanxiao.Text), "','", this.pulicss.GetFormatStr(this.XuejiZhuangtai.SelectedValue), "','", this.pulicss.GetFormatStr(this.Zhiwu.SelectedValue), "','", this.pulicss.GetFormatStr(this.Shengfenzheng.Text), "','", this.pulicss.GetFormatStr(this.Jiangkan.SelectedValue), "','", selectedValue, "','", this.pulicss.GetFormatStr(this.Dianhua.Text), "','", this.pulicss.GetFormatStr(this.Dizhi.Text), 
                    "','", this.pulicss.GetFormatStr(this.Youbian.Text), "','", this.pulicss.GetFormatStr(this.Tongxin.Text), "','", this.pulicss.GetFormatStr(this.Youxiang.Text), "','", this.HukouLeixing.SelectedValue, "','", this.HukouXingzhi.SelectedValue, "','", this.pulicss.GetChecked(this.Sancan), "','", this.LiushouErtong.SelectedValue, "','", this.Nongminggao.SelectedValue, 
                    "','", this.Junrenzinv.SelectedValue, "','", this.Jiaoshizinv.SelectedValue, "','", this.Danqinjiating.SelectedValue, "','", this.Dushengzinv.SelectedValue, "','", this.Pingkunsheng.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str9);
            }
            string sql = "select top 1 id  from qp_sch_Xuesheng  where Xingming='" + this.pulicss.GetFormatStr(this.Xingming.Text) + "' order by id desc ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str9 = "insert into [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.divsch.GetXueqi() + "','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + list["id"].ToString() + "','" + this.Zhiwu.SelectedValue + "','" + this.XuejiZhuangtai.SelectedValue + "')";
                this.List.ExeSql(str9);
            }
            list.Close();
            this.pulicss.InsertLog("新增学生[" + this.Xingming.Text + "]", "在籍生");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ZaijiSheng_add.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianVis(this.Button1, "pppp2aa", this.Session["perstr"].ToString());
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
                        string sql = "select Mingcheng,Nianji from qp_sch_Banji  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                        SqlDataReader list = this.List.GetList(sql);
                        if (list.Read())
                        {
                            string str2 = list["Nianji"].ToString();
                            if (str2.IndexOf("小") >= 0)
                            {
                                this.Shengyuan1.Enabled = true;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "小学";
                            }
                            if (str2.IndexOf("初") >= 0)
                            {
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = true;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "初中";
                            }
                            if (str2.IndexOf("高") >= 0)
                            {
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = true;
                                this.NianjiName.Text = "高中";
                            }
                        }
                        list.Close();
                        string sQL = "select id,name  from qp_sch_DataFile where type='17' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Mingzhu, sQL, "id", "name");
                        string str4 = "select id,name  from qp_sch_DataFile where type='18' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Zhengzhimianmhao, str4, "id", "name");
                        string str5 = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_nothing(this.XuejiZhuangtai, str5, "id", "name");
                        string str6 = "select id,name  from qp_sch_DataFile where type='1' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Zhiwu, str6, "id", "name");
                        string str7 = "select id,name  from qp_sch_DataFile where type='14' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Jiangkan, str7, "id", "name");
                        string str8 = "select id,name  from qp_sch_DataFile where type='6' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan1, str8, "id", "name");
                        string str9 = "select id,name  from qp_sch_DataFile where type='7' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan2, str9, "id", "name");
                        string str10 = "select id,name  from qp_sch_DataFile where type='8' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan3, str10, "id", "name");
                        string str11 = "select id,name  from qp_sch_DataFile where type='15' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.HukouLeixing, str11, "id", "name");
                        string str12 = "select id,name  from qp_sch_DataFile where type='16' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.HukouXingzhi, str12, "id", "name");
                        this.BanJi.Text = this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", base.Request.QueryString["id"].ToString());
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

