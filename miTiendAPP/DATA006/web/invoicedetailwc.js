gx.evt.autoSkip=!1;gx.define("invoicedetailwc",!0,function(n){var t,i;this.ServerClass="invoicedetailwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="invoicedetailwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A98InvoiceDetailIsWholesale=gx.fn.getControlValue("INVOICEDETAILISWHOLESALE");this.AV6InvoiceId=gx.fn.getIntegerValue("vINVOICEID",",");this.AV6InvoiceId=gx.fn.getIntegerValue("vINVOICEID",",")};this.Validv_Type=function(){var n=gx.fn.currentGridRowImpl(15);return this.validCliEvt("Validv_Type",15,function(){try{var n=gx.util.balloon.getNew("vTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV13Type,"Wholesale")==0||gx.text.compare(this.AV13Type,"Retail")==0||gx.text.compare("",this.AV13Type)===0))try{n.setError("Field Type is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e13292_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14292_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23];this.GXLastCtrlId=23;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"invoicedetailwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(16,16,"PRODUCTNAME","Product Name","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(26,17,"INVOICEDETAILQUANTITY","Detail Quantity","","InvoiceDetailQuantity","int",0,"px",6,6,"right",null,[],26,"InvoiceDetailQuantity",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(65,18,"INVOICEDETAILHISTORICPRICE","Historic Price","","InvoiceDetailHistoricPrice","decimal",0,"px",18,18,"right",null,[],65,"InvoiceDetailHistoricPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addComboBox("Type",19,"vTYPE","Type","Type","svchar",null,0,!0,!1,0,"px","column WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"GRIDCONTAINER",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[16]={id:16,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};t[17]={id:17,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEDETAILQUANTITY",fmt:0,gxz:"Z26InvoiceDetailQuantity",gxold:"O26InvoiceDetailQuantity",gxvar:"A26InvoiceDetailQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26InvoiceDetailQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z26InvoiceDetailQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEDETAILQUANTITY",n||gx.fn.currentGridRowImpl(15),gx.O.A26InvoiceDetailQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A26InvoiceDetailQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVOICEDETAILQUANTITY",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[18]={id:18,lvl:2,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEDETAILHISTORICPRICE",fmt:0,gxz:"Z65InvoiceDetailHistoricPrice",gxold:"O65InvoiceDetailHistoricPrice",gxvar:"A65InvoiceDetailHistoricPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A65InvoiceDetailHistoricPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z65InvoiceDetailHistoricPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("INVOICEDETAILHISTORICPRICE",n||gx.fn.currentGridRowImpl(15),gx.O.A65InvoiceDetailHistoricPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A65InvoiceDetailHistoricPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("INVOICEDETAILHISTORICPRICE",n||gx.fn.currentGridRowImpl(15),",",".")},nac:gx.falseFn};t[19]={id:19,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:this.Validv_Type,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPE",fmt:0,gxz:"ZV13Type",gxold:"OV13Type",gxvar:"AV13Type",ucs:[],op:[19],ip:[19],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV13Type=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Type=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vTYPE",n||gx.fn.currentGridRowImpl(15),gx.O.AV13Type);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Type=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTYPE",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEID",fmt:0,gxz:"Z20InvoiceId",gxold:"O20InvoiceId",gxvar:"A20InvoiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z20InvoiceId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("INVOICEID",gx.O.A20InvoiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("INVOICEID",",")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});this.Z16ProductName="";this.O16ProductName="";this.Z26InvoiceDetailQuantity=0;this.O26InvoiceDetailQuantity=0;this.Z65InvoiceDetailHistoricPrice=0;this.O65InvoiceDetailHistoricPrice=0;this.ZV13Type="";this.OV13Type="";this.A20InvoiceId=0;this.Z20InvoiceId=0;this.O20InvoiceId=0;this.A20InvoiceId=0;this.AV6InvoiceId=0;this.A98InvoiceDetailIsWholesale=!1;this.A15ProductId=0;this.A16ProductName="";this.A26InvoiceDetailQuantity=0;this.A65InvoiceDetailHistoricPrice=0;this.AV13Type="";this.Events={e13292_client:["ENTER",!0],e14292_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6InvoiceId",fld:"vINVOICEID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A98InvoiceDetailIsWholesale",fld:"INVOICEDETAILISWHOLESALE",pic:""}],[{ctrl:"vTYPE"},{av:"AV13Type",fld:"vTYPE",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6InvoiceId",fld:"vINVOICEID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6InvoiceId",fld:"vINVOICEID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6InvoiceId",fld:"vINVOICEID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6InvoiceId",fld:"vINVOICEID",pic:"ZZZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.VALIDV_TYPE=[[{ctrl:"vTYPE"},{av:"AV13Type",fld:"vTYPE",pic:""}],[{ctrl:"vTYPE"},{av:"AV13Type",fld:"vTYPE",pic:""}]];this.setVCMap("A98InvoiceDetailIsWholesale","INVOICEDETAILISWHOLESALE",0,"boolean",4,0);this.setVCMap("AV6InvoiceId","vINVOICEID",0,"int",6,0);this.setVCMap("AV6InvoiceId","vINVOICEID",0,"int",6,0);this.setVCMap("AV6InvoiceId","vINVOICEID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6InvoiceId"});i.addRefreshingParm({rfrVar:"AV6InvoiceId"});this.Initialize()})