// JavaScript Document

var _G = function(id){
	return document.getElementById(id);	
}

var _F = function(element_id)
{
	return document.getElementById(element_id).value;
}

var Ajax = {
	Request : function(url,o){
		return $.ajax({
			url : url,
			data : o.parameters,
			cache : false,
			type : o.method,
			success : function(text){ o.onComplete({responseText:text});}
		});	
	}	
}

String.prototype.trim = function(){
	return $.trim(this)	
}

String.prototype.stripTags = function(){
	var div = document.createElement("DIV");
	div.innerHTML=this;
	var text = $(div).text();
	$(div).remove();
	return 	text;
}

document.getElementsByClassName = function(className)
{
	var elements = new Array();
	$("."+className).each(function(){
		elements.push(this);							   
	});
	return elements;
}

Array.prototype.indexOf = function(value){
	return $.inArray(value,this);	
}