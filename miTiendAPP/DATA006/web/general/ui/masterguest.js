gx.evt.autoSkip=!1;gx.define("general.ui.masterguest",!1,function(){this.ServerClass="general.ui.masterguest";this.PackageName="GeneXus.Programs";this.ServerFullClass="general.ui.masterguest.aspx";this.setObjectType("web");this.IsMasterPage=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){};this.e123l2_client=function(){return this.executeServerEvent("ENTER_MPAGE",!0,null,!1,!1)};this.e133l2_client=function(){return this.executeServerEvent("CANCEL_MPAGE",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15];this.GXLastCtrlId=15;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"HEADER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"IMAGE1",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"APPLICATIONHEADER",format:0,grid:0,ctrltype:"textblock"};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"CONTENT",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};this.Events={e123l2_client:["ENTER_MPAGE",!0],e133l2_client:["CANCEL_MPAGE",!0]};this.EvtParms.REFRESH_MPAGE=[[],[]];this.EvtParms.ENTER_MPAGE=[[],[]];this.Initialize()});gx.wi(function(){gx.createMasterPage(general.ui.masterguest)})