gx.evt.autoSkip=!1;gx.define("sector",!1,function(){this.ServerClass="sector";this.PackageName="GeneXus.Programs";this.ServerFullClass="sector.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV7SectorId=gx.fn.getIntegerValue("vSECTORID",",");this.A9SectorId=gx.fn.getIntegerValue("SECTORID",",");this.Gx_date=gx.fn.getDateValue("vTODAY");this.AV12Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.e12032_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13033_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14033_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58];this.GXLastCtrlId=58;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15033_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16033_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17033_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18033_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19033_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORNAME",fmt:0,gxz:"Z10SectorName",gxold:"O10SectorName",gxvar:"A10SectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10SectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10SectorName=n)},v2c:function(){gx.fn.setControlValue("SECTORNAME",gx.O.A10SectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10SectorName=this.val())},val:function(){return gx.fn.getControlValue("SECTORNAME")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORDESCRIPTION",fmt:0,gxz:"Z11SectorDescription",gxold:"O11SectorDescription",gxvar:"A11SectorDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11SectorDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z11SectorDescription=n)},v2c:function(){gx.fn.setControlValue("SECTORDESCRIPTION",gx.O.A11SectorDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11SectorDescription=this.val())},val:function(){return gx.fn.getControlValue("SECTORDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORCREATEDDATE",fmt:0,gxz:"Z34SectorCreatedDate",gxold:"O34SectorCreatedDate",gxvar:"A34SectorCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34SectorCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z34SectorCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("SECTORCREATEDDATE",gx.O.A34SectorCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A34SectorCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("SECTORCREATEDDATE")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORMODIFIEDDATE",fmt:0,gxz:"Z35SectorModifiedDate",gxold:"O35SectorModifiedDate",gxvar:"A35SectorModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A35SectorModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z35SectorModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("SECTORMODIFIEDDATE",gx.O.A35SectorModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A35SectorModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("SECTORMODIFIEDDATE")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"BTN_ENTER",grid:0,evt:"e13033_client",std:"ENTER"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTN_CANCEL",grid:0,evt:"e14033_client"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"BTN_DELETE",grid:0,evt:"e20033_client",std:"DELETE"};this.A10SectorName="";this.Z10SectorName="";this.O10SectorName="";this.A11SectorDescription="";this.Z11SectorDescription="";this.O11SectorDescription="";this.A34SectorCreatedDate=gx.date.nullDate();this.Z34SectorCreatedDate=gx.date.nullDate();this.O34SectorCreatedDate=gx.date.nullDate();this.A35SectorModifiedDate=gx.date.nullDate();this.Z35SectorModifiedDate=gx.date.nullDate();this.O35SectorModifiedDate=gx.date.nullDate();this.AV12Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7SectorId=0;this.AV10WebSession={};this.A9SectorId=0;this.Gx_date=gx.date.nullDate();this.A10SectorName="";this.A11SectorDescription="";this.A34SectorCreatedDate=gx.date.nullDate();this.A35SectorModifiedDate=gx.date.nullDate();this.Gx_mode="";this.Events={e12032_client:["AFTER TRN",!0],e13033_client:["ENTER",!0],e14033_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7SectorId",fld:"vSECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7SectorId",fld:"vSECTORID",pic:"ZZZZZ9",hsh:!0},{av:"A34SectorCreatedDate",fld:"SECTORCREATEDDATE",pic:""},{av:"A35SectorModifiedDate",fld:"SECTORMODIFIEDDATE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7SectorId","vSECTORID",0,"int",6,0);this.setVCMap("A9SectorId","SECTORID",0,"int",6,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV12Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.sector)})