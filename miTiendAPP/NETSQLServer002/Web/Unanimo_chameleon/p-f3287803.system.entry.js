var __extends=this&&this.__extends||function(){var t=function(e,n){t=Object.setPrototypeOf||{__proto__:[]}instanceof Array&&function(t,e){t.__proto__=e}||function(t,e){for(var n in e)if(e.hasOwnProperty(n))t[n]=e[n]};return t(e,n)};return function(e,n){t(e,n);function r(){this.constructor=e}e.prototype=n===null?Object.create(n):(r.prototype=n.prototype,new r)}}();var __spreadArrays=this&&this.__spreadArrays||function(){for(var t=0,e=0,n=arguments.length;e<n;e++)t+=arguments[e].length;for(var r=Array(t),i=0,e=0;e<n;e++)for(var o=arguments[e],s=0,a=o.length;s<a;s++,i++)r[i]=o[s];return r};System.register(["./p-810da28d.system.js"],(function(t){"use strict";var e,n,r,i,o;return{setters:[function(t){e=t.r;n=t.c;r=t.h;i=t.H;o=t.g}],execute:function(){var s=function(t){__extends(e,t);function e(){return t.call(this)||this}Object.defineProperty(e.prototype,"grid",{get:function(){var t;return(t=this.parentGrid)!==null&&t!==void 0?t:this.loadParentGrid()},enumerable:false,configurable:true});Object.defineProperty(e.prototype,"rowId",{get:function(){return this.getAttribute("rowid")},enumerable:false,configurable:true});Object.defineProperty(e.prototype,"highlighted",{get:function(){return this.hasAttribute("highlighted")},set:function(t){if(t===true){this.setAttribute("highlighted","");if(this.grid.onRowHighlightedClass){this.classList.add(this.grid.onRowHighlightedClass)}}else{this.removeAttribute("highlighted");if(this.grid.onRowHighlightedClass){this.classList.remove(this.grid.onRowHighlightedClass)}}},enumerable:false,configurable:true});Object.defineProperty(e.prototype,"selected",{get:function(){return this.hasAttribute("selected")},set:function(t){if(t===true){this.setAttribute("selected","");if(this.grid.onRowSelectedClass){this.classList.add(this.grid.onRowSelectedClass)}}else{this.removeAttribute("selected");if(this.grid.onRowSelectedClass){this.classList.remove(this.grid.onRowSelectedClass)}}},enumerable:false,configurable:true});e.prototype.loadParentGrid=function(){this.parentGrid=this.closest("ch-grid");return this.parentGrid};return e}(HTMLElement);customElements.define("ch-grid-row",s);var a=function(t){__extends(e,t);function e(){return t.call(this)||this}Object.defineProperty(e.prototype,"rowId",{get:function(){var t=this.parentElement;return t.rowId},enumerable:false,configurable:true});Object.defineProperty(e.prototype,"cellId",{get:function(){return this.getAttribute("cellid")},enumerable:false,configurable:true});Object.defineProperty(e.prototype,"selected",{get:function(){return this.hasAttribute("selected")},set:function(t){if(t===true){this.setAttribute("selected","")}else{this.removeAttribute("selected")}},enumerable:false,configurable:true});return e}(HTMLElement);customElements.define("ch-grid-cell",a);function l(t,e){var n=u(t);if(n){if(!n.highlighted){if(e){e.highlighted=false}n.highlighted=true}}else{if(e){e.highlighted=false}}return n}function c(t,e,n){var r=u(t);if(r){if(r.selected){if(t.ctrlKey){r.selected=false;return e.filter((function(t){return t!==r}))}}else{if(n){if(e.length==0){r.selected=true;return e.concat([r])}else{if(t.ctrlKey){r.selected=true;return e.concat([r])}else{e.forEach((function(t){return t.selected=false}));r.selected=true;return[r]}}}else{e.forEach((function(t){return t.selected=false}));r.selected=true;return[r]}}}return e}function d(t,e){var n=h(t);if(n&&!n.selected){if(e){e.selected=false}n.selected=true}return n||e}function u(t){return t.composedPath().find((function(t){return t.tagName==="CH-GRID-ROW"}))}function h(t){return t.composedPath().find((function(t){return t.tagName==="CH-GRID-CELL"}))}var g=function(){function t(t,e){this.lastTargetOrder=0;this.columns=e.map((function(t){return{column:t,rect:t.getBoundingClientRect(),translateX:0,order:t.order}}));this.column=this.columns.find((function(e){return e.column.columnId==t}));this.columns.forEach(this.setColumnHiddenRect.bind(this))}t.prototype.dragging=function(t){var e=this;var n=this.column.column.order;var r=0;var i=false;this.column.translateX=0;this.columns.forEach((function(i){var o=i.column.order;var s=n>o?-1:1;var a=n>o?1:-1;if(i.rect.left<t&&t<i.rect.right&&o!=n){i.translateX=e.column.rect.width*a;i.order=i.column.order+a;e.column.translateX+=i.rect.width*s;r=o}else if(t<i.rect.left&&o<n){i.translateX=e.column.rect.width*a;i.order=i.column.order+a;e.column.translateX+=i.rect.width*s}else if(t>i.rect.right&&o>n){i.translateX=e.column.rect.width*a;i.order=i.column.order+a;e.column.translateX+=i.rect.width*s}else if(o!=n){i.translateX=0;i.order=i.column.order}}));this.column.order=r?r:this.column.column.order;i=r!=this.lastTargetOrder;this.lastTargetOrder=r;return i};t.prototype.dragEnd=function(){this.columns.forEach((function(t){t.column.order=t.order;t.translateX=0}))};t.prototype.getColumnStyle=function(t){var e;return e={},e["--ch-grid-column-"+t.physicalOrder+"-transform"]="translateX("+this.columns[t.physicalOrder-1].translateX+"px)",e};t.prototype.getColumnsFirstLast=function(){var t;var e;this.columns.forEach((function(n){if(!n.column.hidden&&(!t||n.order<t.order)){t=n}if(!n.column.hidden&&(!e||n.order>e.order)){e=n}}));return{columnFirst:t.column,columnLast:e.column}};t.prototype.setColumnHiddenRect=function(t){if(t.column.hidden){var e=this.getPreviousSiblingVisible(t)||this.getNextSiblingVisible(t);t.rect=new DOMRect(t.column.order<e.column.order?e.rect.left:e.rect.right,e.rect.y,0,e.rect.height)}};t.prototype.getPreviousSiblingVisible=function(t){var e;this.columns.forEach((function(n){if(!n.column.hidden&&n.column.order<t.column.order&&(!e||n.column.order>e.column.order)){e=n}}));return e};t.prototype.getNextSiblingVisible=function(t){var e;this.columns.forEach((function(n){if(!n.column.hidden&&n.column.order>t.column.order&&(!e||n.column.order<e.column.order)){e=n}}));return e};return t}();var m=function(){function t(t){this.grid=t;this.defineColumns();this.defineColumnsVariables()}t.prototype.defineColumns=function(){var t=this;this.columns=Array.from(this.grid.el.querySelectorAll("ch-grid-column"));this.columns.forEach((function(e){t.defineColumnId(e);t.defineColumnIndex(e);t.defineColumnOrder(e);t.defineColumnSize(e);t.defineColumnDisplayObserver(e)}))};t.prototype.defineColumnId=function(t){if(!t.columnId){t.columnId="grid-column-"+(this.columns.indexOf(t)+1)}};t.prototype.defineColumnIndex=function(t){t.physicalOrder=this.columns.indexOf(t)+1};t.prototype.defineColumnOrder=function(t){if(!t.order){t.order=t.physicalOrder}};t.prototype.defineColumnSize=function(t){if(!t.size){t.size="auto"}};t.prototype.defineColumnDisplayObserver=function(t){if(t.displayObserverClass&&!t.hidden){var e=document.createElement("ch-grid-column-display");e.setAttribute("slot","column-display");e.setAttribute("class",t.displayObserverClass);e.column=t;this.grid.el.appendChild(e)}};t.prototype.defineColumnsVariables=function(){var t=document.head.querySelector("#ChGrid.ColumnsVariables");if(!t||parseInt(t.getAttribute("data-columns"))<this.columns.length){var e="";for(var n=1;n<=this.columns.length;n++){e+="ch-grid-column:nth-child("+n+"), ch-grid-cell:nth-child("+n+") {\n                    display: var(--ch-grid-column-"+n+"-display);\n                    grid-column: var(--ch-grid-column-"+n+"-position, "+n+");\n                    margin-inline-start: var(--ch-grid-column-"+n+"-margin-start);\n                    border-inline-start: var(--ch-grid-column-"+n+"-border-start);\n                    padding-inline-start: var(--ch-grid-column-"+n+"-padding-start);\n                    margin-inline-end: var(--ch-grid-column-"+n+"-margin-end);\n                    border-inline-end: var(--ch-grid-column-"+n+"-border-end);\n                    padding-inline-end: var(--ch-grid-column-"+n+"-padding-end);\n                    transform: var(--ch-grid-column-"+n+"-transform);\n                }"}if(t){t.setAttribute("data-columns",this.columns.length.toString());t.innerHTML=e}else{document.head.insertAdjacentHTML("beforeend",'<style id="ChGrid.ColumnsVariables" data-columns="'+this.columns.length+'">@layer ch-grid {'+e+"}</style>")}}};t.prototype.columnDragStart=function(t){this.columnDragManager=new g(t,this.columns)};t.prototype.columnDragging=function(t){return this.columnDragManager.dragging(t)};t.prototype.columnDragEnd=function(){this.columnDragManager.dragEnd();this.columnDragManager=null};t.prototype.getGridStyle=function(){return Object.assign(Object.assign(Object.assign(Object.assign({display:"grid"},this.getGridTemplateColumns()),this.getRowBoxSimulationStyle()),this.getDragTransitionStyle()),this.getColumnsStyle())};t.prototype.getGridTemplateColumns=function(){return{"grid-template-columns":this.columns.map((function(t){return"var(--ch-grid-column-"+t.physicalOrder+"-size)"})).join(" ")}};t.prototype.getRowBoxSimulationStyle=function(){var t;var e=this.columnDragManager?this.columnDragManager.getColumnsFirstLast():this.getColumnsFirstLast(),n=e.columnFirst,r=e.columnLast;return t={},t["--ch-grid-column-"+n.physicalOrder+"-margin-start"]="var(--ch-grid-fallback, inherit)",t["--ch-grid-column-"+n.physicalOrder+"-border-start"]="var(--ch-grid-fallback, inherit)",t["--ch-grid-column-"+n.physicalOrder+"-padding-start"]="var(--ch-grid-fallback, inherit)",t["--ch-grid-column-"+r.physicalOrder+"-margin-end"]="var(--ch-grid-fallback, inherit)",t["--ch-grid-column-"+r.physicalOrder+"-border-end"]="var(--ch-grid-fallback, inherit)",t["--ch-grid-column-"+r.physicalOrder+"-padding-end"]="var(--ch-grid-fallback, inherit)",t};t.prototype.getColumnsFirstLast=function(){var t;var e;this.columns.forEach((function(n){if(!n.hidden&&(!t||n.order<t.order)){t=n}if(!n.hidden&&(!e||n.order>e.order)){e=n}}));return{columnFirst:t,columnLast:e}};t.prototype.getDragTransitionStyle=function(){return{"--column-drag-transition-duration":this.columnDragManager?".2s":"0s"}};t.prototype.getColumnsStyle=function(){var t=this;return this.columns.reduce((function(e,n){return Object.assign(Object.assign({},e),t.getColumnStyle(n))}),{})};t.prototype.getColumnStyle=function(t){return Object.assign(Object.assign(Object.assign(Object.assign({},this.getColumnSizeStyle(t)),this.getColumnOrderStyle(t)),this.getColumnDisplayStyle(t)),this.getColumnDraggingStyle(t))};t.prototype.getColumnSizeStyle=function(t){var e;return e={},e["--ch-grid-column-"+t.order+"-size"]=t.hidden?"0px":t.size,e};t.prototype.getColumnOrderStyle=function(t){var e;return e={},e["--ch-grid-column-"+t.physicalOrder+"-position"]=t.order.toString(),e};t.prototype.getColumnDisplayStyle=function(t){var e;return t.hidden?(e={},e["--ch-grid-column-"+t.physicalOrder+"-display"]="none",e):null};t.prototype.getColumnDraggingStyle=function(t){return this.columnDragManager?this.columnDragManager.getColumnStyle(t):null};return t}();var f=":host{display:-ms-flexbox;display:flex;-ms-flex-direction:column;flex-direction:column}.main{display:none;grid-auto-flow:dense;overflow-x:auto}";var p=t("ch_grid",function(){function t(t){e(this,t);this.selectionChanged=n(this,"selectionChanged",7);this.cellClicked=n(this,"cellClicked",7);this.rowsSelected=[];this.rowSelectionMode="single"}t.prototype.componentWillLoad=function(){this.gridManager=new m(this);this.gridStyle=this.gridManager.getGridStyle()};t.prototype.componentShouldUpdate=function(t,e,n){if(n==="rowSelected"){return false}};t.prototype.rowSelectedHandler=function(t){this.selectionChanged.emit({rowsId:t.map((function(t){return t.rowId}))})};t.prototype.cellSelectedHandler=function(t){this.cellClicked.emit({rowId:t.rowId,cellId:t.cellId})};t.prototype.mouseMoveHandler=function(t){if(this.rowSelectionMode!="none"){this.rowHighlighted=l(t,this.rowHighlighted)}};t.prototype.clickHandler=function(t){if(this.rowSelectionMode!="none"){this.cellSelected=d(t,this.cellSelected);this.rowsSelected=c(t,this.rowsSelected,this.rowSelectionMode==="multiple")}};t.prototype.columnStyleChangedHandler=function(){if(this.gridManager){this.gridStyle=this.gridManager.getGridStyle()}};t.prototype.columnDragStartHandler=function(t){this.gridManager.columnDragStart(t.detail.columnId)};t.prototype.columnDraggingHandler=function(t){if(this.gridManager.columnDragging(t.detail.positionX)){this.gridStyle=this.gridManager.getGridStyle()}};t.prototype.columnDragEndHandler=function(){this.gridManager.columnDragEnd();this.gridStyle=this.gridManager.getGridStyle()};t.prototype.settingsShowClickedHandler=function(){this.settingsUI.show=true};t.prototype.settingsCloseClickedHandler=function(){this.settingsUI.show=false};t.prototype.render=function(){return r(i,null,r("header",{part:"header"},r("slot",{name:"header"})),r("section",{class:"main",style:this.gridStyle,part:"main"},r("slot",null)),r("aside",null,this.renderSettings(),r("slot",{name:"column-display"}),r("slot",{name:"row-actions"})),r("footer",{part:"footer"},r("slot",{name:"footer"})))};t.prototype.renderSettings=function(){var t=this;return r("ch-grid-settings",{ref:function(e){return t.settingsUI=e},exportparts:"\n          mask:settings-mask,\n          window:settings-window,\n          header:settings-header,\n          caption:settings-caption,\n          close:settings-close,\n          main:settings-main,\n          footer:settings-footer\n        "},r("slot",{name:"settings"},r("ch-grid-settings-columns",{part:"settings-columns",columns:__spreadArrays(this.gridManager.columns),exportparts:"\n              column:settings-columns-item,\n              column-label:settings-columns-label,\n              column-visible:settings-columns-visible\n            "})))};Object.defineProperty(t.prototype,"el",{get:function(){return o(this)},enumerable:false,configurable:true});Object.defineProperty(t,"watchers",{get:function(){return{rowsSelected:["rowSelectedHandler"],cellSelected:["cellSelectedHandler"]}},enumerable:false,configurable:true});return t}());p.style=f;var y="@layer ch-grid {\n  ch-grid-action-refresh[disabled] {\n    pointer-events: none;\n  }\n}";var b=t("ch_grid_action_refresh",function(){function t(t){var r=this;e(this,t);this.refreshClicked=n(this,"refreshClicked",7);this.handleClick=function(t){t.stopPropagation();r.refreshClicked.emit()}}t.prototype.render=function(){return r(i,{role:"button",tabindex:"0",disabled:this.disabled,onClick:this.handleClick})};return t}());b.style=y;var v="@layer ch-grid {\n  ch-grid-action-settings[disabled] {\n    pointer-events: none;\n  }\n}";var w=t("ch_grid_action_settings",function(){function t(t){var r=this;e(this,t);this.settingsShowClicked=n(this,"settingsShowClicked",7);this.handleClick=function(t){t.stopPropagation();r.settingsShowClicked.emit()}}t.prototype.render=function(){return r(i,{role:"button",tabindex:"0",disabled:this.disabled,onClick:this.handleClick})};return t}());w.style=v;var C="";var S=t("ch_grid_actionbar",function(){function t(t){e(this,t)}Object.defineProperty(t.prototype,"el",{get:function(){return o(this)},enumerable:false,configurable:true});return t}());S.style=C;var k=":host{display:-ms-flexbox;display:flex;position:-webkit-sticky;position:sticky;top:0}:host{background-color:inherit;-webkit-margin-before:inherit;margin-block-start:inherit;-webkit-margin-after:inherit;margin-block-end:inherit;-webkit-border-before:inherit;border-block-start:inherit;-webkit-border-after:inherit;border-block-end:inherit;-webkit-padding-before:inherit;padding-block-start:inherit;-webkit-padding-after:inherit;padding-block-end:inherit;-webkit-transition:-webkit-transform var(--column-drag-transition-duration, 0.2s);transition:-webkit-transform var(--column-drag-transition-duration, 0.2s);transition:transform var(--column-drag-transition-duration, 0.2s);transition:transform var(--column-drag-transition-duration, 0.2s), -webkit-transform var(--column-drag-transition-duration, 0.2s)}:host([resizing]){cursor:ew-resize;pointer-events:none}:host([sort-direction=asc]) .bar .sort .sort-asc{visibility:visible}:host([sort-direction=desc]) .bar .sort .sort-desc{visibility:visible}:host([show-settings]){z-index:1000}.bar{list-style-type:none;margin:0;padding:0;display:-ms-flexbox;display:flex;-ms-flex-align:center;align-items:center}.bar .name{display:-ms-flexbox;display:flex;overflow:hidden;-ms-flex-order:1;order:1}.bar .name .name-text{white-space:nowrap;overflow:hidden;text-overflow:ellipsis}.bar .sort{position:relative;-ms-flex-align:center;align-items:center;-ms-flex-order:2;order:2}.bar .sort:not([hidden]){display:-ms-flexbox;display:flex}.bar .sort .sort-asc{visibility:hidden;-webkit-animation-fill-mode:forwards;animation-fill-mode:forwards}.bar .sort .sort-desc{position:absolute;visibility:hidden;-webkit-animation-fill-mode:forwards;animation-fill-mode:forwards}.bar .settings{-ms-flex-order:3;order:3}.bar .resize{-ms-flex-item-align:stretch;align-self:stretch;margin-left:auto;-ms-flex-order:4;order:4}@-webkit-keyframes column-sort{0%{opacity:0}10%{opacity:1}90%{opacity:1}100%{opacity:0}}@keyframes column-sort{0%{opacity:0}10%{opacity:1}90%{opacity:1}100%{opacity:0}}";var O=t("ch_grid_column",function(){function t(t){e(this,t);this.columnHiddenChanged=n(this,"columnHiddenChanged",7);this.columnSizeChanging=n(this,"columnSizeChanging",7);this.columnSizeChanged=n(this,"columnSizeChanged",7);this.columnOrderChanged=n(this,"columnOrderChanged",7);this.columnSortChanged=n(this,"columnSortChanged",7);this.columnDragStarted=n(this,"columnDragStarted",7);this.columnDragging=n(this,"columnDragging",7);this.columnDragEnded=n(this,"columnDragEnded",7);this.columnNamePosition="text";this.hidden=false;this.hideable=true;this.resizeable=true;this.sortable=true;this.settingable=true;this.showSettings=false;this.dragging=false;this.dragMouseMoveFn=this.dragMouseMoveHandler.bind(this)}t.prototype.componentDidLoad=function(){this.el.addEventListener("mousedown",this.mousedownHandler.bind(this))};t.prototype.sizeHandler=function(){this.columnSizeChanging.emit({columnId:this.columnId,size:this.size})};t.prototype.hiddenHandler=function(){this.columnHiddenChanged.emit({columnId:this.columnId,hidden:this.hidden})};t.prototype.orderHandler=function(){this.columnOrderChanged.emit({columnId:this.columnId,order:this.order})};t.prototype.sortDirectionHandler=function(){if(this.sortDirection){this.columnSortChanged.emit({columnId:this.columnId,sortDirection:this.sortDirection})}};t.prototype.clickHandler=function(){if(!this.dragging){if(this.sortable){this.sortDirection=this.sortDirection=="asc"?"desc":"asc"}}else{this.dragging=false}};t.prototype.settingsCloseClickedHandler=function(){this.showSettings=false};t.prototype.columnResizeFinishedHandler=function(){this.columnSizeChanged.emit({columnId:this.columnId,size:this.size})};t.prototype.mousedownHandler=function(t){t.preventDefault();t.stopPropagation();this.dragMouseDownHandler(t);document.addEventListener("mousemove",this.dragMouseMoveFn,{passive:true});document.addEventListener("mouseup",this.dragMouseUpHandler.bind(this),{once:true})};t.prototype.dragMouseDownHandler=function(t){this.dragMouseMoveStartPositionX=t.pageX;this.columnDragStarted.emit({columnId:this.columnId})};t.prototype.dragMouseMoveHandler=function(t){if(this.dragging||Math.abs(this.dragMouseMoveStartPositionX-t.pageX)>5){this.dragging=true;this.columnDragging.emit({columnId:this.columnId,positionX:t.pageX,direction:t.movementX>0?"right":"left"})}};t.prototype.dragMouseUpHandler=function(){document.removeEventListener("mousemove",this.dragMouseMoveFn);this.columnDragEnded.emit({columnId:this.columnId})};t.prototype.settingsMouseDownHandler=function(t){t.stopPropagation()};t.prototype.settingsClickHandler=function(t){t.stopPropagation();this.showSettings=true};t.prototype.render=function(){return r(i,null,r("ul",{class:"bar",part:"bar"},this.renderName(),this.renderSort(),this.renderSettings(),this.renderResize()),r("ch-grid-column-settings",{column:this,onMouseDown:this.settingsMouseDownHandler,show:this.showSettings,exportparts:"\n            mask:settings-mask,\n            window:settings-window,\n            header:settings-header,\n            caption:settings-caption,\n            close:settings-close,\n            main:settings-main,\n            footer:settings-footer\n          "},r("slot",{name:"settings"})))};t.prototype.renderName=function(){return r("li",{class:"name",part:"bar-name",title:this.columnNamePosition=="title"?this.columnName:null},this.columnIconUrl?r("img",{class:"name-icon",part:"bar-name-icon",src:this.columnIconUrl}):r("div",{class:"name-icon",part:"bar-name-icon"}),r("span",{class:"name-text",part:"bar-name-text",hidden:this.columnNamePosition!="text"},this.columnName))};t.prototype.renderSort=function(){return r("li",{class:"sort",part:"bar-sort",hidden:!this.sortable},r("div",{class:"sort-asc",part:"bar-sort-ascending"}),r("div",{class:"sort-desc",part:"bar-sort-descending"}))};t.prototype.renderSettings=function(){return r("li",{class:"settings",part:"bar-settings",hidden:!this.settingable},r("button",{class:"button",part:"bar-settings-button",onClick:this.settingsClickHandler.bind(this)}))};t.prototype.renderResize=function(){return r("li",{class:"resize",part:"bar-resize",hidden:!this.resizeable},r("ch-grid-column-resize",{column:this,class:"resize-split",part:"bar-resize-split"}))};Object.defineProperty(t.prototype,"el",{get:function(){return o(this)},enumerable:false,configurable:true});Object.defineProperty(t,"watchers",{get:function(){return{size:["sizeHandler"],hidden:["hiddenHandler"],order:["orderHandler"],sortDirection:["sortDirectionHandler"]}},enumerable:false,configurable:true});return t}());O.style=k;var H="@layer ch-grid {\n  ch-grid-columnset {\n    display: contents;\n  }\n  ch-grid-columnset.resizing ch-grid-column {\n    cursor: ew-resize;\n  }\n}\n@layer ch-grid {\n  ch-grid-row {\n    display: contents;\n  }\n}\n@layer ch-grid {\n  ch-grid-cell {\n    grid-column: var(--grid-column);\n    background-color: inherit;\n    -webkit-margin-before: inherit;\n    margin-block-start: inherit;\n    -webkit-margin-after: inherit;\n    margin-block-end: inherit;\n    -webkit-border-before: inherit;\n    border-block-start: inherit;\n    -webkit-border-after: inherit;\n    border-block-end: inherit;\n    -webkit-padding-before: inherit;\n    padding-block-start: inherit;\n    -webkit-padding-after: inherit;\n    padding-block-end: inherit;\n    -webkit-transition: -webkit-transform var(--column-drag-transition-duration, 0.2s);\n    transition: -webkit-transform var(--column-drag-transition-duration, 0.2s);\n    transition: transform var(--column-drag-transition-duration, 0.2s);\n    transition: transform var(--column-drag-transition-duration, 0.2s), -webkit-transform var(--column-drag-transition-duration, 0.2s);\n  }\n}";var x=t("ch_grid_columnset",function(){function t(t){e(this,t)}t.prototype.componentDidLoad=function(){this.columns=Array.from(this.el.querySelectorAll("ch-grid-column"))};t.prototype.columnResizeStartedHandler=function(){this.columns.forEach((function(t){return t.resizing=true}))};t.prototype.columnResizeFinishedHandler=function(){this.columns.forEach((function(t){return t.resizing=false}))};t.prototype.columnSortChangedHandler=function(t){this.columns.forEach((function(e){if(e.columnId!=t.detail.columnId){e.sortDirection=null}}))};t.prototype.render=function(){return r(i,null,r("slot",null))};Object.defineProperty(t.prototype,"el",{get:function(){return o(this)},enumerable:false,configurable:true});return t}());x.style=H;var D=":host{display:-ms-flexbox;display:flex}";var M=t("ch_paginator",function(){function t(t){e(this,t);this.activePageChanged=n(this,"activePageChanged",7)}t.prototype.navigationClickedHandler=function(t){};t.prototype.pageClickedHandler=function(t){};return t}());M.style=D;var I="ch-paginator-navigate[disabled]{pointer-events:none}";var z=t("ch_paginator_navigate",function(){function t(t){var r=this;e(this,t);this.navigationClicked=n(this,"navigationClicked",7);this.handleClick=function(t){t.stopPropagation();r.navigationClicked.emit({navigationType:r.type})}}t.prototype.render=function(){return r(i,{role:"button",tabindex:"0",disabled:this.disabled,onClick:this.handleClick})};Object.defineProperty(t.prototype,"el",{get:function(){return o(this)},enumerable:false,configurable:true});return t}());z.style=I}}}));