gx.evt.autoSkip=!1;gx.define("paymentmethodgeneral",!0,function(n){this.ServerClass="paymentmethodgeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="paymentmethodgeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV12ErrorMessage=gx.fn.getControlValue("vERRORMESSAGE")};this.Valid_Paymentmethodid=function(){return this.validCliEvt("Valid_Paymentmethodid",0,function(){try{var n=gx.util.balloon.getNew("PAYMENTMETHODID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e114c1_client=function(){return this.clearMessages(),this.call("paymentmethod.aspx",["UPD",this.A115PaymentMethodId],null,["Mode","PaymentMethodId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e144c2_client=function(){return this.executeServerEvent("'DEACTIVE'",!1,null,!1,!1)};this.e154c2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e164c2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37];this.GXLastCtrlId=37;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e114c1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDEACTIVE",grid:0,evt:"e144c2_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"svchar",len:200,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODDESCRIPTION",fmt:0,gxz:"Z116PaymentMethodDescription",gxold:"O116PaymentMethodDescription",gxvar:"A116PaymentMethodDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A116PaymentMethodDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z116PaymentMethodDescription=n)},v2c:function(){gx.fn.setControlValue("PAYMENTMETHODDESCRIPTION",gx.O.A116PaymentMethodDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A116PaymentMethodDescription=this.val())},val:function(){return gx.fn.getControlValue("PAYMENTMETHODDESCRIPTION")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"decimal",len:8,dec:2,sign:!0,pic:"ZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODDISCOUNT",fmt:0,gxz:"Z129PaymentMethodDiscount",gxold:"O129PaymentMethodDiscount",gxvar:"A129PaymentMethodDiscount",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A129PaymentMethodDiscount=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z129PaymentMethodDiscount=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PAYMENTMETHODDISCOUNT",gx.O.A129PaymentMethodDiscount,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A129PaymentMethodDiscount=this.val())},val:function(){return gx.fn.getDecimalValue("PAYMENTMETHODDISCOUNT",",",".")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"decimal",len:8,dec:2,sign:!0,pic:"ZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODRECARGE",fmt:0,gxz:"Z130PaymentMethodRecarge",gxold:"O130PaymentMethodRecarge",gxvar:"A130PaymentMethodRecarge",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A130PaymentMethodRecarge=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z130PaymentMethodRecarge=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("PAYMENTMETHODRECARGE",gx.O.A130PaymentMethodRecarge,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A130PaymentMethodRecarge=this.val())},val:function(){return gx.fn.getDecimalValue("PAYMENTMETHODRECARGE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODACTIVE",fmt:0,gxz:"Z117PaymentMethodActive",gxold:"O117PaymentMethodActive",gxvar:"A117PaymentMethodActive",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A117PaymentMethodActive=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z117PaymentMethodActive=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("PAYMENTMETHODACTIVE",gx.O.A117PaymentMethodActive,!0)},c2v:function(){this.val()!==undefined&&(gx.O.A117PaymentMethodActive=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("PAYMENTMETHODACTIVE")},nac:gx.falseFn,values:["true","false"]};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Paymentmethodid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODID",fmt:0,gxz:"Z115PaymentMethodId",gxold:"O115PaymentMethodId",gxvar:"A115PaymentMethodId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A115PaymentMethodId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z115PaymentMethodId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAYMENTMETHODID",gx.O.A115PaymentMethodId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A115PaymentMethodId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAYMENTMETHODID",",")},nac:gx.falseFn};this.declareDomainHdlr(37,function(){});this.A116PaymentMethodDescription="";this.Z116PaymentMethodDescription="";this.O116PaymentMethodDescription="";this.A129PaymentMethodDiscount=0;this.Z129PaymentMethodDiscount=0;this.O129PaymentMethodDiscount=0;this.A130PaymentMethodRecarge=0;this.Z130PaymentMethodRecarge=0;this.O130PaymentMethodRecarge=0;this.A117PaymentMethodActive=!1;this.Z117PaymentMethodActive=!1;this.O117PaymentMethodActive=!1;this.A115PaymentMethodId=0;this.Z115PaymentMethodId=0;this.O115PaymentMethodId=0;this.A116PaymentMethodDescription="";this.A129PaymentMethodDiscount=0;this.A130PaymentMethodRecarge=0;this.A117PaymentMethodActive=!1;this.A115PaymentMethodId=0;this.AV12ErrorMessage="";this.Events={e144c2_client:["'DEACTIVE'",!0],e154c2_client:["ENTER",!0],e164c2_client:["CANCEL",!0],e114c1_client:["'DOUPDATE'",!1]};this.EvtParms.REFRESH=[[{av:"A115PaymentMethodId",fld:"PAYMENTMETHODID",pic:"ZZZZZ9"},{av:"A117PaymentMethodActive",fld:"PAYMENTMETHODACTIVE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A115PaymentMethodId",fld:"PAYMENTMETHODID",pic:"ZZZZZ9"}],[]];this.EvtParms["'DEACTIVE'"]=[[{av:"A115PaymentMethodId",fld:"PAYMENTMETHODID",pic:"ZZZZZ9"},{av:"A117PaymentMethodActive",fld:"PAYMENTMETHODACTIVE",pic:"",hsh:!0},{av:"AV12ErrorMessage",fld:"vERRORMESSAGE",pic:""}],[{av:"AV12ErrorMessage",fld:"vERRORMESSAGE",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PAYMENTMETHODID=[[],[]];this.setVCMap("AV12ErrorMessage","vERRORMESSAGE",0,"svchar",250,0);this.Initialize()})