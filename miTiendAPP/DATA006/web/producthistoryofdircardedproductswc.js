gx.evt.autoSkip=!1;gx.define("producthistoryofdircardedproductswc",!0,function(n){var t,i;this.ServerClass="producthistoryofdircardedproductswc";this.PackageName="GeneXus.Programs";this.ServerFullClass="producthistoryofdircardedproductswc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV6ProductId=gx.fn.getIntegerValue("vPRODUCTID",",");this.AV6ProductId=gx.fn.getIntegerValue("vPRODUCTID",",")};this.e112f2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e142f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e152f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,23,24,25,26,27,28,29,30,31,32];this.GXLastCtrlId=32;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"producthistoryofdircardedproductswc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(81,23,"HISTORYOFDIRCARDEDPRODUCTSID","Products Id","","HistoryOfDircardedProductsId","int",0,"px",6,6,"right",null,[],81,"HistoryOfDircardedProductsId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(82,24,"HISTORYOFDIRCARDEDPRODUCTSDESC","Products Description","","HistoryOfDircardedProductsDesc","svchar",0,"px",200,80,"left",null,[],82,"HistoryOfDircardedProductsDesc",!0,0,!1,!1,"attribute-description",0,"column");i.addSingleLineEdit(83,25,"HISTORYOFDIRCARDEDPRODUCTSDATE","Products Date","","HistoryOfDircardedProductsDate","date",0,"px",8,8,"right",null,[],83,"HistoryOfDircardedProductsDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(84,26,"HISTORYOFDIRCARDEDPRODUCTSQUAN","Products Quantity","","HistoryOfDircardedProductsQuan","int",0,"px",4,4,"right",null,[],84,"HistoryOfDircardedProductsQuan",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit("Update",27,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");i.addSingleLineEdit("Delete",28,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLETOP",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e112f2_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"GRIDCONTAINER",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[23]={id:23,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTORYOFDIRCARDEDPRODUCTSID",fmt:0,gxz:"Z81HistoryOfDircardedProductsId",gxold:"O81HistoryOfDircardedProductsId",gxvar:"A81HistoryOfDircardedProductsId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A81HistoryOfDircardedProductsId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z81HistoryOfDircardedProductsId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("HISTORYOFDIRCARDEDPRODUCTSID",n||gx.fn.currentGridRowImpl(22),gx.O.A81HistoryOfDircardedProductsId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A81HistoryOfDircardedProductsId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("HISTORYOFDIRCARDEDPRODUCTSID",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTORYOFDIRCARDEDPRODUCTSDESC",fmt:0,gxz:"Z82HistoryOfDircardedProductsDesc",gxold:"O82HistoryOfDircardedProductsDesc",gxvar:"A82HistoryOfDircardedProductsDesc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A82HistoryOfDircardedProductsDesc=n)},v2z:function(n){n!==undefined&&(gx.O.Z82HistoryOfDircardedProductsDesc=n)},v2c:function(n){gx.fn.setGridControlValue("HISTORYOFDIRCARDEDPRODUCTSDESC",n||gx.fn.currentGridRowImpl(22),gx.O.A82HistoryOfDircardedProductsDesc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A82HistoryOfDircardedProductsDesc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HISTORYOFDIRCARDEDPRODUCTSDESC",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTORYOFDIRCARDEDPRODUCTSDATE",fmt:0,gxz:"Z83HistoryOfDircardedProductsDate",gxold:"O83HistoryOfDircardedProductsDate",gxvar:"A83HistoryOfDircardedProductsDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A83HistoryOfDircardedProductsDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z83HistoryOfDircardedProductsDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("HISTORYOFDIRCARDEDPRODUCTSDATE",n||gx.fn.currentGridRowImpl(22),gx.O.A83HistoryOfDircardedProductsDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A83HistoryOfDircardedProductsDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("HISTORYOFDIRCARDEDPRODUCTSDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HISTORYOFDIRCARDEDPRODUCTSQUAN",fmt:0,gxz:"Z84HistoryOfDircardedProductsQuan",gxold:"O84HistoryOfDircardedProductsQuan",gxvar:"A84HistoryOfDircardedProductsQuan",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A84HistoryOfDircardedProductsQuan=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z84HistoryOfDircardedProductsQuan=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("HISTORYOFDIRCARDEDPRODUCTSQUAN",n||gx.fn.currentGridRowImpl(22),gx.O.A84HistoryOfDircardedProductsQuan,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A84HistoryOfDircardedProductsQuan=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("HISTORYOFDIRCARDEDPRODUCTSQUAN",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRODUCTID",gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRODUCTID",",")},nac:gx.falseFn};this.declareDomainHdlr(32,function(){});this.Z81HistoryOfDircardedProductsId=0;this.O81HistoryOfDircardedProductsId=0;this.Z82HistoryOfDircardedProductsDesc="";this.O82HistoryOfDircardedProductsDesc="";this.Z83HistoryOfDircardedProductsDate=gx.date.nullDate();this.O83HistoryOfDircardedProductsDate=gx.date.nullDate();this.Z84HistoryOfDircardedProductsQuan=0;this.O84HistoryOfDircardedProductsQuan=0;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.A15ProductId=0;this.Z15ProductId=0;this.O15ProductId=0;this.A15ProductId=0;this.AV6ProductId=0;this.A81HistoryOfDircardedProductsId=0;this.A82HistoryOfDircardedProductsDesc="";this.A83HistoryOfDircardedProductsDate=gx.date.nullDate();this.A84HistoryOfDircardedProductsQuan=0;this.AV12Update="";this.AV13Delete="";this.Events={e112f2_client:["'DOINSERT'",!0],e142f2_client:["ENTER",!0],e152f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductId",fld:"vPRODUCTID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A81HistoryOfDircardedProductsId",fld:"HISTORYOFDIRCARDEDPRODUCTSID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("HISTORYOFDIRCARDEDPRODUCTSDESC","Link")',ctrl:"HISTORYOFDIRCARDEDPRODUCTSDESC",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A81HistoryOfDircardedProductsId",fld:"HISTORYOFDIRCARDEDPRODUCTSID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductId",fld:"vPRODUCTID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductId",fld:"vPRODUCTID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductId",fld:"vPRODUCTID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductId",fld:"vPRODUCTID",pic:"ZZZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.setVCMap("AV6ProductId","vPRODUCTID",0,"int",6,0);this.setVCMap("AV6ProductId","vPRODUCTID",0,"int",6,0);this.setVCMap("AV6ProductId","vPRODUCTID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6ProductId"});i.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6ProductId"});i.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})