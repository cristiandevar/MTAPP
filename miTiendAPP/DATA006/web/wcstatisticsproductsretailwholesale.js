gx.evt.autoSkip=!1;gx.define("wcstatisticsproductsretailwholesale",!0,function(n){var i,t;this.ServerClass="wcstatisticsproductsretailwholesale";this.PackageName="GeneXus.Programs";this.ServerFullClass="wcstatisticsproductsretailwholesale.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="mtaKB";this.SetStandaloneVars=function(){this.AV20Year=gx.fn.getIntegerValue("vYEAR",",");this.AV14Month=gx.fn.getIntegerValue("vMONTH",",");this.AV28Type=gx.fn.getControlValue("vTYPE")};this.e14442_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15442_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8];this.GXLastCtrlId=8;this.QUERYVIEWERSALEContainer=gx.uc.getNew(this,9,0,"QueryViewer",this.CmpContext+"QUERYVIEWERSALEContainer","Queryviewersale","QUERYVIEWERSALE");t=this.QUERYVIEWERSALEContainer;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ObjectId","Objectid","7","str");t.setProp("ObjectType","Objecttype","Query","str");t.setProp("QueryInfo","Queryinfo","","char");t.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");t.setProp("ExternalQueryResult","Externalqueryresult","","char");t.setProp("ObjectInfo","Objectinfo","","char");t.addV2CFunction("AV8Elements","vELEMENTS","SetAxes");t.addC2VFunction(function(n){n.ParentObject.AV8Elements=n.GetAxes();gx.fn.setControlValue("vELEMENTS",n.ParentObject.AV8Elements)});t.setProp("AllowElementsOrderChange","Allowchangeaxesorder",!1,"bool");t.addV2CFunction("AV16Parameters","vPARAMETERS","SetParameters");t.addC2VFunction(function(n){n.ParentObject.AV16Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV16Parameters)});t.setProp("ObjectName","Objectname","QStatisticsProductTopSold","str");t.setProp("Object","Objectcall","","str");t.setProp("Class","Class","QueryViewer","str");t.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");t.setProp("AutoResize","Autoresize",!1,"boolean");t.setProp("AutoResizeType","Autoresizetype","","char");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100%","str");t.setProp("Axes Selectors","Showaxesselectors","","char");t.setProp("FontFamily","Fontfamily","","char");t.setProp("FontSize","Fontsize","","int");t.setProp("FontColor","Fontcolor","","int");t.setProp("AutoRefreshGroup","Autorefreshgroup","","str");t.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");t.setProp("AllowSelection","Allowselection",!1,"bool");t.setProp("RememberLayout","Rememberlayout",!0,"bool");t.setProp("ExportToXML","Exporttoxml",!1,"bool");t.setProp("ExportToHTML","Exporttohtml",!0,"bool");t.setProp("ExportToXLS","Exporttoxls",!1,"bool");t.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");t.setProp("ExportToPDF","Exporttopdf",!0,"bool");t.setProp("Type","Type","Chart","str");t.setProp("Title","Title","Top Products Sold","str");t.setProp("ShowValues","Showvalues",!0,"bool");t.setProp("ShowDataAs","Showdataas","","char");t.setProp("Orientation","Orientation","","char");t.setProp("IncludeTrend","Includetrend",!1,"boolean");t.setProp("TrendPeriod","Trendperiod","","char");t.setProp("IncludeSparkline","Includesparkline",!1,"boolean");t.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");t.setProp("MapLibrary","Maplibrary","ECharts","str");t.setProp("MapType","Maptype","","char");t.setProp("Region","Region","","char");t.setProp("Country","Country","","char");t.setProp("Continent","Continent","","char");t.setProp("ChartType","Charttype","ColumnLine","str");t.setProp("PlotSeries","Plotseries","InTheSameChart","str");t.setProp("XAxisLabels","Xaxislabels","Horizontally","str");t.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");t.setProp("XAxisTitle","Xaxistitle","","str");t.setProp("YAxisTitle","Yaxistitle","","str");t.setProp("Paging","Paging",!1,"boolean");t.setProp("PageSize","Pagesize","","int");t.setProp("CurrentPage","Currentpage","","int");t.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");t.setProp("TotalForRows","Totalforrows","","char");t.setProp("TotalForColumns","Totalforcolumns","","char");t.addV2CFunction("AV10ItemClickData","vITEMCLICKDATA","SetItemClickData");t.addC2VFunction(function(n){n.ParentObject.AV10ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV10ItemClickData)});t.addV2CFunction("AV12ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");t.addC2VFunction(function(n){n.ParentObject.AV12ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV12ItemDoubleClickData)});t.addV2CFunction("AV6DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");t.addC2VFunction(function(n){n.ParentObject.AV6DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV6DragAndDropData)});t.addV2CFunction("AV9FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");t.addC2VFunction(function(n){n.ParentObject.AV9FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV9FilterChangedData)});t.addV2CFunction("AV13ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");t.addC2VFunction(function(n){n.ParentObject.AV13ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV13ItemExpandData)});t.addV2CFunction("AV11ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");t.addC2VFunction(function(n){n.ParentObject.AV11ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV11ItemCollapseData)});t.setProp("AppSettings","Appsettings","","char");t.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");t.setProp("ExecuteShow","Executeshow",!1,"boolean");t.setProp("ServiceUrl","Serviceurl","","char");t.setProp("GenType","Gentype","","char");t.setProp("TranslationType","Translationtype","None","str");t.setProp("ReturnSampleData","Returnsampledata",!1,"boolean");t.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};i[6]={id:6,fld:"TABLE1",grid:0};i[7]={id:7,fld:"",grid:0};i[8]={id:8,fld:"",grid:0};this.AV8Elements=[];this.AV20Year=0;this.AV14Month=0;this.AV28Type=!1;this.Events={e14442_client:["ENTER",!0],e15442_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV20Year",fld:"vYEAR",pic:"ZZZ9"},{av:"AV14Month",fld:"vMONTH",pic:"ZZZ9"},{av:"AV28Type",fld:"vTYPE",pic:""}],[{av:"AV16Parameters",fld:"vPARAMETERS",pic:""}]];this.EvtParms.ENTER=[[],[]];this.setVCMap("AV20Year","vYEAR",0,"int",4,0);this.setVCMap("AV14Month","vMONTH",0,"int",4,0);this.setVCMap("AV28Type","vTYPE",0,"boolean",4,0);this.Initialize()})