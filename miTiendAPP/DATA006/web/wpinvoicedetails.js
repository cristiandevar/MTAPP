gx.evt.autoSkip=!1;gx.define("wpinvoicedetails",!1,function(){var n,t,i;this.ServerClass="wpinvoicedetails";this.PackageName="GeneXus.Programs";this.ServerFullClass="wpinvoicedetails.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.A98InvoiceDetailIsWholesale=gx.fn.getControlValue("INVOICEDETAILISWHOLESALE")};this.Valid_Paymentmethodid=function(){var n=gx.fn.currentGridRowImpl(52);return this.validCliEvt("Valid_Paymentmethodid",52,function(){try{if(gx.fn.currentGridRowImpl(52)===0)return!0;var n=gx.util.balloon.getNew("PAYMENTMETHODID",gx.fn.currentGridRowImpl(52));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Invoiceid=function(){return this.validCliEvt("Valid_Invoiceid",0,function(){try{var n=gx.util.balloon.getNew("INVOICEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productid=function(){var n=gx.fn.currentGridRowImpl(36);return this.validCliEvt("Valid_Productid",36,function(){try{if(gx.fn.currentGridRowImpl(36)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(36));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Type=function(){var n=gx.fn.currentGridRowImpl(36);return this.validCliEvt("Validv_Type",36,function(){try{var n=gx.util.balloon.getNew("vTYPE");if(this.AnyError=0,!(gx.text.compare(this.AV8Type,"Wholesale")==0||gx.text.compare(this.AV8Type,"Retail")==0||gx.text.compare("",this.AV8Type)===0))try{n.setError("Field Type is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e113q1_client=function(){return this.clearMessages(),this.AV9window.Url=gx.http.formatLink("ainvoiceregister.aspx",[this.A20InvoiceId]),this.AV9window.ReturnParms=[],this.AV9window.Height=gx.num.trunc(500,0),this.AV9window.Width=gx.num.trunc(500,0),this.popupOpen(this.AV9window),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e153q2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e163q2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,53,54,55,56,57];this.GXLastCtrlId=57;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",36,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wpinvoicedetails",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addSingleLineEdit(15,37,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!1,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(55,38,"PRODUCTCODE","Code","","ProductCode","svchar",0,"px",100,80,"left",null,[],55,"ProductCode",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(16,39,"PRODUCTNAME","Product","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(26,40,"INVOICEDETAILQUANTITY","Quantity","","InvoiceDetailQuantity","int",0,"px",6,6,"right",null,[],26,"InvoiceDetailQuantity",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(65,41,"INVOICEDETAILHISTORICPRICE","Price","","InvoiceDetailHistoricPrice","decimal",0,"px",18,18,"right",null,[],65,"InvoiceDetailHistoricPrice",!0,2,!1,!1,"Attribute",0,"");t.addComboBox("Type",42,"vTYPE","Sale Type","Type","svchar",null,0,!0,!1,0,"px","");this.Grid1Container.emptyText="";this.setGrid(t);this.Grid2Container=new gx.grid.grid(this,3,"WbpLvl3",52,"Grid2","Grid2","Grid2Container",this.CmpContext,this.IsMasterPage,"wpinvoicedetails",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.Grid2Container;i.addSingleLineEdit(115,53,"PAYMENTMETHODID","Payment Method Id","","PaymentMethodId","int",0,"px",6,6,"right",null,[],115,"PaymentMethodId",!1,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit(116,54,"PAYMENTMETHODDESCRIPTION","Method","","PaymentMethodDescription","svchar",0,"px",200,80,"left",null,[],116,"PaymentMethodDescription",!0,0,!1,!1,"Attribute",0,"");i.addSingleLineEdit(120,55,"INVOICEPAYMENTMETHODIMPORT","Import","","InvoicePaymentMethodImport","decimal",0,"px",18,18,"right",null,[],120,"InvoicePaymentMethodImport",!0,2,!1,!1,"Attribute",0,"");i.addSingleLineEdit(133,56,"INVOICEPAYMENTMETHODDISCOUNTIM","Discount","","InvoicePaymentMethodDiscountIm","decimal",0,"px",18,18,"right",null,[],133,"InvoicePaymentMethodDiscountIm",!0,2,!1,!1,"Attribute",0,"");i.addSingleLineEdit(132,57,"INVOICEPAYMENTMETHODRECHARGEIM","Recharge","","InvoicePaymentMethodRechargeIm","decimal",0,"px",18,18,"right",null,[],132,"InvoicePaymentMethodRechargeIm",!0,2,!1,!1,"Attribute",0,"");this.Grid2Container.emptyText="";this.setGrid(i);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TICKET",grid:0,evt:"e113q1_client"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Invoiceid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container,this.Grid2Container],fld:"INVOICEID",fmt:0,gxz:"Z20InvoiceId",gxold:"O20InvoiceId",gxvar:"A20InvoiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z20InvoiceId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("INVOICEID",gx.O.A20InvoiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("INVOICEID",",")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICETOTALRECEIVABLE",fmt:0,gxz:"Z80InvoiceTotalReceivable",gxold:"O80InvoiceTotalReceivable",gxvar:"A80InvoiceTotalReceivable",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A80InvoiceTotalReceivable=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z80InvoiceTotalReceivable=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("INVOICETOTALRECEIVABLE",gx.O.A80InvoiceTotalReceivable,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A80InvoiceTotalReceivable=this.val())},val:function(){return gx.fn.getDecimalValue("INVOICETOTALRECEIVABLE",",",".")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICECREATEDDATE",fmt:0,gxz:"Z38InvoiceCreatedDate",gxold:"O38InvoiceCreatedDate",gxvar:"A38InvoiceCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38InvoiceCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z38InvoiceCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("INVOICECREATEDDATE",gx.O.A38InvoiceCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A38InvoiceCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("INVOICECREATEDDATE")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[37]={id:37,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(36),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(36),",")},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCODE",fmt:0,gxz:"Z55ProductCode",gxold:"O55ProductCode",gxvar:"A55ProductCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A55ProductCode=n)},v2z:function(n){n!==undefined&&(gx.O.Z55ProductCode=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(36),gx.O.A55ProductCode,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A55ProductCode=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(36))},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(36),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(36))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEDETAILQUANTITY",fmt:0,gxz:"Z26InvoiceDetailQuantity",gxold:"O26InvoiceDetailQuantity",gxvar:"A26InvoiceDetailQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26InvoiceDetailQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z26InvoiceDetailQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEDETAILQUANTITY",n||gx.fn.currentGridRowImpl(36),gx.O.A26InvoiceDetailQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A26InvoiceDetailQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVOICEDETAILQUANTITY",n||gx.fn.currentGridRowImpl(36),",")},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEDETAILHISTORICPRICE",fmt:0,gxz:"Z65InvoiceDetailHistoricPrice",gxold:"O65InvoiceDetailHistoricPrice",gxvar:"A65InvoiceDetailHistoricPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A65InvoiceDetailHistoricPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z65InvoiceDetailHistoricPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("INVOICEDETAILHISTORICPRICE",n||gx.fn.currentGridRowImpl(36),gx.O.A65InvoiceDetailHistoricPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A65InvoiceDetailHistoricPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("INVOICEDETAILHISTORICPRICE",n||gx.fn.currentGridRowImpl(36),",",".")},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:36,gxgrid:this.Grid1Container,fnc:this.Validv_Type,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPE",fmt:0,gxz:"ZV8Type",gxold:"OV8Type",gxvar:"AV8Type",ucs:[],op:[42],ip:[42],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8Type=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8Type=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vTYPE",n||gx.fn.currentGridRowImpl(36),gx.O.AV8Type);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8Type=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTYPE",n||gx.fn.currentGridRowImpl(36))},nac:gx.falseFn};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[53]={id:53,lvl:3,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:52,gxgrid:this.Grid2Container,fnc:this.Valid_Paymentmethodid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODID",fmt:0,gxz:"Z115PaymentMethodId",gxold:"O115PaymentMethodId",gxvar:"A115PaymentMethodId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A115PaymentMethodId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z115PaymentMethodId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PAYMENTMETHODID",n||gx.fn.currentGridRowImpl(52),gx.O.A115PaymentMethodId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A115PaymentMethodId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PAYMENTMETHODID",n||gx.fn.currentGridRowImpl(52),",")},nac:gx.falseFn};n[54]={id:54,lvl:3,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,grid:52,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAYMENTMETHODDESCRIPTION",fmt:0,gxz:"Z116PaymentMethodDescription",gxold:"O116PaymentMethodDescription",gxvar:"A116PaymentMethodDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A116PaymentMethodDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z116PaymentMethodDescription=n)},v2c:function(n){gx.fn.setGridControlValue("PAYMENTMETHODDESCRIPTION",n||gx.fn.currentGridRowImpl(52),gx.O.A116PaymentMethodDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A116PaymentMethodDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAYMENTMETHODDESCRIPTION",n||gx.fn.currentGridRowImpl(52))},nac:gx.falseFn};n[55]={id:55,lvl:3,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:52,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEPAYMENTMETHODIMPORT",fmt:0,gxz:"Z120InvoicePaymentMethodImport",gxold:"O120InvoicePaymentMethodImport",gxvar:"A120InvoicePaymentMethodImport",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A120InvoicePaymentMethodImport=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z120InvoicePaymentMethodImport=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("INVOICEPAYMENTMETHODIMPORT",n||gx.fn.currentGridRowImpl(52),gx.O.A120InvoicePaymentMethodImport,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A120InvoicePaymentMethodImport=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("INVOICEPAYMENTMETHODIMPORT",n||gx.fn.currentGridRowImpl(52),",",".")},nac:gx.falseFn};n[56]={id:56,lvl:3,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:52,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEPAYMENTMETHODDISCOUNTIM",fmt:0,gxz:"Z133InvoicePaymentMethodDiscountIm",gxold:"O133InvoicePaymentMethodDiscountIm",gxvar:"A133InvoicePaymentMethodDiscountIm",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A133InvoicePaymentMethodDiscountIm=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z133InvoicePaymentMethodDiscountIm=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("INVOICEPAYMENTMETHODDISCOUNTIM",n||gx.fn.currentGridRowImpl(52),gx.O.A133InvoicePaymentMethodDiscountIm,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A133InvoicePaymentMethodDiscountIm=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("INVOICEPAYMENTMETHODDISCOUNTIM",n||gx.fn.currentGridRowImpl(52),",",".")},nac:gx.falseFn};n[57]={id:57,lvl:3,type:"decimal",len:18,dec:2,sign:!1,pic:"ZZZZZZZZZZZZZZ9.99",ro:1,isacc:0,grid:52,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEPAYMENTMETHODRECHARGEIM",fmt:0,gxz:"Z132InvoicePaymentMethodRechargeIm",gxold:"O132InvoicePaymentMethodRechargeIm",gxvar:"A132InvoicePaymentMethodRechargeIm",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A132InvoicePaymentMethodRechargeIm=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z132InvoicePaymentMethodRechargeIm=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("INVOICEPAYMENTMETHODRECHARGEIM",n||gx.fn.currentGridRowImpl(52),gx.O.A132InvoicePaymentMethodRechargeIm,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A132InvoicePaymentMethodRechargeIm=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("INVOICEPAYMENTMETHODRECHARGEIM",n||gx.fn.currentGridRowImpl(52),",",".")},nac:gx.falseFn};this.A20InvoiceId=0;this.Z20InvoiceId=0;this.O20InvoiceId=0;this.A80InvoiceTotalReceivable=0;this.Z80InvoiceTotalReceivable=0;this.O80InvoiceTotalReceivable=0;this.A38InvoiceCreatedDate=gx.date.nullDate();this.Z38InvoiceCreatedDate=gx.date.nullDate();this.O38InvoiceCreatedDate=gx.date.nullDate();this.Z15ProductId=0;this.O15ProductId=0;this.Z55ProductCode="";this.O55ProductCode="";this.Z16ProductName="";this.O16ProductName="";this.Z26InvoiceDetailQuantity=0;this.O26InvoiceDetailQuantity=0;this.Z65InvoiceDetailHistoricPrice=0;this.O65InvoiceDetailHistoricPrice=0;this.ZV8Type="";this.OV8Type="";this.Z115PaymentMethodId=0;this.O115PaymentMethodId=0;this.Z116PaymentMethodDescription="";this.O116PaymentMethodDescription="";this.Z120InvoicePaymentMethodImport=0;this.O120InvoicePaymentMethodImport=0;this.Z133InvoicePaymentMethodDiscountIm=0;this.O133InvoicePaymentMethodDiscountIm=0;this.Z132InvoicePaymentMethodRechargeIm=0;this.O132InvoicePaymentMethodRechargeIm=0;this.A20InvoiceId=0;this.A80InvoiceTotalReceivable=0;this.A38InvoiceCreatedDate=gx.date.nullDate();this.A115PaymentMethodId=0;this.A116PaymentMethodDescription="";this.A120InvoicePaymentMethodImport=0;this.A133InvoicePaymentMethodDiscountIm=0;this.A132InvoicePaymentMethodRechargeIm=0;this.A98InvoiceDetailIsWholesale=!1;this.A15ProductId=0;this.A55ProductCode="";this.A16ProductName="";this.A26InvoiceDetailQuantity=0;this.A65InvoiceDetailHistoricPrice=0;this.AV8Type="";this.AV9window={};this.Events={e153q2_client:["ENTER",!0],e163q2_client:["CANCEL",!0],e113q1_client:["'TICKET'",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{av:"A20InvoiceId",fld:"INVOICEID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms["GRID1.LOAD"]=[[{av:"A98InvoiceDetailIsWholesale",fld:"INVOICEDETAILISWHOLESALE",pic:""}],[{ctrl:"vTYPE"},{av:"AV8Type",fld:"vTYPE",pic:""}]];this.EvtParms["'TICKET'"]=[[{av:"A20InvoiceId",fld:"INVOICEID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_INVOICEID=[[],[]];this.EvtParms.VALID_PRODUCTID=[[],[]];this.EvtParms.VALIDV_TYPE=[[{ctrl:"vTYPE"},{av:"AV8Type",fld:"vTYPE",pic:""}],[{ctrl:"vTYPE"},{av:"AV8Type",fld:"vTYPE",pic:""}]];this.EvtParms.VALID_PAYMENTMETHODID=[[],[]];this.setVCMap("A98InvoiceDetailIsWholesale","INVOICEDETAILISWHOLESALE",0,"boolean",4,0);t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingParm(this.GXValidFnc[18]);i.addRefreshingVar(this.GXValidFnc[18]);i.addRefreshingParm(this.GXValidFnc[18]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wpinvoicedetails)})