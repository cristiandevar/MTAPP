gx.evt.autoSkip=!1;gx.define("viewsector",!1,function(){var n,t;this.ServerClass="viewsector";this.PackageName="GeneXus.Programs";this.ServerFullClass="viewsector.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS");this.AV7SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE");this.AV12SectorId=gx.fn.getIntegerValue("vSECTORID",",");this.AV6TabCode=gx.fn.getControlValue("vTABCODE")};this.e11152_client=function(){return this.executeServerEvent("TAB.TABCHANGED",!1,null,!0,!0)};this.e14152_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15152_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,20,21,23,24,25,28,29,31,32,33];this.GXLastCtrlId=33;this.TABContainer=gx.uc.getNew(this,18,15,"gx.ui.controls.BasicTab","TABContainer","Tab","TAB");t=this.TABContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ActivePage","Activepage","","int");t.setDynProp("ActivePageControlName","Activepagecontrolname","","char");t.setProp("PageCount","Pagecount",2,"num");t.setProp("Class","Class","ww__view__tab","str");t.setProp("HistoryManagement","Historymanagement",!0,"bool");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});t.addEventHandler("TabChanged",this.e11152_client);this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"VIEWALL",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLEFIXEDDATA_1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORNAME",fmt:0,gxz:"Z10SectorName",gxold:"O10SectorName",gxvar:"A10SectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10SectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10SectorName=n)},v2c:function(){gx.fn.setControlValue("SECTORNAME",gx.O.A10SectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10SectorName=this.val())},val:function(){return gx.fn.getControlValue("SECTORNAME")},nac:gx.falseFn};this.declareDomainHdlr(15,function(){});n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[20]={id:20,fld:"GENERAL_TITLE",format:0,grid:0,ctrltype:"textblock"};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"TABLEGENERAL",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[28]={id:28,fld:"PRODUCT_TITLE",format:0,grid:0,ctrltype:"textblock"};n[29]={id:29,fld:"",grid:0};n[31]={id:31,fld:"TABLEPRODUCT",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};this.A10SectorName="";this.Z10SectorName="";this.O10SectorName="";this.A10SectorName="";this.AV12SectorId=0;this.AV6TabCode="";this.A9SectorId=0;this.AV11LoadAllTabs=!1;this.AV7SelectedTabCode="";this.Events={e11152_client:["TAB.TABCHANGED",!0],e14152_client:["ENTER",!0],e15152_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV12SectorId",fld:"vSECTORID",pic:"ZZZZZ9",hsh:!0},{av:"AV6TabCode",fld:"vTABCODE",pic:"",hsh:!0},{av:"A10SectorName",fld:"SECTORNAME",pic:""}],[]];this.EvtParms["TAB.TABCHANGED"]=[[{av:"this.TABContainer.ActivePageControlName",ctrl:"TAB",prop:"ActivePageControlName"},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{av:"AV7SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV12SectorId",fld:"vSECTORID",pic:"ZZZZZ9",hsh:!0}],[{av:"AV7SelectedTabCode",fld:"vSELECTEDTABCODE",pic:""},{av:"AV11LoadAllTabs",fld:"vLOADALLTABS",pic:""},{ctrl:"GENERALWC"},{ctrl:"PRODUCTWC"}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV11LoadAllTabs","vLOADALLTABS",0,"boolean",4,0);this.setVCMap("AV7SelectedTabCode","vSELECTEDTABCODE",0,"char",50,0);this.setVCMap("AV12SectorId","vSECTORID",0,"int",6,0);this.setVCMap("AV6TabCode","vTABCODE",0,"char",50,0);this.Initialize();this.setComponent({id:"GENERALWC",GXClass:null,Prefix:"W0026",lvl:1});this.setComponent({id:"PRODUCTWC",GXClass:null,Prefix:"W0034",lvl:1})});gx.wi(function(){gx.createParentObj(this.viewsector)})