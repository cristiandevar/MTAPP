gx.evt.autoSkip=!1;gx.define("purchaseordergeneral",!0,function(n){this.ServerClass="purchaseordergeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="purchaseordergeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){};this.Valid_Purchaseorderid=function(){return this.validCliEvt("Valid_Purchaseorderid",0,function(){try{var n=gx.util.balloon.getNew("PURCHASEORDERID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11131_client=function(){return this.clearMessages(),this.call("purchaseorder.aspx",["UPD",this.A50PurchaseOrderId],null,["Mode","PurchaseOrderId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12131_client=function(){return this.clearMessages(),this.call("purchaseorder.aspx",["DLT",this.A50PurchaseOrderId],null,["Mode","PurchaseOrderId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15132_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16132_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38];this.GXLastCtrlId=38;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11131_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12131_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Purchaseorderid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERID",fmt:0,gxz:"Z50PurchaseOrderId",gxold:"O50PurchaseOrderId",gxvar:"A50PurchaseOrderId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z50PurchaseOrderId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERID",gx.O.A50PurchaseOrderId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PURCHASEORDERID",",")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERNAME",fmt:0,gxz:"Z5SupplierName",gxold:"O5SupplierName",gxvar:"A5SupplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5SupplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5SupplierName=n)},v2c:function(){gx.fn.setControlValue("SUPPLIERNAME",gx.O.A5SupplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5SupplierName=this.val())},val:function(){return gx.fn.getControlValue("SUPPLIERNAME")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCREATEDDATE",fmt:0,gxz:"Z52PurchaseOrderCreatedDate",gxold:"O52PurchaseOrderCreatedDate",gxvar:"A52PurchaseOrderCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCREATEDDATE",gx.O.A52PurchaseOrderCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A52PurchaseOrderCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCREATEDDATE")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERCLOSEDDATE",fmt:0,gxz:"Z66PurchaseOrderClosedDate",gxold:"O66PurchaseOrderClosedDate",gxvar:"A66PurchaseOrderClosedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERCLOSEDDATE",gx.O.A66PurchaseOrderClosedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A66PurchaseOrderClosedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("PURCHASEORDERCLOSEDDATE")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILSQUANTITY",fmt:0,gxz:"Z67PurchaseOrderDetailsQuantity",gxold:"O67PurchaseOrderDetailsQuantity",gxvar:"A67PurchaseOrderDetailsQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A67PurchaseOrderDetailsQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z67PurchaseOrderDetailsQuantity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PURCHASEORDERDETAILSQUANTITY",gx.O.A67PurchaseOrderDetailsQuantity,0)},c2v:function(){this.val()!==undefined&&(gx.O.A67PurchaseOrderDetailsQuantity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PURCHASEORDERDETAILSQUANTITY",",")},nac:gx.falseFn};this.A50PurchaseOrderId=0;this.Z50PurchaseOrderId=0;this.O50PurchaseOrderId=0;this.A5SupplierName="";this.Z5SupplierName="";this.O5SupplierName="";this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.Z52PurchaseOrderCreatedDate=gx.date.nullDate();this.O52PurchaseOrderCreatedDate=gx.date.nullDate();this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.Z66PurchaseOrderClosedDate=gx.date.nullDate();this.O66PurchaseOrderClosedDate=gx.date.nullDate();this.A67PurchaseOrderDetailsQuantity=0;this.Z67PurchaseOrderDetailsQuantity=0;this.O67PurchaseOrderDetailsQuantity=0;this.A50PurchaseOrderId=0;this.A5SupplierName="";this.A52PurchaseOrderCreatedDate=gx.date.nullDate();this.A66PurchaseOrderClosedDate=gx.date.nullDate();this.A67PurchaseOrderDetailsQuantity=0;this.A4SupplierId=0;this.Events={e15132_client:["ENTER",!0],e16132_client:["CANCEL",!0],e11131_client:["'DOUPDATE'",!1],e12131_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A50PurchaseOrderId",fld:"PURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PURCHASEORDERID=[[],[]];this.Initialize()})