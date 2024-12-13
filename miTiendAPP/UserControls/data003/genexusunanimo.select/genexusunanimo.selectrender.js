function GeneXusUnanimo_Select($) {
	  
	  
	  
	  
	  
	  
	  
	  
	 this.setSelectItems = function(value) {
			this.SelectItems = value;
		}

		this.getSelectItems = function() {
			return this.SelectItems;
		} 
	  

	var template = '<ch-select id=\"ch-select-{{Name}}\" name=\"{{Name}}\" class=\"{{Class}}\" icon-src=\"{{Icon}}\" {{#ArrowIcon}}arrow-icon-src=\"{{ArrowIcon}}\"{{/ArrowIcon}} {{^ArrowIcon}}{{/ArrowIcon}} {{#IconAutoColor}}auto-color{{/IconAutoColor}} height=\"{{Height}}\" option-height=\"{{OptionHeight}}\" tabindex=\"0\">	{{#SelectItems}}	<option value=\"{{value}}\" {{#selected}}selected{{/selected}}> {{text}} </option>	{{/SelectItems}}</ch-select>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnItemClick = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnItemClick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='ItemClick']")
				.on('itemclick', this.onItemClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.initItemClick(); 
	}

	this.Scripts = [];

		this.initItemClick = function() {

					const UC = this;
					const elId = "ch-select-" + UC.Name;
					const el = document.getElementById(elId);
					el.addEventListener("optionClickedEvent", function(e){
						/*get the selected option value*/
						for (let i = 0; i < UC.SelectItems.length; i++) {
							const option = UC.SelectItems[i];
							if (option.value === e.detail["option-value"]){
								UC.SelectedItem = option.value;
								if (UC.ItemClick){
									UC.ItemClick();
								}
								break;
							}
						}
					});
				
		}


		this.onItemClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 this.SelectItemsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
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