gx.evt.autoSkip=!1;gx.define("wwsupplier",!1,function(){var n,t;this.ServerClass="wwsupplier";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwsupplier.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){};this.Valid_Supplierid=function(){var n=gx.fn.currentGridRowImpl(27);return this.validCliEvt("Valid_Supplierid",27,function(){try{if(gx.fn.currentGridRowImpl(27)===0)return!0;var n=gx.util.balloon.getNew("SUPPLIERID",gx.fn.currentGridRowImpl(27));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111a2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e151a2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e161a2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,22,23,24,25,26,28,29,30,31,32,33,34,35,36,37];this.GXLastCtrlId=37;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",27,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwsupplier",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(4,28,"SUPPLIERID","Id","","SupplierId","int",0,"px",6,6,"right",null,[],4,"SupplierId",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(5,29,"SUPPLIERNAME","Name","","SupplierName","svchar",0,"px",60,60,"left",null,[],5,"SupplierName",!0,0,!1,!1,"attribute-description",0,"column");t.addSingleLineEdit(6,30,"SUPPLIERDESCRIPTION","Description","","SupplierDescription","svchar",0,"px",200,80,"left",null,[],6,"SupplierDescription",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(7,31,"SUPPLIERPHONE","Phone","","SupplierPhone","char",0,"px",20,20,"left",null,[],7,"SupplierPhone",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(8,32,"SUPPLIEREMAIL","Email","","SupplierEmail","svchar",0,"px",100,80,"left",null,[],8,"SupplierEmail",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(32,33,"SUPPLIERCREATEDDATE","Created Date","","SupplierCreatedDate","date",0,"px",8,8,"right",null,[],32,"SupplierCreatedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(33,34,"SUPPLIERMODIFIEDDATE","Modified Date","","SupplierModifiedDate","date",0,"px",8,8,"right",null,[],33,"SupplierModifiedDate",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit(57,35,"SUPPLIERPRODUCTQUANTITY","Product Quantity","","SupplierProductQuantity","int",0,"px",4,4,"right",null,[],57,"SupplierProductQuantity",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");t.addSingleLineEdit("Update",36,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");t.addSingleLineEdit("Delete",37,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute TextLikeLink",0,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"GRIDCELL",grid:0};n[6]={id:6,fld:"GRIDTABLE",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TABLETOP",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"BTNINSERT",grid:0,evt:"e111a2_client"};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,lvl:0,type:"svchar",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vSUPPLIERNAME",fmt:0,gxz:"ZV11SupplierName",gxold:"OV11SupplierName",gxvar:"AV11SupplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11SupplierName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11SupplierName=n)},v2c:function(){gx.fn.setControlValue("vSUPPLIERNAME",gx.O.AV11SupplierName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11SupplierName=this.val())},val:function(){return gx.fn.getControlValue("vSUPPLIERNAME")},nac:gx.falseFn};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"GRIDCONTAINER",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[28]={id:28,lvl:2,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:this.Valid_Supplierid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERID",fmt:0,gxz:"Z4SupplierId",gxold:"O4SupplierId",gxvar:"A4SupplierId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4SupplierId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4SupplierId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERID",n||gx.fn.currentGridRowImpl(27),gx.O.A4SupplierId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4SupplierId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SUPPLIERID",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:60,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERNAME",fmt:0,gxz:"Z5SupplierName",gxold:"O5SupplierName",gxvar:"A5SupplierName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5SupplierName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5SupplierName=n)},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERNAME",n||gx.fn.currentGridRowImpl(27),gx.O.A5SupplierName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5SupplierName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SUPPLIERNAME",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERDESCRIPTION",fmt:0,gxz:"Z6SupplierDescription",gxold:"O6SupplierDescription",gxvar:"A6SupplierDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6SupplierDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z6SupplierDescription=n)},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERDESCRIPTION",n||gx.fn.currentGridRowImpl(27),gx.O.A6SupplierDescription,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6SupplierDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SUPPLIERDESCRIPTION",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERPHONE",fmt:0,gxz:"Z7SupplierPhone",gxold:"O7SupplierPhone",gxvar:"A7SupplierPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A7SupplierPhone=n)},v2z:function(n){n!==undefined&&(gx.O.Z7SupplierPhone=n)},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERPHONE",n||gx.fn.currentGridRowImpl(27),gx.O.A7SupplierPhone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7SupplierPhone=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SUPPLIERPHONE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIEREMAIL",fmt:0,gxz:"Z8SupplierEmail",gxold:"O8SupplierEmail",gxvar:"A8SupplierEmail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"email",v2v:function(n){n!==undefined&&(gx.O.A8SupplierEmail=n)},v2z:function(n){n!==undefined&&(gx.O.Z8SupplierEmail=n)},v2c:function(n){gx.fn.setGridControlValue("SUPPLIEREMAIL",n||gx.fn.currentGridRowImpl(27),gx.O.A8SupplierEmail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8SupplierEmail=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SUPPLIEREMAIL",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERCREATEDDATE",fmt:0,gxz:"Z32SupplierCreatedDate",gxold:"O32SupplierCreatedDate",gxvar:"A32SupplierCreatedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A32SupplierCreatedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z32SupplierCreatedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERCREATEDDATE",n||gx.fn.currentGridRowImpl(27),gx.O.A32SupplierCreatedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32SupplierCreatedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SUPPLIERCREATEDDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERMODIFIEDDATE",fmt:0,gxz:"Z33SupplierModifiedDate",gxold:"O33SupplierModifiedDate",gxvar:"A33SupplierModifiedDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A33SupplierModifiedDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z33SupplierModifiedDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERMODIFIEDDATE",n||gx.fn.currentGridRowImpl(27),gx.O.A33SupplierModifiedDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33SupplierModifiedDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SUPPLIERMODIFIEDDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUPPLIERPRODUCTQUANTITY",fmt:0,gxz:"Z57SupplierProductQuantity",gxold:"O57SupplierProductQuantity",gxvar:"A57SupplierProductQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A57SupplierProductQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z57SupplierProductQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SUPPLIERPRODUCTQUANTITY",n||gx.fn.currentGridRowImpl(27),gx.O.A57SupplierProductQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A57SupplierProductQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SUPPLIERPRODUCTQUANTITY",n||gx.fn.currentGridRowImpl(27),",")},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:27,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(27))},nac:gx.falseFn};this.AV11SupplierName="";this.ZV11SupplierName="";this.OV11SupplierName="";this.Z4SupplierId=0;this.O4SupplierId=0;this.Z5SupplierName="";this.O5SupplierName="";this.Z6SupplierDescription="";this.O6SupplierDescription="";this.Z7SupplierPhone="";this.O7SupplierPhone="";this.Z8SupplierEmail="";this.O8SupplierEmail="";this.Z32SupplierCreatedDate=gx.date.nullDate();this.O32SupplierCreatedDate=gx.date.nullDate();this.Z33SupplierModifiedDate=gx.date.nullDate();this.O33SupplierModifiedDate=gx.date.nullDate();this.Z57SupplierProductQuantity=0;this.O57SupplierProductQuantity=0;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11SupplierName="";this.A4SupplierId=0;this.A5SupplierName="";this.A6SupplierDescription="";this.A7SupplierPhone="";this.A8SupplierEmail="";this.A32SupplierCreatedDate=gx.date.nullDate();this.A33SupplierModifiedDate=gx.date.nullDate();this.A57SupplierProductQuantity=0;this.AV12Update="";this.AV13Delete="";this.Events={e111a2_client:["'DOINSERT'",!0],e151a2_client:["ENTER",!0],e161a2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SupplierName",fld:"vSUPPLIERNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A4SupplierId",fld:"SUPPLIERID",pic:"ZZZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("SUPPLIERNAME","Link")',ctrl:"SUPPLIERNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A4SupplierId",fld:"SUPPLIERID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SupplierName",fld:"vSUPPLIERNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SupplierName",fld:"vSUPPLIERNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SupplierName",fld:"vSUPPLIERNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11SupplierName",fld:"vSUPPLIERNAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.VALID_SUPPLIERID=[[],[]];t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[18]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[18]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwsupplier)})