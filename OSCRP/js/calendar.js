var startDate;
var startTime;
var okFunction;
var displayCalendar;
var displayTime;
var ServerDate;

function showCalendar(startDate,startTime,okFunction,displayCalendar,displayTime, DateStringFormat)
{
  window.startDate = startDate;
  window.startTime = startTime;
  window.okFunction = okFunction;
  window.displayCalendar = displayCalendar;
  window.displayTime = displayTime;
     
  
  var height="";  
 
//  if (DateStringFormat == "dd/mm/yyyy hh:nn")      
  if (DateStringFormat == "dd-mon-yyyy hh:nn")      
    var urlString = PickerPath+"datetimepickerDay.html?v=1.1";
  else	
    var urlString = PickerPath+"datetimepickerMonth.html?v=1.1";
  	
  if (displayCalendar && displayTime) height="260";
  if (displayCalendar && !displayTime) height="220";
  if (!displayCalendar && displayTime) height="80";
  window.showModalDialog(urlString,window,"dialogHeight:"+height+"px;dialogWidth:210px;dialogTop:250px;dialogLeft:250px;status:0;help:0");
}

function datePicker(editDate){
	showCalendar(editDate.value,'',function(strDate,strTime){editDate.value = strDate},true,false)
}

function datetimePicker(editDate,editTime){

 if (editTime==null) {
   var tokens = editDate.value.split(" ");
   var iniDate='';
   var iniTime=''; 
   if (tokens.length>=1) iniDate = tokens[0];
   if (tokens.length==2) iniTime = tokens[1];
   showCalendar(iniDate,iniTime,function(strDate,strTime){editDate.value = strDate+ ' '+strTime},true,true)
 }
 if (editTime!=null) {
   showCalendar(editDate.value,editTime.value,function(strDate,strTime){editDate.value = strDate; editTime.value=strTime},true,true)
 }   
}

function timePicker(editTime)
{
	showCalendar('',editTime.value,function(strDate,strTime){editTime.value = strTime},false,true)
}

function getDateTime(pDateTimeField,withDate,withTime,DateStringFormat,ServerDate)
{  

  this.ServerDate=ServerDate;
  var returnDateTimeField=null;
  var iniDate='';
  var iniTime=''; 

  function setDateTime(date,time)
  {  	
    var beforeDateValue = returnDateTimeField.value;
    if (time!="") returnDateTimeField.value = date+" "+time;
    else {
	    returnDateTimeField.value = date;
    }
    /*if (beforeDateValue != returnDateTimeField.value)
      pDateTimeField.OnBeforeUpdateMethod();*/
  }
  returnDateTimeField = pDateTimeField;
 
  //if ((!pDateTimeField.readOnly) && (!pDateTimeField.disabled))
  if ((!pDateTimeField.disabled))
  {
    var tokens = pDateTimeField.value.split(" ");
    if (tokens.length>=1) iniDate = tokens[0];
    if (tokens.length==2) iniTime = tokens[1];  
    
    
    var datToken = pDateTimeField.value.split("-");
    var startMonth=null;
    if (datToken.length==3)
    {
		if ((datToken[1]=="Jan") || (datToken[1]=="JAN") || (datToken[1]=="jan"))
		startMonth=1;
		else if ((datToken[1]=="Feb") || (datToken[1]=="FEB") || (datToken[1]=="feb"))	
		startMonth=2;
		else if ((datToken[1]=="Mar") || (datToken[1]=="MAR") || (datToken[1]=="mar"))	
		startMonth=3;
		else if ((datToken[1]=="Apr") || (datToken[1]=="APR") || (datToken[1]=="apr"))	
		startMonth=4;
		else if ((datToken[1]=="May") || (datToken[1]=="MAY") || (datToken[1]=="may"))	
		startMonth=5;
		else if ((datToken[1]=="Jun") || (datToken[1]=="JUN") || (datToken[1]=="jun"))	
		startMonth=6;
		else if ((datToken[1]=="Jul") || (datToken[1]=="JUL") || (datToken[1]=="jul"))	
		startMonth=7;
		else if ((datToken[1]=="Aug") || (datToken[1]=="AUG") || (datToken[1]=="aug"))	
		startMonth=8;
		else if ((datToken[1]=="Sep") || (datToken[1]=="SEP") || (datToken[1]=="sep"))	
		startMonth=9;
		else if ((datToken[1]=="Oct") || (datToken[1]=="OCT") || (datToken[1]=="oct"))	
		startMonth=10;
		else if ((datToken[1]=="Nov") || (datToken[1]=="NOV") || (datToken[1]=="nov"))	
		startMonth=11;
		else if ((datToken[1]=="Dec") || (datToken[1]=="DEC") || (datToken[1]=="dec"))	
		startMonth=12;
		
		iniDate=startMonth+'/'+datToken[0]+'/'+datToken[2];
    }
    showCalendar(iniDate,iniTime,setDateTime,withDate,withTime, DateStringFormat);
    pDateTimeField.focus();
    
  }
}