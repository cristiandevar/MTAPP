gx.evt.autoSkip=!1;gx.define("gx0010",!1,function(){var n,t;this.ServerClass="gx0010";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0010.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV10pBrandId=gx.fn.getIntegerValue("vPBRANDID",",")};this.Validv_Cbrandcreateddate=function(){return this.validCliEvt("Validv_Cbrandcreateddate",0,function(){try{var n=gx.util.balloon.getNew("vCBRANDCREATEDDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8cBrandCreatedDate)===0||new gx.date.gxdate(this.AV8cBrandCreatedDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Brand Created Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Cbrandmodifieddate=function(){return this.validCliEvt("Validv_Cbrandmodifieddate",0,function(){try{var n=gx.util.balloon.getNew("vCBRANDMODIFIEDDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV9cBrandModifiedDate)===0||new gx.date.gxdate(this.AV9cBrandModifiedDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Brand Modified Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e15031_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11031_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("BRANDIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("BRANDIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCBRANDID","Visible",!0)):(gx.fn.setCtrlProperty("BRANDIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCBRANDID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("BRANDIDFILTERCONTAINER","Class")',ctrl:"BRANDIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCBRANDID","Visible")',ctrl:"vCBRANDID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12031_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("BRANDNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("BRANDNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCBRANDNAME","Visible",!0)):(gx.fn.setCtrlProperty("BRANDNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCBRANDNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("BRANDNAMEFILTERCONTAINER","Class")',ctrl:"BRANDNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCBRANDNAME","Visible")',ctrl:"vCBRANDNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13031_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDCREATEDDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e14031_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDMODIFIEDDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e18032_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e19031_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62];this.GXLastCtrlId=62;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0010",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(1,56,"BRANDID","Id","","BrandId","int",0,"px",6,6,"right",null,[],1,"BrandId",!0,0,!1,!1,"Attribute",0,"WWColumn");t.addSingleLineEdit(2,57,"BRANDNAME","Name","","BrandName","svchar",0,"px",60,60,"left",null,[],2,"BrandName",!0,0,!1,!1,"DescriptionAttribute",0,"WWColumn");t.addSingleLineEdit(30,58,"BRANDCREATEDDATE","Created Date","","BrandCreatedDate","date",0,"px",8,8,"right",null,[],30,"BrandCreatedDate",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");t.addSingleLineEdit(31,59,"BRANDMODIFIEDDATE","Modified Date","","BrandModifiedDate","date",0,"px",8,8,"right",null,[],31,"BrandModifiedDate",!0,0,!1,!1,"Attribute",0,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"BRANDIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLBRANDIDFILTER",format:1,grid:0,evt:"e11031_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCBRANDID",fmt:0,gxz:"ZV6cBrandId",gxold:"OV6cBrandId",gxvar:"AV6cBrandId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cBrandId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cBrandId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCBRANDID",gx.O.AV6cBrandId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cBrandId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCBRANDID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"BRANDNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLBRANDNAMEFILTER",format:1,grid:0,evt:"e12031_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCBRANDNAME",fmt:0,gxz:"ZV7cBrandName",gxold:"OV7cBrandName",gxvar:"AV7cBrandName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cBrandName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cBrandName=n)},v2c:function(){gx.fn.setControlValue("vCBRANDNAME",gx.O.AV7cBrandName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cBrandName=this.val())},val:function(){return gx.fn.getControlValue("vCBRANDNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BRANDCREATEDDATEFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLBRANDCREATEDDATEFILTER",format:1,grid:0,evt:"e13031_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cbrandcreateddate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCBRANDCREATEDDATE",fmt:0,gxz:"ZV8cBrandCreatedDate",gxold:"OV8cBrandCreatedDate",gxvar:"AV8cBrandCreatedDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cBrandCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cBrandCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCBRANDCREATEDDATE",gx.O.AV8cBrandCreatedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cBrandCreatedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCBRANDCREATEDDATE")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"BRANDMODIFIEDDATEFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLBRANDMODIFIEDDATEFILTER",format:1,grid:0,evt:"e14031_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cbrandmodifieddate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCBRANDMODIFIEDDATE",fmt:0,gxz:"ZV9cBrandModifiedDate",gxold:"OV9cBrandModifiedDate",gxvar:"AV9cBrandModifiedDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cBrandModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cBrandModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCBRANDMODIFIEDDATE",gx.O.AV9cBrandModifiedDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cBrandModifiedDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCBRANDMODIFIEDDATE")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e15031_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BRANDID",fmt:0,gxz:"Z1BrandId",gxold:"O1BrandId",gxvar:"A1BrandId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1BrandId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1BrandId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("BRANDID",n||gx.fn.currentGridRowImpl(54),gx.O.A1BrandId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1BrandId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("BRANDID",n||gx.fn.currentGridRowImpl(54),",")},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BRANDNAME",fmt:0,gxz:"Z2BrandName",gxold:"O2BrandName",gxvar:"A2BrandName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2BrandName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2BrandName=n)},v2c:function(n){gx.fn.setGridControlValue("BRANDNAME",n||gx.fn.currentGridRowImpl(54),gx.O.A2BrandName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2BrandName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("BRANDNAME",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BRANDCREATEDDATE",fmt:0,gxz:"Z30BrandCreatedDate",gxold:"O30BrandCreatedDate",gxvar:"A30BrandCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30BrandCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z30BrandCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("BRANDCREATEDDATE",n||gx.fn.currentGridRowImpl(54),gx.O.A30BrandCreatedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30BrandCreatedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("BRANDCREATEDDATE",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"BRANDMODIFIEDDATE",fmt:0,gxz:"Z31BrandModifiedDate",gxold:"O31BrandModifiedDate",gxvar:"A31BrandModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A31BrandModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z31BrandModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("BRANDMODIFIEDDATE",n||gx.fn.currentGridRowImpl(54),gx.O.A31BrandModifiedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31BrandModifiedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("BRANDMODIFIEDDATE",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTN_CANCEL",grid:0,evt:"e19031_client"};this.AV6cBrandId=0;this.ZV6cBrandId=0;this.OV6cBrandId=0;this.AV7cBrandName="";this.ZV7cBrandName="";this.OV7cBrandName="";this.AV8cBrandCreatedDate=gx.date.nullDate();this.ZV8cBrandCreatedDate=gx.date.nullDate();this.OV8cBrandCreatedDate=gx.date.nullDate();this.AV9cBrandModifiedDate=gx.date.nullDate();this.ZV9cBrandModifiedDate=gx.date.nullDate();this.OV9cBrandModifiedDate=gx.date.nullDate();this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z1BrandId=0;this.O1BrandId=0;this.Z2BrandName="";this.O2BrandName="";this.Z30BrandCreatedDate=gx.date.nullDate();this.O30BrandCreatedDate=gx.date.nullDate();this.Z31BrandModifiedDate=gx.date.nullDate();this.O31BrandModifiedDate=gx.date.nullDate();this.AV6cBrandId=0;this.AV7cBrandName="";this.AV8cBrandCreatedDate=gx.date.nullDate();this.AV9cBrandModifiedDate=gx.date.nullDate();this.AV10pBrandId=0;this.AV5LinkSelection="";this.A1BrandId=0;this.A2BrandName="";this.A30BrandCreatedDate=gx.date.nullDate();this.A31BrandModifiedDate=gx.date.nullDate();this.Events={e18032_client:["ENTER",!0],e19031_client:["CANCEL",!0],e15031_client:["'TOGGLE'",!1],e11031_client:["LBLBRANDIDFILTER.CLICK",!1],e12031_client:["LBLBRANDNAMEFILTER.CLICK",!1],e13031_client:["LBLBRANDCREATEDDATEFILTER.CLICK",!1],e14031_client:["LBLBRANDMODIFIEDDATEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cBrandId",fld:"vCBRANDID",pic:"ZZZZZ9"},{av:"AV7cBrandName",fld:"vCBRANDNAME",pic:""},{av:"AV8cBrandCreatedDate",fld:"vCBRANDCREATEDDATE",pic:""},{av:"AV9cBrandModifiedDate",fld:"vCBRANDMODIFIEDDATE",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLBRANDIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("BRANDIDFILTERCONTAINER","Class")',ctrl:"BRANDIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("BRANDIDFILTERCONTAINER","Class")',ctrl:"BRANDIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCBRANDID","Visible")',ctrl:"vCBRANDID",prop:"Visible"}]];this.EvtParms["LBLBRANDNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("BRANDNAMEFILTERCONTAINER","Class")',ctrl:"BRANDNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("BRANDNAMEFILTERCONTAINER","Class")',ctrl:"BRANDNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCBRANDNAME","Visible")',ctrl:"vCBRANDNAME",prop:"Visible"}]];this.EvtParms["LBLBRANDCREATEDDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDCREATEDDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("BRANDCREATEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDCREATEDDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLBRANDMODIFIEDDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDMODIFIEDDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("BRANDMODIFIEDDATEFILTERCONTAINER","Class")',ctrl:"BRANDMODIFIEDDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms.ENTER=[[{av:"A1BrandId",fld:"BRANDID",pic:"ZZZZZ9",hsh:!0}],[{av:"AV10pBrandId",fld:"vPBRANDID",pic:"ZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cBrandId",fld:"vCBRANDID",pic:"ZZZZZ9"},{av:"AV7cBrandName",fld:"vCBRANDNAME",pic:""},{av:"AV8cBrandCreatedDate",fld:"vCBRANDCREATEDDATE",pic:""},{av:"AV9cBrandModifiedDate",fld:"vCBRANDMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cBrandId",fld:"vCBRANDID",pic:"ZZZZZ9"},{av:"AV7cBrandName",fld:"vCBRANDNAME",pic:""},{av:"AV8cBrandCreatedDate",fld:"vCBRANDCREATEDDATE",pic:""},{av:"AV9cBrandModifiedDate",fld:"vCBRANDMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cBrandId",fld:"vCBRANDID",pic:"ZZZZZ9"},{av:"AV7cBrandName",fld:"vCBRANDNAME",pic:""},{av:"AV8cBrandCreatedDate",fld:"vCBRANDCREATEDDATE",pic:""},{av:"AV9cBrandModifiedDate",fld:"vCBRANDMODIFIEDDATE",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cBrandId",fld:"vCBRANDID",pic:"ZZZZZ9"},{av:"AV7cBrandName",fld:"vCBRANDNAME",pic:""},{av:"AV8cBrandCreatedDate",fld:"vCBRANDCREATEDDATE",pic:""},{av:"AV9cBrandModifiedDate",fld:"vCBRANDMODIFIEDDATE",pic:""}],[]];this.EvtParms.VALIDV_CBRANDCREATEDDATE=[[],[]];this.EvtParms.VALIDV_CBRANDMODIFIEDDATE=[[],[]];this.setVCMap("AV10pBrandId","vPBRANDID",0,"int",6,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0010)})