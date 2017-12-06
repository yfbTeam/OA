function my_affair(AFF_ID)
{
  myleft=(screen.availWidth-250)/2;
  mytop=(screen.availHeight-200)/2;
  window.open("../affair/note.php?AFF_ID="+AFF_ID,"note_win"+AFF_ID,"height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
}

function my_note(CAL_ID)
{
  myleft=(screen.availWidth-250)/2;
  mytop=(screen.availHeight-200)/2;
  window.open("note.php?CAL_ID="+CAL_ID,"note_win"+CAL_ID,"height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
}

function show_work_stat_detail(TYPE_ID,USER_ID,DATE_BEGIN,DATE_END)
{
  myleft=(screen.availWidth-550)/2;
  mytop=(screen.availHeight-500)/2;

  if(TYPE_ID=="diary")
    window.open("../diary/info/user_search_stat.php?FROMTYPE=WORK_STAT&TO_ID1="+USER_ID+"&BEGIN_DATE="+DATE_BEGIN+"&END_DATE="+DATE_END,"","height=500,width=650,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
  else if(TYPE_ID.substr(0,8)=="workflow")
  {
    myleft=(screen.availWidth-750)/2;
    mytop=(screen.availHeight-600)/2;
  	
  	var LIST_TYPE="";//工作流列表类型（MAIN_FINISH-主办（完成）；MAIN_ALL－主办（所有）；SIGN_FINISH－会签（完成）；SIGN_ALL－会签（所有））
  	if(TYPE_ID.substr(9)=="op")//工作流主办（完成）
  	  LIST_TYPE="MAIN_FINISH";
  	else if(TYPE_ID.substr(9)=="op1")//工作流主办（所有）
  	  LIST_TYPE="MAIN_ALL";
  	else if(TYPE_ID.substr(9)=="sign")//工作流会签（完成）
  	  LIST_TYPE="SIGN_FINISH";
  	else if(TYPE_ID.substr(9)=="sign1")//工作流会签（所有）
  	  LIST_TYPE="SIGN_ALL";

    var openUrl = "workflow_detail.php?LIST_TYPE=" + LIST_TYPE + "&USER_ID_STAT="+USER_ID+"&BEGIN_DATE_STAT="+DATE_BEGIN+"&END_DATE_STAT="+DATE_END;
    window.open(openUrl, "", "height=500,width=750,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
  }
  else
  	window.open(TYPE_ID+".php?USER_ID="+USER_ID+"&DATE_BEGIN="+DATE_BEGIN+"&DATE_END="+DATE_END,"","height=500,width=550,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
}

function my_aff_note(AFF_ID)
{
  myleft=(screen.availWidth-250)/2;
  mytop=(screen.availHeight-200)/2;
  window.open("aff_note.php?AFF_ID="+AFF_ID,"note_win"+AFF_ID,"height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
}

function my_task_note(TASK_ID)
{
  myleft=(screen.availWidth-250)/2;
  mytop=(screen.availHeight-200)/2;
  window.open("../task/note.php?TASK_ID="+TASK_ID,"note_win"+TASK_ID,"height=200,width=250,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,top="+mytop+",left="+myleft);
}

function My_Submit()
{
  document.form1.submit();
}

function set_year(op)
{
  document.form1.BTN_OP.value=op+" year";
  My_Submit();
}

function set_mon(op)
{
  document.form1.BTN_OP.value=op+" month";
  My_Submit();
}

function set_week(op)
{
  document.form1.BTN_OP.value=op+" week";
  My_Submit();
}

function set_day(op)
{
  document.form1.BTN_OP.value=op+" day";
  My_Submit();
}

function set_status(status)
{
  document.form1.OVER_STATUS.value=status;
  My_Submit();
}

function set_option(option, id, className)
{
  hideMenu();
  option = typeof(option)=="undefined" ? "" : option;
  $(id.toUpperCase()+"_FIELD").value=option;
  
  $(id).innerHTML=$(id+'_'+option).innerHTML + $(id).innerHTML.substr($(id).innerHTML.indexOf("<"));
  $(id).className=className+option;
}

function display_front()
{
   var front=document.getElementById("front");
   if(!front)
      return;
   if(front.style.display=='')
      front.style.display='none';
   else
      front.style.display='';
}

function set_view(view, cname)
{
    if(cname=="" || typeof(cname)=='undefined') cname="cal_view";
    var exp = new Date();
    exp.setTime(exp.getTime() + 24*60*60*1000);
    document.cookie = cname+"="+ escape (view) + ";expires=" + exp.toGMTString()+";path=/";
    
    var url=view+'.php?OVER_STATUS='+document.form1.OVER_STATUS.value+'&YEAR='+document.form1.YEAR.value+'&MONTH='+document.form1.MONTH.value+'&DAY='+document.form1.DAY.value;
    if(document.form1.DEPT_ID) url+='&DEPT_ID='+document.form1.DEPT_ID.value;
    if(document.form1.USER_ID) url+='&USER_ID='+document.form1.USER_ID.value;
    location=url;
}

function new_cal(CAL_TIME, TIME_DIFF)
{
   window.open('new?CAL_TIME='+CAL_TIME+"&TIME_DIFF="+TIME_DIFF,'oa_sub_window','height=350,width=500,status=0,toolbar=no,menubar=no,location=no,left=300,top=200,scrollbars=yes,resizable=yes');
}

function new_diary(CAL_DATE)
{
   if(!CAL_DATE)
      CAL_DATE=document.form1.YEAR.value+document.form1.MONTH.value+document.form1.DAY.value;
   window.open('../../diary/new/?CAL_DATE='+CAL_DATE,'diary_sub_window','height=560,width=650,status=0,toolbar=no,menubar=no,location=no,left=180,top=50,scrollbars=yes,resizable=yes');
}

function del_cal(CAL_ID)
{
   var url='delete.php?CAL_ID='+CAL_ID+'&OVER_STATUS='+document.form1.OVER_STATUS.value+'&YEAR='+document.form1.YEAR.value+'&MONTH='+document.form1.MONTH.value+'&DAY='+document.form1.DAY.value;
   if(document.form1.DEPT_ID) url+='&DEPT_ID='+document.form1.DEPT_ID.value;
   if(document.form1.USER_ID) url+='&USER_ID='+document.form1.USER_ID.value;
   if(window.confirm("删除后将不可恢复，确定删除吗？"))
      location=url;
}

function del_aff(AFF_ID)
{
   var url='delete.php?AFF_ID='+AFF_ID+'&OVER_STATUS='+document.form1.OVER_STATUS.value+'&YEAR='+document.form1.YEAR.value+'&MONTH='+document.form1.MONTH.value+'&DAY='+document.form1.DAY.value;
   if(document.form1.DEPT_ID) url+='&DEPT_ID='+document.form1.DEPT_ID.value;
   if(document.form1.USER_ID) url+='&USER_ID='+document.form1.USER_ID.value;
   if(window.confirm("删除后将不可恢复，确定删除吗？"))
      location=url;
}

function del_task(TASK_ID)
{
   var url='../task/delete.php?TASK_ID='+TASK_ID+'&FLAG=info&OVER_STATUS='+document.form1.OVER_STATUS.value+'&YEAR='+document.form1.YEAR.value+'&MONTH='+document.form1.MONTH.value+'&DAY='+document.form1.DAY.value;
   if(document.form1.DEPT_ID) url+='&DEPT_ID='+document.form1.DEPT_ID.value;
   if(document.form1.USER_ID) url+='&USER_ID='+document.form1.USER_ID.value;
   if(window.confirm("删除后将不可恢复，确定删除吗？"))
      location=url;
}

function new_arrange(USER_ID, CAL_TIME, TIME_DIFF)
{
   //window.open('new_affair.php?USER_ID='+USER_ID+'&CAL_TIME='+CAL_TIME+'&TIME_DIFF='+TIME_DIFF,'oa_sub_window','height=350,width=500,status=0,toolbar=no,menubar=no,location=no,left=300,top=200,scrollbars=yes,resizable=yes');
   window.open('index_new.php?USER_ID='+USER_ID+'&CAL_TIME='+CAL_TIME+'&TIME_DIFF='+TIME_DIFF,'oa_sub_window','height=420,width=520,status=0,toolbar=no,menubar=no,location=no,left=300,top=200,scrollbars=yes,resizable=yes');
}
