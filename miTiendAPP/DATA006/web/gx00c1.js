gx.evt.autoSkip=!1;gx.define("gx00c1",!1,function(){var n,t;this.ServerClass="gx00c1";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00c1.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV11pPurchaseOrderId=gx.fn.getIntegerValue("vPPURCHASEORDERID",",");this.AV12pPurchaseOrderDetailId=gx.fn.getIntegerValue("vPPURCHASEORDERDETAILID",",");this.AV11pPurchaseOrderId=gx.fn.getIntegerValue("vPPURCHASEORDERID",",")};this.e151j1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111j1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILID","Visible",!0)):(gx.fn.setCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILID","Visible")',ctrl:"vCPURCHASEORDERDETAILID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121j1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131j1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILQUANTITYORDERED","Visible",!0)):(gx.fn.setCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILQUANTITYORDERED","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILQUANTITYORDERED","Visible")',ctrl:"vCPURCHASEORDERDETAILQUANTITYORDERED",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141j1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILQUANTITYRECEIVED","Visible",!0)):(gx.fn.setCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPURCHASEORDERDETAILQUANTITYRECEIVED","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILQUANTITYRECEIVED","Visible")',ctrl:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e181j2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e191j1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00c1",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(61,56,"PURCHASEORDERDETAILID","Detail Id","","PurchaseOrderDetailId","int",0,"px",6,6,"right",null,[],61,"PurchaseOrderDetailId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(15,57,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(76,58,"PURCHASEORDERDETAILQUANTITYORD","Quantity Ordered","","PurchaseOrderDetailQuantityOrd","int",0,"px",6,6,"right",null,[],76,"PurchaseOrderDetailQuantityOrd",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(77,59,"PURCHASEORDERDETAILQUANTITYREC","Quantity Received","","PurchaseOrderDetailQuantityRec","int",0,"px",6,6,"right",null,[],77,"PurchaseOrderDetailQuantityRec",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(50,60,"PURCHASEORDERID","Purchase Order Id","","PurchaseOrderId","int",0,"px",6,6,"right",null,[],50,"PurchaseOrderId",!1,0,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"PURCHASEORDERDETAILIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLPURCHASEORDERDETAILIDFILTER",format:1,grid:0,evt:"e111j1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPURCHASEORDERDETAILID",fmt:0,gxz:"ZV6cPurchaseOrderDetailId",gxold:"OV6cPurchaseOrderDetailId",gxvar:"AV6cPurchaseOrderDetailId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cPurchaseOrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cPurchaseOrderDetailId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPURCHASEORDERDETAILID",gx.O.AV6cPurchaseOrderDetailId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cPurchaseOrderDetailId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPURCHASEORDERDETAILID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"PRODUCTIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLPRODUCTIDFILTER",format:1,grid:0,evt:"e121j1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTID",fmt:0,gxz:"ZV8cProductId",gxold:"OV8cProductId",gxvar:"AV8cProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cProductId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTID",gx.O.AV8cProductId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cProductId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTID",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLPURCHASEORDERDETAILQUANTITYORDEREDFILTER",format:1,grid:0,evt:"e131j1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",fmt:0,gxz:"ZV14cPurchaseOrderDetailQuantityOrdered",gxold:"OV14cPurchaseOrderDetailQuantityOrdered",gxvar:"AV14cPurchaseOrderDetailQuantityOrdered",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV14cPurchaseOrderDetailQuantityOrdered=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14cPurchaseOrderDetailQuantityOrdered=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPURCHASEORDERDETAILQUANTITYORDERED",gx.O.AV14cPurchaseOrderDetailQuantityOrdered,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV14cPurchaseOrderDetailQuantityOrdered=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPURCHASEORDERDETAILQUANTITYORDERED",",")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLPURCHASEORDERDETAILQUANTITYRECEIVEDFILTER",format:1,grid:0,evt:"e141j1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",fmt:0,gxz:"ZV15cPurchaseOrderDetailQuantityReceived",gxold:"OV15cPurchaseOrderDetailQuantityReceived",gxvar:"AV15cPurchaseOrderDetailQuantityReceived",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15cPurchaseOrderDetailQuantityReceived=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15cPurchaseOrderDetailQuantityReceived=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPURCHASEORDERDETAILQUANTITYRECEIVED",gx.O.AV15cPurchaseOrderDetailQuantityReceived,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV15cPurchaseOrderDetailQuantityReceived=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPURCHASEORDERDETAILQUANTITYRECEIVED",",")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e151j1_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV18Linkselection_GXI)},c2v:function(n){gx.O.AV18Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV18Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILID",fmt:0,gxz:"Z61PurchaseOrderDetailId",gxold:"O61PurchaseOrderDetailId",gxvar:"A61PurchaseOrderDetailId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z61PurchaseOrderDetailId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(54),gx.O.A61PurchaseOrderDetailId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A61PurchaseOrderDetailId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(54),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYORD",fmt:0,gxz:"Z76PurchaseOrderDetailQuantityOrd",gxold:"O76PurchaseOrderDetailQuantityOrd",gxvar:"A76PurchaseOrderDetailQuantityOrd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z76PurchaseOrderDetailQuantityOrd=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(54),gx.O.A76PurchaseOrderDetailQuantityOrd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A76PurchaseOrderDetailQuantityOrd=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYORD",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERDETAILQUANTITYREC",fmt:0,gxz:"Z77PurchaseOrderDetailQuantityRec",gxold:"O77PurchaseOrderDetailQuantityRec",gxvar:"A77PurchaseOrderDetailQuantityRec",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z77PurchaseOrderDetailQuantityRec=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(54),gx.O.A77PurchaseOrderDetailQuantityRec,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A77PurchaseOrderDetailQuantityRec=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERDETAILQUANTITYREC",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[60]={id:60,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PURCHASEORDERID",fmt:0,gxz:"Z50PurchaseOrderId",gxold:"O50PurchaseOrderId",gxvar:"A50PurchaseOrderId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z50PurchaseOrderId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PURCHASEORDERID",n||gx.fn.currentGridRowImpl(54),gx.O.A50PurchaseOrderId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A50PurchaseOrderId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PURCHASEORDERID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTN_CANCEL",grid:0,evt:"e191j1_client"};this.AV6cPurchaseOrderDetailId=0;this.ZV6cPurchaseOrderDetailId=0;this.OV6cPurchaseOrderDetailId=0;this.AV8cProductId=0;this.ZV8cProductId=0;this.OV8cProductId=0;this.AV14cPurchaseOrderDetailQuantityOrdered=0;this.ZV14cPurchaseOrderDetailQuantityOrdered=0;this.OV14cPurchaseOrderDetailQuantityOrdered=0;this.AV15cPurchaseOrderDetailQuantityReceived=0;this.ZV15cPurchaseOrderDetailQuantityReceived=0;this.OV15cPurchaseOrderDetailQuantityReceived=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z61PurchaseOrderDetailId=0;this.O61PurchaseOrderDetailId=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z76PurchaseOrderDetailQuantityOrd=0;this.O76PurchaseOrderDetailQuantityOrd=0;this.Z77PurchaseOrderDetailQuantityRec=0;this.O77PurchaseOrderDetailQuantityRec=0;this.Z50PurchaseOrderId=0;this.O50PurchaseOrderId=0;this.AV6cPurchaseOrderDetailId=0;this.AV8cProductId=0;this.AV14cPurchaseOrderDetailQuantityOrdered=0;this.AV15cPurchaseOrderDetailQuantityReceived=0;this.AV11pPurchaseOrderId=0;this.AV12pPurchaseOrderDetailId=0;this.AV5LinkSelection="";this.A61PurchaseOrderDetailId=0;this.A15ProductId=0;this.A76PurchaseOrderDetailQuantityOrd=0;this.A77PurchaseOrderDetailQuantityRec=0;this.A50PurchaseOrderId=0;this.Events={e181j2_client:["ENTER",!0],e191j1_client:["CANCEL",!0],e151j1_client:["'TOGGLE'",!1],e111j1_client:["LBLPURCHASEORDERDETAILIDFILTER.CLICK",!1],e121j1_client:["LBLPRODUCTIDFILTER.CLICK",!1],e131j1_client:["LBLPURCHASEORDERDETAILQUANTITYORDEREDFILTER.CLICK",!1],e141j1_client:["LBLPURCHASEORDERDETAILQUANTITYRECEIVEDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPurchaseOrderDetailId",fld:"vCPURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"AV8cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV14cPurchaseOrderDetailQuantityOrdered",fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",pic:"ZZZZZ9"},{av:"AV15cPurchaseOrderDetailQuantityReceived",fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",pic:"ZZZZZ9"},{av:"AV11pPurchaseOrderId",fld:"vPPURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLPURCHASEORDERDETAILIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILID","Visible")',ctrl:"vCPURCHASEORDERDETAILID",prop:"Visible"}]];this.EvtParms["LBLPRODUCTIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]];this.EvtParms["LBLPURCHASEORDERDETAILQUANTITYORDEREDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYORDEREDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILQUANTITYORDERED","Visible")',ctrl:"vCPURCHASEORDERDETAILQUANTITYORDERED",prop:"Visible"}]];this.EvtParms["LBLPURCHASEORDERDETAILQUANTITYRECEIVEDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER","Class")',ctrl:"PURCHASEORDERDETAILQUANTITYRECEIVEDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPURCHASEORDERDETAILQUANTITYRECEIVED","Visible")',ctrl:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A61PurchaseOrderDetailId",fld:"PURCHASEORDERDETAILID",pic:"ZZZZZ9",hsh:!0}],[{av:"AV12pPurchaseOrderDetailId",fld:"vPPURCHASEORDERDETAILID",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPurchaseOrderDetailId",fld:"vCPURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"AV8cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV14cPurchaseOrderDetailQuantityOrdered",fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",pic:"ZZZZZ9"},{av:"AV15cPurchaseOrderDetailQuantityReceived",fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",pic:"ZZZZZ9"},{av:"AV11pPurchaseOrderId",fld:"vPPURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPurchaseOrderDetailId",fld:"vCPURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"AV8cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV14cPurchaseOrderDetailQuantityOrdered",fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",pic:"ZZZZZ9"},{av:"AV15cPurchaseOrderDetailQuantityReceived",fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",pic:"ZZZZZ9"},{av:"AV11pPurchaseOrderId",fld:"vPPURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPurchaseOrderDetailId",fld:"vCPURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"AV8cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV14cPurchaseOrderDetailQuantityOrdered",fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",pic:"ZZZZZ9"},{av:"AV15cPurchaseOrderDetailQuantityReceived",fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",pic:"ZZZZZ9"},{av:"AV11pPurchaseOrderId",fld:"vPPURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cPurchaseOrderDetailId",fld:"vCPURCHASEORDERDETAILID",pic:"ZZZZZ9"},{av:"AV8cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV14cPurchaseOrderDetailQuantityOrdered",fld:"vCPURCHASEORDERDETAILQUANTITYORDERED",pic:"ZZZZZ9"},{av:"AV15cPurchaseOrderDetailQuantityReceived",fld:"vCPURCHASEORDERDETAILQUANTITYRECEIVED",pic:"ZZZZZ9"},{av:"AV11pPurchaseOrderId",fld:"vPPURCHASEORDERID",pic:"ZZZZZ9"}],[]];this.setVCMap("AV11pPurchaseOrderId","vPPURCHASEORDERID",0,"int",6,0);this.setVCMap("AV12pPurchaseOrderDetailId","vPPURCHASEORDERDETAILID",0,"int",6,0);this.setVCMap("AV11pPurchaseOrderId","vPPURCHASEORDERID",0,"int",6,0);this.setVCMap("AV11pPurchaseOrderId","vPPURCHASEORDERID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar({rfrVar:"AV11pPurchaseOrderId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm({rfrVar:"AV11pPurchaseOrderId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00c1)})