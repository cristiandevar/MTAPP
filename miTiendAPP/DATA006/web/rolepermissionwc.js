gx.evt.autoSkip=!1;gx.define("rolepermissionwc",!0,function(n){var t,i;this.ServerClass="rolepermissionwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="rolepermissionwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A106PermissionId=gx.fn.getIntegerValue("PERMISSIONID",",");this.AV6RoleId=gx.fn.getIntegerValue("vROLEID",",");this.AV6RoleId=gx.fn.getIntegerValue("vROLEID",",")};this.e14392_client=function(){return this.executeServerEvent("'DOINSERT'",!0,arguments[0],!1,!1)};this.e11392_client=function(){return this.executeServerEvent("'ASSIGN PERMISSION'",!1,null,!1,!1)};this.e15392_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16392_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,19,20,21,22,23,25,26,27,28,29];this.GXLastCtrlId=29;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"rolepermissionwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(107,25,"PERMISSIONNAME","Permission Name","","PermissionName","svchar",0,"px",60,60,"left",null,[],107,"PermissionName",!0,0,!1,!1,"attribute-description",0,"column");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLETOP",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"BTNASSIGNPERMISSION",grid:0,evt:"e11392_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"BTNEXPORT",grid:0,evt:"e17391_client"};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"GRIDCONTAINER",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[25]={id:25,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERMISSIONNAME",fmt:0,gxz:"Z107PermissionName",gxold:"O107PermissionName",gxvar:"A107PermissionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A107PermissionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z107PermissionName=n)},v2c:function(n){gx.fn.setGridControlValue("PERMISSIONNAME",n||gx.fn.currentGridRowImpl(24),gx.O.A107PermissionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A107PermissionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PERMISSIONNAME",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ROLEID",fmt:0,gxz:"Z104RoleId",gxold:"O104RoleId",gxvar:"A104RoleId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A104RoleId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z104RoleId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ROLEID",gx.O.A104RoleId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A104RoleId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ROLEID",",")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});this.Z107PermissionName="";this.O107PermissionName="";this.A104RoleId=0;this.Z104RoleId=0;this.O104RoleId=0;this.A104RoleId=0;this.AV6RoleId=0;this.A106PermissionId=0;this.A107PermissionName="";this.Events={e14392_client:["'DOINSERT'",!0],e11392_client:["'ASSIGN PERMISSION'",!0],e15392_client:["ENTER",!0],e16392_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"sPrefix"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("PERMISSIONNAME","Link")',ctrl:"PERMISSIONNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["'ASSIGN PERMISSION'"]=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6RoleId",fld:"vROLEID",pic:"ZZZZZ9"},{av:"A106PermissionId",fld:"PERMISSIONID",pic:"ZZZZZ9",hsh:!0},{av:"sPrefix"}],[]];this.setVCMap("A106PermissionId","PERMISSIONID",0,"int",6,0);this.setVCMap("AV6RoleId","vROLEID",0,"int",6,0);this.setVCMap("AV6RoleId","vROLEID",0,"int",6,0);this.setVCMap("AV6RoleId","vROLEID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6RoleId"});i.addRefreshingVar({rfrVar:"A106PermissionId"});i.addRefreshingParm({rfrVar:"AV6RoleId"});i.addRefreshingParm({rfrVar:"A106PermissionId"});this.Initialize()})