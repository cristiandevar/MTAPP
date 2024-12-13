gx.evt.autoSkip=!1;gx.define("purchaseorder",!1,function(){var n,t;this.ServerClass="purchaseorder";this.PackageName="GeneXus.Programs";this.ServerFullClass="purchaseorder.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV13PurchaseOrderId=gx.fn.getIntegerValue("vPURCHASEORDERID",",");this.AV11Insert_SupplierId=gx.fn.getIntegerValue("vINSERT_SUPPLIERID",",");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",",");this.Gx_date=gx.fn.getDateValue("vTODAY");this.A135PurchaseOrderConfirmatedDate=gx.fn.getDateValue("PURCHASEORDERCONFIRMATEDDATE");this.A136PurchaseOrderCanceledDescripti=gx.fn.getControlValue("PURCHASEORDERCANCELEDDESCRIPTI");this.A138PurchaseOrderWasPaid=gx.fn.getControlValue("PURCHASEORDERWASPAID");this.A139PurchaseOrderPaidDate=gx.fn.getDateValue("PURCHASEORDERPAIDDATE");this.A96PurchaseOrderLastDetailId=gx.fn.getIntegerValue("PURCHASEORDERLASTDETAILID",",");this.AV16Pgmname=gx.fn.getControlValue("vPGMNAME");this.A134PurchaseOrderDetailSuggestedPr=gx.fn.getDecimalValue("PURCHASEORDERDETAILSUGGESTEDPR",",",".");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Purchaseorderid=function(){return this.validSrvEvt("Valid_Purchaseorderid",0).then(function(n){return n}.closure(this))};this.Valid_Supplierid=function(){return this.validSrvEvt("Valid_Supplierid",0).then(function(n){return n}.closure(this))};this.Valid_Purchaseordercreateddate=function(){return this.validCliEvt("Valid_Purchaseordercreateddate",0,function(){try{var n=gx.util.balloon.getNew("PURCHASEORDERCREATEDDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A52PurchaseOrderCreatedDate)==0||new gx.date.gxdate(this.A52PurchaseOrderCreatedDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Purchase Order Created Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Purchaseordertotalpaid=function(){return this.validCliEvt("Valid_Purchaseordertotalpaid",0,function(){try{var n=gx.util.balloon.getNew("PURCHASEORDERTOTALPAID");if(this.AnyError=0,!(this.A78PurchaseOrderTotalPaid>=0&&gx.num.compare(this.A78PurchaseOrderTotalPaid,new gx.num.dec.bigDecimal("999999999999999.99"))<=0||gx.num.compare(0,this.A78PurchaseOrderTotalPaid)===0))try{n.setError("Invalid Price");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Purchaseorderdetailid=function(){var n=gx.fn.currentGridRowImpl(83);return this.validCliEvt("Valid_Purchaseorderdetailid",83,function(){try{if(gx.fn.currentGridRowImpl(83)===0)return!0;var t=gx.util.balloon.getNew("PURCHASEORDERDETAILID",gx.fn.currentGridRowImpl(83));this.AnyError=0;this.sMode12=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(12,83);this.standaloneModal0712();this.standaloneNotModal0712();gx.fn.gridDuplicateKey(84)&&(t.setError(gx.text.format(gx.getMessage("GXM_1004"),"Detail","","","","","","","","")),this.AnyError=gx.num.trunc(1,0));try{this.A67PurchaseOrderDetailsQuantity=gx.num.trunc(gx.fn.countFrm("A61PurchaseOrderDetailId",0,83,n,gx.trueFn,["A61PurchaseOrderDetailId"]),0)}catch(i){}}catch(i){}try{return(this.Gx_mode=this.sMode12,t==null)?!0:t.show()}catch(i){}return!0})};this.Valid_Productid=function(){var n=gx.fn.currentGridRowImpl(83);return this.validSrvEvt("Valid_Productid",83).then(function(n){try{this.sMode12=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(12,83)}finally{this.Gx_mode=this.sMode12}return n}.closure(this))};this.Valid_Purchaseorderdetailquantityord=function(){var n=gx.fn.currentGridRowImpl(83);return this.validCliEvt("Valid_Purchaseorderdetailquantityord",83,function(){try{if(gx.fn.currentGridRowImpl(83)===0)return!0;var n=gx.util.balloon.getNew("PURCHASEORDERDETAILQUANTITYORD",gx.fn.currentGridRowImpl(83));if(this.AnyError=0,this.sMode12=this.Gx_mode,this.Gx_mode=gx.fn.getGridRowMode(12,83),this.A76PurchaseOrderDetailQuantityOrd<=0)try{n.setError("Enter a positive, integer number");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return(this.Gx_mode=this.sMode12,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Purchaseorderdetailquantityrec=function(){var n=gx.fn.currentGridRowImpl(83);return this.validCliEvt("Valid_Purchaseorderdetailquantityrec",83,function(){try{if(gx.fn.currentGridRowImpl(83)===0)return!0;var t=gx.util.balloon.getNew("PURCHASEORDERDETAILQUANTITYREC",gx.fn.currentGridRowImpl(83));if(this.AnyError=0,this.sMode12=this.Gx_mode,this.Gx_mode=gx.fn.getGridRowMode(12,83),this.A77PurchaseOrderDetailQuantityRec<0)try{t.setError("Enter a positive, integer number o zero");this.AnyError=gx.num.trunc(1,0)}catch(i){}try{this.A67PurchaseOrderDetailsQuantity=gx.num.trunc(gx.fn.countFrm("A61PurchaseOrderDetailId",0,83,n,gx.trueFn,["A61PurchaseOrderDetailId"]),0)}catch(i){}try{this.A96PurchaseOrderLastDetailId=gx.num.trunc(gx.fn.maxFrm("A61PurchaseOrderDetailId",0,",",".",83,n,gx.trueFn,["A61PurchaseOrderDetailId"]),0)}catch(i){}gx.text.compare(this.Gx_mode,"UPD")==0}catch(i){}try{return(this.Gx_mode=this.sMode12,t==null)?!0:t.show()}catch(i){}return!0})};this.standaloneModal0712=function(){this.A96PurchaseOrderLastDetailId=gx.num.trunc(gx.fn.serialRule("A96PurchaseOrderLastDetailId","A61PurchaseOrderDetailId",83,1,this),0);try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("PURCHASEORDERDETAILID","Enabled",0):gx.fn.setCtrlProperty("PURCHASEORDERDETAILID","Enabled",1)}catch(n){}};this.standaloneNotModal0712=function(){};this.e12072_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e130710_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140710_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99];this.GXLastCtrlId=99;this.Gridpurchaseorder_detailContainer=new gx.grid.grid(this,12,"Detail",83,"Gridpurchaseorder_detail","Gridpurchaseorder_detail","Gridpurchaseorder_detailContainer",this.CmpContext,this.IsMasterPage,"purchaseorder",[61],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridpurchaseorder_detailContainer;t.addSingleLineEdit(61,84,"PURCHASEORDERDETAILID","Detail Id","","PurchaseOrderDetailId","int",0,"px",6,6,"right",null,[],61,"PurchaseOrderDetailId",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(15,85,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!0,0,!1,!1,"Attribute",0,"");t.addBitmap("prompt_15","PROMPT_15",99,0,"",0,"",null,"","","gx-prompt Image","");t.addSingleLineEdit(16,86,"PRODUCTNAME","Product Name","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(76,87,"PURCHASEORDERDETAILQUANTITYORD","Quantity Ordered","","PurchaseOrderDetailQuantityOrd","int",0,"px",6,6,"right",null,[],76,"PurchaseOrderDetailQuantityOrd",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(77,88,"PURCHASEORDERDETAILQUANTITYREC","Quantity Received","","PurchaseOrderDetailQuantityRec","int",0,"px",6,6,"right",null,[],77,"PurchaseOrderDetailQuantityRec",!0,0,!1,!1,"Attribute",0,"");this.Gridpurchaseorder_detailContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e150710_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e160710_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e170710_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e180710_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e190710_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Purchaseorderid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridpurchaseorder_detailContainer],fld:"PURCHASEORDERID",fmt:0,gxz:"Z50PurchaseOrderId",gxold:"O50PurchaseOrderId",gxvar:"A50PurchaseOrderId",ucs:[],op:[74],ip:[74,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z50PurchaseOrderId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERID",gx.O.A50PurchaseOrderId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PURCHASEORDERID",",")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Supplierid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERID",fmt:0,gxz:"Z4SupplierId",gxold:"O4SupplierId",gxvar:"A4SupplierId",ucs:[],op:[44],ip:[44,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4SupplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4SupplierId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUPPLIERID",gx.O.A4SupplierId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A4SupplierId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUPPLIERID",",")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_SupplierId)}};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERNAME",fmt:0,gxz:"Z5SupplierName",gxold:"O5SupplierName",gxvar:"A5SupplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5SupplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5SupplierName=n)},v2c:function(){gx.fn.setControlValue("SUPPLIERNAME",gx.O.A5SupplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5SupplierName=this.val())},val:function(){return gx.fn.getControlValue("SUPPLIERNAME")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Purchaseordercreateddate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCREATEDDATE",fmt:0,gxz:"Z52PurchaseOrderCreatedDate",gxold:"O52PurchaseOrderCreatedDate",gxvar:"A52PurchaseOrderCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCREATEDDATE",gx.O.A52PurchaseOrderCreatedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCREATEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Purchaseordertotalpaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERTOTALPAID",fmt:0,gxz:"Z78PurchaseOrderTotalPaid",gxold:"O78PurchaseOrderTotalPaid",gxvar:"A78PurchaseOrderTotalPaid",ucs:[],op:[54],ip:[54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PURCHASEORDERTOTALPAID",gx.O.A78PurchaseOrderTotalPaid,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=this.val())},val:function(){return gx.fn.getDecimalValue("PURCHASEORDERTOTALPAID",",",".")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCLOSEDDATE",fmt:0,gxz:"Z66PurchaseOrderClosedDate",gxold:"O66PurchaseOrderClosedDate",gxvar:"A66PurchaseOrderClosedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCLOSEDDATE",gx.O.A66PurchaseOrderClosedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCLOSEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERMODIFIEDDATE",fmt:0,gxz:"Z53PurchaseOrderModifiedDate",gxold:"O53PurchaseOrderModifiedDate",gxvar:"A53PurchaseOrderModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERMODIFIEDDATE",gx.O.A53PurchaseOrderModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERMODIFIEDDATE")},nac:gx.falseFn};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERACTIVE",fmt:0,gxz:"Z79PurchaseOrderActive",gxold:"O79PurchaseOrderActive",gxvar:"A79PurchaseOrderActive",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A79PurchaseOrderActive=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z79PurchaseOrderActive=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("PURCHASEORDERACTIVE",gx.O.A79PurchaseOrderActive,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A79PurchaseOrderActive=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERACTIVE")},nac:gx.falseFn,values:["true","false"]};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILSQUANTITY",fmt:0,gxz:"Z67PurchaseOrderDetailsQuantity",gxold:"O67PurchaseOrderDetailsQuantity",gxvar:"A67PurchaseOrderDetailsQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A67PurchaseOrderDetailsQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z67PurchaseOrderDetailsQuantity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERDETAILSQUANTITY",gx.O.A67PurchaseOrderDetailsQuantity,0)},c2v:function(){this.val()!==undefined&&(gx.O.A67PurchaseOrderDetailsQuantity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PURCHASEORDERDETAILSQUANTITY",",")},nac:gx.falseFn};n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"DETAILTABLE",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"TITLEDETAIL",format:0,grid:0,ctrltype:"textblock"};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[84]={id:84,lvl:12,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:1,grid:83,gxgrid:this.Gridpurchaseorder_detailContainer,fnc:this.Valid_Purchaseorderdetailid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILID",fmt:0,gxz:"Z61PurchaseOrderDetailId",gxold:"O61PurchaseOrderDetailId",gxvar:"A61PurchaseOrderDetailId",ucs:[],op:[84,74],ip:[74,84],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z61PurchaseOrderDetailId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(83),gx.O.A61PurchaseOrderDetailId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(83),",")},nac:gx.falseFn};n[85]={id:85,lvl:12,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:1,grid:83,gxgrid:this.Gridpurchaseorder_detailContainer,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[86],ip:[86,85],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(83),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(83),",")},nac:gx.falseFn};n[86]={id:86,lvl:12,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:1,grid:83,gxgrid:this.Gridpurchaseorder_detailContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(83),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(83))},nac:gx.falseFn};n[87]={id:87,lvl:12,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:1,grid:83,gxgrid:this.Gridpurchaseorder_detailContainer,fnc:this.Valid_Purchaseorderdetailquantityord,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYORD",fmt:0,gxz:"Z76PurchaseOrderDetailQuantityOrd",gxold:"O76PurchaseOrderDetailQuantityOrd",gxvar:"A76PurchaseOrderDetailQuantityOrd",ucs:[],op:[87],ip:[87],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(83),gx.O.A76PurchaseOrderDetailQuantityOrd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(83),",")},nac:gx.falseFn};n[88]={id:88,lvl:12,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,isacc:1,grid:83,gxgrid:this.Gridpurchaseorder_detailContainer,fnc:this.Valid_Purchaseorderdetailquantityrec,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYREC",fmt:0,gxz:"Z77PurchaseOrderDetailQuantityRec",gxold:"O77PurchaseOrderDetailQuantityRec",gxvar:"A77PurchaseOrderDetailQuantityRec",ucs:[],op:[88,74],ip:[88],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(83),gx.O.A77PurchaseOrderDetailQuantityRec,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(83),",")},nac:gx.falseFn};n[89]={id:89,fld:"",grid:0};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"BTN_ENTER",grid:0,evt:"e130710_client",std:"ENTER"};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"BTN_CANCEL",grid:0,evt:"e140710_client"};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"BTN_DELETE",grid:0,evt:"e200710_client",std:"DELETE"};n[98]={id:98,fld:"PROMPT_4",grid:10};n[99]={id:99,fld:"PROMPT_15",grid:12};this.A50PurchaseOrderId=0;this.Z50PurchaseOrderId=0;this.O50PurchaseOrderId=0;this.A4SupplierId=0;this.Z4SupplierId=0;this.O4SupplierId=0;this.A5SupplierName="";this.Z5SupplierName="";this.O5SupplierName="";this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.Z52PurchaseOrderCreatedDate=gx.date.nullDate();this.O52PurchaseOrderCreatedDate=gx.date.nullDate();this.A78PurchaseOrderTotalPaid=0;this.Z78PurchaseOrderTotalPaid=0;this.O78PurchaseOrderTotalPaid=0;this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.Z66PurchaseOrderClosedDate=gx.date.nullDate();this.O66PurchaseOrderClosedDate=gx.date.nullDate();this.A53PurchaseOrderModifiedDate=gx.date.nullDate();this.Z53PurchaseOrderModifiedDate=gx.date.nullDate();this.O53PurchaseOrderModifiedDate=gx.date.nullDate();this.A79PurchaseOrderActive=!1;this.Z79PurchaseOrderActive=!1;this.O79PurchaseOrderActive=!1;this.A67PurchaseOrderDetailsQuantity=0;this.Z67PurchaseOrderDetailsQuantity=0;this.O67PurchaseOrderDetailsQuantity=0;this.Z61PurchaseOrderDetailId=0;this.O61PurchaseOrderDetailId=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z16ProductName="";this.O16ProductName="";this.Z76PurchaseOrderDetailQuantityOrd=0;this.O76PurchaseOrderDetailQuantityOrd=0;this.Z77PurchaseOrderDetailQuantityRec=0;this.O77PurchaseOrderDetailQuantityRec=0;this.A61PurchaseOrderDetailId=0;this.A15ProductId=0;this.A16ProductName="";this.A76PurchaseOrderDetailQuantityOrd=0;this.A77PurchaseOrderDetailQuantityRec=0;this.A134PurchaseOrderDetailSuggestedPr=0;this.AV16Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_SupplierId=0;this.AV17GXV1=0;this.AV12TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV13PurchaseOrderId=0;this.AV10WebSession={};this.A50PurchaseOrderId=0;this.A4SupplierId=0;this.Gx_date=gx.date.nullDate();this.Gx_BScreen=0;this.A5SupplierName="";this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.A78PurchaseOrderTotalPaid=0;this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.A53PurchaseOrderModifiedDate=gx.date.nullDate();this.A135PurchaseOrderConfirmatedDate=gx.date.nullDate();this.A79PurchaseOrderActive=!1;this.A136PurchaseOrderCanceledDescripti="";this.A138PurchaseOrderWasPaid=!1;this.A139PurchaseOrderPaidDate=gx.date.nullDate();this.A67PurchaseOrderDetailsQuantity=0;this.A96PurchaseOrderLastDetailId=0;this.Gx_mode="";this.Events={e12072_client:["AFTER TRN",!0],e130710_client:["ENTER",!0],e140710_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV13PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV13PurchaseOrderId",fld:"vPURCHASEORDERID",pic:"ZZZZZ9",hsh:!0},{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"},{av:"A66PurchaseOrderClosedDate",fld:"PURCHASEORDERCLOSEDDATE",pic:""},{av:"A53PurchaseOrderModifiedDate",fld:"PURCHASEORDERMODIFIEDDATE",pic:""},{av:"A135PurchaseOrderConfirmatedDate",fld:"PURCHASEORDERCONFIRMATEDDATE",pic:""},{av:"A136PurchaseOrderCanceledDescripti",fld:"PURCHASEORDERCANCELEDDESCRIPTI",pic:""},{av:"A138PurchaseOrderWasPaid",fld:"PURCHASEORDERWASPAID",pic:""},{av:"A139PurchaseOrderPaidDate",fld:"PURCHASEORDERPAIDDATE",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERID=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"},{av:"A67PurchaseOrderDetailsQuantity",fld:"PURCHASEORDERDETAILSQUANTITY",pic:"ZZZ9"},{av:"A96PurchaseOrderLastDetailId",fld:"PURCHASEORDERLASTDETAILID",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A67PurchaseOrderDetailsQuantity",fld:"PURCHASEORDERDETAILSQUANTITY",pic:"ZZZ9"},{av:"A96PurchaseOrderLastDetailId",fld:"PURCHASEORDERLASTDETAILID",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_SUPPLIERID=[[{av:"A4SupplierId",fld:"SUPPLIERID",pic:"ZZZZZ9"},{av:"A5SupplierName",fld:"SUPPLIERNAME",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A5SupplierName",fld:"SUPPLIERNAME",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERCREATEDDATE=[[{av:"A52PurchaseOrderCreatedDate",fld:"PURCHASEORDERCREATEDDATE",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A52PurchaseOrderCreatedDate",fld:"PURCHASEORDERCREATEDDATE",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERTOTALPAID=[[{av:"A78PurchaseOrderTotalPaid",fld:"PURCHASEORDERTOTALPAID",pic:"ZZZZZZZZZZZZZZ9.99"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A78PurchaseOrderTotalPaid",fld:"PURCHASEORDERTOTALPAID",pic:"ZZZZZZZZZZZZZZ9.99"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERDETAILID=[[{av:"A67PurchaseOrderDetailsQuantity",fld:"PURCHASEORDERDETAILSQUANTITY",pic:"ZZZ9"},{av:"A61PurchaseOrderDetailId",fld:"PURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A61PurchaseOrderDetailId",fld:"PURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"A67PurchaseOrderDetailsQuantity",fld:"PURCHASEORDERDETAILSQUANTITY",pic:"ZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PRODUCTID=[[{av:"A15ProductId",fld:"PRODUCTID",pic:"ZZZZZ9"},{av:"A16ProductName",fld:"PRODUCTNAME",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A16ProductName",fld:"PRODUCTNAME",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERDETAILQUANTITYORD=[[{av:"A76PurchaseOrderDetailQuantityOrd",fld:"PURCHASEORDERDETAILQUANTITYORD",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A76PurchaseOrderDetailQuantityOrd",fld:"PURCHASEORDERDETAILQUANTITYORD",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.EvtParms.VALID_PURCHASEORDERDETAILQUANTITYREC=[[{av:"A77PurchaseOrderDetailQuantityRec",fld:"PURCHASEORDERDETAILQUANTITYREC",pic:"ZZZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[{av:"A77PurchaseOrderDetailQuantityRec",fld:"PURCHASEORDERDETAILQUANTITYREC",pic:"ZZZZZ9"},{av:"A67PurchaseOrderDetailsQuantity",fld:"PURCHASEORDERDETAILSQUANTITY",pic:"ZZZ9"},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}]];this.setPrompt("PROMPT_4",[39]);this.setPrompt("PROMPT_15",[85]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV13PurchaseOrderId","vPURCHASEORDERID",0,"int",6,0);this.setVCMap("AV11Insert_SupplierId","vINSERT_SUPPLIERID",0,"int",6,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("A135PurchaseOrderConfirmatedDate","PURCHASEORDERCONFIRMATEDDATE",0,"date",8,0);this.setVCMap("A136PurchaseOrderCanceledDescripti","PURCHASEORDERCANCELEDDESCRIPTI",0,"svchar",200,0);this.setVCMap("A138PurchaseOrderWasPaid","PURCHASEORDERWASPAID",0,"boolean",4,0);this.setVCMap("A139PurchaseOrderPaidDate","PURCHASEORDERPAIDDATE",0,"date",8,0);this.setVCMap("A96PurchaseOrderLastDetailId","PURCHASEORDERLASTDETAILID",0,"int",6,0);this.setVCMap("AV16Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("A134PurchaseOrderDetailSuggestedPr","PURCHASEORDERDETAILSUGGESTEDPR",83,"decimal",18,2);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"GeneralUITransactionContext",0,0);t.addPostingVar({rfrVar:"A96PurchaseOrderLastDetailId"});t.addPostingVar({rfrVar:"Gx_BScreen"});t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize();this.LvlOlds[10]=["O96PurchaseOrderLastDetailId","O67PurchaseOrderDetailsQuantity"]});gx.wi(function(){gx.createParentObj(this.purchaseorder)})