gx.evt.autoSkip=!1;gx.define("gx0090",!1,function(){var n,t;this.ServerClass="gx0090";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0090.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV13pOrderDetailId=gx.fn.getIntegerValue("vPORDERDETAILID",",")};this.Validv_Corderdetailcreateddate=function(){return this.validCliEvt("Validv_Corderdetailcreateddate",0,function(){try{var n=gx.util.balloon.getNew("vCORDERDETAILCREATEDDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11cOrderDetailCreatedDate)===0||new gx.date.gxdate(this.AV11cOrderDetailCreatedDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Order Detail Created Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Corderdetailmodifieddate=function(){return this.validCliEvt("Validv_Corderdetailmodifieddate",0,function(){try{var n=gx.util.balloon.getNew("vCORDERDETAILMODIFIEDDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12cOrderDetailModifiedDate)===0||new gx.date.gxdate(this.AV12cOrderDetailModifiedDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Order Detail Modified Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e180c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCORDERDETAILID","Visible",!0)):(gx.fn.setCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCORDERDETAILID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"ORDERDETAILIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILID","Visible")',ctrl:"vCORDERDETAILID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCORDERDETAILQUANTITY","Visible",!0)):(gx.fn.setCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCORDERDETAILQUANTITY","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class")',ctrl:"ORDERDETAILQUANTITYFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILQUANTITY","Visible")',ctrl:"vCORDERDETAILQUANTITY",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCORDERDETAILCURRENTPRICE","Visible",!0)):(gx.fn.setCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCORDERDETAILCURRENTPRICE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCURRENTPRICEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILCURRENTPRICE","Visible")',ctrl:"vCORDERDETAILCURRENTPRICE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCORDERDETAILSUGGESTEDPRICE","Visible",!0)):(gx.fn.setCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCORDERDETAILSUGGESTEDPRICE","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILSUGGESTEDPRICE","Visible")',ctrl:"vCORDERDETAILSUGGESTEDPRICE",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCREATEDDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170c1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILMODIFIEDDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e210c2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220c1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94];this.GXLastCtrlId=94;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0090",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(44,86,"ORDERDETAILID","Detail Id","","OrderDetailId","int",0,"px",6,6,"right",null,[],44,"OrderDetailId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(15,87,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(45,88,"ORDERDETAILQUANTITY","Detail Quantity","","OrderDetailQuantity","int",0,"px",6,6,"right",null,[],45,"OrderDetailQuantity",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(46,89,"ORDERDETAILCURRENTPRICE","Current Price","","OrderDetailCurrentPrice","decimal",0,"px",10,10,"right",null,[],46,"OrderDetailCurrentPrice",!0,2,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(47,90,"ORDERDETAILSUGGESTEDPRICE","Suggested Price","","OrderDetailSuggestedPrice","decimal",0,"px",10,10,"right",null,[],47,"OrderDetailSuggestedPrice",!0,2,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(48,91,"ORDERDETAILCREATEDDATE","Created Date","","OrderDetailCreatedDate","date",0,"px",8,8,"right",null,[],48,"OrderDetailCreatedDate",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"ORDERDETAILIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLORDERDETAILIDFILTER",format:1,grid:0,evt:"e110c1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILID",fmt:0,gxz:"ZV6cOrderDetailId",gxold:"OV6cOrderDetailId",gxvar:"AV6cOrderDetailId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cOrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cOrderDetailId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCORDERDETAILID",gx.O.AV6cOrderDetailId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cOrderDetailId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCORDERDETAILID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"PRODUCTIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLPRODUCTIDFILTER",format:1,grid:0,evt:"e120c1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTID",fmt:0,gxz:"ZV7cProductId",gxold:"OV7cProductId",gxvar:"AV7cProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cProductId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTID",gx.O.AV7cProductId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cProductId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTID",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ORDERDETAILQUANTITYFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLORDERDETAILQUANTITYFILTER",format:1,grid:0,evt:"e130c1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILQUANTITY",fmt:0,gxz:"ZV8cOrderDetailQuantity",gxold:"OV8cOrderDetailQuantity",gxvar:"AV8cOrderDetailQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cOrderDetailQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cOrderDetailQuantity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCORDERDETAILQUANTITY",gx.O.AV8cOrderDetailQuantity,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cOrderDetailQuantity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCORDERDETAILQUANTITY",",")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"ORDERDETAILCURRENTPRICEFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLORDERDETAILCURRENTPRICEFILTER",format:1,grid:0,evt:"e140c1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILCURRENTPRICE",fmt:0,gxz:"ZV9cOrderDetailCurrentPrice",gxold:"OV9cOrderDetailCurrentPrice",gxvar:"AV9cOrderDetailCurrentPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cOrderDetailCurrentPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV9cOrderDetailCurrentPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("vCORDERDETAILCURRENTPRICE",gx.O.AV9cOrderDetailCurrentPrice,2,".")},c2v:function(){this.val()!==undefined&&(gx.O.AV9cOrderDetailCurrentPrice=this.val())},val:function(){return gx.fn.getDecimalValue("vCORDERDETAILCURRENTPRICE",",",".")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLORDERDETAILSUGGESTEDPRICEFILTER",format:1,grid:0,evt:"e150c1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILSUGGESTEDPRICE",fmt:0,gxz:"ZV10cOrderDetailSuggestedPrice",gxold:"OV10cOrderDetailSuggestedPrice",gxvar:"AV10cOrderDetailSuggestedPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cOrderDetailSuggestedPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV10cOrderDetailSuggestedPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(){gx.fn.setDecimalValue("vCORDERDETAILSUGGESTEDPRICE",gx.O.AV10cOrderDetailSuggestedPrice,2,".")},c2v:function(){this.val()!==undefined&&(gx.O.AV10cOrderDetailSuggestedPrice=this.val())},val:function(){return gx.fn.getDecimalValue("vCORDERDETAILSUGGESTEDPRICE",",",".")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"ORDERDETAILCREATEDDATEFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLORDERDETAILCREATEDDATEFILTER",format:1,grid:0,evt:"e160c1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Corderdetailcreateddate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILCREATEDDATE",fmt:0,gxz:"ZV11cOrderDetailCreatedDate",gxold:"OV11cOrderDetailCreatedDate",gxvar:"AV11cOrderDetailCreatedDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[66],ip:[66],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cOrderDetailCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cOrderDetailCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCORDERDETAILCREATEDDATE",gx.O.AV11cOrderDetailCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cOrderDetailCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCORDERDETAILCREATEDDATE")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"ORDERDETAILMODIFIEDDATEFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLORDERDETAILMODIFIEDDATEFILTER",format:1,grid:0,evt:"e170c1_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Corderdetailmodifieddate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCORDERDETAILMODIFIEDDATE",fmt:0,gxz:"ZV12cOrderDetailModifiedDate",gxold:"OV12cOrderDetailModifiedDate",gxvar:"AV12cOrderDetailModifiedDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[76],ip:[76],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cOrderDetailModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12cOrderDetailModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCORDERDETAILMODIFIEDDATE",gx.O.AV12cOrderDetailModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12cOrderDetailModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCORDERDETAILMODIFIEDDATE")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e180c1_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV17Linkselection_GXI)},c2v:function(n){gx.O.AV17Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV17Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDERDETAILID",fmt:0,gxz:"Z44OrderDetailId",gxold:"O44OrderDetailId",gxvar:"A44OrderDetailId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A44OrderDetailId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z44OrderDetailId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ORDERDETAILID",n||gx.fn.currentGridRowImpl(84),gx.O.A44OrderDetailId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A44OrderDetailId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ORDERDETAILID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(84),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDERDETAILQUANTITY",fmt:0,gxz:"Z45OrderDetailQuantity",gxold:"O45OrderDetailQuantity",gxvar:"A45OrderDetailQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A45OrderDetailQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z45OrderDetailQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ORDERDETAILQUANTITY",n||gx.fn.currentGridRowImpl(84),gx.O.A45OrderDetailQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A45OrderDetailQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ORDERDETAILQUANTITY",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDERDETAILCURRENTPRICE",fmt:0,gxz:"Z46OrderDetailCurrentPrice",gxold:"O46OrderDetailCurrentPrice",gxvar:"A46OrderDetailCurrentPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A46OrderDetailCurrentPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z46OrderDetailCurrentPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("ORDERDETAILCURRENTPRICE",n||gx.fn.currentGridRowImpl(84),gx.O.A46OrderDetailCurrentPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A46OrderDetailCurrentPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("ORDERDETAILCURRENTPRICE",n||gx.fn.currentGridRowImpl(84),",",".")},nac:gx.falseFn};n[90]={id:90,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDERDETAILSUGGESTEDPRICE",fmt:0,gxz:"Z47OrderDetailSuggestedPrice",gxold:"O47OrderDetailSuggestedPrice",gxvar:"A47OrderDetailSuggestedPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A47OrderDetailSuggestedPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z47OrderDetailSuggestedPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("ORDERDETAILSUGGESTEDPRICE",n||gx.fn.currentGridRowImpl(84),gx.O.A47OrderDetailSuggestedPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A47OrderDetailSuggestedPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("ORDERDETAILSUGGESTEDPRICE",n||gx.fn.currentGridRowImpl(84),",",".")},nac:gx.falseFn};n[91]={id:91,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ORDERDETAILCREATEDDATE",fmt:0,gxz:"Z48OrderDetailCreatedDate",gxold:"O48OrderDetailCreatedDate",gxvar:"A48OrderDetailCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A48OrderDetailCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z48OrderDetailCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ORDERDETAILCREATEDDATE",n||gx.fn.currentGridRowImpl(84),gx.O.A48OrderDetailCreatedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A48OrderDetailCreatedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ORDERDETAILCREATEDDATE",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[92]={id:92,fld:"",grid:0};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"BTN_CANCEL",grid:0,evt:"e220c1_client"};this.AV6cOrderDetailId=0;this.ZV6cOrderDetailId=0;this.OV6cOrderDetailId=0;this.AV7cProductId=0;this.ZV7cProductId=0;this.OV7cProductId=0;this.AV8cOrderDetailQuantity=0;this.ZV8cOrderDetailQuantity=0;this.OV8cOrderDetailQuantity=0;this.AV9cOrderDetailCurrentPrice=0;this.ZV9cOrderDetailCurrentPrice=0;this.OV9cOrderDetailCurrentPrice=0;this.AV10cOrderDetailSuggestedPrice=0;this.ZV10cOrderDetailSuggestedPrice=0;this.OV10cOrderDetailSuggestedPrice=0;this.AV11cOrderDetailCreatedDate=gx.date.nullDate();this.ZV11cOrderDetailCreatedDate=gx.date.nullDate();this.OV11cOrderDetailCreatedDate=gx.date.nullDate();this.AV12cOrderDetailModifiedDate=gx.date.nullDate();this.ZV12cOrderDetailModifiedDate=gx.date.nullDate();this.OV12cOrderDetailModifiedDate=gx.date.nullDate();this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z44OrderDetailId=0;this.O44OrderDetailId=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z45OrderDetailQuantity=0;this.O45OrderDetailQuantity=0;this.Z46OrderDetailCurrentPrice=0;this.O46OrderDetailCurrentPrice=0;this.Z47OrderDetailSuggestedPrice=0;this.O47OrderDetailSuggestedPrice=0;this.Z48OrderDetailCreatedDate=gx.date.nullDate();this.O48OrderDetailCreatedDate=gx.date.nullDate();this.AV6cOrderDetailId=0;this.AV7cProductId=0;this.AV8cOrderDetailQuantity=0;this.AV9cOrderDetailCurrentPrice=0;this.AV10cOrderDetailSuggestedPrice=0;this.AV11cOrderDetailCreatedDate=gx.date.nullDate();this.AV12cOrderDetailModifiedDate=gx.date.nullDate();this.AV13pOrderDetailId=0;this.A49OrderDetailModifiedDate=gx.date.nullDate();this.AV5LinkSelection="";this.A44OrderDetailId=0;this.A15ProductId=0;this.A45OrderDetailQuantity=0;this.A46OrderDetailCurrentPrice=0;this.A47OrderDetailSuggestedPrice=0;this.A48OrderDetailCreatedDate=gx.date.nullDate();this.Events={e210c2_client:["ENTER",!0],e220c1_client:["CANCEL",!0],e180c1_client:["'TOGGLE'",!1],e110c1_client:["LBLORDERDETAILIDFILTER.CLICK",!1],e120c1_client:["LBLPRODUCTIDFILTER.CLICK",!1],e130c1_client:["LBLORDERDETAILQUANTITYFILTER.CLICK",!1],e140c1_client:["LBLORDERDETAILCURRENTPRICEFILTER.CLICK",!1],e150c1_client:["LBLORDERDETAILSUGGESTEDPRICEFILTER.CLICK",!1],e160c1_client:["LBLORDERDETAILCREATEDDATEFILTER.CLICK",!1],e170c1_client:["LBLORDERDETAILMODIFIEDDATEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cOrderDetailId",fld:"vCORDERDETAILID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cOrderDetailQuantity",fld:"vCORDERDETAILQUANTITY",pic:"ZZZZZ9"},{av:"AV9cOrderDetailCurrentPrice",fld:"vCORDERDETAILCURRENTPRICE",pic:"ZZZZZZ9.99"},{av:"AV10cOrderDetailSuggestedPrice",fld:"vCORDERDETAILSUGGESTEDPRICE",pic:"ZZZZZZ9.99"},{av:"AV11cOrderDetailCreatedDate",fld:"vCORDERDETAILCREATEDDATE",pic:""},{av:"AV12cOrderDetailModifiedDate",fld:"vCORDERDETAILMODIFIEDDATE",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLORDERDETAILIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"ORDERDETAILIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILIDFILTERCONTAINER","Class")',ctrl:"ORDERDETAILIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILID","Visible")',ctrl:"vCORDERDETAILID",prop:"Visible"}]];this.EvtParms["LBLPRODUCTIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]];this.EvtParms["LBLORDERDETAILQUANTITYFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class")',ctrl:"ORDERDETAILQUANTITYFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILQUANTITYFILTERCONTAINER","Class")',ctrl:"ORDERDETAILQUANTITYFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILQUANTITY","Visible")',ctrl:"vCORDERDETAILQUANTITY",prop:"Visible"}]];this.EvtParms["LBLORDERDETAILCURRENTPRICEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCURRENTPRICEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILCURRENTPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCURRENTPRICEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILCURRENTPRICE","Visible")',ctrl:"vCORDERDETAILCURRENTPRICE",prop:"Visible"}]];this.EvtParms["LBLORDERDETAILSUGGESTEDPRICEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCORDERDETAILSUGGESTEDPRICE","Visible")',ctrl:"vCORDERDETAILSUGGESTEDPRICE",prop:"Visible"}]];this.EvtParms["LBLORDERDETAILCREATEDDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCREATEDDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILCREATEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILCREATEDDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLORDERDETAILMODIFIEDDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILMODIFIEDDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ORDERDETAILMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"ORDERDETAILMODIFIEDDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms.ENTER=[[{av:"A44OrderDetailId",fld:"ORDERDETAILID",pic:"ZZZZZ9",hsh:!0}],[{av:"AV13pOrderDetailId",fld:"vPORDERDETAILID",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cOrderDetailId",fld:"vCORDERDETAILID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cOrderDetailQuantity",fld:"vCORDERDETAILQUANTITY",pic:"ZZZZZ9"},{av:"AV9cOrderDetailCurrentPrice",fld:"vCORDERDETAILCURRENTPRICE",pic:"ZZZZZZ9.99"},{av:"AV10cOrderDetailSuggestedPrice",fld:"vCORDERDETAILSUGGESTEDPRICE",pic:"ZZZZZZ9.99"},{av:"AV11cOrderDetailCreatedDate",fld:"vCORDERDETAILCREATEDDATE",pic:""},{av:"AV12cOrderDetailModifiedDate",fld:"vCORDERDETAILMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cOrderDetailId",fld:"vCORDERDETAILID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cOrderDetailQuantity",fld:"vCORDERDETAILQUANTITY",pic:"ZZZZZ9"},{av:"AV9cOrderDetailCurrentPrice",fld:"vCORDERDETAILCURRENTPRICE",pic:"ZZZZZZ9.99"},{av:"AV10cOrderDetailSuggestedPrice",fld:"vCORDERDETAILSUGGESTEDPRICE",pic:"ZZZZZZ9.99"},{av:"AV11cOrderDetailCreatedDate",fld:"vCORDERDETAILCREATEDDATE",pic:""},{av:"AV12cOrderDetailModifiedDate",fld:"vCORDERDETAILMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cOrderDetailId",fld:"vCORDERDETAILID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cOrderDetailQuantity",fld:"vCORDERDETAILQUANTITY",pic:"ZZZZZ9"},{av:"AV9cOrderDetailCurrentPrice",fld:"vCORDERDETAILCURRENTPRICE",pic:"ZZZZZZ9.99"},{av:"AV10cOrderDetailSuggestedPrice",fld:"vCORDERDETAILSUGGESTEDPRICE",pic:"ZZZZZZ9.99"},{av:"AV11cOrderDetailCreatedDate",fld:"vCORDERDETAILCREATEDDATE",pic:""},{av:"AV12cOrderDetailModifiedDate",fld:"vCORDERDETAILMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cOrderDetailId",fld:"vCORDERDETAILID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cOrderDetailQuantity",fld:"vCORDERDETAILQUANTITY",pic:"ZZZZZ9"},{av:"AV9cOrderDetailCurrentPrice",fld:"vCORDERDETAILCURRENTPRICE",pic:"ZZZZZZ9.99"},{av:"AV10cOrderDetailSuggestedPrice",fld:"vCORDERDETAILSUGGESTEDPRICE",pic:"ZZZZZZ9.99"},{av:"AV11cOrderDetailCreatedDate",fld:"vCORDERDETAILCREATEDDATE",pic:""},{av:"AV12cOrderDetailModifiedDate",fld:"vCORDERDETAILMODIFIEDDATE",pic:""}],[]];this.EvtParms.VALIDV_CORDERDETAILCREATEDDATE=[[],[]];this.EvtParms.VALIDV_CORDERDETAILMODIFIEDDATE=[[],[]];this.setVCMap("AV13pOrderDetailId","vPORDERDETAILID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0090)})