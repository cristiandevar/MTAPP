gx.evt.autoSkip=!1;gx.define("employee",!1,function(){this.ServerClass="employee";this.PackageName="GeneXus.Programs";this.ServerFullClass="employee.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV7EmployeeId=gx.fn.getIntegerValue("vEMPLOYEEID",",");this.Gx_date=gx.fn.getDateValue("vTODAY");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.AV13Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Employeeid=function(){return this.validCliEvt("Valid_Employeeid",0,function(){try{var n=gx.util.balloon.getNew("EMPLOYEEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12042_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13044_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14044_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15044_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16044_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17044_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18044_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19044_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Employeeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEEID",fmt:0,gxz:"Z12EmployeeId",gxold:"O12EmployeeId",gxvar:"A12EmployeeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12EmployeeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12EmployeeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("EMPLOYEEID",gx.O.A12EmployeeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12EmployeeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("EMPLOYEEID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEEFIRSTNAME",fmt:0,gxz:"Z13EmployeeFirstName",gxold:"O13EmployeeFirstName",gxvar:"A13EmployeeFirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13EmployeeFirstName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13EmployeeFirstName=n)},v2c:function(){gx.fn.setControlValue("EMPLOYEEFIRSTNAME",gx.O.A13EmployeeFirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13EmployeeFirstName=this.val())},val:function(){return gx.fn.getControlValue("EMPLOYEEFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEELASTNAME",fmt:0,gxz:"Z14EmployeeLastName",gxold:"O14EmployeeLastName",gxvar:"A14EmployeeLastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14EmployeeLastName=n)},v2z:function(n){n!==undefined&&(gx.O.Z14EmployeeLastName=n)},v2c:function(){gx.fn.setControlValue("EMPLOYEELASTNAME",gx.O.A14EmployeeLastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A14EmployeeLastName=this.val())},val:function(){return gx.fn.getControlValue("EMPLOYEELASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEECREATEDDATE",fmt:0,gxz:"Z36EmployeeCreatedDate",gxold:"O36EmployeeCreatedDate",gxvar:"A36EmployeeCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A36EmployeeCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z36EmployeeCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("EMPLOYEECREATEDDATE",gx.O.A36EmployeeCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A36EmployeeCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("EMPLOYEECREATEDDATE")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEEMODIFIEDDATE",fmt:0,gxz:"Z37EmployeeModifiedDate",gxold:"O37EmployeeModifiedDate",gxvar:"A37EmployeeModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A37EmployeeModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z37EmployeeModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("EMPLOYEEMODIFIEDDATE",gx.O.A37EmployeeModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A37EmployeeModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("EMPLOYEEMODIFIEDDATE")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"BTN_ENTER",grid:0,evt:"e13044_client",std:"ENTER"};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTN_CANCEL",grid:0,evt:"e14044_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTN_DELETE",grid:0,evt:"e20044_client",std:"DELETE"};this.A12EmployeeId=0;this.Z12EmployeeId=0;this.O12EmployeeId=0;this.A13EmployeeFirstName="";this.Z13EmployeeFirstName="";this.O13EmployeeFirstName="";this.A14EmployeeLastName="";this.Z14EmployeeLastName="";this.O14EmployeeLastName="";this.A36EmployeeCreatedDate=gx.date.nullDate();this.Z36EmployeeCreatedDate=gx.date.nullDate();this.O36EmployeeCreatedDate=gx.date.nullDate();this.A37EmployeeModifiedDate=gx.date.nullDate();this.Z37EmployeeModifiedDate=gx.date.nullDate();this.O37EmployeeModifiedDate=gx.date.nullDate();this.AV13Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7EmployeeId=0;this.AV10WebSession={};this.A12EmployeeId=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A13EmployeeFirstName="";this.A14EmployeeLastName="";this.A36EmployeeCreatedDate=gx.date.nullDate();this.A37EmployeeModifiedDate=gx.date.nullDate();this.Gx_mode="";this.Events={e12042_client:["AFTER TRN",!0],e13044_client:["ENTER",!0],e14044_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9",hsh:!0},{av:"A12EmployeeId",fld:"EMPLOYEEID",pic:"ZZZZZ9"},{av:"A36EmployeeCreatedDate",fld:"EMPLOYEECREATEDDATE",pic:""},{av:"A37EmployeeModifiedDate",fld:"EMPLOYEEMODIFIEDDATE",pic:""}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_EMPLOYEEID=[[],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7EmployeeId","vEMPLOYEEID",0,"int",6,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV13Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.employee)})