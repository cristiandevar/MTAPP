gx.evt.autoSkip=!1;gx.define("wppurchaseorderdetails",!1,function(){var n,t;this.ServerClass="wppurchaseorderdetails";this.PackageName="GeneXus.Programs";this.ServerFullClass="wppurchaseorderdetails.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A50PurchaseOrderId=gx.fn.getIntegerValue("PURCHASEORDERID",",");this.A50PurchaseOrderId=gx.fn.getIntegerValue("PURCHASEORDERID",",");this.A50PurchaseOrderId=gx.fn.getIntegerValue("PURCHASEORDERID",",")};this.Validv_Purchaseordertotalprojected=function(){return this.validCliEvt("Validv_Purchaseordertotalprojected",0,function(){try{var n=gx.util.balloon.getNew("vPURCHASEORDERTOTALPROJECTED");if(this.AnyError=0,!(this.AV10PurchaseOrderTotalProjected>=0&&gx.num.compare(this.AV10PurchaseOrderTotalProjected,new gx.num.dec.bigDecimal("999999999999999.99"))<=0||gx.num.compare(0,this.AV10PurchaseOrderTotalProjected)===0))try{n.setError("Invalid Price");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productid=function(){var n=gx.fn.currentGridRowImpl(38);return this.validCliEvt("Valid_Productid",38,function(){try{if(gx.fn.currentGridRowImpl(38)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(38));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Purchaseorderdetailsubtotal=function(){var n=gx.fn.currentGridRowImpl(38);return this.validCliEvt("Validv_Purchaseorderdetailsubtotal",38,function(){try{var n=gx.util.balloon.getNew("vPURCHASEORDERDETAILSUBTOTAL");if(this.AnyError=0,!(this.AV9PurchaseOrderDetailSubtotal>=0&&this.AV9PurchaseOrderDetailSubtotal<=999999999.99||0===this.AV9PurchaseOrderDetailSubtotal))try{n.setError("Field Purchase Order Detail Subtotal is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productid=function(){var n=gx.fn.currentGridRowImpl(38);return this.validCliEvt("Valid_Productid",38,function(){try{if(gx.fn.currentGridRowImpl(38)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(38));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e112n1_client=function(){return this.clearMessages(),this.AV8window.Url=gx.http.formatLink("apurchaseordervoucher.aspx",[this.A50PurchaseOrderId]),this.AV8window.ReturnParms=[],this.AV8window.Height=gx.num.trunc(370,0),this.AV8window.Width=gx.num.trunc(500,0),this.popupOpen(this.AV8window),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e152n2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e162n2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48];this.GXLastCtrlId=48;this.GriddetailsContainer=new gx.grid.grid(this,2,"WbpLvl2",38,"Griddetails","Griddetails","GriddetailsContainer",this.CmpContext,this.IsMasterPage,"wppurchaseorderdetails",[],!1,1,!1,!0,5,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GriddetailsContainer;t.addSingleLineEdit(15,39,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(55,40,"PRODUCTCODE","Code","","ProductCode","svchar",0,"px",100,80,"left",null,[],55,"ProductCode",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(16,41,"PRODUCTNAME","Product","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(17,42,"PRODUCTSTOCK","Current Stock","","ProductStock","int",0,"px",6,6,"right",null,[],17,"ProductStock",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(69,43,"PRODUCTMINIUMSTOCK","Min. Stock","","ProductMiniumStock","int",0,"px",6,6,"right",null,[],69,"ProductMiniumStock",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(76,44,"PURCHASEORDERDETAILQUANTITYORD","Qty. Ordered","","PurchaseOrderDetailQuantityOrd","int",0,"px",6,6,"right",null,[],76,"PurchaseOrderDetailQuantityOrd",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(85,45,"PRODUCTCOSTPRICE","Cost Price","","ProductCostPrice","decimal",0,"px",18,18,"right",null,[],85,"ProductCostPrice",!0,2,!1,!1,"Attribute",0,"");t.addSingleLineEdit(77,46,"PURCHASEORDERDETAILQUANTITYREC","Qty. Received","","PurchaseOrderDetailQuantityRec","int",0,"px",6,6,"right",null,[],77,"PurchaseOrderDetailQuantityRec",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(134,47,"PURCHASEORDERDETAILSUGGESTEDPR","Suggested Price","","PurchaseOrderDetailSuggestedPr","decimal",0,"px",18,18,"right",null,[],134,"PurchaseOrderDetailSuggestedPr",!0,2,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Purchaseorderdetailsubtotal",48,"vPURCHASEORDERDETAILSUBTOTAL","Subtotal","","PurchaseOrderDetailSubtotal","decimal",0,"px",15,15,"right",null,[],"Purchaseorderdetailsubtotal","PurchaseOrderDetailSubtotal",!0,2,!1,!1,"Attribute",0,"");this.GriddetailsContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"VOUCHER",grid:0,evt:"e112n1_client"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCREATEDDATE",fmt:0,gxz:"Z52PurchaseOrderCreatedDate",gxold:"O52PurchaseOrderCreatedDate",gxvar:"A52PurchaseOrderCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCREATEDDATE",gx.O.A52PurchaseOrderCreatedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCREATEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(13,function(){});n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCLOSEDDATE",fmt:0,gxz:"Z66PurchaseOrderClosedDate",gxold:"O66PurchaseOrderClosedDate",gxvar:"A66PurchaseOrderClosedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCLOSEDDATE",gx.O.A66PurchaseOrderClosedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCLOSEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(17,function(){});n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPURHCASEORDERSTATE",fmt:0,gxz:"ZV13PurhcaseOrderState",gxold:"OV13PurhcaseOrderState",gxvar:"AV13PurhcaseOrderState",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13PurhcaseOrderState=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13PurhcaseOrderState=n)},v2c:function(){gx.fn.setControlValue("vPURHCASEORDERSTATE",gx.O.AV13PurhcaseOrderState,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV13PurhcaseOrderState=this.val())},val:function(){return gx.fn.getControlValue("vPURHCASEORDERSTATE")},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vISOWED",fmt:0,gxz:"ZV14IsOwed",gxold:"OV14IsOwed",gxvar:"AV14IsOwed",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV14IsOwed=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14IsOwed=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vISOWED",gx.O.AV14IsOwed,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14IsOwed=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vISOWED")},nac:gx.falseFn,values:["true","false"]};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,lvl:0,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERTOTALPAID",fmt:0,gxz:"Z78PurchaseOrderTotalPaid",gxold:"O78PurchaseOrderTotalPaid",gxvar:"A78PurchaseOrderTotalPaid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PURCHASEORDERTOTALPAID",gx.O.A78PurchaseOrderTotalPaid,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=this.val())},val:function(){return gx.fn.getDecimalValue("PURCHASEORDERTOTALPAID",",",".")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,lvl:0,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Purchaseordertotalprojected,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPURCHASEORDERTOTALPROJECTED",fmt:0,gxz:"ZV10PurchaseOrderTotalProjected",gxold:"OV10PurchaseOrderTotalProjected",gxvar:"AV10PurchaseOrderTotalProjected",ucs:[],op:[33],ip:[33],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10PurchaseOrderTotalProjected=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV10PurchaseOrderTotalProjected=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("vPURCHASEORDERTOTALPROJECTED",gx.O.AV10PurchaseOrderTotalProjected,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV10PurchaseOrderTotalProjected=this.val())},val:function(){return gx.fn.getDecimalValue("vPURCHASEORDERTOTALPROJECTED",",",".")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[39]={id:39,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(38),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(38),",")},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCODE",fmt:0,gxz:"Z55ProductCode",gxold:"O55ProductCode",gxvar:"A55ProductCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A55ProductCode=n)},v2z:function(n){n!==undefined&&(gx.O.Z55ProductCode=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(38),gx.O.A55ProductCode,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A55ProductCode=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(38))},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(38),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(38))},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSTOCK",fmt:0,gxz:"Z17ProductStock",gxold:"O17ProductStock",gxvar:"A17ProductStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A17ProductStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z17ProductStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(38),gx.O.A17ProductStock,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A17ProductStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(38),",")},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTMINIUMSTOCK",fmt:0,gxz:"Z69ProductMiniumStock",gxold:"O69ProductMiniumStock",gxvar:"A69ProductMiniumStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A69ProductMiniumStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z69ProductMiniumStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTMINIUMSTOCK",n||gx.fn.currentGridRowImpl(38),gx.O.A69ProductMiniumStock,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A69ProductMiniumStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTMINIUMSTOCK",n||gx.fn.currentGridRowImpl(38),",")},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYORD",fmt:0,gxz:"Z76PurchaseOrderDetailQuantityOrd",gxold:"O76PurchaseOrderDetailQuantityOrd",gxvar:"A76PurchaseOrderDetailQuantityOrd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(38),gx.O.A76PurchaseOrderDetailQuantityOrd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(38),",")},nac:gx.falseFn};n[45]={id:45,lvl:2,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCOSTPRICE",fmt:0,gxz:"Z85ProductCostPrice",gxold:"O85ProductCostPrice",gxvar:"A85ProductCostPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A85ProductCostPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z85ProductCostPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTCOSTPRICE",n||gx.fn.currentGridRowImpl(38),gx.O.A85ProductCostPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A85ProductCostPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTCOSTPRICE",n||gx.fn.currentGridRowImpl(38),",",".")},nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYREC",fmt:0,gxz:"Z77PurchaseOrderDetailQuantityRec",gxold:"O77PurchaseOrderDetailQuantityRec",gxvar:"A77PurchaseOrderDetailQuantityRec",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(38),gx.O.A77PurchaseOrderDetailQuantityRec,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(38),",")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILSUGGESTEDPR",fmt:0,gxz:"Z134PurchaseOrderDetailSuggestedPr",gxold:"O134PurchaseOrderDetailSuggestedPr",gxvar:"A134PurchaseOrderDetailSuggestedPr",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A134PurchaseOrderDetailSuggestedPr=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z134PurchaseOrderDetailSuggestedPr=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PURCHASEORDERDETAILSUGGESTEDPR",n||gx.fn.currentGridRowImpl(38),gx.O.A134PurchaseOrderDetailSuggestedPr,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A134PurchaseOrderDetailSuggestedPr=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PURCHASEORDERDETAILSUGGESTEDPR",n||gx.fn.currentGridRowImpl(38),",",".")},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"decimal",len:15,dec:2,sign:!1,pic:"ZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:38,gxgrid:this.GriddetailsContainer,fnc:this.Validv_Purchaseorderdetailsubtotal,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPURCHASEORDERDETAILSUBTOTAL",fmt:0,gxz:"ZV9PurchaseOrderDetailSubtotal",gxold:"OV9PurchaseOrderDetailSubtotal",gxvar:"AV9PurchaseOrderDetailSubtotal",ucs:[],op:[48],ip:[48],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV9PurchaseOrderDetailSubtotal=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV9PurchaseOrderDetailSubtotal=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("vPURCHASEORDERDETAILSUBTOTAL",n||gx.fn.currentGridRowImpl(38),gx.O.AV9PurchaseOrderDetailSubtotal,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9PurchaseOrderDetailSubtotal=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("vPURCHASEORDERDETAILSUBTOTAL",n||gx.fn.currentGridRowImpl(38),",",".")},nac:gx.falseFn};this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.Z52PurchaseOrderCreatedDate=gx.date.nullDate();this.O52PurchaseOrderCreatedDate=gx.date.nullDate();this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.Z66PurchaseOrderClosedDate=gx.date.nullDate();this.O66PurchaseOrderClosedDate=gx.date.nullDate();this.AV13PurhcaseOrderState="";this.ZV13PurhcaseOrderState="";this.OV13PurhcaseOrderState="";this.AV14IsOwed=!1;this.ZV14IsOwed=!1;this.OV14IsOwed=!1;this.A78PurchaseOrderTotalPaid=0;this.Z78PurchaseOrderTotalPaid=0;this.O78PurchaseOrderTotalPaid=0;this.AV10PurchaseOrderTotalProjected=0;this.ZV10PurchaseOrderTotalProjected=0;this.OV10PurchaseOrderTotalProjected=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z55ProductCode="";this.O55ProductCode="";this.Z16ProductName="";this.O16ProductName="";this.Z17ProductStock=0;this.O17ProductStock=0;this.Z69ProductMiniumStock=0;this.O69ProductMiniumStock=0;this.Z76PurchaseOrderDetailQuantityOrd=0;this.O76PurchaseOrderDetailQuantityOrd=0;this.Z85ProductCostPrice=0;this.O85ProductCostPrice=0;this.Z77PurchaseOrderDetailQuantityRec=0;this.O77PurchaseOrderDetailQuantityRec=0;this.Z134PurchaseOrderDetailSuggestedPr=0;this.O134PurchaseOrderDetailSuggestedPr=0;this.ZV9PurchaseOrderDetailSubtotal=0;this.OV9PurchaseOrderDetailSubtotal=0;this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.AV13PurhcaseOrderState="";this.AV14IsOwed=!1;this.A78PurchaseOrderTotalPaid=0;this.AV10PurchaseOrderTotalProjected=0;this.A50PurchaseOrderId=0;this.A79PurchaseOrderActive=!1;this.A138PurchaseOrderWasPaid=!1;this.A15ProductId=0;this.A55ProductCode="";this.A16ProductName="";this.A17ProductStock=0;this.A69ProductMiniumStock=0;this.A76PurchaseOrderDetailQuantityOrd=0;this.A85ProductCostPrice=0;this.A77PurchaseOrderDetailQuantityRec=0;this.A134PurchaseOrderDetailSuggestedPr=0;this.AV9PurchaseOrderDetailSubtotal=0;this.AV8window={};this.Events={e152n2_client:["ENTER",!0],e162n2_client:["CANCEL",!0],e112n1_client:["'VOUCHER'",!1]};this.EvtParms.REFRESH=[[{av:"GRIDDETAILS_nFirstRecordOnPage"},{av:"GRIDDETAILS_nEOF"},{ctrl:"GRIDDETAILS",prop:"Rows"},{av:"AV14IsOwed",fld:"vISOWED",pic:""},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["'VOUCHER'"]=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["GRIDDETAILS.REFRESH"]=[[{av:"A77PurchaseOrderDetailQuantityRec",fld:"PURCHASEORDERDETAILQUANTITYREC",pic:"ZZZZZ9",hsh:!0},{av:"A76PurchaseOrderDetailQuantityOrd",fld:"PURCHASEORDERDETAILQUANTITYORD",pic:"ZZZZZ9",hsh:!0},{av:"A134PurchaseOrderDetailSuggestedPr",fld:"PURCHASEORDERDETAILSUGGESTEDPR",pic:"ZZZZZZZZZZZZZZ9.99",hsh:!0},{av:"A85ProductCostPrice",fld:"PRODUCTCOSTPRICE",pic:"ZZZZZZZZZZZZZZ9.99"}],[{av:"AV10PurchaseOrderTotalProjected",fld:"vPURCHASEORDERTOTALPROJECTED",pic:"ZZZZZZZZZZZZZZ9.99"}]];this.EvtParms["GRIDDETAILS.LOAD"]=[[{av:"A77PurchaseOrderDetailQuantityRec",fld:"PURCHASEORDERDETAILQUANTITYREC",pic:"ZZZZZ9",hsh:!0},{av:"A134PurchaseOrderDetailSuggestedPr",fld:"PURCHASEORDERDETAILSUGGESTEDPR",pic:"ZZZZZZZZZZZZZZ9.99",hsh:!0},{av:"A85ProductCostPrice",fld:"PRODUCTCOSTPRICE",pic:"ZZZZZZZZZZZZZZ9.99"}],[{av:"AV9PurchaseOrderDetailSubtotal",fld:"vPURCHASEORDERDETAILSUBTOTAL",pic:"ZZZZZZZZZZZ9.99"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRIDDETAILS_FIRSTPAGE=[[{av:"GRIDDETAILS_nFirstRecordOnPage"},{av:"GRIDDETAILS_nEOF"},{ctrl:"GRIDDETAILS",prop:"Rows"},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"AV14IsOwed",fld:"vISOWED",pic:""}],[]];this.EvtParms.GRIDDETAILS_PREVPAGE=[[{av:"GRIDDETAILS_nFirstRecordOnPage"},{av:"GRIDDETAILS_nEOF"},{ctrl:"GRIDDETAILS",prop:"Rows"},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"AV14IsOwed",fld:"vISOWED",pic:""}],[]];this.EvtParms.GRIDDETAILS_NEXTPAGE=[[{av:"GRIDDETAILS_nFirstRecordOnPage"},{av:"GRIDDETAILS_nEOF"},{ctrl:"GRIDDETAILS",prop:"Rows"},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"AV14IsOwed",fld:"vISOWED",pic:""}],[]];this.EvtParms.GRIDDETAILS_LASTPAGE=[[{av:"GRIDDETAILS_nFirstRecordOnPage"},{av:"GRIDDETAILS_nEOF"},{ctrl:"GRIDDETAILS",prop:"Rows"},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"AV14IsOwed",fld:"vISOWED",pic:""}],[]];this.EvtParms.VALIDV_PURCHASEORDERTOTALPROJECTED=[[],[]];this.EvtParms.VALID_PRODUCTID=[[],[]];this.EvtParms.VALIDV_PURCHASEORDERDETAILSUBTOTAL=[[{av:"AV9PurchaseOrderDetailSubtotal",fld:"vPURCHASEORDERDETAILSUBTOTAL",pic:"ZZZZZZZZZZZ9.99"}],[{av:"AV9PurchaseOrderDetailSubtotal",fld:"vPURCHASEORDERDETAILSUBTOTAL",pic:"ZZZZZZZZZZZ9.99"}]];this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Griddetails"});t.addRefreshingVar({rfrVar:"A50PurchaseOrderId"});t.addRefreshingParm({rfrVar:"A50PurchaseOrderId"});t.addRefreshingParm(this.GXValidFnc[25]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wppurchaseorderdetails)})