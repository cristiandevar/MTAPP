gx.evt.autoSkip=!1;gx.define("purchaseordergeneral",!0,function(n){this.ServerClass="purchaseordergeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="purchaseordergeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A50PurchaseOrderId=gx.fn.getIntegerValue("PURCHASEORDERID",",");this.A50PurchaseOrderId=gx.fn.getIntegerValue("PURCHASEORDERID",",")};this.Validv_State=function(){return this.validCliEvt("Validv_State",0,function(){try{var n=gx.util.balloon.getNew("vSTATE");if(this.AnyError=0,!(gx.text.compare(this.AV12State,"Pending")==0||gx.text.compare(this.AV12State,"Canceled")==0||gx.text.compare(this.AV12State,"Received")==0||gx.text.compare("",this.AV12State)===0))try{n.setError("Field State is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11131_client=function(){return this.clearMessages(),this.AV13window.Url=gx.http.formatLink("apurchaseordervoucher.aspx",[this.A50PurchaseOrderId]),this.AV13window.ReturnParms=[],this.AV13window.Height=gx.num.trunc(370,0),this.AV13window.Width=gx.num.trunc(500,0),this.popupOpen(this.AV13window),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14132_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15132_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64];this.GXLastCtrlId=64;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNVIEWVOUCHER",grid:0,evt:"e11131_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"ATTRIBUTESTABLE",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCREATEDDATE",fmt:0,gxz:"Z52PurchaseOrderCreatedDate",gxold:"O52PurchaseOrderCreatedDate",gxvar:"A52PurchaseOrderCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCREATEDDATE",gx.O.A52PurchaseOrderCreatedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCREATEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERNAME",fmt:0,gxz:"Z5SupplierName",gxold:"O5SupplierName",gxvar:"A5SupplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5SupplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5SupplierName=n)},v2c:function(){gx.fn.setControlValue("SUPPLIERNAME",gx.O.A5SupplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5SupplierName=this.val())},val:function(){return gx.fn.getControlValue("SUPPLIERNAME")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,lvl:0,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERTOTALPAID",fmt:0,gxz:"Z78PurchaseOrderTotalPaid",gxold:"O78PurchaseOrderTotalPaid",gxvar:"A78PurchaseOrderTotalPaid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z78PurchaseOrderTotalPaid=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PURCHASEORDERTOTALPAID",gx.O.A78PurchaseOrderTotalPaid,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A78PurchaseOrderTotalPaid=this.val())},val:function(){return gx.fn.getDecimalValue("PURCHASEORDERTOTALPAID",",",".")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCLOSEDDATE",fmt:0,gxz:"Z66PurchaseOrderClosedDate",gxold:"O66PurchaseOrderClosedDate",gxvar:"A66PurchaseOrderClosedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCLOSEDDATE",gx.O.A66PurchaseOrderClosedDate,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCLOSEDDATE")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});t[32]={id:32,fld:"",grid:0};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_State,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATE",fmt:0,gxz:"ZV12State",gxold:"OV12State",gxvar:"AV12State",ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV12State=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12State=n)},v2c:function(){gx.fn.setComboBoxValue("vSTATE",gx.O.AV12State);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV12State=this.val())},val:function(){return gx.fn.getControlValue("vSTATE")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCONFIRMATEDDATE",fmt:0,gxz:"Z135PurchaseOrderConfirmatedDate",gxold:"O135PurchaseOrderConfirmatedDate",gxvar:"A135PurchaseOrderConfirmatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A135PurchaseOrderConfirmatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z135PurchaseOrderConfirmatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCONFIRMATEDDATE",gx.O.A135PurchaseOrderConfirmatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A135PurchaseOrderConfirmatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCONFIRMATEDDATE")},nac:gx.falseFn};t[42]={id:42,fld:"",grid:0};t[43]={id:43,fld:"",grid:0};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCANCELEDDESCRIPTI",fmt:0,gxz:"Z136PurchaseOrderCanceledDescripti",gxold:"O136PurchaseOrderCanceledDescripti",gxvar:"A136PurchaseOrderCanceledDescripti",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A136PurchaseOrderCanceledDescripti=n)},v2z:function(n){n!==undefined&&(gx.O.Z136PurchaseOrderCanceledDescripti=n)},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCANCELEDDESCRIPTI",gx.O.A136PurchaseOrderCanceledDescripti,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A136PurchaseOrderCanceledDescripti=this.val())},val:function(){return gx.fn.getControlValue("PURCHASEORDERCANCELEDDESCRIPTI")},nac:gx.falseFn};this.declareDomainHdlr(46,function(){});t[47]={id:47,fld:"",grid:0};t[48]={id:48,fld:"",grid:0};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERWASPAID",fmt:0,gxz:"Z138PurchaseOrderWasPaid",gxold:"O138PurchaseOrderWasPaid",gxvar:"A138PurchaseOrderWasPaid",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A138PurchaseOrderWasPaid=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z138PurchaseOrderWasPaid=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("PURCHASEORDERWASPAID",gx.O.A138PurchaseOrderWasPaid,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A138PurchaseOrderWasPaid=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERWASPAID")},nac:gx.falseFn,values:["true","false"]};t[52]={id:52,fld:"",grid:0};t[53]={id:53,fld:"",grid:0};t[54]={id:54,fld:"",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERPAIDDATE",fmt:0,gxz:"Z139PurchaseOrderPaidDate",gxold:"O139PurchaseOrderPaidDate",gxvar:"A139PurchaseOrderPaidDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A139PurchaseOrderPaidDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z139PurchaseOrderPaidDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERPAIDDATE",gx.O.A139PurchaseOrderPaidDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A139PurchaseOrderPaidDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERPAIDDATE")},nac:gx.falseFn};t[57]={id:57,fld:"",grid:0};t[58]={id:58,fld:"",grid:0};t[59]={id:59,fld:"",grid:0};t[60]={id:60,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERMODIFIEDDATE",fmt:0,gxz:"Z53PurchaseOrderModifiedDate",gxold:"O53PurchaseOrderModifiedDate",gxvar:"A53PurchaseOrderModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERMODIFIEDDATE",gx.O.A53PurchaseOrderModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A53PurchaseOrderModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERMODIFIEDDATE")},nac:gx.falseFn};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,fld:"",grid:0};t[64]={id:64,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERACTIVE",fmt:0,gxz:"Z79PurchaseOrderActive",gxold:"O79PurchaseOrderActive",gxvar:"A79PurchaseOrderActive",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A79PurchaseOrderActive=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z79PurchaseOrderActive=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERACTIVE",gx.O.A79PurchaseOrderActive,0)},c2v:function(){this.val()!==undefined&&(gx.O.A79PurchaseOrderActive=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERACTIVE")},nac:gx.falseFn};this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.Z52PurchaseOrderCreatedDate=gx.date.nullDate();this.O52PurchaseOrderCreatedDate=gx.date.nullDate();this.A5SupplierName="";this.Z5SupplierName="";this.O5SupplierName="";this.A78PurchaseOrderTotalPaid=0;this.Z78PurchaseOrderTotalPaid=0;this.O78PurchaseOrderTotalPaid=0;this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.Z66PurchaseOrderClosedDate=gx.date.nullDate();this.O66PurchaseOrderClosedDate=gx.date.nullDate();this.AV12State="";this.ZV12State="";this.OV12State="";this.A135PurchaseOrderConfirmatedDate=gx.date.nullDate();this.Z135PurchaseOrderConfirmatedDate=gx.date.nullDate();this.O135PurchaseOrderConfirmatedDate=gx.date.nullDate();this.A136PurchaseOrderCanceledDescripti="";this.Z136PurchaseOrderCanceledDescripti="";this.O136PurchaseOrderCanceledDescripti="";this.A138PurchaseOrderWasPaid=!1;this.Z138PurchaseOrderWasPaid=!1;this.O138PurchaseOrderWasPaid=!1;this.A139PurchaseOrderPaidDate=gx.date.nullDate();this.Z139PurchaseOrderPaidDate=gx.date.nullDate();this.O139PurchaseOrderPaidDate=gx.date.nullDate();this.A53PurchaseOrderModifiedDate=gx.date.nullDate();this.Z53PurchaseOrderModifiedDate=gx.date.nullDate();this.O53PurchaseOrderModifiedDate=gx.date.nullDate();this.A79PurchaseOrderActive=!1;this.Z79PurchaseOrderActive=!1;this.O79PurchaseOrderActive=!1;this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.A5SupplierName="";this.A78PurchaseOrderTotalPaid=0;this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.AV12State="";this.A135PurchaseOrderConfirmatedDate=gx.date.nullDate();this.A136PurchaseOrderCanceledDescripti="";this.A138PurchaseOrderWasPaid=!1;this.A139PurchaseOrderPaidDate=gx.date.nullDate();this.A53PurchaseOrderModifiedDate=gx.date.nullDate();this.A79PurchaseOrderActive=!1;this.A50PurchaseOrderId=0;this.A4SupplierId=0;this.AV13window={};this.Events={e14132_client:["ENTER",!0],e15132_client:["CANCEL",!0],e11131_client:["'DOVIEWVOUCHER'",!1]};this.EvtParms.REFRESH=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"},{av:"A138PurchaseOrderWasPaid",fld:"PURCHASEORDERWASPAID",pic:""},{av:"A66PurchaseOrderClosedDate",fld:"PURCHASEORDERCLOSEDDATE",pic:""},{av:"A79PurchaseOrderActive",fld:"PURCHASEORDERACTIVE",pic:""}],[]];this.EvtParms["'DOVIEWVOUCHER'"]=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_STATE=[[],[]];this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);this.setVCMap("A50PurchaseOrderId","PURCHASEORDERID",0,"int",6,0);this.Initialize()})