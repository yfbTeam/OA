var preId;
function showOperatorWin(divPrefix,divId,toLeft) {
      
      hideOperatorWin2(divPrefix);
      if (preId != null && preId == divId) {
        preId = "";
      	return;
      }
	  var x=event.x+document.body.scrollLeft; 
	  var y=event.y+document.body.scrollTop; 
	  var divobj = null;

	  divobj = document.getElementById(divPrefix + divId);	
      if(divobj!=null){
  		  divobj.style.pixelLeft = x - toLeft;
		  divobj.style.pixelTop = y;
		  divobj.style.display = "block";
		  preId = divId;
	  }    

}

function hideOperatorWin(divPrefix) {
    hideOperatorWin2(divPrefix);
    preId = "";
}

function hideOperatorWin2(divPrefix) {
    if (preId != null) {
		var divobj = document.getElementById(divPrefix + preId);
		if(divobj!=null){
			divobj.style.display = "none";
		}    	
    }
}