function MySidebar($) {
	  
	  
	  
	  
	  
	 this.setMySidebarItems = function(value) {
			this.MySidebarItems = value;
		}

		this.getMySidebarItems = function() {
			return this.MySidebarItems;
		} 
	  
	  
	  
	  
	  

	var template = '<ch-sidebar-menu     menu-title=\"{{Title}}\"     id=\"ch-sidebar-menu\"     class=\"{{Class}}\"     distance-to-top=\"{{DistanceToTop}}\"     collapsible=\"{{Collapsible}}\"     active-item-id=\"{{ActiveItemId}}\" >    <ch-sidebar-menu-list>	  {{#MySidebarItems}}      <ch-sidebar-menu-list-item id=\"{{id}}\" item-icon-src=\"{{icon}}\" {{#IconAutoColor}}auto-color{{/IconAutoColor}}>        {{title}}		{{#hasSubItems}}        <ch-sidebar-menu-list slot=\"list\">		  {{#MySidebarSubItems}}            <ch-sidebar-menu-list-item id=\"{{id}}\">              {{title}}		  			  {{#hasSubItems}}				<ch-sidebar-menu-list slot=\"list\">				{{#MySidebarSubSubItems}}					<ch-sidebar-menu-list-item id=\"{{id}}\">					{{title}}					</ch-sidebar-menu-list-item>				{{/MySidebarSubSubItems}}				</ch-sidebar-menu-list>			  {{/hasSubItems}}            </ch-sidebar-menu-list-item>		  {{/MySidebarSubItems}}		</ch-sidebar-menu-list>		{{/hasSubItems}}      </ch-sidebar-menu-list-item>	  {{/MySidebarItems}}    </ch-sidebar-menu-list>    <div slot=\"footer\">{{FooterText}}</div></ch-sidebar-menu>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnItemClick = 0; 
	var _iOnGetState = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnItemClick = 0; 
			_iOnGetState = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='ItemClick']")
				.on('itemclick', this.onItemClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='GetState']")
				.on('getstate', this.onGetStateHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.initSidebar(); 
	}

	this.Scripts = [];

		this.initSidebar = function() {

					const UC = this;
					const sidebar = document.getElementById("ch-sidebar-menu"); 
					
					sidebar.addEventListener("collapseBtnClicked", function(e){
						UC.isCollapsed = e.detail.isCollapsed;
						if (UC.GetState){
							UC.GetState();
						}
					});
					
					sidebar.addEventListener("itemClickedEvent", function(e){
						/*get the item's target*/
						for (let i = 0; i < UC.MySidebarItems.length; i++) {
							const item = UC.MySidebarItems[i];
							if (item.id === e.detail["item-id"]){
								if (item.target !== "") {
									UC.SelectedItemTarget = item.target;
									if (UC.ItemClick){
										UC.ItemClick();
									}
									break;
								}
							}
							if (item.hasSubItems) {
								for (let j = 0; j < item.MySidebarSubItems.length; j++) {
									const subItem = item.MySidebarSubItems[j];
									if (subItem.id === e.detail["item-id"]){
										if (subItem.target !== "") {
											UC.SelectedItemTarget = subItem.target;
											if (UC.ItemClick){
												UC.ItemClick();
											}
											break;
										}
									}
									if (subItem.hasSubItems) {		
										for (let k = 0; k < subItem.MySidebarSubSubItems.length; k++) {
											const subSubItem = subItem.MySidebarSubSubItems[k];
											if (subSubItem.id === e.detail["item-id"]){
												if (subSubItem.target !== "") {
													UC.SelectedItemTarget = subSubItem.target;
													if (UC.ItemClick){
														UC.ItemClick();
													}
													break;
												}
											}
										}
										
									}
								}
							}
						}
					});
				
					const toggleSidebarBtn = document.getElementsByClassName("sidebar__toggle-ico")[0];
					toggleSidebarBtn.addEventListener("click", function(e){
						const menu = sidebar.shadowRoot.lastChild;
						if (!menu.classList.contains("visible-xs")){
							menu.classList.add("visible-xs");
							menu.classList.remove("hidden-xs");
							}else{
							menu.classList.remove("visible-xs");
							menu.classList.add("hidden-xs");
						}
					})
				
		}
		this.GetActiveItem = function() {

					/*get active item from storage*/
					const UC = this;
					let activeItem = sessionStorage.getItem("active-item");
					UC.MySidebarItems.activeItem = activeItem;
				
		}


		this.onItemClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 this.MySidebarItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.ItemClick) {
				this.ItemClick();
			}
		} 

		this.onGetStateHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 this.MySidebarItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
				 
				 
			}

			if (this.GetState) {
				this.GetState();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}