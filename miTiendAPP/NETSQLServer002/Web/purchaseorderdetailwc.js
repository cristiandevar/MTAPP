gx.evt.autoSkip=!1;gx.define("purchaseorderdetailwc",!0,function(n){var t,i;this.ServerClass="purchaseorderdetailwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="purchaseorderdetailwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV6PurchaseOrderId=gx.fn.getIntegerValue("vPURCHASEORDERID",",");this.AV6PurchaseOrderId=gx.fn.getIntegerValue("vPURCHASEORDERID",",")};this.Valid_Productid=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Valid_Productid",15,function(){try{if(gx.fn.currentGridRowImpl(15)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(15));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e131h2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e141h2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23,24,25];this.GXLastCtrlId=25;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"purchaseorderdetailwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(61,16,"PURCHASEORDERDETAILID","Detail Id","","PurchaseOrderDetailId","int",0,"px",6,6,"right",null,[],61,"PurchaseOrderDetailId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(62,17,"PURCHASEORDERDETAILQUANTITY","Detail Quantity","","PurchaseOrderDetailQuantity","int",0,"px",4,4,"right",null,[],62,"PurchaseOrderDetailQuantity",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(15,18,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(63,19,"PURCHASEORDERDETAILCURRENTPRIC","Current Price","","PurchaseOrderDetailCurrentPric","decimal",0,"px",10,10,"right",null,[],63,"PurchaseOrderDetailCurrentPric",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(64,20,"PURCHASEORDERDETAILSUGGESTEDPR","Suggested Price","","PurchaseOrderDetailSuggestedPr","decimal",0,"px",10,10,"right",null,[],64,"PurchaseOrderDetailSuggestedPr",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(16,21,"PRODUCTNAME","Product Name","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"GRIDCONTAINER",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[16]={id:16,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILID",fmt:0,gxz:"Z61PurchaseOrderDetailId",gxold:"O61PurchaseOrderDetailId",gxvar:"A61PurchaseOrderDetailId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z61PurchaseOrderDetailId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(15),gx.O.A61PurchaseOrderDetailId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[17]={id:17,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITY",fmt:0,gxz:"Z62PurchaseOrderDetailQuantity",gxold:"O62PurchaseOrderDetailQuantity",gxvar:"A62PurchaseOrderDetailQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A62PurchaseOrderDetailQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z62PurchaseOrderDetailQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITY",n||gx.fn.currentGridRowImpl(15),gx.O.A62PurchaseOrderDetailQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A62PurchaseOrderDetailQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITY",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[18]={id:18,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(15),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[19]={id:19,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILCURRENTPRIC",fmt:0,gxz:"Z63PurchaseOrderDetailCurrentPric",gxold:"O63PurchaseOrderDetailCurrentPric",gxvar:"A63PurchaseOrderDetailCurrentPric",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A63PurchaseOrderDetailCurrentPric=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z63PurchaseOrderDetailCurrentPric=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PURCHASEORDERDETAILCURRENTPRIC",n||gx.fn.currentGridRowImpl(15),gx.O.A63PurchaseOrderDetailCurrentPric,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A63PurchaseOrderDetailCurrentPric=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PURCHASEORDERDETAILCURRENTPRIC",n||gx.fn.currentGridRowImpl(15),",",".")},nac:gx.falseFn};t[20]={id:20,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILSUGGESTEDPR",fmt:0,gxz:"Z64PurchaseOrderDetailSuggestedPr",gxold:"O64PurchaseOrderDetailSuggestedPr",gxvar:"A64PurchaseOrderDetailSuggestedPr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A64PurchaseOrderDetailSuggestedPr=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z64PurchaseOrderDetailSuggestedPr=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PURCHASEORDERDETAILSUGGESTEDPR",n||gx.fn.currentGridRowImpl(15),gx.O.A64PurchaseOrderDetailSuggestedPr,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A64PurchaseOrderDetailSuggestedPr=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PURCHASEORDERDETAILSUGGESTEDPR",n||gx.fn.currentGridRowImpl(15),",",".")},nac:gx.falseFn};t[21]={id:21,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERID",fmt:0,gxz:"Z50PurchaseOrderId",gxold:"O50PurchaseOrderId",gxvar:"A50PurchaseOrderId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z50PurchaseOrderId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERID",gx.O.A50PurchaseOrderId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PURCHASEORDERID",",")},nac:gx.falseFn};this.declareDomainHdlr(25,function(){});this.Z61PurchaseOrderDetailId=0;this.O61PurchaseOrderDetailId=0;this.Z62PurchaseOrderDetailQuantity=0;this.O62PurchaseOrderDetailQuantity=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z63PurchaseOrderDetailCurrentPric=0;this.O63PurchaseOrderDetailCurrentPric=0;this.Z64PurchaseOrderDetailSuggestedPr=0;this.O64PurchaseOrderDetailSuggestedPr=0;this.Z16ProductName="";this.O16ProductName="";this.A50PurchaseOrderId=0;this.Z50PurchaseOrderId=0;this.O50PurchaseOrderId=0;this.A50PurchaseOrderId=0;this.AV6PurchaseOrderId=0;this.A61PurchaseOrderDetailId=0;this.A62PurchaseOrderDetailQuantity=0;this.A15ProductId=0;this.A63PurchaseOrderDetailCurrentPric=0;this.A64PurchaseOrderDetailSuggestedPr=0;this.A16ProductName="";this.Events={e131h2_client:["ENTER",!0],e141h2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.VALID_PRODUCTID=[[],[]];this.setVCMap("AV6PurchaseOrderId","vPURCHASEORDERID",0,"int",6,0);this.setVCMap("AV6PurchaseOrderId","vPURCHASEORDERID",0,"int",6,0);this.setVCMap("AV6PurchaseOrderId","vPURCHASEORDERID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6PurchaseOrderId"});i.addRefreshingParm({rfrVar:"AV6PurchaseOrderId"});this.Initialize()})