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

    public class ZaijiSheng_lb_update : Page
    {
        protected Label BanJi;
        protected Button Button1;
        protected Button Button2;
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
        protected TextBox Laiyuanxiao;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected RadioButtonList LiushouErtong;
        protected DropDownList Mingzhu;
        protected TextBox NianjiName;
        protected RadioButtonList Nongminggao;
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
        protected Label XuejiZhuangtai;
        protected TextBox Youbian;
        protected TextBox Youxiang;
        protected Image Zhaopian;
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
                    "Update qp_sch_Xuesheng     Set Zhuxiao='", this.Zhuxiao.SelectedValue, "',Xuejihao='", this.pulicss.GetFormatStr(this.Xuejihao.Text), "',Xuehao='", this.pulicss.GetFormatStr(this.Xuehao.Text), "',Kaohao='", this.pulicss.GetFormatStr(this.Kaohao.Text), "',Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Xingbie='", this.Xingbie.SelectedValue, "',Chusheng='", this.pulicss.GetFormatStr(this.Chusheng.Text), "',Mingzhu='", this.Mingzhu.SelectedValue, 
                    "',Jiguan='", this.pulicss.GetFormatStr(this.Jiguan.Text), "',Chushengdi='", this.pulicss.GetFormatStr(this.Chushengdi.Text), "',RuxiaoShijian='", this.pulicss.GetFormatStr(this.RuxiaoShijian.Text), "',RuxiaoChengji='", this.pulicss.GetFormatStr(this.RuxiaoChengji.Text), "',Zhaopian='/SchTable/Xueji/file/", str3, "',Zhengzhimianmhao='", this.Zhengzhimianmhao.SelectedValue, "',Laiyuanxiao='", this.pulicss.GetFormatStr(this.Laiyuanxiao.Text), "',Zhiwu='", this.Zhiwu.SelectedValue, 
                    "',Shengfenzheng='", this.pulicss.GetFormatStr(this.Shengfenzheng.Text), "',Jiangkan='", this.Jiangkan.SelectedValue, "',Shengyuan='", selectedValue, "',Dianhua='", this.pulicss.GetFormatStr(this.Dianhua.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Youbian='", this.pulicss.GetFormatStr(this.Youbian.Text), "',Tongxin='", this.pulicss.GetFormatStr(this.Tongxin.Text), "',Youxiang='", this.pulicss.GetFormatStr(this.Youxiang.Text), 
                    "',HukouLeixing='", this.HukouLeixing.SelectedValue, "',HukouXingzhi='", this.HukouXingzhi.SelectedValue, "',Sancan='", this.pulicss.GetChecked(this.Sancan), "',LiushouErtong='", this.pulicss.GetFormatStr(this.LiushouErtong.SelectedValue), "',Nongminggao='", this.pulicss.GetFormatStr(this.Nongminggao.SelectedValue), "',Junrenzinv='", this.pulicss.GetFormatStr(this.Junrenzinv.SelectedValue), "',Jiaoshizinv='", this.pulicss.GetFormatStr(this.Jiaoshizinv.SelectedValue), "',Danqinjiating='", this.pulicss.GetFormatStr(this.Danqinjiating.SelectedValue), 
                    "',Dushengzinv='", this.pulicss.GetFormatStr(this.Dushengzinv.SelectedValue), "',Pingkunsheng='", this.pulicss.GetFormatStr(this.Pingkunsheng.SelectedValue), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { 
                    "Update qp_sch_Xuesheng     Set Zhuxiao='", this.Zhuxiao.SelectedValue, "',Xuejihao='", this.pulicss.GetFormatStr(this.Xuejihao.Text), "',Xuehao='", this.pulicss.GetFormatStr(this.Xuehao.Text), "',Kaohao='", this.pulicss.GetFormatStr(this.Kaohao.Text), "',Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Xingbie='", this.Xingbie.SelectedValue, "',Chusheng='", this.pulicss.GetFormatStr(this.Chusheng.Text), "',Mingzhu='", this.Mingzhu.SelectedValue, 
                    "',Jiguan='", this.pulicss.GetFormatStr(this.Jiguan.Text), "',Chushengdi='", this.pulicss.GetFormatStr(this.Chushengdi.Text), "',RuxiaoShijian='", this.pulicss.GetFormatStr(this.RuxiaoShijian.Text), "',RuxiaoChengji='", this.pulicss.GetFormatStr(this.RuxiaoChengji.Text), "',Zhaopian='/SchTable/Xueji/file/0.jpg',Zhengzhimianmhao='", this.Zhengzhimianmhao.SelectedValue, "',Laiyuanxiao='", this.pulicss.GetFormatStr(this.Laiyuanxiao.Text), "',Zhiwu='", this.Zhiwu.SelectedValue, "',Shengfenzheng='", this.pulicss.GetFormatStr(this.Shengfenzheng.Text), 
                    "',Jiangkan='", this.Jiangkan.SelectedValue, "',Shengyuan='", selectedValue, "',Dianhua='", this.pulicss.GetFormatStr(this.Dianhua.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Youbian='", this.pulicss.GetFormatStr(this.Youbian.Text), "',Tongxin='", this.pulicss.GetFormatStr(this.Tongxin.Text), "',Youxiang='", this.pulicss.GetFormatStr(this.Youxiang.Text), "',HukouLeixing='", this.HukouLeixing.SelectedValue, 
                    "',HukouXingzhi='", this.HukouXingzhi.SelectedValue, "',Sancan='", this.pulicss.GetChecked(this.Sancan), "',LiushouErtong='", this.pulicss.GetFormatStr(this.LiushouErtong.SelectedValue), "',Nongminggao='", this.pulicss.GetFormatStr(this.Nongminggao.SelectedValue), "',Junrenzinv='", this.pulicss.GetFormatStr(this.Junrenzinv.SelectedValue), "',Jiaoshizinv='", this.pulicss.GetFormatStr(this.Jiaoshizinv.SelectedValue), "',Danqinjiating='", this.pulicss.GetFormatStr(this.Danqinjiating.SelectedValue), "',Dushengzinv='", this.pulicss.GetFormatStr(this.Dushengzinv.SelectedValue), 
                    "',Pingkunsheng='", this.pulicss.GetFormatStr(this.Pingkunsheng.SelectedValue), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str9);
            }
            string sql = string.Concat(new object[] { "Update [stu_table_", this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]), "_", this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]), "]    Set Zhiwu='", this.Zhiwu.SelectedValue, "' where   XsId='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改学生[" + this.Xingming.Text + "]", "在籍生");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ZaijiSheng_lb.aspx?id=" + this.ViewState["UrlBanji"] + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ZaijiSheng_lb.aspx?id=" + this.ViewState["UrlBanji"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_sch_DataFile where type='17' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mingzhu, sQL, "id", "name");
                string str2 = "select id,name  from qp_sch_DataFile where type='18' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhengzhimianmhao, str2, "id", "name");
                string str3 = "select id,name  from qp_sch_DataFile where type='1' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwu, str3, "id", "name");
                string str4 = "select id,name  from qp_sch_DataFile where type='14' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jiangkan, str4, "id", "name");
                string str5 = "select id,name  from qp_sch_DataFile where type='6' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan1, str5, "id", "name");
                string str6 = "select id,name  from qp_sch_DataFile where type='7' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan2, str6, "id", "name");
                string str7 = "select id,name  from qp_sch_DataFile where type='8' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan3, str7, "id", "name");
                string str8 = "select id,name  from qp_sch_DataFile where type='15' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.HukouLeixing, str8, "id", "name");
                string str9 = "select id,name  from qp_sch_DataFile where type='16' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.HukouXingzhi, str9, "id", "name");
                string sql = "select * from qp_sch_Xuesheng where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuxiao.SelectedValue = list["Zhuxiao"].ToString();
                    this.Xuejihao.Text = list["Xuejihao"].ToString();
                    this.Xuehao.Text = list["Xuehao"].ToString();
                    this.Kaohao.Text = list["Kaohao"].ToString();
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Xingbie.SelectedValue = list["Xingbie"].ToString();
                    this.Chusheng.Text = list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Mingzhu.SelectedValue = list["Mingzhu"].ToString();
                    this.Jiguan.Text = list["Jiguan"].ToString();
                    this.Chushengdi.Text = list["Chushengdi"].ToString();
                    this.RuxiaoShijian.Text = list["RuxiaoShijian"].ToString();
                    this.RuxiaoChengji.Text = list["RuxiaoChengji"].ToString();
                    this.Zhaopian.ImageUrl = "" + list["Zhaopian"].ToString() + "";
                    this.Zhengzhimianmhao.SelectedValue = list["Zhengzhimianmhao"].ToString();
                    this.Laiyuanxiao.Text = list["Laiyuanxiao"].ToString();
                    this.Zhiwu.SelectedValue = list["Zhiwu"].ToString();
                    this.Shengfenzheng.Text = list["Shengfenzheng"].ToString();
                    this.Jiangkan.SelectedValue = list["Jiangkan"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Tongxin.Text = list["Tongxin"].ToString();
                    this.Youxiang.Text = list["Youxiang"].ToString();
                    this.HukouLeixing.SelectedValue = list["HukouLeixing"].ToString();
                    this.HukouXingzhi.SelectedValue = list["HukouXingzhi"].ToString();
                    this.pulicss.SetChecked(this.Sancan, list["Sancan"].ToString());
                    this.LiushouErtong.SelectedValue = list["LiushouErtong"].ToString();
                    this.Nongminggao.SelectedValue = list["Nongminggao"].ToString();
                    this.Junrenzinv.SelectedValue = list["Junrenzinv"].ToString();
                    this.Jiaoshizinv.SelectedValue = list["Jiaoshizinv"].ToString();
                    this.Danqinjiating.SelectedValue = list["Danqinjiating"].ToString();
                    this.Dushengzinv.SelectedValue = list["Dushengzinv"].ToString();
                    this.Pingkunsheng.SelectedValue = list["Pingkunsheng"].ToString();
                    string str11 = "select * from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]) + "] where  XsId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str11);
                    if (reader2.Read())
                    {
                        this.ViewState["UrlBanji"] = reader2["Banji"].ToString();
                        this.BanJi.Text = this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", reader2["Banji"].ToString());
                        this.XuejiZhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", reader2["XuejiZhuangtai"].ToString());
                        this.Zhiwu.SelectedValue = reader2["Zhiwu"].ToString();
                        string str12 = "select Mingcheng,Nianji from qp_sch_Banji  where id='" + reader2["Banji"].ToString() + "'  ";
                        SqlDataReader reader3 = this.List.GetList(str12);
                        if (reader3.Read())
                        {
                            string str13 = reader3["Nianji"].ToString();
                            if (str13.IndexOf("小") >= 0)
                            {
                                this.Shengyuan1.SelectedValue = list["Shengyuan"].ToString();
                                this.Shengyuan1.Enabled = true;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "小学";
                            }
                            if (str13.IndexOf("初") >= 0)
                            {
                                this.Shengyuan2.SelectedValue = list["Shengyuan"].ToString();
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = true;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "初中";
                            }
                            if (str13.IndexOf("高") >= 0)
                            {
                                this.Shengyuan3.SelectedValue = list["Shengyuan"].ToString();
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = true;
                                this.NianjiName.Text = "高中";
                            }
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

