gx.evt.autoSkip=!1;gx.define("wplogin",!1,function(){var n,t;this.ServerClass="wplogin";this.PackageName="GeneXus.Programs";this.ServerFullClass="wplogin.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A101UserPassword=gx.fn.getControlValue("USERPASSWORD");this.A109UserHash=gx.fn.getControlValue("USERHASH");this.A100UserName=gx.fn.getControlValue("USERNAME");this.A111UserActive=gx.fn.getControlValue("USERACTIVE");this.A99UserId=gx.fn.getIntegerValue("USERID",",");this.AV8Context=gx.fn.getControlValue("vCONTEXT")};this.Validv_Username=function(){return this.validCliEvt("Validv_Username",0,function(){try{var n=gx.util.balloon.getNew("vUSERNAME");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12342_client=function(){return this.executeServerEvent("'LOGIN'",!0,null,!1,!1)};this.e13342_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15342_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36];this.GXLastCtrlId=36;this.UCPROBAMOSLOADER1Container=gx.uc.getNew(this,37,20,"UCProbamosLoader","UCPROBAMOSLOADER1Container","Ucprobamosloader1","UCPROBAMOSLOADER1");t=this.UCPROBAMOSLOADER1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLECONTENT",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLEHEADER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"IMAGE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLEUSERPASS",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,lvl:0,type:"svchar",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Username,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",fmt:0,gxz:"ZV5UserName",gxold:"OV5UserName",gxvar:"AV5UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV5UserName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"svchar",len:40,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",fmt:0,gxz:"ZV6UserPassword",gxold:"OV6UserPassword",gxvar:"AV6UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV6UserPassword,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"LOGIN",grid:0,evt:"e13342_client",std:"ENTER"};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TABLELOGINERROR",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};this.AV5UserName="";this.ZV5UserName="";this.OV5UserName="";this.AV6UserPassword="";this.ZV6UserPassword="";this.OV6UserPassword="";this.AV5UserName="";this.AV6UserPassword="";this.A111UserActive=!1;this.A109UserHash="";this.A101UserPassword="";this.A100UserName="";this.A99UserId=0;this.AV8Context={UserId:0,UserName:""};this.Events={e12342_client:["'LOGIN'",!0],e13342_client:["ENTER",!0],e15342_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'LOGIN'"]=[[{av:"A100UserName",fld:"USERNAME",pic:""},{av:"AV5UserName",fld:"vUSERNAME",pic:""},{av:"A101UserPassword",fld:"USERPASSWORD",pic:""},{av:"AV6UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"A109UserHash",fld:"USERHASH",pic:""},{av:"A111UserActive",fld:"USERACTIVE",pic:""},{av:"A99UserId",fld:"USERID",pic:"ZZZZZ9"},{av:"AV8Context",fld:"vCONTEXT",pic:""}],[]];this.EvtParms.ENTER=[[{av:"A100UserName",fld:"USERNAME",pic:""},{av:"AV5UserName",fld:"vUSERNAME",pic:""},{av:"A101UserPassword",fld:"USERPASSWORD",pic:""},{av:"AV6UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"A109UserHash",fld:"USERHASH",pic:""},{av:"A111UserActive",fld:"USERACTIVE",pic:""},{av:"A99UserId",fld:"USERID",pic:"ZZZZZ9"},{av:"AV8Context",fld:"vCONTEXT",pic:""}],[{av:"AV8Context",fld:"vCONTEXT",pic:""}]];this.EvtParms.VALIDV_USERNAME=[[],[]];this.EnterCtrl=["LOGIN"];this.setVCMap("A101UserPassword","USERPASSWORD",0,"svchar",40,0);this.setVCMap("A109UserHash","USERHASH",0,"svchar",40,0);this.setVCMap("A100UserName","USERNAME",0,"svchar",20,0);this.setVCMap("A111UserActive","USERACTIVE",0,"boolean",4,0);this.setVCMap("A99UserId","USERID",0,"int",6,0);this.setVCMap("AV8Context","vCONTEXT",0,"GeneralUISDTContextSession",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wplogin)})