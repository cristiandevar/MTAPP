gx.evt.autoSkip=!1;gx.define("gx00e0",!1,function(){var n,t;this.ServerClass="gx00e0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00e0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV10pProductPerishableId=gx.fn.getIntegerValue("vPPRODUCTPERISHABLEID",",")};this.Validv_Cproductperishablebatchdate=function(){return this.validCliEvt("Validv_Cproductperishablebatchdate",0,function(){try{var n=gx.util.balloon.getNew("vCPRODUCTPERISHABLEBATCHDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8cProductPerishableBatchDate)===0||new gx.date.gxdate(this.AV8cProductPerishableBatchDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Product Perishable Batch Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Cproductperishableexpirationdate=function(){return this.validCliEvt("Validv_Cproductperishableexpirationdate",0,function(){try{var n=gx.util.balloon.getNew("vCPRODUCTPERISHABLEEXPIRATIONDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV9cProductPerishableExpirationDate)===0||new gx.date.gxdate(this.AV9cProductPerishableExpirationDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Product Perishable Expiration Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e15451_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11451_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTPERISHABLEID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTPERISHABLEID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTPERISHABLEID","Visible")',ctrl:"vCPRODUCTPERISHABLEID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12451_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!0)):(gx.fn.setCtrlProperty("PRODUCTIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRODUCTID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13451_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14451_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e18452_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19451_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62];this.GXLastCtrlId=62;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00e0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(70,56,"PRODUCTPERISHABLEID","Perishable Id","","ProductPerishableId","int",0,"px",6,6,"right",null,[],70,"ProductPerishableId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(15,57,"PRODUCTID","Product Id","","ProductId","int",0,"px",6,6,"right",null,[],15,"ProductId",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(71,58,"PRODUCTPERISHABLEBATCHDATE","Batch Date","","ProductPerishableBatchDate","date",0,"px",8,8,"right",null,[],71,"ProductPerishableBatchDate",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(72,59,"PRODUCTPERISHABLEEXPIRATIONDAT","Expiration Date","","ProductPerishableExpirationDat","date",0,"px",8,8,"right",null,[],72,"ProductPerishableExpirationDat",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"PRODUCTPERISHABLEIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLPRODUCTPERISHABLEIDFILTER",format:1,grid:0,evt:"e11451_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTPERISHABLEID",fmt:0,gxz:"ZV6cProductPerishableId",gxold:"OV6cProductPerishableId",gxvar:"AV6cProductPerishableId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cProductPerishableId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cProductPerishableId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTPERISHABLEID",gx.O.AV6cProductPerishableId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cProductPerishableId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTPERISHABLEID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"PRODUCTIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLPRODUCTIDFILTER",format:1,grid:0,evt:"e12451_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTID",fmt:0,gxz:"ZV7cProductId",gxold:"OV7cProductId",gxvar:"AV7cProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cProductId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTID",gx.O.AV7cProductId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cProductId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRODUCTID",",")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLPRODUCTPERISHABLEBATCHDATEFILTER",format:1,grid:0,evt:"e13451_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cproductperishablebatchdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTPERISHABLEBATCHDATE",fmt:0,gxz:"ZV8cProductPerishableBatchDate",gxold:"OV8cProductPerishableBatchDate",gxvar:"AV8cProductPerishableBatchDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cProductPerishableBatchDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cProductPerishableBatchDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTPERISHABLEBATCHDATE",gx.O.AV8cProductPerishableBatchDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cProductPerishableBatchDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCPRODUCTPERISHABLEBATCHDATE")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLPRODUCTPERISHABLEEXPIRATIONDATEFILTER",format:1,grid:0,evt:"e14451_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cproductperishableexpirationdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",fmt:0,gxz:"ZV9cProductPerishableExpirationDate",gxold:"OV9cProductPerishableExpirationDate",gxvar:"AV9cProductPerishableExpirationDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cProductPerishableExpirationDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cProductPerishableExpirationDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCPRODUCTPERISHABLEEXPIRATIONDATE",gx.O.AV9cProductPerishableExpirationDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cProductPerishableExpirationDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCPRODUCTPERISHABLEEXPIRATIONDATE")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e15451_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPERISHABLEID",fmt:0,gxz:"Z70ProductPerishableId",gxold:"O70ProductPerishableId",gxvar:"A70ProductPerishableId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A70ProductPerishableId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z70ProductPerishableId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTPERISHABLEID",n||gx.fn.currentGridRowImpl(54),gx.O.A70ProductPerishableId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A70ProductPerishableId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTPERISHABLEID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",fmt:0,gxz:"Z15ProductId",gxold:"O15ProductId",gxvar:"A15ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(54),gx.O.A15ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPERISHABLEBATCHDATE",fmt:0,gxz:"Z71ProductPerishableBatchDate",gxold:"O71ProductPerishableBatchDate",gxvar:"A71ProductPerishableBatchDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A71ProductPerishableBatchDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z71ProductPerishableBatchDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTPERISHABLEBATCHDATE",n||gx.fn.currentGridRowImpl(54),gx.O.A71ProductPerishableBatchDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A71ProductPerishableBatchDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("PRODUCTPERISHABLEBATCHDATE",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPERISHABLEEXPIRATIONDAT",fmt:0,gxz:"Z72ProductPerishableExpirationDat",gxold:"O72ProductPerishableExpirationDat",gxvar:"A72ProductPerishableExpirationDat",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A72ProductPerishableExpirationDat=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z72ProductPerishableExpirationDat=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTPERISHABLEEXPIRATIONDAT",n||gx.fn.currentGridRowImpl(54),gx.O.A72ProductPerishableExpirationDat,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A72ProductPerishableExpirationDat=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("PRODUCTPERISHABLEEXPIRATIONDAT",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTN_CANCEL",grid:0,evt:"e19451_client"};this.AV6cProductPerishableId=0;this.ZV6cProductPerishableId=0;this.OV6cProductPerishableId=0;this.AV7cProductId=0;this.ZV7cProductId=0;this.OV7cProductId=0;this.AV8cProductPerishableBatchDate=gx.date.nullDate();this.ZV8cProductPerishableBatchDate=gx.date.nullDate();this.OV8cProductPerishableBatchDate=gx.date.nullDate();this.AV9cProductPerishableExpirationDate=gx.date.nullDate();this.ZV9cProductPerishableExpirationDate=gx.date.nullDate();this.OV9cProductPerishableExpirationDate=gx.date.nullDate();this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z70ProductPerishableId=0;this.O70ProductPerishableId=0;this.Z15ProductId=0;this.O15ProductId=0;this.Z71ProductPerishableBatchDate=gx.date.nullDate();this.O71ProductPerishableBatchDate=gx.date.nullDate();this.Z72ProductPerishableExpirationDat=gx.date.nullDate();this.O72ProductPerishableExpirationDat=gx.date.nullDate();this.AV6cProductPerishableId=0;this.AV7cProductId=0;this.AV8cProductPerishableBatchDate=gx.date.nullDate();this.AV9cProductPerishableExpirationDate=gx.date.nullDate();this.AV10pProductPerishableId=0;this.AV5LinkSelection="";this.A70ProductPerishableId=0;this.A15ProductId=0;this.A71ProductPerishableBatchDate=gx.date.nullDate();this.A72ProductPerishableExpirationDat=gx.date.nullDate();this.Events={e18452_client:["ENTER",!0],e19451_client:["CANCEL",!0],e15451_client:["'TOGGLE'",!1],e11451_client:["LBLPRODUCTPERISHABLEIDFILTER.CLICK",!1],e12451_client:["LBLPRODUCTIDFILTER.CLICK",!1],e13451_client:["LBLPRODUCTPERISHABLEBATCHDATEFILTER.CLICK",!1],e14451_client:["LBLPRODUCTPERISHABLEEXPIRATIONDATEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductPerishableId",fld:"vCPRODUCTPERISHABLEID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cProductPerishableBatchDate",fld:"vCPRODUCTPERISHABLEBATCHDATE",pic:""},{av:"AV9cProductPerishableExpirationDate",fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLPRODUCTPERISHABLEIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEIDFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTPERISHABLEID","Visible")',ctrl:"vCPRODUCTPERISHABLEID",prop:"Visible"}]];this.EvtParms["LBLPRODUCTIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTIDFILTERCONTAINER","Class")',ctrl:"PRODUCTIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRODUCTID","Visible")',ctrl:"vCPRODUCTID",prop:"Visible"}]];this.EvtParms["LBLPRODUCTPERISHABLEBATCHDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEBATCHDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLPRODUCTPERISHABLEEXPIRATIONDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER","Class")',ctrl:"PRODUCTPERISHABLEEXPIRATIONDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms.ENTER=[[{av:"A70ProductPerishableId",fld:"PRODUCTPERISHABLEID",pic:"ZZZZZ9",hsh:!0}],[{av:"AV10pProductPerishableId",fld:"vPPRODUCTPERISHABLEID",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductPerishableId",fld:"vCPRODUCTPERISHABLEID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cProductPerishableBatchDate",fld:"vCPRODUCTPERISHABLEBATCHDATE",pic:""},{av:"AV9cProductPerishableExpirationDate",fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductPerishableId",fld:"vCPRODUCTPERISHABLEID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cProductPerishableBatchDate",fld:"vCPRODUCTPERISHABLEBATCHDATE",pic:""},{av:"AV9cProductPerishableExpirationDate",fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductPerishableId",fld:"vCPRODUCTPERISHABLEID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cProductPerishableBatchDate",fld:"vCPRODUCTPERISHABLEBATCHDATE",pic:""},{av:"AV9cProductPerishableExpirationDate",fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cProductPerishableId",fld:"vCPRODUCTPERISHABLEID",pic:"ZZZZZ9"},{av:"AV7cProductId",fld:"vCPRODUCTID",pic:"ZZZZZ9"},{av:"AV8cProductPerishableBatchDate",fld:"vCPRODUCTPERISHABLEBATCHDATE",pic:""},{av:"AV9cProductPerishableExpirationDate",fld:"vCPRODUCTPERISHABLEEXPIRATIONDATE",pic:""}],[]];this.EvtParms.VALIDV_CPRODUCTPERISHABLEBATCHDATE=[[],[]];this.EvtParms.VALIDV_CPRODUCTPERISHABLEEXPIRATIONDATE=[[],[]];this.setVCMap("AV10pProductPerishableId","vPPRODUCTPERISHABLEID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00e0)})