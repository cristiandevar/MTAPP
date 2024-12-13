function GeneXusUnanimo_Dropdown($) {
	  
	  
	  
	  
	  
	  
	 this.setDropdownItems = function(value) {
			this.DropdownItems = value;
		}

		this.getDropdownItems = function() {
			return this.DropdownItems;
		} 
	  
	  
	  

	var template = '<div class=\"dropdown\">	<div class=\"dd-flex-container\">		<div class=\"dd-vertical-separator\" id=\"ddSeparator\"></div>		<div class=\"dd-text-container\" id=\"textContainer\">			<div class=\"row\"> <span class=\"dd-username\">{{UserFullName}}</span> </div>			<div class=\"row\"> <span class=\"dd-companyname\">{{UserCompany}}</span> </div>		</div>		<div class=\"dd-avatar-container\" id=\"imgContainer\">			<img {{#UserPhoto}}src={{UserPhoto}}{{/UserPhoto}} class=\"dd-avatar\" alt=\"avatar-image\">		</div>	</div> 	<div class=\"dropdown-content\">		{{#DropdownItems}}		<a id=\"{{id}}\" class=\"dd-option-container\" href=\"#\">			<img alt=\"{{alternativeText}}\" class=\"dd-option-icon\" src={{icon}}>			<span class=\"dd-option\">{{title}}</span>		</a>		{{/DropdownItems}}		{{#ShowLogoutOption}}		<!-- default logout event -->		<a class=\"dd-option-container\"  data-event=\"Logout\" >			<img alt=\"logout_icon\" class=\"dd-option-icon\" src={{LogoutIcon}}>			<span class=\"dd-option\">Logout</span>		</a>		{{/ShowLogoutOption}}	</div></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnLogout = 0; 
	var _iOnItemClick = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnLogout = 0; 
			_iOnItemClick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Logout']")
				.on('click', this.onLogoutHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='ItemClick']")
				.on('itemclick', this.onItemClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Init(); 
	}

	this.Scripts = [];

		this.Init = function() {

			  	const UC = this;
				const imgContainer = $("#imgContainer");
				const textContainer = $("#textContainer");
				const verticalSeparator = $("#ddSeparator");
				switch(UC.DisplayType) {
					case "Avatar":
					textContainer[0].hidden = true;
					break;
					case "Text":
					imgContainer[0].hidden = true;
					break;
					case "Avatar and Text":
					break;
				}

				/*get the item's target*/
				const el = document.getElementsByClassName("dropdown-content")[0];
				el.addEventListener("click", function(e){
					var anchor = getParentAnchor(e.target);
					if(anchor !== null) {
						for (let i = 0; i < UC.DropdownItems.length; i++) {
							const item = UC.DropdownItems[i];
							if (item.id === anchor.id){
								UC.SelectedItemId = item.id;
								UC.SelectedItemTarget = item.link;
								UC.ItemClick();
								break;
							}
						}
					}
				});

				var getParentAnchor = function (element) {
					while (element !== null) {
						if (element.tagName && element.tagName.toUpperCase() === "A") {
						return element;
						}
						element = element.parentNode;
					}
					return null;
				};
			  
		}


		this.onLogoutHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 this.DropdownItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.Logout) {
				this.Logout();
			}
		} 

		this.onItemClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 this.DropdownItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.ItemClick) {
				this.ItemClick();
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