gx.evt.autoSkip=!1;gx.define("productsrankingsales",!1,function(){var n,t;this.ServerClass="productsrankingsales";this.PackageName="GeneXus.Programs";this.ServerFullClass="productsrankingsales.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){};this.Validv_Datefrom=function(){return this.validCliEvt("Validv_Datefrom",0,function(){try{var n=gx.util.balloon.getNew("vDATEFROM");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6DateFrom)===0||new gx.date.gxdate(this.AV6DateFrom).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Date From is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Dateto=function(){return this.validCliEvt("Validv_Dateto",0,function(){try{var n=gx.util.balloon.getNew("vDATETO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7DateTo)===0||new gx.date.gxdate(this.AV7DateTo).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Date To is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111r2_client=function(){return this.executeServerEvent("'GENERATEPDF'",!1,null,!1,!1)};this.e131r2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e141r2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,26,27,28,29,30,31,32,33,34];this.GXLastCtrlId=34;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"productsrankingsales",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addSingleLineEdit(55,25,"PRODUCTCODE","Product Code","","ProductCode","svchar",0,"px",100,80,"left",null,[],55,"ProductCode",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(16,26,"PRODUCTNAME","Product Name","","ProductName","svchar",0,"px",60,60,"left",null,[],16,"ProductName",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(17,27,"PRODUCTSTOCK","Product Stock","","ProductStock","int",0,"px",6,6,"right",null,[],17,"ProductStock",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit(18,28,"PRODUCTPRICE","Product Price","","ProductPrice","decimal",0,"px",10,10,"right",null,[],18,"ProductPrice",!0,2,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Sales",29,"vSALES","Sales","","Sales","int",0,"px",4,4,"right",null,[],"Sales","Sales",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Stocksale",30,"vSTOCKSALE","Stock Sale","","StockSale","int",0,"px",6,6,"right",null,[],"Stocksale","StockSale",!0,0,!1,!1,"Attribute",0,"");t.addSingleLineEdit("Subtotal",31,"vSUBTOTAL","Subtotal","","Subtotal","decimal",0,"px",10,10,"right",null,[],"Subtotal","Subtotal",!0,2,!1,!1,"Attribute",0,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vSUPPLIERID",fmt:0,gxz:"ZV5SupplierId",gxold:"OV5SupplierId",gxvar:"AV5SupplierId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV5SupplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5SupplierId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vSUPPLIERID",gx.O.AV5SupplierId)},c2v:function(){this.val()!==undefined&&(gx.O.AV5SupplierId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vSUPPLIERID",",")},nac:gx.falseFn};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Datefrom,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vDATEFROM",fmt:0,gxz:"ZV6DateFrom",gxold:"OV6DateFrom",gxvar:"AV6DateFrom",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[15],ip:[15],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6DateFrom=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6DateFrom=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vDATEFROM",gx.O.AV6DateFrom,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6DateFrom=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vDATEFROM")},nac:gx.falseFn};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Dateto,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vDATETO",fmt:0,gxz:"ZV7DateTo",gxold:"OV7DateTo",gxvar:"AV7DateTo",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[19],ip:[19],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7DateTo=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7DateTo=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vDATETO",gx.O.AV7DateTo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7DateTo=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vDATETO")},nac:gx.falseFn};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[25]={id:25,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCODE",fmt:0,gxz:"Z55ProductCode",gxold:"O55ProductCode",gxvar:"A55ProductCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A55ProductCode=n)},v2z:function(n){n!==undefined&&(gx.O.Z55ProductCode=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(24),gx.O.A55ProductCode,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A55ProductCode=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};n[26]={id:26,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z16ProductName",gxold:"O16ProductName",gxvar:"A16ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A16ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z16ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(24),gx.O.A16ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSTOCK",fmt:0,gxz:"Z17ProductStock",gxold:"O17ProductStock",gxvar:"A17ProductStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A17ProductStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z17ProductStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(24),gx.O.A17ProductStock,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A17ProductStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPRICE",fmt:0,gxz:"Z18ProductPrice",gxold:"O18ProductPrice",gxvar:"A18ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A18ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z18ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(24),gx.O.A18ProductPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(24),",",".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSALES",fmt:0,gxz:"ZV8Sales",gxold:"OV8Sales",gxvar:"AV8Sales",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8Sales=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8Sales=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vSALES",n||gx.fn.currentGridRowImpl(24),gx.O.AV8Sales,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8Sales=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vSALES",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTOCKSALE",fmt:0,gxz:"ZV10StockSale",gxold:"OV10StockSale",gxvar:"AV10StockSale",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV10StockSale=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10StockSale=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vSTOCKSALE",n||gx.fn.currentGridRowImpl(24),gx.O.AV10StockSale,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10StockSale=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vSTOCKSALE",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"ZZZZZZ9.99",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBTOTAL",fmt:0,gxz:"ZV9Subtotal",gxold:"OV9Subtotal",gxvar:"AV9Subtotal",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV9Subtotal=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV9Subtotal=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("vSUBTOTAL",n||gx.fn.currentGridRowImpl(24),gx.O.AV9Subtotal,2,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9Subtotal=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("vSUBTOTAL",n||gx.fn.currentGridRowImpl(24),",",".")},nac:gx.falseFn};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"GENERATEPDF",grid:0,evt:"e111r2_client"};this.AV5SupplierId=0;this.ZV5SupplierId=0;this.OV5SupplierId=0;this.AV6DateFrom=gx.date.nullDate();this.ZV6DateFrom=gx.date.nullDate();this.OV6DateFrom=gx.date.nullDate();this.AV7DateTo=gx.date.nullDate();this.ZV7DateTo=gx.date.nullDate();this.OV7DateTo=gx.date.nullDate();this.Z55ProductCode="";this.O55ProductCode="";this.Z16ProductName="";this.O16ProductName="";this.Z17ProductStock=0;this.O17ProductStock=0;this.Z18ProductPrice=0;this.O18ProductPrice=0;this.ZV8Sales=0;this.OV8Sales=0;this.ZV10StockSale=0;this.OV10StockSale=0;this.ZV9Subtotal=0;this.OV9Subtotal=0;this.AV5SupplierId=0;this.AV6DateFrom=gx.date.nullDate();this.AV7DateTo=gx.date.nullDate();this.A28ProductCreatedDate=gx.date.nullDate();this.A4SupplierId=0;this.A40000GXC1=0;this.A40001GXC2=0;this.A40002GXC3=0;this.A15ProductId=0;this.A55ProductCode="";this.A16ProductName="";this.A17ProductStock=0;this.A18ProductPrice=0;this.AV8Sales=0;this.AV10StockSale=0;this.AV9Subtotal=0;this.Events={e111r2_client:["'GENERATEPDF'",!0],e131r2_client:["ENTER",!0],e141r2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"AV6DateFrom",fld:"vDATEFROM",pic:""},{av:"AV7DateTo",fld:"vDATETO",pic:""},{ctrl:"vSUPPLIERID"},{av:"AV5SupplierId",fld:"vSUPPLIERID",pic:"ZZZZZ9"}],[]];this.EvtParms["'GENERATEPDF'"]=[[{ctrl:"vSUPPLIERID"},{av:"AV5SupplierId",fld:"vSUPPLIERID",pic:"ZZZZZ9"},{av:"AV6DateFrom",fld:"vDATEFROM",pic:""},{av:"AV7DateTo",fld:"vDATETO",pic:""}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_DATEFROM=[[],[]];this.EvtParms.VALIDV_DATETO=[[],[]];t.addRefreshingVar(this.GXValidFnc[10]);t.addRefreshingVar(this.GXValidFnc[15]);t.addRefreshingVar(this.GXValidFnc[19]);t.addRefreshingParm(this.GXValidFnc[10]);t.addRefreshingParm(this.GXValidFnc[15]);t.addRefreshingParm(this.GXValidFnc[19]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.productsrankingsales)})