gx.evt.autoSkip=!1;gx.define("employeeinvoicewc",!0,function(n){var t,i;this.ServerClass="employeeinvoicewc";this.PackageName="GeneXus.Programs";this.ServerFullClass="employeeinvoicewc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV6EmployeeId=gx.fn.getIntegerValue("vEMPLOYEEID",",");this.AV6EmployeeId=gx.fn.getIntegerValue("vEMPLOYEEID",",")};this.Valid_Invoiceid=function(){var n=gx.fn.currentGridRowImpl(22);return this.validCliEvt("Valid_Invoiceid",22,function(){try{if(gx.fn.currentGridRowImpl(22)===0)return!0;var n=gx.util.balloon.getNew("INVOICEID",gx.fn.currentGridRowImpl(22));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110l2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e140l2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150l2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20,21,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"employeeinvoicewc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(20,23,"INVOICEID","Id","","InvoiceId","int",0,"px",6,6,"right",null,[],20,"InvoiceId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(21,24,"INVOICEDATE","Date","","InvoiceDate","date",0,"px",8,8,"right",null,[],21,"InvoiceDate",!0,0,!1,!1,"attribute-description",0,"column");i.addSingleLineEdit(38,25,"INVOICECREATEDDATE","Created Date","","InvoiceCreatedDate","date",0,"px",8,8,"right",null,[],38,"InvoiceCreatedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(39,26,"INVOICEMODIFIEDDATE","Modified Date","","InvoiceModifiedDate","date",0,"px",8,8,"right",null,[],39,"InvoiceModifiedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(68,27,"INVOICEPRODUCTQUANTITY","Product Quantity","","InvoiceProductQuantity","int",0,"px",4,4,"right",null,[],68,"InvoiceProductQuantity",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit("Update",28,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");i.addSingleLineEdit("Delete",29,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLETOP",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110l2_client"};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"GRIDCONTAINER",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[23]={id:23,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:this.Valid_Invoiceid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEID",fmt:0,gxz:"Z20InvoiceId",gxold:"O20InvoiceId",gxvar:"A20InvoiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z20InvoiceId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEID",n||gx.fn.currentGridRowImpl(22),gx.O.A20InvoiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A20InvoiceId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVOICEID",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEDATE",fmt:0,gxz:"Z21InvoiceDate",gxold:"O21InvoiceDate",gxvar:"A21InvoiceDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A21InvoiceDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z21InvoiceDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEDATE",n||gx.fn.currentGridRowImpl(22),gx.O.A21InvoiceDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21InvoiceDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("INVOICEDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICECREATEDDATE",fmt:0,gxz:"Z38InvoiceCreatedDate",gxold:"O38InvoiceCreatedDate",gxvar:"A38InvoiceCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A38InvoiceCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z38InvoiceCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICECREATEDDATE",n||gx.fn.currentGridRowImpl(22),gx.O.A38InvoiceCreatedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38InvoiceCreatedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("INVOICECREATEDDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEMODIFIEDDATE",fmt:0,gxz:"Z39InvoiceModifiedDate",gxold:"O39InvoiceModifiedDate",gxvar:"A39InvoiceModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A39InvoiceModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z39InvoiceModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEMODIFIEDDATE",n||gx.fn.currentGridRowImpl(22),gx.O.A39InvoiceModifiedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A39InvoiceModifiedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("INVOICEMODIFIEDDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVOICEPRODUCTQUANTITY",fmt:0,gxz:"Z68InvoiceProductQuantity",gxold:"O68InvoiceProductQuantity",gxvar:"A68InvoiceProductQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A68InvoiceProductQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z68InvoiceProductQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVOICEPRODUCTQUANTITY",n||gx.fn.currentGridRowImpl(22),gx.O.A68InvoiceProductQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A68InvoiceProductQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVOICEPRODUCTQUANTITY",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPLOYEEID",fmt:0,gxz:"Z12EmployeeId",gxold:"O12EmployeeId",gxvar:"A12EmployeeId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12EmployeeId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12EmployeeId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("EMPLOYEEID",gx.O.A12EmployeeId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12EmployeeId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("EMPLOYEEID",",")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});this.Z20InvoiceId=0;this.O20InvoiceId=0;this.Z21InvoiceDate=gx.date.nullDate();this.O21InvoiceDate=gx.date.nullDate();this.Z38InvoiceCreatedDate=gx.date.nullDate();this.O38InvoiceCreatedDate=gx.date.nullDate();this.Z39InvoiceModifiedDate=gx.date.nullDate();this.O39InvoiceModifiedDate=gx.date.nullDate();this.Z68InvoiceProductQuantity=0;this.O68InvoiceProductQuantity=0;this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A12EmployeeId=0;this.Z12EmployeeId=0;this.O12EmployeeId=0;this.A12EmployeeId=0;this.AV6EmployeeId=0;this.A20InvoiceId=0;this.A21InvoiceDate=gx.date.nullDate();this.A38InvoiceCreatedDate=gx.date.nullDate();this.A39InvoiceModifiedDate=gx.date.nullDate();this.A68InvoiceProductQuantity=0;this.AV13Update="";this.AV14Delete="";this.Events={e110l2_client:["'DOINSERT'",!0],e140l2_client:["ENTER",!0],e150l2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A20InvoiceId",fld:"INVOICEID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("INVOICEDATE","Link")',ctrl:"INVOICEDATE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A20InvoiceId",fld:"INVOICEID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EmployeeId",fld:"vEMPLOYEEID",pic:"ZZZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_INVOICEID=[[],[]];this.setVCMap("AV6EmployeeId","vEMPLOYEEID",0,"int",6,0);this.setVCMap("AV6EmployeeId","vEMPLOYEEID",0,"int",6,0);this.setVCMap("AV6EmployeeId","vEMPLOYEEID",0,"int",6,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6EmployeeId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6EmployeeId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})