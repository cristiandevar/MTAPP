gx.evt.autoSkip=!1;gx.define("wwsector",!1,function(){var n,t;this.ServerClass="wwsector";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwsector.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A9SectorId=gx.fn.getIntegerValue("SECTORID",",")};this.e11162_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e15162_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16162_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwsector",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(10,28,"SECTORNAME","Name","","SectorName","svchar",0,"px",60,60,"left",null,[],10,"SectorName",!0,0,!1,!1,"attribute-description",0,"column");t.addSingleLineEdit(11,29,"SECTORDESCRIPTION","Description","","SectorDescription","svchar",0,"px",200,80,"left",null,[],11,"SectorDescription",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(34,30,"SECTORCREATEDDATE","Created Date","","SectorCreatedDate","date",0,"px",8,8,"right",null,[],34,"SectorCreatedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(35,31,"SECTORMODIFIEDDATE","Modified Date","","SectorModifiedDate","date",0,"px",8,8,"right",null,[],35,"SectorModifiedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit("Update",32,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");t.addSingleLineEdit("Delete",33,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"GRIDCELL",grid:0};n[6]={id:6,fld:"GRIDTABLE",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLETOP",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e11162_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vSECTORNAME",fmt:0,gxz:"ZV11SectorName",gxold:"OV11SectorName",gxvar:"AV11SectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11SectorName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11SectorName=n)},v2c:function(){gx.fn.setControlValue("vSECTORNAME",gx.O.AV11SectorName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11SectorName=this.val())},val:function(){return gx.fn.getControlValue("vSECTORNAME")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GRIDCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORNAME",fmt:0,gxz:"Z10SectorName",gxold:"O10SectorName",gxvar:"A10SectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A10SectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10SectorName=n)},v2c:function(n){gx.fn.setGridControlValue("SECTORNAME",n||gx.fn.currentGridRowImpl(27),gx.O.A10SectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10SectorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SECTORNAME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORDESCRIPTION",fmt:0,gxz:"Z11SectorDescription",gxold:"O11SectorDescription",gxvar:"A11SectorDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A11SectorDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z11SectorDescription=n)},v2c:function(n){gx.fn.setGridControlValue("SECTORDESCRIPTION",n||gx.fn.currentGridRowImpl(27),gx.O.A11SectorDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11SectorDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SECTORDESCRIPTION",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORCREATEDDATE",fmt:0,gxz:"Z34SectorCreatedDate",gxold:"O34SectorCreatedDate",gxvar:"A34SectorCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A34SectorCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z34SectorCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SECTORCREATEDDATE",n||gx.fn.currentGridRowImpl(27),gx.O.A34SectorCreatedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A34SectorCreatedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SECTORCREATEDDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SECTORMODIFIEDDATE",fmt:0,gxz:"Z35SectorModifiedDate",gxold:"O35SectorModifiedDate",gxvar:"A35SectorModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A35SectorModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z35SectorModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SECTORMODIFIEDDATE",n||gx.fn.currentGridRowImpl(27),gx.O.A35SectorModifiedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A35SectorModifiedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SECTORMODIFIEDDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};this.AV11SectorName="";this.ZV11SectorName="";this.OV11SectorName="";this.Z10SectorName="";this.O10SectorName="";this.Z11SectorDescription="";this.O11SectorDescription="";this.Z34SectorCreatedDate=gx.date.nullDate();this.O34SectorCreatedDate=gx.date.nullDate();this.Z35SectorModifiedDate=gx.date.nullDate();this.O35SectorModifiedDate=gx.date.nullDate();this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11SectorName="";this.A9SectorId=0;this.A10SectorName="";this.A11SectorDescription="";this.A34SectorCreatedDate=gx.date.nullDate();this.A35SectorModifiedDate=gx.date.nullDate();this.AV12Update="";this.AV13Delete="";this.Events={e11162_client:["'DOINSERT'",!0],e15162_client:["ENTER",!0],e16162_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SectorName",fld:"vSECTORNAME",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUPDATE","Enabled")',ctrl:"vUPDATE",prop:"Enabled"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vDELETE","Enabled")',ctrl:"vDELETE",prop:"Enabled"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("SECTORNAME","Link")',ctrl:"SECTORNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SectorName",fld:"vSECTORNAME",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUPDATE","Enabled")',ctrl:"vUPDATE",prop:"Enabled"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vDELETE","Enabled")',ctrl:"vDELETE",prop:"Enabled"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SectorName",fld:"vSECTORNAME",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUPDATE","Enabled")',ctrl:"vUPDATE",prop:"Enabled"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vDELETE","Enabled")',ctrl:"vDELETE",prop:"Enabled"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SectorName",fld:"vSECTORNAME",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUPDATE","Enabled")',ctrl:"vUPDATE",prop:"Enabled"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vDELETE","Enabled")',ctrl:"vDELETE",prop:"Enabled"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SectorName",fld:"vSECTORNAME",pic:""},{av:'gx.fn.getCtrlProperty("vUPDATE","Visible")',ctrl:"vUPDATE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vUPDATE","Enabled")',ctrl:"vUPDATE",prop:"Enabled"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:'gx.fn.getCtrlProperty("vDELETE","Visible")',ctrl:"vDELETE",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vDELETE","Enabled")',ctrl:"vDELETE",prop:"Enabled"},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"A9SectorId",fld:"SECTORID",pic:"ZZZZZ9",hsh:!0}],[]];this.setVCMap("A9SectorId","SECTORID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Visible",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Enabled",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Visible",gxAttId:"Delete"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Enabled",gxAttId:"Delete"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingVar({rfrVar:"A9SectorId"});t.addRefreshingParm(this.GXValidFnc[18]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Visible",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Enabled",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Visible",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Enabled",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"A9SectorId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwsector)})